using Hotel.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Hotel.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IMongoDatabase _db;
        public EmployeesRepository(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionStrings);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<employees> employeeCollection => _db.GetCollection<employees>("Employees");

        public void Create(employees employee)
        {
            employeeCollection.InsertOne(employee);
        }

        public void Delete(string Ime)
        {
            var filter = Builders<employees>.Filter.Eq(c => c.Ime, Ime);
            employeeCollection.DeleteOne(filter);
        }

        public IEnumerable<employees> GetAllServices()
        {
            return employeeCollection.Find(a => true).ToList();
        }

        public employees GetServiceDetails(string Name)
        {
            var hotelDetails = employeeCollection.Find(m => m.Ime == Name).FirstOrDefault();
            return hotelDetails;
        }

        public void Update(string _id, employees employee)
        {
            var filter = Builders<employees>.Filter.Eq(c => c._id, _id);
            var update = Builders<employees>.Update
                .Set("Ime", employee.Ime)
                .Set("Prezime", employee.Prezime)
                .Set("Pozicija", employee.Pozicija)
                .Set("Placa", employee.Placa)
                .Set("HotelId", employee.HotelId);

            employeeCollection.UpdateOne(filter, update);
        }
    }
}
