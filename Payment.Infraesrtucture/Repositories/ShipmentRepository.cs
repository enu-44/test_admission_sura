using System;
using System.Threading.Tasks;
using Payment.Core.Utils;
using Payment.Domain.Interfaces;
using Payment.Domain.Models;
using Payment.Infraesrtucture.Entities;
using Payment.Infraesrtucture.Persistence;

namespace Payment.Infraesrtucture.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly PaymentDbContext _context;
        public ShipmentRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<Result<CreateShipmentOrderDTO, Exception>> save(CreateShipmentOrderDTO shipmentOrder)
        {
            var entity = new ShipmentOrder
            {
                OrderId = shipmentOrder.OrderId,
                ShippingAddress = shipmentOrder.ShippingAddress
            };
            try
            {
                _context.ShipmentOrders.Add(entity);
                await _context.SaveChangesAsync();
                return new Right<CreateShipmentOrderDTO>(shipmentOrder);
            }
            catch (Exception e)
            {
                return new Left<CreateShipmentOrderDTO, Exception>(e);
            }
        }
    }
}