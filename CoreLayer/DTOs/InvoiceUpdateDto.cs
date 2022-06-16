using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class InvoiceUpdateDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
