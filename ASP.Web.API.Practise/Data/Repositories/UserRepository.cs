using Domian.Interfaces.Repositories;
using Domian.Models;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users = new()
        {
            new User { Id = Guid.NewGuid(), Email = "test@mail.ru", Name = "Ivan", Password = "test"},
            new User { Id = Guid.NewGuid(), Email = "test2@mail.ru", Name = "Vova", Password = "test2"},
            new User { Id = Guid.NewGuid(), Email = "test3@mail.ru", Name = "Sasha", Password = "test3"},
            new User { Id = Guid.NewGuid(), Email = "test4@mail.ru", Name = "Dima", Password = "test4"},
        };

        public User GetUser(Guid userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }
        public List<User> GetUsers()
        {
            return Users;
        }

        public void CreateUser(User user)
        {
            Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var userDb = Users.FirstOrDefault(u => u.Id == user.Id);

            if (userDb is not null)
            {
                userDb.Email = user.Email;
                userDb.Name = user.Name;
                userDb.Password = user.Password;
            }

            Users.Remove(user);
            Users.Add(userDb);
        }

        public void AddDocumentToUser(Guid userId, Document document)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);

            user.Documents ??= new List<Document>();
            user.Documents.Add(document);
        }

        public bool DoesUserExists(Guid userId)
        {
            return Users.Any(u=> u.Id == userId);
        }
    }
}
