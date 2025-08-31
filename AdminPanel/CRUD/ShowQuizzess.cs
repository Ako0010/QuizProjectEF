
using AdminPanel.Database;
using Microsoft.EntityFrameworkCore;
namespace AdminPanel.CRUD;


static class ShowQuizzess
{
    public static void ShowQuizzes(QuizDBContext db)
    {
        var quizzes = db.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Answers).ToList();

        if (quizzes.Count == 0)
        {
            Console.WriteLine("Heç bir quiz tapılmadı.");
        }
        else
        {
            foreach (var quiz in quizzes)
            {
                Console.WriteLine($"Quiz ID: {quiz.QuizId}, Kateqoriya: {quiz.Category}");
                foreach (var question in quiz.Questions)
                {
                    Console.WriteLine($"  Sual #{question.QuestionId}: {question.Text}");
                    foreach (var answer in question.Answers)
                    {
                        Console.WriteLine($"    Variant: {answer.Text} Cavabi: {answer.IsCorrect}");
                    }
                }
            }
        }
        Console.WriteLine("Davam etmək üçün Enter basın...");
        Console.ReadLine();
    }
}
