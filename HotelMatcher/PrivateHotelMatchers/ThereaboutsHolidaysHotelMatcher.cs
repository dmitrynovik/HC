using System;
using System.Diagnostics;
using HotelMatcher.Interfaces;

namespace HotelMatcher.PrivateHotelMatchers
{
    internal class ThereaboutsHolidaysHotelMatcher : IHotelMatcher
    {
        public bool IsMatch(SupplierHotel supplierHotel, Hotel hotel)
        {
            return SameChainCode(supplierHotel.ChainCode, hotel.ChainCode) && IsAround(supplierHotel, hotel);
        }

        /// <summary>
        /// Returns true if and only if two hotels are geographically close.
        /// </summary>
        private static bool IsAround(SupplierHotel supplierHotel, Hotel hotel)
        {
            const double distanceThreshold = 0.2d; // km
            const int kilometersInDegree = 111;

            var diffLatitude  = (supplierHotel.Latitude - hotel.Latitude) * kilometersInDegree;
            var diffLongitude = (supplierHotel.Longitude - hotel.Longitude) * kilometersInDegree;

            // For the formula to calculate the distance, please see http://en.wikipedia.org/wiki/Distance#Geometry
            var distance = Math.Sqrt((double) ((diffLatitude*diffLatitude) + (diffLongitude*diffLongitude)));

            // debug-only mode diagnostics:
            Debug.WriteLine("Calculated distance between ({0},{1}) and ({2},{3}) is {4} km", 
                supplierHotel.Latitude, supplierHotel.Longitude, hotel.Latitude, hotel.Longitude, distance);

            return distance <= distanceThreshold;
        }

        private static bool SameChainCode(string chainCode1, string chainCode2)
        {
            // Margin case (Null) handling:
            if (chainCode1 == null)
                return (chainCode2 == null);
            if (chainCode2 == null)
                return false;

            // I assume chain code is NOT case-sensitive (no information is given in the assignment, the assumption may be wrong):
            return chainCode1.Trim().ToLower() == chainCode2.Trim().ToLower();
        }
    }
}
