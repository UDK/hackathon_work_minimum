using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hack_api.Model;

namespace workminimum.Models
{
    public class Note : INote
    {
        public string title { get ; set ; }
        public string body { get ; set ; }
        public string[] tags { get ; set ; }
        public string[] attachments { get ; set ; }
       
    }
}
