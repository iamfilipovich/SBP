using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hotel.Models
{
    public class hotels
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int HotelID { get; set; }
        public string ImeHotela { get; set; }

        public string Adresa { get; set; }
    }
}
