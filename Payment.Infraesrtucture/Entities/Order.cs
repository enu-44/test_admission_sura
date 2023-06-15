using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Infraesrtucture.Entities.Base;

namespace Payment.Infraesrtucture.Entities
{
    public class Order : EntityBase<int>
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ShipmentOrder> ShipmentOrders { get; set; }


    }
}