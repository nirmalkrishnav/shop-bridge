using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.DTOs
{
    public class Inventory
    {

        public  int Id { get; set; }
        [Required(ErrorMessage = "Name is required")] 
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
