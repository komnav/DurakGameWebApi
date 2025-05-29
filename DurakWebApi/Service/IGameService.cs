using DurakWebApi.Entities;
using DurakWebApi.Requests;

namespace DurakWebApi.Service;

public interface IGameService
{
    void Start(Player player1, Player player2);

    bool IsGameOver();

    void AttackerAction(AttackerActionRequest request);

    void DefenderAction(DefendingActionRequest request);

    string ShowCardsHandPlayers();

    Player Winner();
}