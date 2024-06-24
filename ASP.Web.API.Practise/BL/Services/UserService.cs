using Common.Helpers;
using Common.Requests.UserRquests;
using Common.Responses.UserResponses;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace BL.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IDocumentRepository _documentRepository;

        public UserService(IUserRepository userRepository, IDocumentRepository documentRepository)
        {
            _userRepository = userRepository;
            _documentRepository = documentRepository;
        }

        public void AddDocumentToUser(int documentId, Guid userId)
        {
            if (!_documentRepository.DoesDocumentExists(documentId))
            {
                throw new NotFoundException("Документ не существует");
            }

            if (!_userRepository.DoesUserExists(userId))
            {
                throw new NotFoundException("Пользователь не существует");
            }

            var document = _documentRepository.GetDocument(documentId);
            document.UserId = userId;
            _userRepository.AddDocumentToUser(userId, document);
            _documentRepository.UpdateDocument(document);
        }

        public GetUserResponse GetUser(Guid userId)
        {
            return _userRepository.GetUser(userId);
        }

        public IEnumerable<GetUserResponse> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void CreateUser(CreateUserRequest createUserRequest)
        {
            if (!ValidationHelper.IsValidEmail(createUserRequest.Email))
            {
                throw new BadRequestException("Невалидный email");
            }

            if (_userRepository.DoesUserExistsWithThisEmail(createUserRequest.Email))
            {
                throw new BadRequestException("Пользователь с таким email уже существует");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
                Password = createUserRequest.Password,
            };

            _userRepository.CreateUser(user);
        }

        public void UpdateUser(UpdateUserRequest updateUserRequest)
        {
            var user = new User
            {
                Id = updateUserRequest.Id,
                Name = updateUserRequest.Name,
                Email = updateUserRequest.Email,
            };
            _userRepository.UpdateUser(user);
        }
    }
}
