using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Of_Hot_Air
{
    public class SNAFUNumberAdapter : INumberAdapter
    {
        private SNAFUNumberConvertor convertor;

        public static SNAFUNumberAdapter Create(SNAFUNumberConvertor convertor)
        {
            return new SNAFUNumberAdapter(convertor);
        }

        public SNAFUNumberAdapter(SNAFUNumberConvertor convertor)
        {
            this.convertor = convertor;       
        }
        public decimal TodecimalNumber(string stringNumber)
        {
            return convertor.ConvertSnafuNumberToDecimal(stringNumber);
        }

        public string ToStringNumber(decimal decimalNumber)
        {
            return convertor.ConvertDecimalToSnafuNumber(decimalNumber);
        }
    }
}
