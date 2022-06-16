using NotasWorkshop.Model.Entities;

namespace NotasWorkshop.Model.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User CreateUser(User user);
        User DeleteUser(User user);
    }
}