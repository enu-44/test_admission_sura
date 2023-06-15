using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Core.Utils;
using Payment.Domain.Interfaces;
using Payment.Domain.Models;
using Payment.Infraesrtucture.Entities;
using Payment.Infraesrtucture.Persistence;

namespace Payment.Infraesrtucture.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PaymentDbContext _context;
        public OrderRepository(PaymentDbContext context)
        {
            _context = context;
        }
        public async Task<Result<int, Exception>> save(CreateOrderDTO order)
        {
            var entity = new Order
            {
                TotalAmount = order.TotalAmmount,
                UserId = order.UserId,
                OrderDetails = order.Detail.Select(a => new OrderDetail
                {
                    Price = a.Price,
                    ProductId = a.ProductId
                }).ToList()
            };
            try
            {
                _context.Orders.Add(entity);
                await _context.SaveChangesAsync();
                return new Right<int>(entity.Id);
            }
            catch (Exception e)
            {
                return new Left<int, Exception>(e);
            }
        }
    }
}