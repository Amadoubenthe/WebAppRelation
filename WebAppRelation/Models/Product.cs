﻿namespace WebAppRelation.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
