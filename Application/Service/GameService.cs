using Application.Requests;
using DurakGame.Entities;
using DurakGame.Entities.Enum;
using DurakGame.Requests;

namespace DurakGame.Service;

public class GameService : IGameService
{
    public void AttackerAction(AttackerActionRequest request)
    {
        if (request.Action == AttackerActionType.Beat)
        {
            _game.Beat = _game.FieldCards;
            _game.FieldCards.Clear();

            (_game.Defender, _game.Attacker) = (_game.Attacker, _game.Defender);

            ExcitementOfTheHandAttacker();
            ExcitementOfTheHandDefending();
            _game.CurrentAction = GameAction.AttackerAction;
            return;
        }

        _gameValidator.ValidateAttackerRequest(request, _game);
        var cardsAttackerRequest = request.Cards;
        _game.FieldCards.AddRange(cardsAttackerRequest);

        foreach (var requestCard in cardsAttackerRequest)
        {
            _game.Attacker.Hand.RemoveAll(
                x => x.Suit == requestCard.Suit
                     && x.Rank == requestCard.Rank);
        }

        _game.CurrentAction = GameAction.DefendAction;
    }

    public void DefenderAction(DefendingActionRequest request)
    {
        _gameValidator.ValidateDefenderRequest(request, _game);

        if (request.Action == DefendingActionType.Defend)
        {
            var cardsDefendingRequest = request.Cards;
            _game.FieldCards.AddRange(cardsDefendingRequest);
            foreach (var requestCard in cardsDefendingRequest)
            {
                _game.Defender.Hand
                    .RemoveAll(x => x.Suit == requestCard.Suit && x.Rank == requestCard.Rank);
            }

            _game.CurrentAction = GameAction.AttackerAction;
        }

        if (request.Action == DefendingActionType.Take)
        {
            _game.Defender.Hand.AddRange(_game.FieldCards);
            _game.FieldCards.Clear();

            ExcitementOfTheHandAttacker();
            _game.CurrentAction = GameAction.AttackerAction;
        }
    }
}