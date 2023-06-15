using Payment.Infraesrtucture.Entities.Base;

namespace Payment.Infraesrtucture.Entities
{
    public class ShipmentOrder : EntityBase<int>
    {
        public string ShippingAddress { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}