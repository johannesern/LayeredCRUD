using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LayeredCRUD
{
    internal interface IDAO
    {
        public void Create(BsonDocument document);
        public void Delete(string id);
        public void UpdatePrice(string id, string input);
        public List<BsonDocument> Read();
    }
}
