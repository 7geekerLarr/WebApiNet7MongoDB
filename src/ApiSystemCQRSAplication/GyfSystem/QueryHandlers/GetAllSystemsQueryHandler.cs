using ApiSystemCQRSDomain.Models;
using ApiSystemCQRSInfrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApiSystemCQRSAplication.GyfSystem.Queries.GetAllSystemsQuery;

namespace ApiSystemCQRSAplication.GyfSystem.QueryHandlers
{
    public class GetAllSystemsQueryHandler
    {
        #region HandlerClass
        public class HandlerClass : IRequestHandler<GetAllSystems, List<GyfSystemMongoModels>>
        {
            private readonly IGyfSystems _GyfSystemsRepository;
            public HandlerClass(IGyfSystems GyfSystemsRepository)
            {
                _GyfSystemsRepository = GyfSystemsRepository;
            }
            
            public async  Task<List<GyfSystemMongoModels>> Handle(GetAllSystems request, CancellationToken cancellationToken)
            {
                var resultado = await _GyfSystemsRepository.GetAll();
                return resultado?.OrderBy(x => x.Name).ToList() ?? new List<GyfSystemMongoModels>();
            }
        }
        #endregion
    }
}
