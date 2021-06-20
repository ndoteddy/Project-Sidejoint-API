using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SideJointAPI.Model
{    public class PriceTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int itemid { get; set; }
        public decimal price { get; set; }
        public DateTime createdat { get; set; }
        public int createdby { get; set; }
    }
}

