
using AdminPanel.Models;
using AdminPanel.Database;
using Microsoft.EntityFrameworkCore;


namespace AdminPanel.Services
{
class QuizService
    {
        private QuizDBContext _context;

        public QuizService(QuizDBContext context)
        {
            _context = context;
        }

        public List<Quiz> GetAllQuizzes()
        {
            var quizzes = _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .ToList();

            return quizzes;
        }



        public void AddOrUpdateQuiz(Quiz quiz)
        {
            var existing = _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefault(q => q.QuizId == quiz.QuizId);

            if (existing != null)
            {
                existing.Category = quiz.Category;

                _context.Questions.RemoveRange(existing.Questions);
                _context.SaveChanges();

                existing.Questions = quiz.Questions;

                foreach (var question in existing.Questions)
                {
                    question.QuizId = existing.QuizId;
                    _context.Questions.Add(question);

                    foreach (var answer in question.Answers)
                    {
                        answer.QuestionId = question.QuestionId;
                        _context.Answers.Add(answer);
                    }
                }
            }
            else
            {
                _context.Quizzes.Add(quiz);
            }

            _context.SaveChanges();
        }


        public void DeleteQuiz(int quizId)
        {
            var quizzes = GetAllQuizzes();
            var quizToRemove = quizzes.FirstOrDefault(q => q.QuizId == quizId);
            if (quizToRemove != null)
            {
                quizzes.Remove(quizToRemove);
                _context.Quizzes.Remove(quizToRemove);
            }
        }
    }
}
