using System.Linq;
using HotelMatcher.Interfaces;

namespace HotelMatcher.HotelMatchers
{
    internal class SuperfluousHotelMatcher : IHotelMatcher
    {
        /// <summary>Return True if and only if "un-punctuated" name and address match.</summary>
        public bool Macthes(SupplierHotel supplierHotel, Hotel hotel)
        {
            return (ExcludePunctuation(supplierHotel.Name) == ExcludePunctuation(hotel.Name)) &&
                   (ExcludePunctuation(supplierHotel.Address) == ExcludePunctuation(hotel.Address));
        }

        /// <summary>Returns the string with the punctuation removed, which consists only of letters and digits in lower case.</summary>
        /// <param name="source">The string to remove the punctuation.</param>
        private static string ExcludePunctuation(string source)
        {
            if (string.IsNullOrWhiteSpace(source)) // Marginal case - empty or null string, avoid NullRef and unneeded processing
                return string.Empty;

            // Return the new "core" lowercase string containing only letters and digits.
            // Example: " AbBa; " => "abba"
            return new string(source.Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .ToArray());
        }
    }
}
