using GrpcHighscoreService.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcHighscoreService.Data
{
    public class DataManager
    {
        private readonly HighscoreContext _highscoreContext;
        public DataManager(HighscoreContext highscoreContext)
        {
            _highscoreContext = highscoreContext;
        }

        public bool AnyScoresInDatabase()
        {
            return _highscoreContext.Scores.Any();
        }

        public async Task<int> CreateScoreAsync(Score score)
        {
            _highscoreContext.Scores.Add(score);
            await _highscoreContext.SaveChangesAsync();
            return score.Id;
        }

        public async Task<List<Score>> GetAllScoresAsync()
        {
            return await _highscoreContext.Scores
                .OrderByDescending(score => score.Points).ToListAsync();
        }

        public async Task<List<Score>> GetTopScoresAsync(int count)
        {
            return await _highscoreContext.Scores
                .OrderByDescending(score => score.Points).Take(count).ToListAsync();
        }

        public async Task<List<Score>> GetScoresByPlayerAsync(string playerName)
        {
            return await _highscoreContext.Scores
                .Where(score => score.PlayerName == playerName)
                .OrderByDescending(score => score.Points)
                .ToListAsync();
        }

        public async Task<Score> GetScoreByIdAsync(int id)
        {
            return await _highscoreContext.Scores
                .SingleAsync(score => score.Id == id);
        }

        public async Task RemoveAllScoresAsync()
        {
            _highscoreContext.Scores.RemoveRange(_highscoreContext.Scores);
            await _highscoreContext.SaveChangesAsync();
        }

    }
}
