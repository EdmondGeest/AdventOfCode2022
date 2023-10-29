using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventGames.Data.Models
{
    public class SnafuNumberRecord
    {
        public string Number { get; set; }

        public static SnafuNumberRecord Create(string number)
        {
            return new SnafuNumberRecord { Number = number.Trim() };
        }
    }
}
