using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Hotel.Models
{
    public class employees
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pozicija { get; set; }
        public decimal Placa { get; set; }
        public string HotelId { get; set; }
    }
}
