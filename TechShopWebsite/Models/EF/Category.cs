using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechShopWebsite.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbstraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please upload Image")]
        [StringLength(100)]
        public string CategoryImage { get; set; }

    }
}