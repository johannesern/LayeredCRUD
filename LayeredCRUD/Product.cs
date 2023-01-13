using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredCRUD
{
    internal class Product
    {
        //Attribut
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]        
        public string Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Name}\n" +
                   $"{Price}\n" +
                   $"{Quantity}\n" +
                   $"{Description}";
        }
    }
}
