﻿
namespace sharp.Serene.Common.Endpoints
{
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.UserPreferenceRepository;
    using MyRow = Entities.UserPreferenceRow;

    [RoutePrefix("Services/Common/UserPreference"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize]
    public class UserPreferenceController : ServiceEndpoint
    {
        [HttpPost]
        public ServiceResponse Update(IUnitOfWork uow, UserPreferenceUpdateRequest request)
        {
            return new MyRepository().Update(uow, request);
        }

        public UserPreferenceRetrieveResponse Retrieve(IDbConnection connection, UserPreferenceRetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }
    }
}
