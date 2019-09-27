using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workminimum.Models;

namespace hack_api.Model
{
    public class DataMobailLevel : GetJSON
    {

        public double X { get; set; }

        public int typeG { get; set; }

        public double Y { get; set; }

        public string nameOperator { get; set; }

        public int level { get; set; }

        public long time { get; set; }
    }
}
