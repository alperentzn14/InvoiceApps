using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class CustomerWithProductsDto:CustomerDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
