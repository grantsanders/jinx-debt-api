using jinx_debt_api.Models;
using jinx_debt_api.Data.Contexts;

namespace jinx_debt_api.Data;

public class GameRepository
{
    private readonly GameContext _context;

    public GameRepository(GameContext context)
    {
        _context = context;
    }

    public async Task<Game> GetCurrentGame(int player1ID, int player2ID)
    {
        return _context.Games.First(p => p.Player1_ID == player1ID && p.Player2_ID == player2ID);
    }
    
    public async Task<List<Game>> GetAllGames()
    {
        return _context.Games.ToList();
    }
    
    public async Task<Game> UpdateGame(Game Game)
    {
        _context.Games.Update(Game);
        await _context.SaveChangesAsync();
        return _context.Games.First(d => d.ID == Game.ID);
    }

    public async Task<Game> CreateNewGame(Game Game)
    {
        _context.Games.Add(Game);
        await _context.SaveChangesAsync();
        return _context.Games.First(d => d.ID == Game.ID);
    }
}