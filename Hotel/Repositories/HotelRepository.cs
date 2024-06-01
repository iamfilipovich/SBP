using Hotel.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IMongoDatabase _db;
        public HotelRepository(IOptions<Settings> options)
        {
            var client = new MongoClient (options.Value.ConnectionStrings);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<hotels> hotelCollection => _db.GetCollection<hotels>("Hotel");

        public hotels GetHotelsDetails(string Name)
        {
            var hotelDetails = hotelCollection.Find(m => m.ImeHotela == Name).FirstOrDefault();
            return hotelDetails;
        }
        public IEnumerable<hotels> GetAllHotels()
        {
            return hotelCollection.Find(a => true).ToList();
        }
        public void Create(hotels hotels)
        {
            hotelCollection.InsertOne(hotels);
        }

        public void Delete(string ImeHotela)
        {
            var filter = Builders<hotels>.Filter.Eq(c => c.ImeHotela, ImeHotela);
            hotelCollection.DeleteOne(filter);
        }

        public void Update(string Id, hotels hotels)
        {
            var filter = Builders<hotels>.Filter.Eq(c => c._id, Id);
            var update = Builders<hotels>.Update
                .Set("HotelID", hotels.HotelID)
                .Set("ImeHotela", hotels.ImeHotela)
                .Set("Adresa", hotels.Adresa);

            hotelCollection.UpdateOne(filter, update);
        }   
    }
}
