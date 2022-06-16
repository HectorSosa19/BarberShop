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
    public class AppointmentValidation : BaseValidator<AppointmentDto>
    {
        public AppointmentValidation()
        {
            RuleFor(x=> x.DateHour).NotEmpty().NotNull();
            RuleFor(x => x.IsCancelled).NotNull().NotEmpty();
        }
    }
}
