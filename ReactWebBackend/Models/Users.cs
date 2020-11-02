using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReactWebBackend.Models
{
    public class Users

    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        public List<Book> Books { get; set; }

    }
}
