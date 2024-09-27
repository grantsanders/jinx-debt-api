using jinx_debt_api.Data.Contexts;
using jinx_debt_api.Models;

namespace jinx_debt_api.Data;

public class DebtRepository
{
    private readonly DebtContext _context;

    public DebtRepository(DebtContext context)
    {
        _context = context;
    }

    public async Task<Debt> GetCurrentDebt(int player1ID, int player2ID)
    {
        return _context.Debts.First(p => p.Player1_ID == player1ID && p.Player2_ID == player2ID);
    }
    
    public async Task<Debt> UpdateDebt(Debt debt)
    {
        _context.Debts.Update(debt);
        await _context.SaveChangesAsync();
        return _context.Debts.First(d => d.ID == debt.ID);
    }

    public async Task<Debt> CreateNewDebt(Debt debt)
    {
        _context.Debts.Add(debt);
        await _context.SaveChangesAsync();
        return _context.Debts.First(d => d.ID == debt.ID);
    }
}