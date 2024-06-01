using Hotel.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public class GuestsRepository : IGuestsRepository
    {
        private readonly IMongoDatabase _db;
        public GuestsRepository(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionStrings);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<guests> guestCollection => _db.GetCollection<guests>("Guests");

        public void Create(guests guest)
        {
            guestCollection.InsertOne(guest);
        }

        public void Delete(string Ime)
        {
            var filter = Builders<guests>.Filter.Eq(c => c.Ime, Ime);
            guestCollection.DeleteOne(filter);
        }

        public IEnumerable<guests> GetAllGuests()
        {
            return guestCollection.Find(a => true).ToList();
        }

        public guests GetGuestDetails(string Name)
        {
            var hotelDetails = guestCollection.Find(m => m.Ime == Name).FirstOrDefault();
            return hotelDetails;
        }

        public void Update(string Id, guests guest)
        {
            var filter = Builders<guests>.Filter.Eq(c => c._id, Id);
            var update = Builders<guests>.Update
                .Set("Ime", guest.Ime)
                .Set("Prezime", guest.Prezime)
                .Set("Adresa", guest.Adresa)
                .Set("Telefon", guest.Telefon)
                .Set("Email", guest.Email)
;

            guestCollection.UpdateOne(filter, update);
        }
    }
}
