using HotelMatcher.Interfaces;

namespace HotelMatcher.UnitTest
{
    public abstract class HotelTestBase
    {
        protected abstract string SupplierCode { get; }
        protected readonly IHotelMatcher Matcher;

        protected HotelTestBase()
        {
            Matcher = HotelsMatchersFactory.Create(SupplierCode);
        }

        protected Hotel CreateHotel(string name, string address = null)
        {
            return new Hotel() { Name = name, Address = address };
        }

        protected SupplierHotel CreateSupplierHotel(string name, string address = null)
        {
            return new SupplierHotel() { Name = name, Address = address };
        }

        protected Hotel CreateHotel(double latitude, double longitude)
        {
            return new Hotel() { Latitude = (decimal)latitude, Longitude = (decimal)longitude };
        }

        protected static SupplierHotel CreateSupplierHotel(double latitude, double longitude)
        {
            return new SupplierHotel() { Latitude = (decimal)latitude, Longitude = (decimal)longitude };
        }
    }
}
