using ApiSystemCQRSAplication.HandleError;
using ApiSystemCQRSDomain.Models;
using ApiSystemCQRSInfrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRSAplication.GyfSystem.Commands.CreateSystem
{
    public class CreateSystemCommand
    {
        #region CreateSystem
        public class CreateSystem : IRequest<GyfSystemMongoModels>
        {
            public string? IdSystem { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? User { get; set; }
            public string? License { get; set; }
        }
        #endregion

    }
}
