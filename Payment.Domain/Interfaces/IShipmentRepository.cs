using System;
using System.Threading.Tasks;
using Payment.Core.Utils;
using Payment.Domain.Models;

namespace Payment.Domain.Interfaces
{
    public interface IShipmentRepository
    {
        Task<Result<CreateShipmentOrderDTO, Exception>> save(CreateShipmentOrderDTO shipmentOrder);
    }
}