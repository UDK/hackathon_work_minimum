using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workminimum.Models
{
    public class Note
    {
        public string title { get; set; }
        public string body { get; set; }
        public Int64 id { get; set; }
        public string[] tags { get; set; }  
        public string[] attachments { get; set; }

    }
}
