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
    public class GyfSystemModels
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? User { get; set; }
        public string? License { get; set; }
    }
}
