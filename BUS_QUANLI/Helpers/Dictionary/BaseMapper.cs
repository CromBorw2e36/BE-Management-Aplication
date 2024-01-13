using quan_li_app.Models;

namespace quan_li_app.Helpers.Dictionary
{
    public class BaseMapper
    {
        private Dictionary<EnumQuanLi, string> baseMapper;

        public BaseMapper()
        {
            baseMapper = new Dictionary<EnumQuanLi, string>
            {
                 {EnumQuanLi.ADMIN, "ADMIN" },
                 {EnumQuanLi.NEWUSER, "Người dùng mới" },
                 {EnumQuanLi.NotFoundDictionary, "Không tìm thấy" },
            };
        }

        public string GetMessageDescription(EnumQuanLi param)
        {
            if (baseMapper.ContainsKey(param))
            {
                return baseMapper[param];
            }
            else
            {
                return baseMapper[EnumQuanLi.NotFoundDictionary];
            }
        }


        public string GetSysCompany()
        {
            return baseMapper[EnumQuanLi.ADMIN];
        }
    }
}
