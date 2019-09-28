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
using System.Runtime.CompilerServices;

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
            return "1";
        }


        [HttpGet]
        [Route("all")]
        public string PostPeople()
        {
            //Вынести на уровень выше
            const string nameCollection = "Note";
            MongoClient client = new MongoClient("mongodb+srv://public:12345qwert@hackathon-giyck.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("coordinateHackathon");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(nameCollection);
            //switch (jSON.func)
            //{
            //    case "ADD":
            //        Add(collection, jSON);
            //        return "1";
            //    case "ALL":
            //        return GetNotes(collection).GetAwaiter().GetResult();
            //    case "DEL":
            //        return Delete(collection, jSON.Id).GetAwaiter().GetResult().ToJson();
            //    case "UPD":
            //        return Update(collection, jSON).GetAwaiter().GetResult();
            //}
            var dd = GetNotes(collection).GetAwaiter().GetResult();

            return dd;
            //List<Point> bsonElementsValid = new List<Point>(bsonElements.Count / 4);
            //foreach (BsonDocument bsonValidTrue in bsonElements)
            //{
            //    if (bsonValidTrue.GetValue("valid").AsBoolean == true && bsonValidTrue.GetValue("X").AsDouble != 0)
            //    {
            //        bsonElementsValid.Add(new Point(bsonValidTrue.GetValue("X").AsDouble, bsonValidTrue.GetValue("Y").AsDouble));
            //    }
            //}
            //MathIn checkPoints = new MathIn(bsonElementsValid);
            //foreach (BsonDocument bsonValidTrue in bsonElements)
            //{
            //    if (bsonValidTrue.GetValue("valid").AsBoolean == true && bsonValidTrue.GetValue("X").AsDouble != 0)
            //    {
            //        bsonElementsValid.Add(new Point(bsonValidTrue.GetValue("X").AsDouble, bsonValidTrue.GetValue("Y").AsDouble));
            //    }
            //}
            //checkPoints.pointInLine();
            //return "1";
        }

        private static void Add(IMongoCollection<BsonDocument> collection, GetJSON note)
        {
             collection.InsertOne(note.ToBsonDocument());
        }
        private static async Task<string> GetNotes(IMongoCollection<BsonDocument> collection)
        {
            var Items = await collection.Find(new BsonDocument()).Project("{_id:0,X:1,Y:1,level:1}").ToListAsync();
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
    class MathIn
    {
        List<Point> points;

        public MathIn(List<Point> arPoints)
        {
            points = arPoints;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool pointInLine(Point pointCompare)
        {
            for(int twoPoint = 0; twoPoint<points.Count-1; twoPoint++)
            {
                double x1 = points[twoPoint].X;
                double x2 = points[twoPoint+1].X;
                double x3 = pointCompare.X;
                double y1 = points[twoPoint].Y;
                double y2 = points[twoPoint+1].Y;
                double y3 = pointCompare.Y;
                double A = y2 - y1;
                double B = x1 - x2;
                double C = x1 * (y1 - y2) + y1 * (x2 - x1);
                double d = Math.Abs(A * pointCompare.X + B * pointCompare.Y + C) / Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
            }
            return false;
        }
    }

    struct Point
    {
        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public double X;
        public double Y;
    }
}
