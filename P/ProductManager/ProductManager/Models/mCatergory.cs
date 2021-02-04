using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
    public class mCatergory
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Please enter Category name ")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}