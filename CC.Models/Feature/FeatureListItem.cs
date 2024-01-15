using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models.Feature
{
    public class FeatureListItem
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
    }
}