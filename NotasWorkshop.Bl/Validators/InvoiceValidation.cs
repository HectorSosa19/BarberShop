using NotasWorkshop.Bl.Validators.Generic;
using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace NotasWorkshop.Bl.Validators
{
    public class InvoiceValidation : BaseValidator<InvoiceDto>
    {
        public InvoiceValidation()
        {
            RuleFor(x=> x.Date).NotEmpty().NotNull();
            RuleFor(x=> x.Total).NotEmpty().NotNull();
            RuleFor(x=> x.Details).NotEmpty().NotNull();
        }
    }
}
