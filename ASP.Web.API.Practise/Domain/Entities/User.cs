﻿namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Document> Documents { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is User user)
                return Id == user.Id;

            return false;
        }
    }
}
