using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RnD.Apps.Models
{
    [Table("AppSetting")]
    public class AppSetting
    {
        [Key]
        public int ApplicationId { get; set; }

        [DisplayName("Application Name")]
        [MaxLength(200)]
        public string ApplicationName { get; set; }

        [DisplayName("Application Version")]
        [MaxLength(200)]
        public string ApplicationVersion { get; set; }
    }

    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }
    }

    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(200)]
        public string Name { get; set; }

        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Select one category.")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}