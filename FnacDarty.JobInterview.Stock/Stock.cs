namespace FnacDarty.JobInterview.Stock
{
    public class Stock : IEntity //BaseEntity
    {
        //public Stock()
        //{

        //}

        //public Stock(int productId, int quantity)
        //{
        //    Id = productId;
        //    Quantity = quantity;
        //}

        public int Id { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        
    }
}
