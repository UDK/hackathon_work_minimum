﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hack_api.Model;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace workminimum.Models
{
    public class GetJSON
    {
        [BsonIgnoreIfNull]
        public string func { get; set; }
        [BsonIgnoreIfNull]
        public string Id { get; set; }

    }
}
