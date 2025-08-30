using QuizProject.Models;
namespace QuizProject.Services.Interface;


public interface IUserService
{
    User Register(string username, string password, DateTime birthDate);
    User Login(string username, string password);
}

