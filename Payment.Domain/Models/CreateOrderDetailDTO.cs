
namespace Payment.Domain.Models
{
    public class CreateOrderDetailDTO
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}