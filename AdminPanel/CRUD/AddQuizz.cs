
using AdminPanel.Models;
using AdminPanel.Database;

namespace AdminPanel.CRUD;

 static class AddQuizz
{
    public static void AddQuiz(QuizDBContext context)
    {
        Console.Clear();
        Console.WriteLine("Yeni quiz əlavə et:");

        string category;
        do
        {
            Console.Write("Kateqoriya daxil edin: ");
            category = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(category));

        var newQuiz = new Quiz
        {
            Category = category,
            Questions = new List<Question>()
        };

        bool addMoreQuestions = true;
        while (addMoreQuestions)
        {
            var question = CreateQuestionn(context);
            if (question != null)
            {
                newQuiz.Questions.Add(question);
            }

            Console.Write("Daha bir sual əlavə etmək istəyirsiniz? (h/x): ");
            var ans = Console.ReadLine()?.Trim().ToLower();
            addMoreQuestions = ans == "h";
        }

        if (newQuiz.Questions.Count > 0)
        {
            context.Quizzes.Add(newQuiz);
            context.SaveChanges();
            Console.WriteLine("Quiz bazaya əlavə edildi!");
        }
        else
        {
            Console.WriteLine("Heç bir sual əlavə edilmədi. Quiz əlavə olunmadı.");
        }

        Console.WriteLine("Davam etmək üçün Enter basın...");
        Console.ReadLine();
    }


   public static Question CreateQuestionn(QuizDBContext context)
    {
        Console.Clear();
        Console.Write("Sual mətni: ");
        var text = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Sual mətni boş ola bilməz.");
            return null;
        }

        var question = new Question
        {
            Text = text,
            Answers = new List<Answer>()
        };

        int varIndex = 1;
        while (question.Answers.Count < 6)
        {
            Console.Write($"Variant #{varIndex} (boş burax bitirmək üçün): ");
            var variantText = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(variantText))
            {
                if (question.Answers.Count >= 3) break;
                Console.WriteLine("Ən azı 3 variant olmalıdır.");
                continue;
            }

            question.Answers.Add(new Answer
            {
                Text = variantText,
                IsCorrect = false
            });

            varIndex++;
        }

        Console.WriteLine("Düzgün cavabların nömrələrini daxil edin (bitirmək üçün boş buraxın):");
        while (true)
        {
            Console.Write("Nömrə: ");
            var input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input)) break;

            if (int.TryParse(input, out int idx) && idx >= 1 && idx <= question.Answers.Count)
            {
                question.Answers[idx - 1].IsCorrect = true;
            }
            else
            {
                Console.WriteLine("Yanlış nömrə.");
            }
        }

        return question;
    }
}
