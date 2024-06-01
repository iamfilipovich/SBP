using Hotel.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly IMongoDatabase _db;
        public ReservationsRepository(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionStrings);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<reservations> reservationCollection => _db.GetCollection<reservations>("Reservations");

        public void Create(reservations reservation)
        {
            reservationCollection.InsertOne(reservation);
        }

        public void Delete(string GostId)
        {
            var filter = Builders<reservations>.Filter.Eq(c => c.GostId, GostId);
            reservationCollection.DeleteOne(filter);

        }

        public IEnumerable<reservations> GetAllReservations()
        {
            return reservationCollection.Find(a => true).ToList();
        }

        public reservations GetReservationDetails(string Id)
        {
            var hotelDetails = reservationCollection.Find(m => m.GostId == Id).FirstOrDefault();
            return hotelDetails;
        }

        public void Update(string Id, reservations reservation)
        {
            var filter = Builders<reservations>.Filter.Eq(c => c._id, Id);
            var update = Builders<reservations>.Update
                .Set("GostId", reservation.GostId)
                .Set("SobaId", reservation.SobaId)
                .Set("DatumDolaska", reservation.DatumDolaska)
                .Set("DatumOdlaska", reservation.DatumOdlaska);

            reservationCollection.UpdateOne(filter, update);
        }
    }
}
