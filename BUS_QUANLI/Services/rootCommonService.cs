using Microsoft.AspNetCore.Http;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.ViewModels.Data;

namespace BUS_QUANLI.Services
{
    public class rootCommonService
    {
        public readonly DataContext dataContext;
        public readonly SystemContext systemContext;
        public readonly CommonHelpers commonHelpers;
        public readonly ViewModelAccount viewModelAccount;
        public readonly TokenHelper tokenHelper;
        public readonly StatusMessageMapper statusMessageMapper;

        public rootCommonService()
        {
            this.dataContext = new DataContext();
            this.systemContext = new SystemContext();
            this.viewModelAccount = new ViewModelAccount();
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper();
            this.statusMessageMapper = new StatusMessageMapper();
        }

        public string GetMessageDescription(EnumQuanLi param, HttpRequest httpRequest)
        {
            return statusMessageMapper.GetMessageDescription(param, httpRequest);
        }

    }
}
