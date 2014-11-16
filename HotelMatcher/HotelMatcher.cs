using System;
using HotelMatcher.Interfaces;

namespace HotelMatcher
{
    /// <summary>
    /// The "matcher" master class implementing matching between hotels of different suppliers.
    /// </summary>
    public class HotelMatcher : IHotelMatcher
    {
        public bool IsMatch(SupplierHotel supplierHotel, Hotel hotel)
        {
            // Validation for Null:
            if (supplierHotel == null)
                throw new ArgumentNullException("supplierHotel");
            if (hotel == null)
                throw new ArgumentNullException("hotel");

            // Use factory to create correct matcher for the given code:
            return HotelsMatchersFactory.Create(supplierHotel.SupplierCode).IsMatch(supplierHotel, hotel);
        }
    }
}
