using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IGameRepository
{
    void Start(Player player1, Player player2);

    Game GetGame();

    void DistributeCards();
    
    void ShowCardsHandPlayers();
    
    void ExcitementOfTheHandAttacker();

    void ExcitementOfTheHandDefending();

    Player Winner();
}