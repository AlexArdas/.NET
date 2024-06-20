using Domian.Models;

namespace Domian.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
        List<User> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void AddDocumentToUser(Guid userId, Document document);
        bool DoesUserExists(Guid userId);
    }
}
