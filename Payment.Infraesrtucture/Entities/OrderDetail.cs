using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Infraesrtucture.Entities.Base;

namespace Payment.Infraesrtucture.Entities
{
    public class OrderDetail : EntityBase<int>
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}