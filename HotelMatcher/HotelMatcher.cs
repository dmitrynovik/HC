using System;
using HotelMatcher.Interfaces;

namespace HotelMatcher
{
    /// <summary>
    /// The "matcher" master class implementing matching between hotels of different suppliers.
    /// </summary>
    public class HotelMatcher : IHotelMatcher
    {
        public bool Macthes(SupplierHotel supplierHotel, Hotel hotel)
        {
            if (supplierHotel == null) throw new ArgumentNullException(nameof(supplierHotel));
            if (hotel == null) throw new ArgumentNullException(nameof(hotel));

            // Use factory to create correct matcher for the given code:
            return HotelsMatchersFactory.Create(supplierHotel.SupplierCode).Macthes(supplierHotel, hotel);
        }
    }
}
