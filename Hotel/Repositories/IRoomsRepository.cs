using Hotel.Models;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public interface IRoomsRepository
    {
        IMongoCollection<rooms> roomCollection { get; }
        IEnumerable<rooms> GetAllRooms();
        void Create(rooms room);
        void Update(string Id, rooms room);
        void Delete(string TipSobe);
        rooms GetRoomDetails(string TipSobe);
    }
}
