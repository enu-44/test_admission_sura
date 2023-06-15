namespace Payment.Domain.Models
{
    public class CreateShipmentOrderDTO
    {
        public int OrderId { get; set; }
        public string ShippingAddress { get; set; }
    }
}