using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models
{
    public class mProductManager
    {
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
        [Display(Name = "Product name")]
        public string ProductName { get; set; }
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}