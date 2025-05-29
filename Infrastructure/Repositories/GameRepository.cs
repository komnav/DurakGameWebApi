using Domain.Entities;
using Domain.Entities.Enum;

namespace Infrastructure.Repositories;

public class GameRepository(Game game, Deck deck) : IGameRepository
{
    private Game _game = game;
    private readonly Random _random = new Random();
    private Deck _deck = deck;

    public void Start(Player player1, Player player2)
    {
        _game = new Game();

        _deck = new Deck();

        _game.Player1 = new GamePlayer { Player = player1, Hand = [] };

        _game.Player2 = new GamePlayer { Player = player2, Hand = [] };

        DistributeCards();

        DefineAttackerAndDefender();

        _game.CurrentAction = GameAction.AttackerAction;
    }

    public Game GetGame()
    {
        return _game;
    }

    public void DistributeCards()
    {
        var deck = _game.Deck.Cards.OrderBy(_ => _random.Next()).ToList();
        for (var i = 0; i < 6; i++)
        {
            var card1 = deck.First();
            _game.Player1.Hand.Add(card1);
            _game.Deck.DeleteCard(card1);
            deck.RemoveAt(0);

            var card2 = deck.First();
            _game.Player2.Hand.Add(card2);
            _game.Deck.DeleteCard(card2);
            deck.RemoveAt(0);
        }
    }
    public void ShowCardsHandPlayers()
    {
        foreach (var cardAttacker in _game.Attacker.Hand)
        {
            Console.WriteLine(
                $"Cards attacker:{cardAttacker.Id} {_game.Attacker.Player.Name} = > {cardAttacker.Rank} ({cardAttacker.Suit})");
        }

        Console.WriteLine("_________________________");
        foreach (var cardDefending in _game.Defender.Hand)
        {
            Console.WriteLine(
                $"Cards defending: {_game.Defender.Player.Name} = > {cardDefending.Rank} ({cardDefending.Suit})");
        }
    }

    public void ExcitementOfTheHandAttacker()
    {
        var deck = _game.Deck.Cards;
        if (deck.Count != 0)
        {
            var countForExcitementOfTheHandAttacker = 6 - _game.Attacker.Hand.Count;
            for (var i = 0; i < countForExcitementOfTheHandAttacker; i++)
            {
                var card1 = deck.First();
                _game.Attacker.Hand.Add(card1);
                _game.Deck.DeleteCard(card1);
            }
        }
    }

    public void ExcitementOfTheHandDefending()
    {
        var deck = _game.Deck.Cards;
        if (deck.Count != 0)
        {
            var countForExcitementOfTheHandAttacker = 6 - _game.Defender.Hand.Count;
            for (var i = 0; i < countForExcitementOfTheHandAttacker; i++)
            {
                var card1 = deck.First();
                _game.Defender.Hand.Add(card1);
                _game.Deck.DeleteCard(card1);
            }
        }
    }

    public Player Winner()
    {
        if (_game.Player1.Hand.Count == 0)
        {
            return _game.Player1.Player;
        }
        else
        {
            return _game.Player2.Player;
        }
    }
}