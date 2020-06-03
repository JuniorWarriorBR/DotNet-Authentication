using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using jobRegister.Models.UserModel;


namespace jobRegister.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            user.Id = Guid.NewGuid();
            user.Password = ComputeSha256Hash(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Read(string email, string password)
        {
            return _context.Users.SingleOrDefault(
                usuario => usuario.Email == email && usuario.Password == ComputeSha256Hash(password)
            );

            // var result = _context.Users
            //     .Where(u => u.Email == email && u.Password == ComputeSha256Hash(password))
            //     .Select(u => new { u.Id, u.Email, u.Role })
            //     .FirstOrDefault();
            // return result;
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
