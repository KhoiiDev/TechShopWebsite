using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TechShopWebsite.Models.EF
{
    [Table("tb_Contact")]
    public class Contact : CommonAbstraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string contactName { get; set; }
        [StringLength(100)]
        public string contactEmail { get; set; }
        [StringLength(500)]
        public string contactMessage { get; set; }
        [StringLength(500)]
        public string contactSubject { get; set; }
        public string username { get; set; }

    }
}