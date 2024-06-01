using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Hotel.Models
{
    public class services
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string Naziv { get; set; }
        public decimal Cijena { get; set; }

        public string HotelId { get; set; }
    }
}
