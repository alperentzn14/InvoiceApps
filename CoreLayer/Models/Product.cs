namespace CoreLayer.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

    }
}
