using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace TechShopWebsite.Models
{
    public abstract class CommonAbstraction
    {
        public String meta { get; set; }
        public bool hide { get; set; }
        public DateTime datebegin { get; set; }
        public String order { get; set; }
    }
}