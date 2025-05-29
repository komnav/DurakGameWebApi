using Domain.Entities;
using DurakGame.Requests;

namespace Application.Requests;

public class DefendingActionRequest
{
    public List<Card> Cards { get; set; }

    public DefendingActionType Action { get; set; }
}