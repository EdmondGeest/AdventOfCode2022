using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventGames.Data.Models
{
    public class RPSGameRecord
    {
        public string player1Input { get; set; }
        public string player2Input { get; set; }

        public static RPSGameRecord Create(string player1Input, string player2Input)
        {
            return new RPSGameRecord {  player1Input = player1Input.Trim(), player2Input = player2Input.Trim() };
        }
    }
}
