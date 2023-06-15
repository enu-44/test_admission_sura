using System.Collections.Generic;

namespace Payment.Domain.Models.request
{
    public class OrderRequestDTO
    {
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
        public List<CreateOrderDetailDTO> Detail { get; set; }
    }
}