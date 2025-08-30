

using System.Security.Cryptography;
using System.Text;

namespace QuizProjectEF.Helper;
class HashPassword
{
    public static string HashPasswordd(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();

            foreach (var b in bytes)
                builder.Append(b.ToString("x2")); 

            return builder.ToString();
        }
    }
}
