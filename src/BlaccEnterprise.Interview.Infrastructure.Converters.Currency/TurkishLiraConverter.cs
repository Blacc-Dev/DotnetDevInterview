using System;

using BlaccEnterprise.Interview.Infrastructure.Converters;

namespace BlaccEnterprise.Interview.Converters.Currency
{
    public class TurkishLiraConverter : ICurrencyToWordConverter
    {
        public string Convert(double amount)
        {
            var leftPart = (int)Math.Floor(amount);
            var leftPartWord = $"{_numberToWords(leftPart)} TL";

            var rightPart = (int)((amount - leftPart) * 100);

            if(rightPart != 0)
            {
                var rigthPartWord = $"{_smallNumberToWord(rightPart, "")} KR";
                return $"{leftPartWord} {rigthPartWord}";
            }

            return leftPartWord;
        }

        private string _numberToWords(int number)
        {
            if (number == 0)
                return "sıfır";

            var words = "";

            if (number / 1000000000 > 0)
            {
                words += _numberToWords(number / 1000000000) + "milyar";
                number %= 1000000000;
            }

            if (number / 1000000 > 0)
            {
                words += _numberToWords(number / 1000000) + "milyon";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += _numberToWords(number / 1000) + "bin";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += _numberToWords(number / 100) + "yüz";
                number %= 100;
            }

            words = _smallNumberToWord(number, words);

            return words;
        }

        private static string _smallNumberToWord(int number, string words)
        {
            if (number <= 0) 
                return words;

            var unitsMap = new[] { "sıfır", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz", "on", "onbir", "oniki", "onüç", "ondört", "onbeş", "onaltı", "onyedi", "onsekiz", "ondokuz" };
            var tensMap = new[] { "sıfır", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += unitsMap[number % 10];
            }
            return words;
        }
    }
}
