using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class InvoiceDto:BaseDto
    {
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
