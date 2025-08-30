


namespace QuizProject.Models;



public class Quiz
{
    public int QuizId { get; set; }
    public string Category { get; set; }

    public List<Question> Questions { get; set; }
    public List<UserScore> Scores { get; set; }
}