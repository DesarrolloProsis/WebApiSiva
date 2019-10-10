using System.Threading.Tasks;
using WebApiSiva.Models;

namespace WebApiSiva.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password); 
         Task<User> Login(string username, string pasword);
         Task<bool> UserExists(string username);
    }
}