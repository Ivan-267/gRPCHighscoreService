using GrpcHighscoreService.Data.Models;
using System;
using System.Threading.Tasks;

namespace GrpcHighscoreService.Data
{
    public class DemoDataGenerator
    {
        private readonly DataManager _dataManager;
        public DemoDataGenerator(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        /// <summary>
        /// Generates demo scores with randomized values only if there are no scores already in the database.
        /// </summary>
        /// <param name="amount">How many scores to generate.</param>
        /// <param name="maxPoints">The maximum amount of score points for each score.</param>
        public async Task InitializeDemoScoresAsync(int amount, int maxPoints)
        {
            if (!_dataManager.AnyScoresInDatabase())
            {
                await CreateDemoScoresAsync(amount, maxPoints);
            }
        }
        public async Task CreateDemoScoresAsync(int amount, int maxPoints)
        {
            var random = new Random();

            for (int i = 0; i < amount; i++)
            {
                await _dataManager.CreateScoreAsync(new Score()
                {
                    PlayerName = $"Player{random.Next() % 10000}",
                    Points = random.Next() % maxPoints + 1,
                    TimeCreated = DateTime.UtcNow
                });
            }
        }
    }
}
