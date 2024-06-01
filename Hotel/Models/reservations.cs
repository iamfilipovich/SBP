using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Hotel.Models
{
    public class reservations
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string GostId { get; set; }
        public string SobaId { get; set; }
        public DateTime DatumDolaska { get; set; }
        public DateTime DatumOdlaska { get; set; }
    }
}
