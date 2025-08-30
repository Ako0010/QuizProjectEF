using AdminPanel.Database;
using Microsoft.EntityFrameworkCore;
namespace AdminPanel.CRUD;

static class DeleteQuizz
{
    public static void DeleteQuiz(QuizDBContext db)
    {
        Console.Clear();
        Console.Write("Silmək istədiyiniz Quiz ID-ni daxil edin: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Yanlış ID. Davam etmək üçün Enter basın...");
            Console.ReadLine();
            return;
        }

        var quiz = db.Quizzes
                     .Include(q => q.Questions)
                     .ThenInclude(q => q.Answers)
                     .FirstOrDefault(q => q.QuizId == id);

        if (quiz == null)
        {
            Console.WriteLine("Belə ID-li quiz tapılmadı. Davam etmək üçün Enter basın...");
            Console.ReadLine();
            return;
        }

        db.Quizzes.Remove(quiz);
        db.SaveChanges();

        Console.WriteLine("Quiz silindi. Davam etmək üçün Enter basın...");
        Console.ReadLine();
    }
}
