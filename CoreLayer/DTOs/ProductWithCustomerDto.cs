namespace CoreLayer.DTOs
{
    public class ProductWithCustomerDto:ProductDto
    {
        public CustomerDto Customer { get; set; }
    }
}
