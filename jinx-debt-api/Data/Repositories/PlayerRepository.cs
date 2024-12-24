using jinx_debt_api.Models;
using jinx_debt_api.Data.Contexts;

namespace jinx_debt_api.Data;

public class PlayerRepository
{
    private readonly GameContext _context;
    
    public PlayerRepository(GameContext context)
    {
        _context = context;
    }

    public async Task<Player?> GetPlayer(int playerID) => _context.Players.FirstOrDefault(p => p.ID == playerID);
    public async Task<List<Player>> GetAllPlayers() => _context.Players.ToList();
    
    public async Task<Player> CreatePlayer(string playerName)
    {
        _context.Players.Add(new Player() { Name = playerName });
        await _context.SaveChangesAsync();
        return _context.Players.FirstOrDefault(p => p.Name == playerName);
    }
    
}