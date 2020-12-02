using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarparkWhere.Entities;
using CarparkWhere.Helpers;

namespace CarparkWhere.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
    }
    public class UserService : IUserService
    {
        private DataContext context;

        public UserService(DataContext dataContext)
        {
            context = dataContext;
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = context.Users.SingleOrDefault(x => x.Email == email);

            // Check if the user with the specified email address exists
            if (user == null)
            {
                return null;
            }

            // Check if the password provided for the user is correct
            if (!CheckPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("A password is required.");
            }

            if (context.Users.Any(x => x.Email == user.Email))
            {
                throw new Exception("The email address provided is currently used by another user.");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or contains only whitespaces.", "password");
            }

            var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool CheckPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or contains only whitespaces.", "password");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Password hash is of invalid length (expected 64 bytes)", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Password salt is of invalid length (expected 128 bytes)", "passwordSalt");
            }

            var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
