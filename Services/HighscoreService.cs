using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Services;
using GrpcHighscoreService.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Grpc.Services.HighscoreService;
using Score = GrpcHighscoreService.Data.Models.Score;
using ScoreResource = Grpc.Services.Score;

namespace GrpcHighscoreService
{
    internal class HighscoreService : HighscoreServiceBase
    {
        private readonly DataManager _dataManager;

        public HighscoreService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public override async Task<CreateScoreResponse> CreateScore(CreateScoreRequest request, ServerCallContext context)
        {
            Score newScore = new Score()
            {
                Points = request.Points,
                PlayerName = request.PlayerName,
                TimeCreated = DateTime.UtcNow
            };

            int scoreId = await _dataManager.CreateScoreAsync(newScore);

            return new CreateScoreResponse() { Id = scoreId };
        }

        public override async Task<ScoreResponse> GetAllScores(Empty request, ServerCallContext context)
        {
            var allScores = ConvertToScoreResponse(await _dataManager.GetAllScoresAsync());
            return allScores;
        }

        public override async Task<ScoreResponse> GetScoresByPlayer(GetScoresByPlayerRequest request, ServerCallContext context)
        {
            var scoresForPlayer = ConvertToScoreResponse(await _dataManager.GetScoresByPlayerAsync(request.PlayerName));
            return scoresForPlayer;
        }

        public override async Task<GetScoreByIdResponse> GetScoreById(GetScoreByIdRequest request, ServerCallContext context)
        {
            var scoreByIdResponse = new GetScoreByIdResponse()
            {
                Score = ConvertToScoreResource(await _dataManager.GetScoreByIdAsync(request.Id))
            };
            return scoreByIdResponse;
        }

        public override async Task<ScoreResponse> GetTopScores(GetTopScoresRequest request, ServerCallContext context)
        {
            var topScores = ConvertToScoreResponse(await _dataManager.GetTopScoresAsync(request.NumberOfScores));
            return topScores;
        }

        public static ScoreResponse ConvertToScoreResponse(IEnumerable<Score> scores)
        {
            var scoreResponse = new ScoreResponse();

            foreach (var score in scores)
            {
                scoreResponse.Scores.Add(ConvertToScoreResource(score));
            }

            return scoreResponse;
        }

        public static ScoreResource ConvertToScoreResource(Score score)
        {
            var scoreResource = new ScoreResource()
            {
                Id = score.Id,
                PlayerName = score.PlayerName,
                Points = score.Points,
                CreateTime = Timestamp.FromDateTime(score.TimeCreated.ToUniversalTime())
            };
            return scoreResource;
        }

    }
}
