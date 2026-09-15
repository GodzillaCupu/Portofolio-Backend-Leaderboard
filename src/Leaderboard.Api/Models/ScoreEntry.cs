namespace Leaderboard.Api.Models;

public class ScoreEntry
{
    public long Id { get; set; }

    public Guid PlayerId { get; set; }
    public Player Player { get; set; } = null!;

    public long Score { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}