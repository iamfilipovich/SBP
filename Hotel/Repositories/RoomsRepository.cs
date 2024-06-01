using Hotel.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Hotel.Repositories
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly IMongoDatabase _db;
        public RoomsRepository(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionStrings);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<rooms> roomCollection => _db.GetCollection<rooms>("Rooms");

        public void Create(rooms room)
        {
            roomCollection.InsertOne(room);

        }

        public void Delete(string TipSobe)
        {
            var filter = Builders<rooms>.Filter.Eq(c => c.TipSobe, TipSobe);
            roomCollection.DeleteOne(filter);
        }

        public IEnumerable<rooms> GetAllRooms()
        {
            return roomCollection.Find(a => true).ToList();

        }

        public rooms GetRoomDetails(string Name)
        {
            var hotelDetails = roomCollection.Find(m => m.TipSobe == Name).FirstOrDefault();
            return hotelDetails;
        }

        public void Update(string Id, rooms room)
        {
            var filter = Builders<rooms>.Filter.Eq(c => c._id, Id);
            var update = Builders<rooms>.Update
                .Set("TipSobe", room.TipSobe)
                .Set("BrojKreveta", room.BrojKreveta)
                .Set("Cijena", room.Cijena)
                .Set("HotelId", room.HotelId);

            roomCollection.UpdateOne(filter, update);
        }
    }
}
