using System.ComponentModel.DataAnnotations;

namespace TestRestautantProductOnly.Model.Shipments
{
    public class ShipmentItem
    {
        [Key]
        public Guid ItemId { get; set; }
        public string? BookName { get; set; }
        public int Quantity { get; set; }
    }
}
