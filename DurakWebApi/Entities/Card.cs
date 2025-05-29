using DurakWebApi.Entities.Enum;

namespace DurakWebApi.Entities;

public class Card
{
    public byte Id { get; set; }
    public Rank Rank { get; set; }

    public Suit Suit { get; set; }
    
}