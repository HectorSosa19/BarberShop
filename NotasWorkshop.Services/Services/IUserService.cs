using NotasWorkshop.Model.Entities;
using NotasWorkshop.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public interface IUserService : IEntityCRUDService<User,UserDto>
    {
        List<User> GetAllUsers();
        User CreateUser(User user);
        User DeleteUser(User user);
    }
}
