using ApiSystemCQRSAplication.HandleError;
using ApiSystemCQRSDomain.Models;
using ApiSystemCQRSInfrastructure.Services;
using MediatR;
using System.Net;
using static ApiSystemCQRSAplication.GyfSystem.Commands.DeleteSystem.DeleteSystemCommand;

namespace ApiSystemCQRSAplication.GyfSystem.CommandHandlers
{
    public class DeleteSystemCommandHandler
    {
        #region HandlerClass
        public class HandlerClass : IRequestHandler<DeleteSystem>
        {
            private readonly IGyfSystems _GyfSystemsRepository;
            public HandlerClass(IGyfSystems GyfSystemsRepository)
            {
                _GyfSystemsRepository = GyfSystemsRepository;
            }
            public async Task<Unit> Handle(DeleteSystem request, CancellationToken cancellationToken)
            {
                if (request.IdSystem == "0")
                {
                    throw new HandleException(HttpStatusCode.NotFound, new { GySistemas = "Id del sistema no es valido, no puede ser 0!" });
                }
                if (request.IdSystem == null)
                {
                    throw new HandleException(HttpStatusCode.NotFound, new { GySistemas = "Id del sistema no es valido, no puede ser null!" });
                }
                var resul = await _GyfSystemsRepository.Del(request.IdSystem);               
                
                if (resul)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new HandleException(HttpStatusCode.NotImplemented, new { GySistemas = "Error, Sistema no ha sido borrado  (Id: " + request.IdSystem + ")" });
                }

            }


        }
        #endregion
    }
}
