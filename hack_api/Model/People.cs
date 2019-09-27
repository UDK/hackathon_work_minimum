using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workminimum.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace hack_api.Model
{
    public class People
    {

        [BsonIgnoreIfNull]
        public string func { get; set; }
        [BsonIgnoreIfNull]
        public string id { get; set; }
        public int name { get; set; }
        public int surName { get; set; }
        public int lastName { get; set; }

    }
}
