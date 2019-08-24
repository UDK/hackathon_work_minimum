using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workminimum.Models
{
    public class Note
    {
        string title { get; set; }
        string body { get; set; }
        Int64 id { get; set; }
        string[] tags { get; set; }
        DateTime lastTimeModified
        {
            get
            {
                return lastTimeModified;
            }
            set
            {
                lastTimeModified = DateTime.Now;
            }
        }
        string[] attachments { get; set; }
    }
}
