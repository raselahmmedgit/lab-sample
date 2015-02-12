using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RnD.Apps.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }
    }

    public class Product
    {
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