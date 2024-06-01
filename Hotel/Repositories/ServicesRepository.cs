using Hotel.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly IMongoDatabase _db;
        public ServicesRepository(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionStrings);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<services> serviceCollection => _db.GetCollection<services>("Services");

        public services GetServiceDetails(string Name)
        {
            var hotelDetails = serviceCollection.Find(m => m.Naziv == Name).FirstOrDefault();
            return hotelDetails;
        }
        public IEnumerable<services> GetAllServices()
        {
            return serviceCollection.Find(a => true).ToList();
        }
        public void Create(services service)
        {
            serviceCollection.InsertOne(service);
        }

        public void Delete(string Naziv)
        {
            var filter = Builders<services>.Filter.Eq(c => c.Naziv, Naziv);
            serviceCollection.DeleteOne(filter);
        }

        public void Update(string _id, services service)
        {
            var filter = Builders<services>.Filter.Eq(c => c._id, _id);
            var update = Builders<services>.Update
                .Set("Naziv", service.Naziv)
                .Set("Cijena", service.Cijena)
                .Set("HotelId", service.HotelId);

            serviceCollection.UpdateOne(filter, update);
        }
    }
}
