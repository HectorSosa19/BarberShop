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
    public class BarberProfileValidation : BaseValidator<BarberProfileDto>
    {
        public BarberProfileValidation()
        {
            RuleFor(x => x.Experience).NotEmpty().NotNull();
            RuleFor(x => x.IsAvailable).NotEmpty().NotNull();
            RuleFor(x => x.SeatNum).NotEmpty().NotNull();
        }
    }
}
