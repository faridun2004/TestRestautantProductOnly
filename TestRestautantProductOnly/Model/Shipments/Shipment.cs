﻿using System.ComponentModel.DataAnnotations;

namespace TestRestautantProductOnly.Model.Shipments
{
    public class Shipment
    {
        [Key]
        public Guid ShipmentId { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public ShippingAddress? ShippingAddress { get; set; }
        public List<ShipmentItem>? Items { get; set; }
        public Status Status { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; } = DateTime.Now;
        public Shipment()
        {
            Items = new List<ShipmentItem>();
        }
    }
}
