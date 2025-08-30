

namespace QuizProject.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }

    public List<UserScore> Scores { get; set; }
}
