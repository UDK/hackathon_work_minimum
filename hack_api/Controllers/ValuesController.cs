using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using workminimum.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace hack_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public string Post([FromBody] GetJSON jSON)
        {
            //Вынести на уровень выше
            const string nameCollection = "Note";
            MongoClient client = new MongoClient("mongodb+srv://public:12345qwert@hackathon-giyck.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("hackathon");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(nameCollection);
            switch (jSON.func)
            {
                case "ADD":
                    Add(collection, jSON.GetNote()).GetAwaiter();
                    return "1";
                case "ALL":
                    return GetNotes(collection).GetAwaiter().GetResult();
                case "DEL":
                    return Delete(collection,jSON.id).GetAwaiter().GetResult().ToJson();
            }
            return "0";
        }

        private static async Task Add(IMongoCollection<BsonDocument> collection, Note note)
        {
            await collection.InsertOneAsync(note.ToBsonDocument());
        }
        private static async Task<string> GetNotes(IMongoCollection<BsonDocument> collection)
        {
            var Items = await collection.Find(new BsonDocument()).ToListAsync();
            return Items.ToJson();
        }
        private static async Task<string> Delete(IMongoCollection<BsonDocument> collection,string idRemove)
        {
            var ss = new BsonDocument("_id", new ObjectId("5d7e747b02a3cd1318e17af7"));
            var result = await collection.DeleteOneAsync(ss);
            return result.ToJson();
        }
    }
}
