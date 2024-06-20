using Domian.Entities;

namespace Domian.Interfaces.Services
{
    public interface IUserService
    {
        User GetUser(Guid userId);
        List<User> GetUsers();
        void CreateUser(CreateUserModel user);
        void UpdateUser(User user);
        void AddDocumentToUser(int documentId, Guid userId);
    }
}
