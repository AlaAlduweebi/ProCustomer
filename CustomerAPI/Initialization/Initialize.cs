using CustomerAPI.Initialization;
using CustomersUI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CustomersAPI.Initialization
{
    public class Initialize : ControllerBase
    {
        public readonly Random Rand = new();
        public readonly StaticData staticData = new();

        public T GetRandomEnumValue<T>() where T : Enum
        {
            T[] values = (T[])Enum.GetValues(typeof(T));
            return values[Rand.Next(values.Length)];
        }

        public Customer GetBaseCostumer(int id) 
        {
            return staticData.BaseCostumer[id];
        }

        public Customer.Company GetBaseCompany(int id)
        {
            return staticData.BaseCompany[id];
        }

        public DateOnly GenerateRandomDate(int startYear, int endYear)
        {
            var startDate = new DateTime(startYear, 1, 1);
            var endDate = new DateTime(endYear, 12, 31);

            var range = (endDate - startDate).Days;
            var randomDateTime = startDate.AddDays(Rand.Next(range));
            var randomDateOnly = new DateOnly(randomDateTime.Year, randomDateTime.Month, randomDateTime.Day);

            return randomDateOnly;
        }

        public string GenerateRandomTelNr()
        {
            var telNr = "+";
            telNr += Rand.Next(1, 99).ToString("00");
            telNr += Rand.Next(1, 999).ToString("000");
            telNr += Rand.Next(1, 9999999).ToString("0000000");

            return telNr;
        }

        public TimeSpan GenerateRandomTime()
        {
            var hours = Rand.Next(0, 24);
            var minutes = Rand.Next(0, 60);
            var seconds = Rand.Next(0, 60);

            var randomTime = new TimeSpan(hours, minutes, seconds);

            return randomTime;
        }

        public string GenerateRandomSeat()
        {
            var row = (char)('A' + Rand.Next(10));
            var column = Rand.Next(1, 7);
            return $"{row}{column}";
        }

        public string GenerateTerminalId()
        {
            var prefix = "TER";
            var nr = Rand.Next(1000, 10000);
            return prefix + nr;
        }

        public string GenerateCardNumber()
        {
            StringBuilder iban = new StringBuilder();
            var chars = "0123456789";
            iban.Append("DE");

            for (int i = 0; i < 20; i++)
            {
                iban.Append(chars[Rand.Next(chars.Length)]);
                if ((i + 1) % 4 == 0 && i != 19)
                {
                    iban.Append(' ');
                }
            }
            return iban.ToString();
        }

        public string GenerateActionNr()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[11];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[Rand.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public string GenerateRandomAmount(decimal minAmount, decimal maxAmount)
        {
            var range = (double)(maxAmount - minAmount);
            var randomValue = Rand.NextDouble() * range;
            var amount = minAmount + (decimal)randomValue;

            return amount.ToString("0.00").Replace(".", ",");
        }
    }
}
