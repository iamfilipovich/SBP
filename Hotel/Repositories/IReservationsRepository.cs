using Hotel.Models;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public interface IReservationsRepository
    {
        IMongoCollection<reservations> reservationCollection { get; }
        IEnumerable<reservations> GetAllReservations();
        void Create(reservations reservation);
        void Update(string Id, reservations reservation);
        void Delete(string GostId);
        reservations GetReservationDetails(string Id);
    }
}
