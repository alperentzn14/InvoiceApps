using CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class InvoiceDetailDto:InvoiceDto
    {
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }
        public virtual List<Invoice> Invoices { get; private set; }
        //public decimal Total { get { return Invoices.Sum(t => t.SubTotal); } }

    }
}
