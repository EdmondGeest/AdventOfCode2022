using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Of_Hot_Air
{
    public interface INumberAdapter
    {
        decimal TodecimalNumber(string stringNumber);
        string ToStringNumber(decimal decimalNumber);
    }
}
