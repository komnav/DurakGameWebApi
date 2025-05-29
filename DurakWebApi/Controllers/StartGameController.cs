using System.Security.Cryptography;
using DurakWebApi.Entities;
using DurakWebApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace DurakWebApi.Controllers;

[ApiController]
[Route("api/startGame")]
public class StartGameController(IGameService gameService) : ControllerBase
{
    private readonly IGameService _gameService = gameService;
    private readonly Player _player1 = new Player { Name = "Player 1", };
    private readonly Player _player2 = new Player { Name = "Player 1", };

    [HttpPost("startGame")]
    public IActionResult StartGame()
    {
        _gameService.Start(_player1, _player2);
        return Ok();
    }
}