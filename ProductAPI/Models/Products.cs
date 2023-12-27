﻿namespace ProductAPI.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductBrand { get; set; }

        public int ProductQuantity { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
