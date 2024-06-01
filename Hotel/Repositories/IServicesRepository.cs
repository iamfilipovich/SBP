using Hotel.Models;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public interface IServicesRepository
    {
        IMongoCollection<services> serviceCollection { get; }
        IEnumerable<services> GetAllServices();
        void Create(services service);
        void Update(string _id, services service);
        void Delete(string Naziv);
        services GetServiceDetails(string Naziv);
    }
}