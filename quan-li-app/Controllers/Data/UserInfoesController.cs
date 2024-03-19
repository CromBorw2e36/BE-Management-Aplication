using BUS_QUANLI.Services;
using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly DataContext _context;

        public UserInfoesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost, ActionName("UserIns")]
        public async Task<ActionResult<StatusMessage>> UserIns(UserInfo userInfo)
        {
            if (userInfo is not null)
            {
                try
                {
                    UserInfo user = new UserInfo
                    {
                        id = Guid.NewGuid().ToString(),
                        name = userInfo.name,
                        dateOfBirth = userInfo.dateOfBirth,
                        address = userInfo.address,
                        phoneNumber = userInfo.phoneNumber,
                        gender = userInfo.gender,
                        nationality = userInfo.nationality, // quốc tịch
                        ethnicity = userInfo.ethnicity, //  dân tộc
                        interests = userInfo.interests, // sở thích
                        maritalStatus = userInfo.maritalStatus, //  tình trạng hôn nhân
                        modifyDate = DateTime.Now, //  tình trạng hôn nhân
                        BHXH = userInfo.BHXH, // sở thích
                        CCCD = userInfo.CCCD, // sở thích
                    };

                    _context.UserInfomation.Add(user);
                    await _context.SaveChangesAsync();
                    return new StatusMessage(1, "Đã thêm thông tin người dùng");
                }
                catch
                {
                    return new StatusMessage(0, "Thêm thông tin người dùng thất bại");
                }
            }
            return new StatusMessage(0, "Vui lòng nhập dữ liệu đầy đủ"); ;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult<StatusMessage>> UpdUser(UserInfo userInfo)
        {
            if (userInfo is not null)
            {
                try
                {
                    UserInfo user = _context.UserInfomation.Where(x => x.id == userInfo.id).FirstOrDefault();

                    user.name = userInfo.name;
                    user.dateOfBirth = userInfo.dateOfBirth;
                    user.address = userInfo.address;
                    user.phoneNumber = userInfo.phoneNumber;
                    user.gender = userInfo.gender;
                    user.nationality = userInfo.nationality; // quốc tịch
                    user.ethnicity = userInfo.ethnicity; //  dân tộc
                    user.interests = userInfo.interests; // sở thích
                    user.maritalStatus = userInfo.maritalStatus; //  tình trạng hôn nhân
                    user.modifyDate = DateTime.Now; //  tình trạng hôn nhân
                    user.BHXH = userInfo.BHXH; // sở thích
                    user.CCCD = userInfo.CCCD; // sở thích

                    _context.UserInfomation.Add(user);
                    await _context.SaveChangesAsync();
                    return new StatusMessage(1, "Đã thêm thông tin người dùng");
                }
                catch
                {
                    return new StatusMessage(0, "Thêm thông tin người dùng thất bại");
                }
            }
            return new StatusMessage(0, "Vui lòng nhập dữ liệu đầy đủ"); ;
        }

        [HttpPost]
        [Route("GetUser")]
        public async Task<ActionResult<UserInfo>> GetMyUser()
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string userId = tokenHelper.GetUsername(HttpContext.Request);
                try
                {
                    UserInfo user = _context.UserInfomation.Where(x => x.id == userId).FirstOrDefault();

                    return user;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<ActionResult<List<UserInfo>>> GetLstUser()
        {

            TokenHelper tokenHelper = new TokenHelper();

            string userId = tokenHelper.GetUsername(HttpContext.Request);

            Account account = await _context.Accounts.Where(x => x.account == userId).FirstOrDefaultAsync();

            if (account.companyCode == "ADMIN")
            {
                List<UserInfo> users = _context.UserInfomation.ToList();
                return users;
            }
            else if (account.companyCode is not null)
            {
                List<Account> accounts = _context.Accounts.Where(x => x.companyCode == account.companyCode).ToList();

                List<UserInfo> users = new List<UserInfo>();
                foreach (var item in accounts)
                {
                    UserInfo user = _context.UserInfomation.Where(x => x.id == item.account).FirstOrDefault();
                    if (user != null)
                    {
                        users.Add(user);
                    }
                }

                return users;
            }
            else
            {
                return new List<UserInfo>();
            }
        }

        [HttpPost, Route("GetUserInformation")]
        public async Task<ActionResult<UserInformationClientGetUser>> GetUserInformation(string? username)
        {
            TokenHelper tokenHelper = new TokenHelper();
            if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
            {
                string userId = tokenHelper.GetUsername(HttpContext.Request);
                if (username != null) userId = username;
                if (userId != null)
                {
                    UserInformationClient userInformationClient = new UserInformationClient(_context);
                    try
                    {
                        UserInformationClientGetUser obj = await userInformationClient.getUserInformation(userId);
                        return obj;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
                return null;
            }
            else
            {
                return Unauthorized();
            }
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(string id)
        {
            var userInfo = await _context.UserInfomation.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInfomation.Remove(userInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoExists(string id)
        {
            return _context.UserInfomation.Any(e => e.id == id);
        }
    }
}
