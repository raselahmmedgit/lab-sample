using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.Apps.ViewModels
{
    public class CategoryTableModels
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
    }

    public class ProductTableModels
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}