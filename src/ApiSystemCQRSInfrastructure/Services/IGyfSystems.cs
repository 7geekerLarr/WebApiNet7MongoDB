using ApiSystemCQRSDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRSInfrastructure.Services
{
    public  interface IGyfSystems
    {
        
        Task<List<GyfSystemMongoModels>?> GetAll();        
        Task<GyfSystemMongoModels?> GetOne(string Id);        
        Task<bool> Add(GyfSystemMongoModels entity);        
        Task<bool> Upd(GyfSystemMongoModels entity);        
        Task<bool> Del(string Id);
    }
}
