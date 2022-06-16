using AutoMapper;
using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Model.Repositories;
using NotasWorkshop.Model.UnitOfWorks;
using NotasWorkshop.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public class UserService : EntityCRUDService<User,UserDto>,IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUnitOfWork<INotasWorkshopDbContext> uow, IUserRepository userRepository)
            : base(mapper, uow)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            _userRepository.CreateUser(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
            return user;
        }
        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            return users;
        }
    }
}
