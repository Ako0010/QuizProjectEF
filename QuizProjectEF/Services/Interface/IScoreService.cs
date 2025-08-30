
using QuizProject.Models;

namespace QuizProject.Services.Interface;

public interface IScoreService
{
    void SaveScore(UserScore score);
    List<UserScore> GetUserScores(string username);
    List<UserScore> GetTopScores(string category, int count);
}
