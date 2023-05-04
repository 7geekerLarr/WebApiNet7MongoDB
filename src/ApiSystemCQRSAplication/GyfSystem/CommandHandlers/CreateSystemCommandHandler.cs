using ApiSystemCQRSAplication.HandleError;
using ApiSystemCQRSDomain.Models;
using ApiSystemCQRSInfrastructure.Services;
using MediatR;
using System.Net;
using static ApiSystemCQRSAplication.GyfSystem.Commands.CreateSystem.CreateSystemCommand;

namespace ApiSystemCQRSAplication.GyfSystem.CommandHandlers
{
    public class CreateSystemCommandHandler
    {
        #region HandlerClass
        public class HandlerClass : IRequestHandler<CreateSystem, GyfSystemMongoModels>
        {
            private readonly IGyfSystems _GyfSystemsRepository;
            public HandlerClass(IGyfSystems GyfSystemsRepository)
            {
                _GyfSystemsRepository = GyfSystemsRepository;
            }
            public async Task<GyfSystemMongoModels> Handle(CreateSystem request, CancellationToken cancellationToken)
            {
                GyfSystemMongoModels entity = new GyfSystemMongoModels();
                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.License = request.License;
                entity.User = request.User;
                entity.IdSystem = request.IdSystem;

                if (entity == null)
                {
                    throw new HandleException(HttpStatusCode.BadRequest, new { GySistemas = "La estructura no es correcta!" });
                }
                if (entity.IdSystem == "0")
                {
                    throw new HandleException(HttpStatusCode.BadRequest, new { GySistemas = "La estructura no es correcta!" + entity.IdSystem });
                }
                if (entity.IdSystem == null || entity.Name == null)
                {
                    throw new HandleException(HttpStatusCode.BadRequest, new { GySistemas = "La estructura no es correcta!"   });               
                }
                if (entity.IdSystem == "" || entity.Name == "")
                {
                    throw new HandleException(HttpStatusCode.BadRequest, new { GySistemas = "Campos obligatotios:IdSystem y Name, La estructura no es correcta!" });
                }
                var result = await _GyfSystemsRepository.Add(entity);
                if (result)
                {
                    return entity;
                }
                else
                {
                    throw new HandleException(HttpStatusCode.NotImplemented, new { GySistemas = "Error, Sistema no ha sido creado!" });
                }

            }


        }
        #endregion

    }
}
