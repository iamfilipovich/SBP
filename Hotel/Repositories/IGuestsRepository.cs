using Hotel.Models;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public interface IGuestsRepository
    {
        IMongoCollection<guests> guestCollection { get; }
        IEnumerable<guests> GetAllGuests();
        void Create(guests guest);
        void Update(string Id, guests guest);
        void Delete(string Ime);
        guests GetGuestDetails(string Name);
    }
}
