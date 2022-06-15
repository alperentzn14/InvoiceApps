namespace CoreLayer.Models
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
