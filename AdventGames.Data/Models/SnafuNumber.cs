using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventGames.Data.Models
{
    public class SnafuNumber
    {
        public string Number { get; set; }

        public static SnafuNumber Create(string number)
        {
            return new SnafuNumber { Number = number.Trim() };
        }
    }
}
