using System;
using System.Linq;
using System.Threading.Tasks;
using Payment.Core.UseCase;
using Payment.Core.Utils;
using Payment.Domain.Interfaces;
using Payment.Domain.Models;
using Payment.Domain.Models.request;

namespace Payment.Domain.Application
{
    public class PaymentOrderUseCase : Command<Task<Result<OrderRequestDTO, Exception>>, OrderRequestDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShipmentRepository _IShipmentRepository;

        public PaymentOrderUseCase(IOrderRepository orderRepository, IShipmentRepository iShipmentRepository)
        {
            _orderRepository = orderRepository;
            _IShipmentRepository = iShipmentRepository;
        }

        public async override Task<Result<OrderRequestDTO, Exception>> execute(OrderRequestDTO param)
        {
            var resultOrder = await _orderRepository.save(new CreateOrderDTO
            {
                UserId = param.UserId,
                TotalAmmount = param.Detail.Sum(a => a.Price),
                Detail = param.Detail
            });
            if (resultOrder.IsLeft()) return new Left<OrderRequestDTO, Exception>(resultOrder.Error);

            var resultShipment = await _IShipmentRepository.save(new CreateShipmentOrderDTO
            {
                OrderId = resultOrder.Value,
                ShippingAddress = param.ShippingAddress
            });
            return new Right<OrderRequestDTO>(param);
        }

    }
}