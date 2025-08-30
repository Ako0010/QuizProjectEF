

namespace AdminPanel.Models;

public class Question
{
    public int QuestionId { get; set; }

    public string Text { get; set; }
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public List<Answer> Answers { get; set; }
}
