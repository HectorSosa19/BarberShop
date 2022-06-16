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
    public class TypeHairCutValidation : BaseValidator<TypeHairCutDto>
    {
        public TypeHairCutValidation()
        {
            RuleFor(x=>x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Duration).NotEmpty().NotNull();
            RuleFor(x=> x.Price).NotEmpty().NotNull();
        }
    }
}
