using ApiSystemCQRSDomain.Models;
using Microsoft.Extensions.Configuration;

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiSystemCQRSInfrastructure.Services
{
    public class GyfSystemsRepository : IGyfSystems
    {
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly IMongoCollection<GyfSystemMongoModels> _collection;

        public GyfSystemsRepository(IConfiguration config)
        {
            _connectionString = config.GetSection("MongoDbSettings:ConnectionString").Value;
            _databaseName = config.GetSection("MongoDbSettings:DatabaseName").Value;
            _collectionName = config.GetSection("MongoDbSettings:CollectionName").Value;

            var mongoClient = new MongoClient(_connectionString);
            var database = mongoClient.GetDatabase(_databaseName);
            _collection = database.GetCollection<GyfSystemMongoModels>(_collectionName);
        }

        #region Add
        public async Task<bool> Add(GyfSystemMongoModels entity)
        {
            try
            {
                var systems = new GyfSystemMongoModels()
                {
                    IdSystem = entity.IdSystem,
                    Name = entity.Name,
                    Description = entity.Description,
                    User = entity.User,
                    License = entity.License
                };
                await _collection.InsertOneAsync(systems);
                return true;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region GetOne
        public async Task<GyfSystemMongoModels?> GetOne(string Id)
        {
            var filter = Builders<GyfSystemMongoModels>.Filter.Eq("IdSystem", Id);
            var result = await _collection.FindAsync(filter);
            return result.FirstOrDefault();
        }
        #endregion

        #region GetAll
        public async Task<List<GyfSystemMongoModels>?> GetAll()
        {
            try
            {
                var result = await _collection.Find(x => true).Limit(25).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }
        #endregion

        #region Upd
        public async Task<bool> Upd(GyfSystemMongoModels entity)
        {
            try
            {
                var filter = Builders<GyfSystemMongoModels>.Filter.Eq("IdSystem", entity.IdSystem);
                var update = Builders<GyfSystemMongoModels>.Update
                    .Set("Name", entity.Name)
                    .Set("Description", entity.Description)
                    .Set("User", entity.User)
                    .Set("License", entity.License);

                var result = await _collection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Del
        public async Task<bool> Del(string Id)
        {
            var filter = Builders<GyfSystemMongoModels>.Filter.Eq(s => s.IdSystem, Id);
            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
