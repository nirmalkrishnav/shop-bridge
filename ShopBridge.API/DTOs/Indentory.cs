﻿using System;

namespace ShopBridge.DTOs
{
    public class Inventory
    {
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
    }
}
