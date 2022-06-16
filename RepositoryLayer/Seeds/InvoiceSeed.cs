using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Seeds
{
    internal class InvoiceSeed : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {


            builder.HasData(
                new Invoice
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    Quantity = 2,
                    Total=200
                },
                new Invoice
                {
                    Id = 2,
                    CustomerId = 2,
                    ProductId = 2,
                    Quantity = 2,
                    Total = 400
                },
                   new Invoice
                   {
                       Id = 3,
                       CustomerId = 3,
                       ProductId = 3,
                       Quantity = 3,
                       Total = 900
                   });
        }
    }
}
