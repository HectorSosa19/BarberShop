using NotasWorkshop.Core.BaseModel.BaseEntity;
using NotasWorkshop.Core.BaseModel.BaseEntityDto;
using NotasWorkshop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Entities
{ 
    public class UserDto : BaseEntityDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Phone { get; set; } = string.Empty;
        public char Gender { get; set; } 
        public UserRoles UserRoles { get; set; }
    }
}
