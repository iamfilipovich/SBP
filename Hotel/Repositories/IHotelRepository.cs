using MongoDB.Driver;
using Hotel.Models;
using System.Collections.Generic;

namespace Hotel.Repositories
{
    public interface IHotelRepository
    {
        IMongoCollection<hotels> hotelCollection { get; }
        IEnumerable<hotels> GetAllHotels();
        void Create(hotels hotels);
        void Update(string Id, hotels hotels);
        void Delete(string ImeHotela);
        hotels GetHotelsDetails(string Name);
    }
}
