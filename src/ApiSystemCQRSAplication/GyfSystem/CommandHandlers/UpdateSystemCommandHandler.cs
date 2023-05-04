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
using static ApiSystemCQRSAplication.GyfSystem.Commands.UpdateSystem.UpdateSystemCommand;

namespace ApiSystemCQRSAplication.GyfSystem.CommandHandlers
{
    public class UpdateSystemCommandHandler
    {
        #region HandlerClass
        public class HandlerClass : IRequestHandler<UpdateSystem, GyfSystemMongoModels>
        {
            private readonly IGyfSystems _GyfSystemsRepository;
            #region HandlerClass            
            public HandlerClass(IGyfSystems GyfSystemsRepository)
            {
                _GyfSystemsRepository = GyfSystemsRepository;
            }
            #endregion
            #region Handle           
            public async Task<GyfSystemMongoModels> Handle(UpdateSystem request, CancellationToken cancellationToken)
            {
                GyfSystemMongoModels entity = new GyfSystemMongoModels();
                entity.IdSystem = request.IdSystem;
                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.License = request.License;
                entity.User = request.User;

                if (entity == null)
                {
                    throw new HandleException(HttpStatusCode.BadRequest, new { GySistemas = "La estructura no es correcta!" });
                }
                if (request.IdSystem == "0")
                {
                    throw new HandleException(HttpStatusCode.NotFound, new { GySistemas = "Id del sistema no es valido, no puede ser 0!" });
                }
                if (request.IdSystem == null)
                {
                    throw new HandleException(HttpStatusCode.NotFound, new { GySistemas = "Id del sistema no es valido, no puede ser null!" });
                }                             

                var result = await _GyfSystemsRepository.Upd(entity);
                if (result)
                {
                    return entity;
                }
                else
                {
                    throw new HandleException(HttpStatusCode.NotImplemented, new { GySistemas = "Error, Sistema no han sido encontrado, Sistema no ha sido actualizado!" });                    
                }
            }

            #endregion
        }
        #endregion
    }
}
