using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideJointAPI.Model
{

    public class PriceSummaryDTO
    {
        public int itemid { set; get; }
        public string name { set; get; }
        public string email { set; get; }
        public double todayopenvalue { get; set; }

        public List<PriceSummaryItem >priceSummaryItem { set; get; }
    }

    public class PriceSummaryItem
    {
        public int itemid { get; set; }
        public decimal averageprice { get; set; }
        public decimal totalprice { get; set; }
        public string percentage { get; set; }
        public string pricestatus { get; set; }    
    }
}

