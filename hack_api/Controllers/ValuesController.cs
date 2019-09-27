using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using workminimum.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using hack_api.Model;
using Microsoft.AspNetCore.Cors;

namespace hack_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "HELLO DIMA";
        }
        [Route("data")]
        // POST api/values
        [HttpPost]
        public string PostData([FromBody] DataMobailLevel[] jSON)
        {
            //Вынести на уровень выше
            const string nameCollection = "Note";
            MongoClient client = new MongoClient("mongodb+srv://public:12345qwert@hackathon-giyck.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("coordinateHackathon");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(nameCollection);
            //switch (jSON.func)
            //{
            //    case "ADD":
            //        Add(collection, jSON).GetAwaiter();
            //        return "1";
            //    case "ALL":
            //        return GetNotes(collection).GetAwaiter().GetResult();
            //    case "DEL":
            //        return Delete(collection,jSON.Id).GetAwaiter().GetResult().ToJson();
            //    case "UPD":
            //        return Update(collection, jSON).GetAwaiter().GetResult();
            //}
            foreach (DataMobailLevel jSONdata in jSON)
            {
                Add(collection, jSONdata);
            }
            return "0";
        }


        [HttpPost]
        [Route("people")]
        public string PostPeople([FromBody] People jSON)
        {
            //Вынести на уровень выше
            const string nameCollection = "People";
            MongoClient client = new MongoClient("mongodb+srv://public:12345qwert@hackathon-giyck.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("coordinateHackathon");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(nameCollection);
            switch (jSON.func)
            {
                case "ADD":
                    Add(collection, jSON);
                    return "1";
                case "ALL":
                    return GetNotes(collection).GetAwaiter().GetResult();
                case "DEL":
                    return Delete(collection, jSON.Id).GetAwaiter().GetResult().ToJson();
                case "UPD":
                    return Update(collection, jSON).GetAwaiter().GetResult();
            }
            return "0";
        }

        private static void Add(IMongoCollection<BsonDocument> collection, GetJSON note)
        {
             collection.InsertOneAsync(note.ToBsonDocument());
        }
        private static async Task<string> GetNotes(IMongoCollection<BsonDocument> collection)
        {
            var Items = await collection.Find(new BsonDocument()).ToListAsync();
            return Items.ToJson();
        }
        private static async Task<string> Delete(IMongoCollection<BsonDocument> collection, string idRemove)
        {
            var ss = new BsonDocument("_id", new ObjectId(idRemove));
            var result = await collection.DeleteOneAsync(ss);
            return result.ToJson();
        }
        private static async Task<string> Update(IMongoCollection<BsonDocument> collection, GetJSON note )
        {
            var result = await collection.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(note.Id)),note.ToBsonDocument());
            return result.ToJson();
        }
    }
}
