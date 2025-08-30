namespace QuizProject.Models;

public class Answer
{
    public int AnswerId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
