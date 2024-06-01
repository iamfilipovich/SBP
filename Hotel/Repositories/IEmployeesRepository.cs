using Hotel.Models;
using MongoDB.Driver;

namespace Hotel.Repositories
{
    public interface IEmployeesRepository
    {
        IMongoCollection<employees> employeeCollection { get; }
        IEnumerable<employees> GetAllServices();
        void Create(employees employee);
        void Update(string _id, employees employee);
        void Delete(string Ime);
        employees GetServiceDetails(string Ime);
    }
}
