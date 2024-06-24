using Common.Responses.UserResponses;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        GetUserResponse GetUser(Guid userId);
        IEnumerable<GetUserResponse> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void AddDocumentToUser(Guid userId, Document document);
        bool DoesUserExists(Guid userId);
        bool DoesUserExistsWithThisEmail(string email);
    }
}
