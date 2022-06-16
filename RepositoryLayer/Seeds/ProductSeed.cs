using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CustomerId = 1,
                Name = "product 1",
                Price = 100


            },
            new Product
            {
                Id = 2,
                CustomerId = 2,
                Name = "prodcut 2",
                Price = 200


            },
             new Product
             {
                 Id = 3,
                 CustomerId = 3,
                 Name = "prodcut 3",
                 Price = 300


             });

        }
    }
}
