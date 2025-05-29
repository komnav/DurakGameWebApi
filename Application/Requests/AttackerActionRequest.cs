using Domain.Entities;
using DurakGame.Requests;

namespace Application.Requests;

public class AttackerActionRequest
{
    public List<Card> Cards { get; set; }

    public AttackerActionType Action { get; set; }
}