using Domain.Entities.Enum;

namespace Domain.Entities;

public class Card
{
    public byte Id { get; set; }
    public Rank Rank { get; set; }

    public Suit Suit { get; set; }
}