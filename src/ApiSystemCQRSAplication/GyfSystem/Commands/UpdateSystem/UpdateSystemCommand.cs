using ApiSystemCQRSDomain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRSAplication.GyfSystem.Commands.UpdateSystem
{
    public class UpdateSystemCommand
    {
        #region  UpdateSystem
        public class UpdateSystem : IRequest<GyfSystemMongoModels>
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
