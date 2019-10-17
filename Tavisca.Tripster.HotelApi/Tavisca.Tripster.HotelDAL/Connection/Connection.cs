using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.Tripster.Hotel.DataAcessLayer
{
    class Connection
    {
        static void Main(string[] args)
        {
            var settings2 = new MongoClientSettings
            {
                Server = new MongoServerAddress("3.14.69.62", 27017),
                UseSsl = false
            }; 

            var client = new MongoClient(settings2);
            IMongoDatabase db = client.GetDatabase("hotels");
            var collection = db.GetCollection<BsonDocument>("details");
            var author1 = new BsonDocument
        {
            {"id", 1},
            {"firstname", "Joydip"},
            {"lastname", "Kanjilal"}
        };
            var author2 = new BsonDocument
        {
            {"id", 2},
            {"firstname", "Steve"},
            {"lastname", "Smith"}
        };
            var author3 = new BsonDocument
        {
            {"id", 3},
            {"firstname", "Gary"},
            {"lastname", "Stevens"}
        };
            var authors = new List<BsonDocument>();
            authors.Add(author1);
            authors.Add(author2);
            authors.Add(author3);
            collection.InsertMany(authors);
            Console.Read();

        }

        static async Task MainAsync()
        {
            var connectionString = "mongodb://3.14.69.62:27017";

            var client = new MongoClient(connectionString);
        }
    }
}
