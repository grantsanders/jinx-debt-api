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
        
        app.MapGet("/GetDebt/{debtId}", async Task<Debt> (int player1DebtId, int player2DebtId, [FromServices] DebtRepository debtRepository) =>
            {
                return await debtRepository.GetCurrentDebt(player1DebtId, player2DebtId);
            })
            .WithName("GetDebtBetweenUsers")    
            .WithOpenApi();
        
        app.MapPost("/CreateDebt", async Task<Debt> ([FromBody] Debt newDebt, [FromServices] DebtRepository debtRepository) =>
            {
                return await debtRepository.CreateNewDebt(newDebt);
            })
            .WithName("CreateDebt")    
            .WithOpenApi();


        
        
        
    }
}