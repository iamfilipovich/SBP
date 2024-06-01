using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Hotel.Models
{
    public class guests
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
