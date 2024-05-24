using BUS_QUANLI.Helpers;
using Microsoft.AspNetCore.Http;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.ViewModels.Data;

namespace BUS_QUANLI.Services.MasterData
{
    public class rootCommonService : CommonHelpers
    {
        public readonly DataContext dataContext;
        public readonly SystemContext systemContext;
        public readonly CommonHelpers commonHelpers;
        public readonly ViewModelAccount viewModelAccount;
        public readonly TokenHelper tokenHelper;
        public readonly StatusMessageMapper statusMessageMapper;
        public readonly LogTimeDataUpdateService logTimeDataUpdateService;

        public rootCommonService()
        {
            dataContext = new DataContext();
            systemContext = new SystemContext();
            viewModelAccount = new ViewModelAccount();
            commonHelpers = new CommonHelpers();
            tokenHelper = new TokenHelper();
            statusMessageMapper = new StatusMessageMapper();
            logTimeDataUpdateService = new LogTimeDataUpdateService();
        }

        public string GetMessageDescription(EnumQuanLi param, HttpRequest httpRequest)
        {
            return statusMessageMapper.GetMessageDescription(param, httpRequest);
        }

    }
}
