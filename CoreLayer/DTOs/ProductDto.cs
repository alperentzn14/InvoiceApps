namespace CoreLayer.DTOs
{
    public class ProductDto:BaseDto
    {
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int CustomerId { get; set; }
    }
}
