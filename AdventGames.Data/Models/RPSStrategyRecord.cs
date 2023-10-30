using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventGames.Data.Models
{
    public class RPSStrategyRecord
    {
        public string opponentChoice { get; set; }
        public string playerStrategyChoice { get; set; }

        public static RPSStrategyRecord Create(string opponentInput, string playerInput)
        {
            return new RPSStrategyRecord {  opponentChoice = opponentInput.Trim(), playerStrategyChoice = playerInput.Trim() };
        }
    }
}
