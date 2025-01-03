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
        
        app.MapGet("/GetAllPlayers", async Task<List<Player>> ([FromServices] PlayerRepository playerRepository) =>
            {
                return await playerRepository.GetAllPlayers();
            })
            .WithName("GetAllPlayers")    
            .WithOpenApi();
        
        app.MapPost("/CreatePlayer", async Task<Player> ([FromBody] string playerName, [FromServices] PlayerRepository playerRepository) =>
            {
                return await playerRepository.CreatePlayer(playerName);
            })
            .WithName("CreatePlayer")    
            .WithOpenApi();
        
        
        app.MapGet("/GetGame/{player1GameId}/{player2GameId}", async (int player1GameId, int player2GameId, [FromServices] GameRepository gameRepository) => 
            {
                return await gameRepository.GetCurrentGame(player1GameId, player2GameId);
            })
            .WithName("GetGameBetweenUsers")    
            .WithOpenApi();
        
        app.MapGet("/GetAllGames", async Task<List<Game>> ([FromServices] GameRepository GameRepository) =>
            {
                return await GameRepository.GetAllGames();
            })
            .WithName("GetAllGames")    
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
