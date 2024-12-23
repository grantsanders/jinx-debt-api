using jinx_debt_api.Data;
using jinx_debt_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace jinx_debt_api.Endpoints;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/GetPlayer/{playerId}", async Task<Player> (int playerId, [FromServices] PlayerRepository playerRepository) =>
            {
                return await playerRepository.GetPlayer(playerId);
            })
            .WithName("GetPlayerByID")    
            .WithOpenApi();
        
        app.MapPost("/CreatePlayer", async Task<Player> ([FromBody] string playerName, [FromServices] PlayerRepository playerRepository) =>
            {
                return await playerRepository.CreatePlayer(playerName);
            })
            .WithName("CreatePlayer")    
            .WithOpenApi();
        
        app.MapGet("/GetGame/{GameId}", async Task<Game> (int player1GameId, int player2GameId, [FromServices] GameRepository GameRepository) =>
            {
                return await GameRepository.GetCurrentGame(player1GameId, player2GameId);
            })
            .WithName("GetGameBetweenUsers")    
            .WithOpenApi();
        
        app.MapPost("/CreateGame", async Task<Game> ([FromBody] Game newGame, [FromServices] GameRepository GameRepository) =>
            {
                return await GameRepository.CreateNewGame(newGame);
            })
            .WithName("CreateGame")    
            .WithOpenApi();

        app.MapPatch("UpdateGame",
            async Task<Game> ([FromBody] Game updatedGame, [FromServices] GameRepository GameRepository) =>
            {
                return await GameRepository.UpdateGame(updatedGame);
            })
                .WithName("UpdateDebt")
                .WithOpenApi();
    }
}
