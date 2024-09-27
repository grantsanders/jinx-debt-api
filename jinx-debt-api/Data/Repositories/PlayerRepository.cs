using jinx_debt_api.Data.Contexts;
using jinx_debt_api.Models;

namespace jinx_debt_api.Data;

public class PlayerRepository
{
    private readonly DebtContext _context;
    
    public PlayerRepository(DebtContext context)
    {
        _context = context;
    }

    public async Task<Player?> GetPlayer(int playerID) => _context.Players.FirstOrDefault(p => p.ID == playerID);
    
    public async Task<Player> CreatePlayer(string playerName)
    {
        _context.Players.Add(new Player() { Name = playerName });
        await _context.SaveChangesAsync();
        return _context.Players.FirstOrDefault(p => p.Name == playerName);
    }
    
}