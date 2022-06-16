using CoreLayer.DTOs;
using FluentValidation;

namespace ServiceLayer.Validations
{
    public class InvoiceDtoValidator : AbstractValidator<InvoiceDto>
    {
        public InvoiceDtoValidator()
        {

       
            RuleFor(x => x.Quantity).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

        }
    }
}
