﻿using System.ComponentModel.DataAnnotations;

namespace TestRestautantProductOnly.Model.Shipments
{
    public class ShippingAddress
    {
        [Key]
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
