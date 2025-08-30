

using Microsoft.EntityFrameworkCore;
using QuizProject.Models;
using QuizProject.Services.Interface;
using QuizProjectEF.DBEntity;

namespace QuizProject.Services;

public class UserService : IUserService
{
    private QuizDBContext _context;

    public UserService(QuizDBContext context)
    {
        _context = context;
    }


    public User Register(string username, string password, DateTime birthDate)
    {
        if (_context.Users.Any(u => u.UserName == username))
            return null;

        var user = new User
        {
            UserName = username,
            Password = password,
            BirthDate = birthDate
        };

        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }


    public User Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserName == username);

        if (user != null && user.Password == password)
        {
            return user;
        }

        return null;
    }



    public void UpdateUser(User updatedUser)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
        if (existingUser != null)
        {
            existingUser.Password = updatedUser.Password;
            existingUser.BirthDate = updatedUser.BirthDate;
            _context.SaveChanges();
        }
    }

}
