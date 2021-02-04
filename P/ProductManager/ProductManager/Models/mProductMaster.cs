using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
    public class mProductMaster
    {
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter Category name ")]
        [Display(Name = "Category Name")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please enter product name ")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
       // public IEnumerable<mCatergory> Category { get; set; }
    }
}