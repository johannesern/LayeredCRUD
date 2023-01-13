using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace LayeredCRUD
{
    internal class MongoDAO : IDAO
    {
        private MongoClient _client;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> _collection;

        public MongoDAO(string connectionString, string database)
        {            
            _client = new MongoClient(connectionString);
            this.database = _client.GetDatabase(database);
            _collection = this.database.GetCollection<BsonDocument>("product");
        }
        public void Create(BsonDocument document)
        {
            _collection.InsertOne(document);
        }

        public void Delete(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            _collection.DeleteOne(filter);
        }

        public List<BsonDocument> Read()
        {
            return _collection.Find(_ => true).ToList();
        }

        public void UpdatePrice(string id, string input)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("price", input);
            _collection.UpdateOne(filter, update);
        }
    }
}
