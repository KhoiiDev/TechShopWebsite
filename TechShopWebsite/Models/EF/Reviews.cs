using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechShopWebsite.Models.EF
{
    [Table("tb_Reviews")]
    public class Reviews : CommonAbstraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Reviewer không được để trống")]
        [StringLength(100)]
        public string Reviewer { get; set; }
        [Required(ErrorMessage = "ReviewContent không được để trống")]
        [StringLength(100)]
        public string ReviewContent { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(500)]
        public string Email { get; set; }
        public int Rating { get; set; }
    }
}