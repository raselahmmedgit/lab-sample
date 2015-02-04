using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.TestSample.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}