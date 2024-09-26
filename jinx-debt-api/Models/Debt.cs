namespace jinx_debt_api.Models;

public class Debt
{
    public int ID { get; set; }
    public int Player1_ID { get; set; }
    public int Player2_ID { get; set; }
    public int ScoreValue { get; set; }
}