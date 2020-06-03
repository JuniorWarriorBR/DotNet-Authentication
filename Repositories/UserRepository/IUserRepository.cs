using jobRegister.Models.UserModel;

namespace jobRegister.Repositories.UserRepository
{
    public interface IUserRepository
    {
        User Read(string email, string password);
        void Create(User usuario);
    }
}
