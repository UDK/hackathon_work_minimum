using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hack_api.Model
{
    interface INote
    {
        string title { get; set; }
        string body { get; set; }
        string[] tags { get; set; }
        string[] attachments { get; set; }
    }
}
