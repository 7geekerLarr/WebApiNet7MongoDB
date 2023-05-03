using ApiSystemCQRSDomain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRSAplication.GyfSystem.Queries
{
    public class GetAllSystemsQuery
    {
        #region ExecuteList       
        public class GetAllSystems : IRequest<List<GyfSystemMongoModels>>
        {

        }
        #endregion
    }
}
