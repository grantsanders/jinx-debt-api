using jinx_debt_api.Data;
using jinx_debt_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace jinx_debt_api.Endpoints;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/GetPlayer", async Task<Player> (int playerId, [FromServices] PlayerRepository playerRepository) =>
            {
                return await playerRepository.GetPlayer(playerId);
            })
            .WithName("SummarizeTicket")    
            .WithOpenApi();

    }
}