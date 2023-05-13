using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechShopWebsite.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string productName { get; set; }
        [AllowHtml]
        [StringLength(500000)]
        public string description { get; set; }
        public decimal price { get; set; }
        public bool isSale { get; set; }
        public decimal sale { get; set; }

        [StringLength(500)]
        public string manufacturer { get; set; }
        [StringLength(500)]
        public string img { get; set; }
        [StringLength(50000)]
        public string screen { get; set; }
        [StringLength(500)]
        public string CPU { get; set; }
        [StringLength(500)]
        public string OS { get; set; }
        [StringLength(500)]
        public string RAM { get; set; }
        [StringLength(500)]
        public string HardDrive { get; set; }

        [StringLength(500)]
        public string Camera { get; set; }
        [StringLength(500)]
        public string Capacity { get; set; }
        public int stars { get; set; }
        public int vote { get; set; }

        public virtual List<Reviews> reviews { get; set; }
        public String type { get; set; }
    }
}