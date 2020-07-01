using EmployeesCatalog.Models;
using MongoDB.Driver;
using System;

namespace EmployeesCatalog.Serivices
{
    public class DatabaseSetup
    {
        private string          _connectionString;
        private IMongoDatabase  _database;
        private MongoClient     _client;

        public DatabaseSetup(string connectionString, string dbName)
        {
            _connectionString = connectionString;
            try
            {
                _client = new MongoClient(_connectionString);
                _database = _client.GetDatabase(dbName);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public string ConnectionString
        {
            get { return _connectionString;  }
            set 
            {
                if (_connectionString != value)
                    _connectionString = value;
            }
        }
        
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public void CreateCollection(string collectionName)
        {
            if (_database.GetCollection<Employee>(ConnectionString) == null)
            {
                _database.CreateCollection(collectionName);
            }
        }

        public IMongoCollection<Employee> GetEmployeesCollection(string collectionName)
        {
            return _database.GetCollection<Employee>(collectionName);
        }
    }

}
