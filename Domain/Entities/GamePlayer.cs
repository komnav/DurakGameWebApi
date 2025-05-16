namespace Domain.Entities;

public abstract class GamePlayer
{
    public List<Card> Hand { get; set; }

    public Player Player { get; set; }
    
}