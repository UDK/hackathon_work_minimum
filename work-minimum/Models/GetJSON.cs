using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workminimum.Models
{
    public class GetJSON : Note
    {
        public string func { get; set; }
        
        public Note getNote()
        {
            return null;
            //return new Note(title, body, id, tags, lastTimeModified, attachments);
        }
    }
}
