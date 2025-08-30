

using Microsoft.EntityFrameworkCore;
using QuizProject.Models;
using QuizProject.Services.Interface;
using QuizProjectEF.DBEntity;

namespace QuizProject.Services;

public class ScoreService : IScoreService
{
    private QuizDBContext _context;

    public ScoreService(QuizDBContext context)
    {
        _context = context;
    }

    public void SaveScore(UserScore newScore)
    {
            var existingScore = _context.UserScores
                .FirstOrDefault(us => us.UserId == newScore.UserId && us.QuizId == newScore.QuizId);

            if (existingScore != null)
            {
                if (existingScore.Score != newScore.Score)
                {
                existingScore.Score = newScore.Score;
                _context.UserScores.Update(existingScore);
                }

            }
            else
            {
                _context.UserScores.Add(newScore);
            }

            _context.SaveChanges();
        }



    public List<UserScore> GetUserScores(string username)
    {
        return _context.UserScores
            .Where(x => x.UserName == username)
            .OrderByDescending(x => x.Date)
            .ToList();
    }

    public List<UserScore> GetTopScores(string category, int count)
    {
        string normalizedCategory = category.Trim().ToLower();

        var grouped = _context.UserScores
                           .Where(x => x.Category.Trim().ToLower() == normalizedCategory && x.Score > 0)
                           .GroupBy(x => x.UserName.Trim().ToLower())
                           .ToList();

        var groupedScores = grouped.Select(g => new UserScore
        {
            UserName = g.First().UserName,
            Category = category,
            Score = g.Sum(x => x.Score),
            Date = g.Max(x => x.Date)
        })
        .OrderByDescending(x => x.Score)
        .ThenBy(x => x.Date)
        .Take(count)
        .ToList();

        return groupedScores;
    }



}

