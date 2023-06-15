using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.Domain.Application;
using Payment.Domain.Models.request;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentOrderUseCase _paymentOrderUseCase;
        public PaymentController(PaymentOrderUseCase paymentOrderUseCase)
        {
            _paymentOrderUseCase = paymentOrderUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderRequestDTO dto)
        {
            var result = await _paymentOrderUseCase.execute(dto);
            if (result.IsLeft()) return Conflict(result.Error.Message);
            return Ok("payment execute successfully");
        }
    }
}