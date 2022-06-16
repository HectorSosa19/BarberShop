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
    public class UserValidationcs : BaseValidator<UserDto>
    {
        public UserValidationcs()
        {
            RuleFor(x => x.Name).NotEmpty().Length(30).NotNull();
            RuleFor(x=> x.LastName).NotEmpty().Length(30).NotNull();
            RuleFor(x => x.Email).NotEmpty().Length(60).NotNull();
            RuleFor(x => x.Username).NotEmpty().NotNull().Length(30);
            RuleFor(x=> x.Password).NotEmpty().Length(16).NotNull();
            RuleFor(x=> x.Phone).NotEmpty().Length(30).NotNull();
            RuleFor(x=> x.Gender).NotNull().NotEmpty();
        }
    }
}
