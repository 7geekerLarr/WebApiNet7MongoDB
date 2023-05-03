using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRSDomain.Models
{
    public class GyfSystemMongoModels
    {
        [BsonId]
        public ObjectId Id { get; set; }        
       
        [BsonElement("nombre")]
        public string? Name { get; set; }
        [BsonElement("description")]
        public string? Description { get; set; }
        [BsonElement("user")]
        public string? User { get; set; }
        [BsonElement("license")]
        public string? License { get; set; }
        [BsonElement("idsystem")]
        public string? IdSystem { get; set; }
    }
}
