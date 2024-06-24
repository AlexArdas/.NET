using Common.Requests.UserRquests;
using Common.Responses.UserResponses;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        GetUserResponse GetUser(Guid userId);
        IEnumerable<GetUserResponse> GetUsers();
        void CreateUser(CreateUserRequest createUserRequest);
        void UpdateUser(UpdateUserRequest updateUserRequest);
        void AddDocumentToUser(int documentId, Guid userId);
    }
}
