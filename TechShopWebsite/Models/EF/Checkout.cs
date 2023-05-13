using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TechShopWebsite.Models.EF
{
    [Table("tb_Checkout")]
    public class Checkout : CommonAbstraction
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string receiver { get; set; }

        public string phone { get; set; }

        public string Address { get; set; }

        public string province { get; set; }

        public string district { get; set; }

        public string ZipCode { get; set; }
        public bool isPay { get; set; }
        public virtual List<Cart> carts { get; set; }

        public string username { get; set; }

    }
}