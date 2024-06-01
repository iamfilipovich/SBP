using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Hotel.Models
{
    public class rooms
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string TipSobe { get; set; }
        public int BrojKreveta { get; set; }
        public decimal Cijena { get; set; }

        public string HotelId { get; set; }
    }
}
