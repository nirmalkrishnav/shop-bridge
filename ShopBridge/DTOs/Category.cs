using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBridge.DTOs
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }

    }
}
