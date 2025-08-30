
namespace AdminPanel.Models;



public class Quiz
{
    public int QuizId { get; set; }
    public string Category { get; set; }

    public List<Question> Questions { get; set; }
}