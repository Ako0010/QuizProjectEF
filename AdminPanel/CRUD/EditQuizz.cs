using AdminPanel.Models;
using AdminPanel.Database;
using Microsoft.EntityFrameworkCore;
using AdminPanel.CRUD;

static class EditQuizz
{
    public static void EditQuiz(QuizDBContext context)
    {
        Console.Clear();
        Console.Write("Redaktə etmək istədiyiniz Quiz ID-ni daxil edin: ");
        if (!int.TryParse(Console.ReadLine(), out int quizId))
        {
            Console.WriteLine("Yanlış ID. Davam etmək üçün Enter basın...");
            Console.ReadLine();
            return;
        }

        var quiz = context.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Answers)
            .FirstOrDefault(q => q.QuizId == quizId);

        if (quiz == null)
        {
            Console.WriteLine("Belə ID-li quiz tapılmadı. Davam etmək üçün Enter basın...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Cari Kateqoriya: {quiz.Category}");
        Console.Write("Yeni kateqoriya daxil edin (dəyişdirmək istəmirsinizsə boş buraxın): ");
        var newCategory = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newCategory))
            quiz.Category = newCategory;

        bool editingQuestions = true;
        while (editingQuestions)
        {
            Console.Clear();
            Console.WriteLine($"Quiz ID: {quiz.QuizId} | Kateqoriya: {quiz.Category}");
            Console.WriteLine("Suallar:");
            foreach (var q in quiz.Questions)
            {
                Console.WriteLine($"  {q.QuizId}. {q.Text}");
            }

            Console.WriteLine("\nSeçimlər:");
            Console.WriteLine("1. Sual əlavə et");
            Console.WriteLine("2. Sual redaktə et");
            Console.WriteLine("3. Sualı Silmek");
            Console.WriteLine("4. çıx");
            Console.Write("Seçiminiz: ");
            var sel = Console.ReadLine();

            switch (sel)
            {
                case "1":
                    AddQuestion(context, quiz);
                    break;
                case "2":
                    EditExistingQuestion(context, quiz);
                    break;
                case "3":
                    DeleteQuestion(context, quiz);
                    break;
                case "4":
                    editingQuestions = false;
                    break;
                default:
                    Console.WriteLine("Yanlış seçim. Davam etmək üçün Enter basın...");
                    Console.ReadLine();
                    break;
            }
        }

        context.SaveChanges();
        Console.WriteLine("Dəyişikliklər yadda saxlanıldı. Davam etmək üçün Enter basın...");
        Console.ReadLine();
    }

    private static void AddQuestion(QuizDBContext context, Quiz quiz)
    {
        Console.Clear();
        Console.WriteLine("Yeni sual əlavə et:");

        Console.Write("Sual mətni: ");
        var text = Console.ReadLine();

        if (text.Length < 6)
        {
            Console.WriteLine("Sual mətni ən azı 6 simvol uzunluğunda olmalıdır!");
            Console.ReadLine();
            return;
        }

        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Sual mətni boş ola bilməz!");
            Console.ReadLine();
            return;
        }

        var question = new Question
        {
            Text = text,
            QuizId = quiz.QuizId
        };

        question.Answers = new List<Answer>();

        Console.WriteLine("Variantları daxil edin (bitirmək üçün boş buraxın):");
        while (true)
        {
            Console.Write("Variant: ");
            var variant = Console.ReadLine();

            if (variant.Length < 6)
            {
                Console.WriteLine("Variant ən azı 6 simvol uzunluğunda olmalıdır!");
                continue;
            }

            if (string.IsNullOrEmpty(variant)) break;
            question.Answers.Add(new Answer { Text = variant, IsCorrect = false });
        }

        if (question.Answers.Count < 3)
        {
            Console.WriteLine("Ən azı 3 variant daxil edilməlidir!");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Düzgün cavabların nömrələrini daxil edin (bitirmək üçün boş buraxın):");
        while (true)
        {
            Console.Write("Düzgün cavab nömrəsi: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;

            if (int.TryParse(input, out int index) && index >= 1 && index <= question.Answers.Count)
            {
                question.Answers[index - 1].IsCorrect = true;
            }
            else
            {
                Console.WriteLine("Düzgün nömrə daxil edin.");
            }
        }

        if (!question.Answers.Any(a => a.IsCorrect))
        {
            Console.WriteLine("Ən azı bir düzgün cavab daxil edilməlidir!");
            Console.ReadLine();
            return;
        }

        quiz.Questions.Add(question);
        context.Questions.Add(question);
        context.SaveChanges();

        Console.WriteLine("Sual əlavə edildi. Davam etmək üçün Enter basın...");
        Console.ReadLine();
    }

    private static void EditExistingQuestion(QuizDBContext context, Quiz quiz)
    {
        Console.Write("Redaktə etmək istədiyiniz sual nömrəsini daxil edin: ");
        if (!int.TryParse(Console.ReadLine(), out int qId))
        {
            Console.WriteLine("Yanlış nömrə!");
            Console.ReadLine();
            return;
        }

        var question = quiz.Questions.FirstOrDefault(q => q.QuizId == qId);
        if (question == null)
        {
            Console.WriteLine("Belə sual yoxdur!");
            Console.ReadLine();
            return;
        }

        Console.WriteLine($"Cari sual mətni: {question.Text}");
        Console.Write("Yeni sual mətni (dəyişdirmək istəmirsinizsə boş buraxın): ");
        var newText = Console.ReadLine();

        if (newText.Length < 6 && !string.IsNullOrEmpty(newText))
        {
            Console.WriteLine("Sual mətni ən azı 6 simvol uzunluğunda olmalıdır!");
            Console.ReadLine();
            return;
        }

        if (!string.IsNullOrEmpty(newText))
            question.Text = newText;

        Console.WriteLine("Hazırki variantlar:");
        for (int i = 0; i < question.Answers.Count; i++)
        {
            var ans = question.Answers[i];
            Console.WriteLine($"{i + 1}. {ans.Text} - {(ans.IsCorrect ? "Düzgün" : "Yanlış")}");
        }

        Console.WriteLine("Yeni variantları daxil edin (bitirmək üçün boş buraxın):");
        var newAnswers = new List<Answer>();
        while (true)
        {
            Console.Write("Variant: ");
            var variant = Console.ReadLine();

            if (variant.Length < 6)
            {
                Console.WriteLine("Variant ən azı 6 simvol uzunluğunda olmalıdır!");
                continue;
            }

            if (string.IsNullOrEmpty(variant)) break;
            newAnswers.Add(new Answer { Text = variant, IsCorrect = false, QuestionId = question.QuizId });
        }

        if (newAnswers.Count > 0)
        {
            context.Answers.RemoveRange(question.Answers);
            question.Answers = newAnswers;
            foreach (var a in newAnswers)
            {
                context.Answers.Add(a);
            }
        }

        Console.WriteLine("Düzgün cavabların nömrələrini daxil edin (bitirmək üçün boş buraxın):");
        foreach (var ans in question.Answers)
            ans.IsCorrect = false;

        while (true)
        {
            Console.Write("Düzgün cavab nömrəsi: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;

            if (int.TryParse(input, out int idx) && idx >= 1 && idx <= question.Answers.Count)
            {
                question.Answers[idx - 1].IsCorrect = true;
            }
            else
            {
                Console.WriteLine("Düzgün nömrə daxil edin.");
            }
        }

        context.SaveChanges();
        Console.WriteLine("Sual redaktə edildi. Davam etmək üçün Enter basın...");
        Console.ReadLine();

    }
    private static void DeleteQuestion(QuizDBContext context, Quiz quiz)
    {
        Console.Write("Silmək istədiyiniz sual nömrəsini daxil edin: ");
        if (!int.TryParse(Console.ReadLine(), out int qId))
        {
            Console.WriteLine("Yanlış nömrə!");
            Console.ReadLine();
            return;
        }

        var question = quiz.Questions.FirstOrDefault(q => q.QuestionId == qId);
        if (question == null)
        {
            Console.WriteLine("Belə sual yoxdur!");
            Console.ReadLine();
            return;
        }

        context.Answers.RemoveRange(question.Answers);
        context.Questions.Remove(question);
        context.SaveChanges();

        quiz.Questions.Remove(question);

        Console.WriteLine("Sual silindi. Davam etmək üçün Enter basın...");
        Console.ReadLine();
    }
}
