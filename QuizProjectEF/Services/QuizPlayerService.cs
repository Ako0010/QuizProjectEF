using Microsoft.EntityFrameworkCore;
using QuizProject.Models;
using QuizProject.Services.Interface;
using QuizProjectEF.DBEntity;


namespace QuizProject.Services;


public class QuizPlayerService : IQuizPlayerService
{
    private QuizDBContext _context;
    private IScoreService _scoreService;

    public QuizPlayerService(QuizDBContext context,IScoreService scoreService)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        _context = context;
        _scoreService = scoreService;
    }

    public List<string> GetCategories()
    {
        return _context.Quizzes.Select(q => q.Category).ToList();
    }

    public int PlayQuizAndReturnScore(string category)
    {
        var quizzesInCategory = _context.Quizzes
            .Where(q => q.Category.ToLower() == category.ToLower())
            .Select(q => new
            {
                q.QuizId,
                q.Category,
                Questions = q.Questions.ToList()
            })
            .ToList();

        if (!quizzesInCategory.Any())
        {
            Console.WriteLine($"\n'{category}' kateqoriyasında quiz tapılmadı.");
            return 0;
        }

        var selectedQuiz = _context.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Answers).ToList()
            .FirstOrDefault(q => q.Category.ToLower() == category.ToLower());

        if (selectedQuiz == null)
        {
            Console.WriteLine($"\n'{category}' kateqoriyasında quiz tapılmadı.");
            return 0;
        }

        var questions = selectedQuiz.Questions.ToList();

        var random = new Random();
        questions = questions.OrderBy(q => random.Next()).ToList();

        int totalQuestions = questions.Count >= 20 ? 20 : questions.Count;

        int correctAnswers = PlayQuizFromQuestions(questions, totalQuestions, category);

        var currentUser = _context.Users.FirstOrDefault();

        if (currentUser == null)
        {
            Console.WriteLine("İstifadəçi tapılmadı. Score əlavə olunmadı.");
            return correctAnswers;
        }

        var existingScore = _context.UserScores
            .FirstOrDefault(us => us.UserId == currentUser.Id && us.QuizId == selectedQuiz.QuizId);

        if (existingScore != null)
        {
            existingScore.Score = correctAnswers;
            _context.UserScores.Update(existingScore);
        }
        else
        {
            var score = new UserScore
            {
                UserName = currentUser.UserName,
                UserId = currentUser.Id,
                QuizId = selectedQuiz.QuizId,
                Score = correctAnswers,
                Date = DateTime.Now,
                Category = category
            };
           _context.UserScores.Add(score);
        }
        try
        {
        _context.SaveChanges();
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Xəta baş verdi: {ex.Message}");

        }


        return correctAnswers;
    }


    public int PlayMixedQuiz(int totalQuestions)
    {
        var allQuestions = _context.Questions
            .Include(q => q.Answers)
            .ToList();

        if (!allQuestions.Any())
        {
            Console.WriteLine("Quiz sualları tapılmadı.");
            return 0;
        }

        var random = new Random();
        allQuestions = allQuestions.OrderBy(q => random.Next()).ToList();

        int maxQuestions = allQuestions.Count >= totalQuestions ? totalQuestions : allQuestions.Count;



        return PlayQuizFromQuestions(allQuestions, maxQuestions, "Qarışıq");
    }

    private int PlayQuizFromQuestions(List<Question> questions, int totalQuestions, string categoryName)
    {
        Console.WriteLine($"\n--- {categoryName} üzrə {totalQuestions} sual ---");

        int correctAnswers = 0;

        var wrongAnswers = new List<(string questionText, List<string> userAnswers, List<string> correctAnswers)>();

        for (int questionIndex = 0; questionIndex < totalQuestions; questionIndex++)
        {
            var q = questions[questionIndex];
            var variants = q.Answers.ToList();
            var random = new Random();
            variants = variants.OrderBy(v => random.Next()).ToList();

            Console.WriteLine($"\nSual {questionIndex + 1}: {q.Text}");

            for (int i = 0; i < variants.Count; i++)
                Console.WriteLine($"   {(char) ('A' + i)}) {variants[i].Text}");

            Console.Write("Cavabların nömrəsini ver vergüllə ayır: ");
            var input = Console.ReadLine();

            var selectedIndexes = input == null ? new List<int>() :
                input.Split(',')
                     .Where(s => !string.IsNullOrEmpty(s))
                     .Select(s => char.ToUpper(s.Trim()[0]) - 'A')
                     .Where(idx => idx >= 0 && idx < variants.Count)
                     .ToList();

            var correctAnswerIndexes = variants
                .Select((a, index) => new { a.IsCorrect, index })
                .Where(x => x.IsCorrect)
                .Select(x => x.index)
                .ToList();

            bool isCorrect = selectedIndexes.Count == correctAnswerIndexes.Count &&
                             selectedIndexes.All(idx => correctAnswerIndexes.Contains(idx));

            if (isCorrect)
            {
                correctAnswers++;
            }
            else
            {
                var userAnswers = selectedIndexes.Select(i => variants[i].Text).ToList();
                var corrects = correctAnswerIndexes.Select(i => variants[i].Text).ToList();
                wrongAnswers.Add((q.Text, userAnswers, corrects));
            }
        }

        Console.WriteLine("\n--- Nəticə ---");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Düzgün: {correctAnswers} / {totalQuestions}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Səhv: {totalQuestions - correctAnswers} / {totalQuestions}");
        Console.ResetColor();


        if (wrongAnswers.Any())
        {
            Console.WriteLine("\nSəhv cavab verdiyin suallar:");
            int num = 1;
            foreach (var item in wrongAnswers)
            {
                Console.WriteLine($"\n{num++}) {item.questionText}");
                Console.WriteLine($" Sənin cavabın: {string.Join(", ", item.userAnswers)}");
                Console.WriteLine($" Düzgün cavab:  {string.Join(", ", item.correctAnswers)}");
            }
            Console.WriteLine("Çıxmaq üçün hər hansı bir düyməyə bas...");
            Console.ReadKey();
            Console.Clear();
        }


        return correctAnswers;
    }

}

