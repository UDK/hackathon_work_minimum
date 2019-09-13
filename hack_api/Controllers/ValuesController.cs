using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using workminimum.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace hack_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] GetJSON jSON)
        {
            MongoClient client = new MongoClient("mongodb+srv://public:123456qwerty@hackathon-giyck.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("hackathon");
            Note debug = jSON as Note;
            
        }

    }
}
