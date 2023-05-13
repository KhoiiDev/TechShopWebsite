using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechShopWebsite.Models.EF
{
    [Table("tb_Cart")]
    public class Cart : CommonAbstraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public decimal cost { get; set; }
        [Required]
        public bool isPay { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public virtual Product product { get; set; }
    }
}