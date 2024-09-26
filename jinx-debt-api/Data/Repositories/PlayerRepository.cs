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

    public async Task<Player> GetPlayer(int playerID)
    {
        
            return _context.Players.Where(p => p.ID == playerID).FirstOrDefault();
        
    }
    
}