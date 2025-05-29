using DurakWebApi.Entities;

namespace DurakWebApi.Requests;

public class AttackerActionRequest
{
    public List<Card> Cards { get; set; }

    public AttackerActionType Action { get; set; }
}