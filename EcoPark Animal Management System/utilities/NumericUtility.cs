using System;
using System.Globalization;

namespace EcoPark_Animal_Management_System.utilities
{
    // Utility class for safely parsing numeric and boolean values
    internal static class NumericUtility
    {
        // Tries to parse an integer from string
        public static (int value, bool success) TryParseInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return (result, true);
            }

            return (0, false);
        }

        // Tries to parse an integer within a specific range
        public static (int value, bool success) TryParseInt(string input, int min, int max)
        {
            if (int.TryParse(input, out int result))
            {
                if (result >= min && result <= max)
                {
                    return (result, true);
                }
            }

            return (0, false);
        }

        // Tries to parse a double using invariant culture
        public static (double value, bool success) TryParseDouble(string input)
        {
            if (double.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double result))
            {
                return (result, true);
            }

            return (0.0, false);
        }

        // Tries to parse a double within a specific range
        public static (double value, bool success) TryParseDouble(string input, double min, double max)
        {
            if (double.TryParse(
                input,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double result))
            {
                if (result >= min && result <= max)
                {
                    return (result, true);
                }
            }

            return (0.0, false);
        }

        // Tries to parse a boolean value
        public static (bool value, bool success) TryParseBool(string input)
        {
            if (bool.TryParse(input, out bool result))
            {
                return (result, true);
            }

            return (false, false);
        }
    }
}
