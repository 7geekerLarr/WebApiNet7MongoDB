using ApiSystemCQRSDomain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRSAplication.GyfSystem.Queries
{
    public class GetSystemByIdQuery
    {
        #region Execute
        public class GetSystemById : IRequest<GyfSystemMongoModels>
        {
            public string? IdSystem { get; set; }
        }
        #endregion
    }
}
