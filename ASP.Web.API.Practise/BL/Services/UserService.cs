using Domian.Interfaces.Repositories;
using Domian.Interfaces.Services;
using Domian.Models;

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
                throw new ArgumentException("Документ не существует");
            }

            if (!_userRepository.DoesUserExists(userId))
            {
                throw new ArgumentNullException("User не существует");
            }

            var document = _documentRepository.GetDocument(documentId);
            document.UserId = userId;
            _userRepository.AddDocumentToUser(userId, document);
            _documentRepository.UpdateDocument(document);
        }

        public User GetUser(Guid userId)
        {
            return _userRepository.GetUser(userId);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}
