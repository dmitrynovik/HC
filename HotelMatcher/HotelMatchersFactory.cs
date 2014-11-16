using System;
using HotelMatcher.Interfaces;
using HotelMatcher.PrivateHotelMatchers;

namespace HotelMatcher
{
    /// <summary>
    /// The factory which creates correct matcher for the given supplier.
    /// </summary>
    public class HotelsMatchersFactory
    {
        public static IHotelMatcher Create(string supplierCode)
        {
            if (supplierCode == null)
                throw new ArgumentNullException("supplierCode");

            // Note: in current implementation the supplier's code is hardcoded in the factory.
            // This means, every time a new supplier is added, the new supplier's code must be added below.
            // 
            // As alternative solution, we may have supplier codes in configuration file, 
            // so that the factory will not need to be touched,
            // and an addition of supplier will require simply an addition of the entry in configuration file.
            switch (supplierCode.ToUpper())
            {
                // Add new supplier's code here (create new case):
                case "SUP":
                    return new SuperfluousHotelMatcher();
                case "HUH":
                    return new ThereaboutsHolidaysHotelMatcher();
                case "GCC":
                    return new ContraryCountryGetawaysHotelMatcher();
                default:
                    throw new ArgumentException(string.Format("Cannot create hotel matcher: supplier code {0} unknown."), supplierCode);
            }
        }
    }
}
