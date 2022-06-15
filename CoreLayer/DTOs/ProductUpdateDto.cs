namespace CoreLayer.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int CustomerId { get; set; }
    }
}
