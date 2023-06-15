using System.Collections.Generic;

namespace Payment.Domain.Models
{
    public class CreateOrderDTO
    {
        public int UserId { get; set; }
        public decimal TotalAmmount { get; set; }
        public List<CreateOrderDetailDTO> Detail { get; set; }
    }
}