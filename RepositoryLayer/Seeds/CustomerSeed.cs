using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Seeds
{
    internal class CustomerSeed:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {


            builder.HasData(
                new Customer { Id = 1, Name = "Alperen",Adress="İstanbul",PhoneNumber="5456030503",Surname="Tüzün"
                },
                new Customer { Id = 2, Name = "test", Adress = "Adana", PhoneNumber = "545603033", Surname = "testt" 
                },
                   new Customer { Id = 3, Name = "test2", Adress = "Bursa", PhoneNumber = "545603222", Surname = "test22" 
                   });
        }
    }
}
