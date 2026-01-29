using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace EcoPark_Animal_Management_System.utilities
{
    internal static class NumericUtility
    {
        // ---------- INTEGER ----------

        public static (int value, bool success) TryParseInt(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return (result, true);
            }

            return (0, false);
        }

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

        // ---------- DOUBLE ----------

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

        // ---------- BOOL ----------

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
