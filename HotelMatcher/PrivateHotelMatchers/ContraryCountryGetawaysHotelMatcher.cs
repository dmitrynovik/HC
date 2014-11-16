using System;
using System.Collections.Generic;
using System.Linq;
using HotelMatcher.Interfaces;

namespace HotelMatcher.PrivateHotelMatchers
{
    internal class ContraryCountryGetawaysHotelMatcher : IHotelMatcher
    {
        public bool IsMatch(SupplierHotel supplierHotel, Hotel hotel)
        {
            // Returns True if and only if the words in supplier's name match the words in reverse order.
            // Here, LINQ comes in handy (SequenceEqual is already implemented)
            return GetWords(hotel.Name).SequenceEqual(GetWords(supplierHotel.Name).Reverse());
        }

        /// <summary>
        /// Returns the sequence of the words from the sentence.
        /// </summary>
        private static IEnumerable<string> GetWords(string source)
        {
            if (string.IsNullOrEmpty(source))
                return new string[] { source };
            
            return source.Split(new char[] { ' ', ':', '.', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower()); // make words case-insencitive (may be not needed).
        }
    }
}
