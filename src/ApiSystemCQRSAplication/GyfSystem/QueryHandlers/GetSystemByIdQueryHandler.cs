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
using static ApiSystemCQRSAplication.GyfSystem.Queries.GetSystemByIdQuery;

namespace ApiSystemCQRSAplication.GyfSystem.QueryHandlers
{
    public class GetSystemByIdQueryHandler
    {
        #region HandlerClass
        public class HandlerClass : IRequestHandler<GetSystemById, GyfSystemMongoModels>
        {
            private readonly IGyfSystems _GyfSystemsRepository;
            public HandlerClass(IGyfSystems GyfSystemsRepository)
            {
                _GyfSystemsRepository = GyfSystemsRepository;
            }
            public async Task<GyfSystemMongoModels> Handle(GetSystemById request, CancellationToken cancellationToken)
            {
                if (request.IdSystem == "0")
                {
                    throw new HandleException(HttpStatusCode.BadRequest, new { GySistemas = "Id del sistema no es valido, no puede ser (0)" });                
                }
                if (request.IdSystem == null)
                {
                    throw new HandleException(HttpStatusCode.BadRequest, new { GySistemas = "Id del sistema no es valido, no puede ser (0)" });
                }
                var result = await _GyfSystemsRepository.GetOne(request.IdSystem);
                if (result == null)
                {
                    throw new HandleException(HttpStatusCode.NotFound, new { GySistemas = "Sistema no encontrado" });
                }
                return result;


            }


        }
        #endregion
    }
}
//resultado = resultado?.ToList() ?? new List<GyfSystemMongoModels>();

//var result = resultado.FirstOrDefault(s => s.IdSystem == request.IdSystem);
//if (result == null)
// {
//     throw new HandleException(HttpStatusCode.NotFound, new { GySistemas = "No se encontro el id del sistema, por favor revise el id correcto y mande de nuevo (Id:" + request.Id + ")" });
// }