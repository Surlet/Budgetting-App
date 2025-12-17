using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingApp.Services
{
    public static class DecimalParser
    {
        public static bool TryParseFlexible(string input, out decimal value)
        {
            value = 0;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim().Replace(',', '.');

            return decimal.TryParse(
                input,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out value
            );
        }

        public static decimal ParseFlexible(string input)
        {
            if (TryParseFlexible(input, out var value))
                return value;

            throw new FormatException($"Invalid decimal value: {input}");
        }
    }
}
