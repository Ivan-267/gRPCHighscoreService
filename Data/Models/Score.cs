using System;
using System.ComponentModel.DataAnnotations;

namespace GrpcHighscoreService.Data.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public int Points { get; set; }
        public string PlayerName { get; set; }
        public DateTime TimeCreated { get; set; }

        public Score() { }
        public Score(int points, string playerName, DateTime timeCreated)
        {
            Points = points;
            PlayerName = playerName;
            TimeCreated = timeCreated;
        }

        public override string ToString()
        {
            return $"Id: {Id} Points: {Points} PlayerName: {PlayerName} TimeCreated: {TimeCreated}";
        }
    }
}
