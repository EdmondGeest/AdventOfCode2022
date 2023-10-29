using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventGames.Data.Models
{
    public class RPSGameRecord
    {
        public string opponentInput { get; set; }
        public string playerInput { get; set; }

        public static RPSGameRecord Create(string opponentInput, string playerInput)
        {
            return new RPSGameRecord {  opponentInput = opponentInput.Trim(), playerInput = playerInput.Trim() };
        }
    }
}
