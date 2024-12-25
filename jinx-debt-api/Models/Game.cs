using System.ComponentModel.DataAnnotations.Schema;

namespace jinx_debt_api.Models;

public class Game
{
    public int ID { get; set; }
    public int Player1_ID { get; set; }
    public int Player2_ID { get; set; }
    public int Player1_Score { get; set; }
    public int Player2_Score { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? Advantage { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
    public DateTime LastModifyDate { get; set; }
}