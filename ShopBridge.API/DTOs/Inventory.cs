using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.DTOs
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 99999, ErrorMessage = "The Quantity {0} must be greater than {1}.")]
        public int Quantity { get; set; }
        
        [Required(ErrorMessage = "Unit is required")]
        [MinLength(1)]
        public string Unit { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 99999, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
