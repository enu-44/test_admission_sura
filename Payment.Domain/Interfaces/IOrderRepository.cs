using System;
using System.Threading.Tasks;
using Payment.Core.Utils;
using Payment.Domain.Models;

namespace Payment.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Result<int, Exception>> save(CreateOrderDTO order);
    }
}