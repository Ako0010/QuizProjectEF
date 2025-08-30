

namespace QuizProject.Models;

public class UserScore
{
    public int Id { get; set; }
    public int Score { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } 
    public string UserName { get; set; }

    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }

    public string Category { get; set; }
    public DateTime Date { get; set; }
}
