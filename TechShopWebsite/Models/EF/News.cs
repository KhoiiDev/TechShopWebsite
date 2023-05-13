using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechShopWebsite.Models.EF
{
    [Table("tb_News")]
    public class News : CommonAbstraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100)]
        public string title { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống")]
        [StringLength(5000)]
        public string description { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(50000)]
        public string content { get; set; }
        [Required(ErrorMessage = "Hình ảnh không được để trống ")]
        [StringLength(500)]
        public string avatar { get; set; }
    }
}