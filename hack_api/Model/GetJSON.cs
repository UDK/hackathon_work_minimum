using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hack_api.Model;

namespace workminimum.Models
{
    public class GetJSON : DataMobailLevel
    {
        public string func { get; set; }

        public string id { get; set; }

        public DataMobailLevel GetParent()
        {
            DataMobailLevel data = new DataMobailLevel();
            data.X = this.X;
            data.Y = this.Y;
            data.level = this.level;
            data.nameOperator = this.nameOperator;
            return data;
        }
    }
}
