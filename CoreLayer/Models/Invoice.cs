namespace CoreLayer.Models
{
    public class Invoice:BaseEntity
    {
        public int Quantity { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public   Customer? Customer { get; set; }
        public  Product? Product { get; set; }

        public decimal Total { get; set; }
         //public decimal SubTotal { get { return Product.Price * Quantity; } }

    }
}
