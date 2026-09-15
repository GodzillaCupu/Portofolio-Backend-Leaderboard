using System.ComponentModel.DataAnnotations;

namespace Leaderboard.Api.Models;

public class Player
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(32)]
    public string Username { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<ScoreEntry> Scores { get; set; } = new();
}