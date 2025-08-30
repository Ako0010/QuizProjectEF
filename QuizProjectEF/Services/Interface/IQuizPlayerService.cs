
namespace QuizProject.Services.Interface;


public interface IQuizPlayerService
{
    List<string> GetCategories();
    int PlayQuizAndReturnScore(string category);
    int PlayMixedQuiz(int totalQuestions);
}
