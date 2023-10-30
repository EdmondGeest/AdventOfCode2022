using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Of_Hot_Air
{
    /// <summary>
    /// De SNAFUNumberConvertor kan snafunummers omzetten in leesbare decimale nummers
    /// en kan decimale nummers omzetten in snafu nummers
    /// </summary>
    public class SNAFUNumberConvertor
    {
        public static SNAFUNumberConvertor Create()
        {
            return new SNAFUNumberConvertor();
        }

        // De te gebuiken snafu digits
        private string SnafuDigits = "=-012";

        /// <summary>
        /// Deze functie valideert de snafu nummers
        /// </summary>
        /// <param name="snafuNumber"></param>
        /// <returns></returns>
        public bool ValidateSnafuNumber(string snafuNumber)
        {
            bool result = true;
            string[] snafuNumberArray = snafuNumber.Select(x => x.ToString()).ToArray();

            foreach (var item in snafuNumberArray)
            {
                result = result && SnafuDigits.Any(x => x.ToString().Equals(item));
            }
            return result;
        }

        /// <summary>
        /// Deze functie converteert een snafunummer naar een decimaal
        /// </summary>
        /// <param name="snafuNumber"></param>
        /// <returns>snafunumber als decimaal</returns>
        public Decimal ConvertSnafuNumberToDecimal(string snafuNumber)
        {
            if (ValidateSnafuNumber(snafuNumber))
            {
                Decimal result = 0;
                int power = 0;

                string[] snafuNumberArray = snafuNumber.Select(x => x.ToString()).ToArray();


                for (int i = snafuNumberArray.Length - 1; i >= 0; i--)
                {
                    int value = ConvertSnafuDigitToInt(snafuNumberArray[i]);
                    result = result + (Decimal)(value * (Math.Pow(5, power++)));
                }

                return result;
            }
            else
                throw new ArgumentException(string.Format("Er is een foutief SNAFU nummer aangeleverd", snafuNumber));

        }

        /// <summary>
        /// Deze functie converteert een decimaal naar een snafunummer
        /// </summary>
        /// <param name="decimalNumber"></param>
        /// <returns>snafunummer</returns>
        public string ConvertDecimalToSnafuNumber(Decimal decimalNumber)
        {
            string result = string.Empty;

            result = CalculateSnafuNumber(decimalNumber, result);

            return result;
        }

        /// <summary>
        /// Met deze functie bepalen we de waarde van een snafudigit
        /// </summary>
        /// <param name="snafuDigit"></param>
        /// <returns></returns>
        private int ConvertSnafuDigitToInt(string snafuDigit)
        {
            return SnafuDigits.IndexOf(snafuDigit) - 2;
        }

        /// <summary>
        /// Deze functie bepaalt recursief de digits voor het snafu nummer
        /// </summary>
        /// <param name="decimalNumber"></param>
        /// <param name="result"></param>
        /// <returns>het snafu nummer</returns>
        private string CalculateSnafuNumber(Decimal decimalNumber, string result)
        {
            // Bepaal de macht, die bepaalt op welke plaats een digit in het resultaat geplaatst wordt
            int power = DeterminePower(decimalNumber);

            // Maak de result string met de lengte van power + 1 (power kan 0 zijn), gevuld met 0
            // Deze string wordt vooraf aangemaakt omdat in een enkel geval een bepaalde power
            // een 0 resultaat levert en dan wordt het result niet aangevuld. Op deze manier zal in 
            // geval van een ontbrekende power toch een 0 ingevuld zijn. 
            if (string.IsNullOrWhiteSpace(result))
                result = new string('0', power + 1);

            if (power >= 0)
            {
                // Bepaal digit welke het kleinste verschil met de input oplevert
                int digit = DetermineDigitWithSmallestDifference(decimalNumber, power);
                result = AddSnafuDigitToResult(result, digit, power);

                // Bepaal nu de restwaarde om verder te rekenen
                Decimal rest = decimalNumber - (Decimal)(Math.Pow(5, power)*digit);
                if (rest != 0) // Als rest == 0, dan is de berekening gereed
                    result = CalculateSnafuNumber(rest, result);
            }

            return result;
        }

        /// <summary>
        /// Met deze functie berekenen we met welke digit we met  de geleverde power 
        /// het dichtst bij het aangeleverde nummer komen
        /// </summary>
        /// <param name="decimalNumber"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        private int DetermineDigitWithSmallestDifference(decimal decimalNumber, int power)
        {
            int factor = -2; // kleinste waarde uit [2, 1, 0, -1, -2]
            int digit = factor;
            Decimal diffValue = decimalNumber;
            while (factor <= 2) // Tot en met grootste waarde uit [2, 1, 0, -1, -2]
            {
                Decimal factorValue = decimalNumber - (Decimal)(Math.Pow(5, power) * factor);
                if (Math.Abs(factorValue) < Math.Abs(diffValue))
                {
                    diffValue = factorValue;
                    digit = factor;
                }
                factor++;
            }

            return digit;
        }

        /// <summary>
        /// Met deze functie bepalen we de macht van 5 die groter is dan het aangeleverde nummer
        /// Met de daaonderliggende power kunnen we dus een waarde bepalen die in de buurt ligt 
        /// van het aangeleverde nummer
        /// </summary>
        /// <param name="decimalNumber"></param>
        /// <returns></returns>
        private int DeterminePower(decimal decimalNumber)
        {
            decimal value = Math.Abs(decimalNumber);
            decimal maxValue = 0;
            int power = 0;

            while (maxValue < value)
            {
                maxValue = maxValue + (Decimal)(Math.Pow(5, power++) * 2);
            }

            return power - 1;
        }

        /// <summary>
        /// Deze functie plaatst een digit op de juiste positie in het result.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="digit"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private string AddSnafuDigitToResult(string result, int digit, int position)
        {
            string[] inputArray = result.Select(x => x.ToString()).ToArray();
            inputArray[inputArray.Length - position - 1] = SnafuDigits[(int)digit+2].ToString();
            return string.Join(string.Empty, inputArray);
        }
    }
}
