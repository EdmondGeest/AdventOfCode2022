using Full_Of_Hot_Air;
using System.Numerics;

namespace Full_Of_Hot_Air.Tests
{
    [TestClass]
    public class ConvertorTests
    {
        [DataRow("2", 2)]
        [DataRow("1", 1)]
        [DataRow("0", 0)]
        [DataRow("-", -1)]
        [DataRow("=", -2)]
        [DataRow("1=-0-2", 1747)]
        [DataRow("12111", 906)]
        [DataRow("2=0=", 198)]
        [DataRow("21", 11)]
        [DataRow("2=01", 201)]
        [DataRow("111", 31)]
        [DataRow("20012", 1257)]
        [DataRow("112", 32)]
        [DataRow("1=-1=", 353)]
        [DataRow("1-12", 107)]
        [DataRow("12", 7)]
        [DataRow("1=", 3)]
        [DataRow("122", 37)]
        [DataRow("1=-0-2", 1747)]
        [DataRow("1121-1110-1=0", 314159265)]
        [TestMethod]
        public void ElfsSnafuConvertor_Converts_SnafuNumbers_To_Decimals(string snafu, int input)
        {
            SNAFUNumberConvertor convertor = new SNAFUNumberConvertor();

            var result = convertor.ConvertSnafuNumberToDecimal(snafu);

            Assert.AreEqual(input, result);

        }

        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(3, "1=")]
        [DataRow(4, "1-")]
        [DataRow(5, "10")]
        [DataRow(6, "11")]
        [DataRow(7, "12")]
        [DataRow(8, "2=")]
        [DataRow(9, "2-")]
        [DataRow(10, "20")]
        [DataRow(15, "1=0")]
        [DataRow(20, "1-0")]
        [DataRow(1257, "20012")]
        [DataRow(1747, "1=-0-2")]
        [DataRow(2022, "1=11-2")]
        [DataRow(12345, "1-0---0")]
        [DataRow(314159265, "1121-1110-1=0")]
        [TestMethod]
        public void ElfsSnafuConvertor_Converts_Decimals_To_SnafuNumbers(Int32 input, string snafuResult)
        {
            SNAFUNumberConvertor convertor = new SNAFUNumberConvertor();

            var result = convertor.ConvertDecimalToSnafuNumber((Decimal)input);

            Assert.AreEqual(snafuResult, result);
        }

        [TestMethod]
        public void ElfsSnafuConvertor_Converts_ListOfSnafuValues_To_Decimals_And_Converts_SumOfDecimals_To_Snafu_Equals_Expected_SnafuValue()
        {
            SNAFUNumberConvertor convertor = new SNAFUNumberConvertor();

            Decimal result = 0;

            string[] inputArray = { "1=-0-2", "12111", "2=0=", "21", "2=01", "111", "20012", "112", "1=-1=", "1-12", "12", "1=", "122" };
            foreach (string input in inputArray)
                result += convertor.ConvertSnafuNumberToDecimal(input);

            String snafuResult = convertor.ConvertDecimalToSnafuNumber(result);

            Assert.AreEqual("2=-1=0", snafuResult);
        }

        [DataRow("=", true)]
        [DataRow("-", true)]
        [DataRow("0", true)]
        [DataRow("1", true)]
        [DataRow("2", true)]
        [DataRow("3", false)]
        [DataRow("1121-1110-1=0", true)]
        [DataRow("1121X1110-1=0", false)]
        [TestMethod]
        public void ElfsSnafuConvertor_Validates_SnafuNumbers(string snafuNumber, bool valid)
        {
            SNAFUNumberConvertor convertor = new SNAFUNumberConvertor();
            var result = convertor.ValidateSnafuNumber(snafuNumber);

            Assert.AreEqual(valid, result);
        }
    }
}