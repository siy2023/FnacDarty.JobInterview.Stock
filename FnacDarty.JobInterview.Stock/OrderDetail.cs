using System;

namespace FnacDarty.JobInterview.Stock
{
    public class OrderDetail : BaseEntity
    {
        public OrderDetail()
        {

        }

        public OrderDetail(Guid productId, decimal price, int quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public Guid ProductId { get; set; }
        public decimal Price { get; set; } = 0;
        public int Quantity { get; set; }
    }
}
