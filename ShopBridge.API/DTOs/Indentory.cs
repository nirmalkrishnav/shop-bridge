﻿using System;

namespace ShopBridge.DTOs
{
    public class Inventory : Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
    }
}
