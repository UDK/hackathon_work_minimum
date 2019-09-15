using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workminimum.Models
{
    public class GetJSON : Note
    {
        public string func { get; set; }

        public string id { get; set; }

        public Note GetNote()
        {
            Note note = new Note();
            note.title = this.title;
            note.body = this.body;
            note.tags = this.tags;
            note.attachments = this.attachments;
            return note;
        }
    }
}
