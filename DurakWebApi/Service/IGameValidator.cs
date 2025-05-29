using DurakWebApi.Entities;
using DurakWebApi.Requests;

namespace DurakWebApi.Service;
public interface IGameValidator
{
    void ValidateAttackerRequest(AttackerActionRequest request, Game game);

    void ValidateDefenderRequest(DefendingActionRequest request, Game game);
}