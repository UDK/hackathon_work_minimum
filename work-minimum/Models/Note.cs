﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workminimum.Models
{
    public abstract class Note
    {
        public string title { get; set; }
        public string body { get; set; }
        public Int64 id { get; set; }
        public string[] tags { get; set; }
        public string lastTimeModified { get; set; }
  
        public string[] attachments { get; set; }

        public Note(string title, string body, Int64 id,string[]tags,string lastTimeModified, string[] attachments)
        {
            this.title = title;
            this.body = body;
            this.id = id;
            this.tags = tags;
            this.lastTimeModified = lastTimeModified;
            this.attachments = attachments;
        }
    }
}
