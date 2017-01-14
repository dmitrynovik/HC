using System;
using System.Collections.Generic;
using System.Linq;
using HotelMatcher.Interfaces;

namespace HotelMatcher.HotelMatchers
{
    internal class ContraryCountryGetawaysHotelMatcher : IHotelMatcher
    {
        private static readonly char[] WordBoundary = { ' ', ':', '.', ',', ';' };

        /// <summary>Returns True if and only if the words in supplier's name match the words in reverse order.</summary>
        public bool Macthes(SupplierHotel supplierHotel, Hotel hotel)
        {
            return GetWords(hotel.Name).SequenceEqual(GetWords(supplierHotel.Name).Reverse());
        }

        /// <summary>Returns the sequence of the words from the sentence.</summary>
        private static IEnumerable<string> GetWords(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return new[] { string.Empty };
            
            return source.Split(WordBoundary, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLowerInvariant()); // case-insensitive.
        }
    }
}
