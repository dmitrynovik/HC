using System.Diagnostics;
using System.Linq;
using HotelMatcher.Interfaces;

namespace HotelMatcher.PrivateHotelMatchers
{
    internal class SuperfluousHotelMatcher : IHotelMatcher
    {
        public bool IsMatch(SupplierHotel supplierHotel, Hotel hotel)
        {
            // Return True if and only if "un-punctuated" name and address match:
            return (ExcludePunctuation(supplierHotel.Name) == ExcludePunctuation(hotel.Name)) &&
                   (ExcludePunctuation(supplierHotel.Address) == ExcludePunctuation(hotel.Address));
        }

        /// <summary>Returns the string with the punctuation removed, which consists only of letters and digits in lower case.</summary>
        /// <param name="source">The string to remove the punctuation.</param>
        private static string ExcludePunctuation(string source)
        {
            if (string.IsNullOrEmpty(source)) // Marginal case - empty or null string, avoid NullRef and unneeded processing
                return source;

            // Return the new "core" lowercase string containing only letters and digits.
            // Example: " AbBa; " => "abba"
            var result = new string(source.Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .ToArray());

            // debug-only mode diagnostics:
            Debug.WriteLine("[SuperfluousHotelMatcher.ExcludePunctuation] Input: '{0}'; Output: '{1}';", source, result);
            return result;
        }
    }
}
