using System;
using HotelMatcher.Interfaces;

namespace HotelMatcher.HotelMatchers
{
    internal class ThereaboutsHolidaysHotelMatcher : IHotelMatcher
    {
        public bool Macthes(SupplierHotel supplierHotel, Hotel hotel)
        {
            return SameChainCode(supplierHotel.ChainCode, hotel.ChainCode) && IsAround(supplierHotel, hotel);
        }

        /// <summary>Returns true if and only if two hotels are geographically close.</summary>
        private static bool IsAround(SupplierHotel supplierHotel, Hotel hotel)
        {
            const decimal maxDistance = 0.2m; // km
            const decimal kilometersInLatitudeDegree = 111.699m;

            var diffLatitude  = (supplierHotel.Latitude - hotel.Latitude) * kilometersInLatitudeDegree;
            var diffLongitude = (supplierHotel.Longitude - hotel.Longitude) * (kilometersInLatitudeDegree / 0.5m);

            // For the formula to calculate the distance, please see http://en.wikipedia.org/wiki/Distance#Geometry
            var distance = (decimal) Math.Sqrt((double)(diffLatitude*diffLatitude + diffLongitude*diffLongitude));

            return distance <= maxDistance;
        }

        private static bool SameChainCode(string chainCode1, string chainCode2)
        {
            // Margin case (Null) handling:
            if (chainCode1 == null)
                return chainCode2 == null;
            if (chainCode2 == null)
                return false;

            // Assume chain code is NOT case-sensitive:
            return chainCode1.Trim().ToLowerInvariant() == chainCode2.Trim().ToLowerInvariant();
        }
    }
}
