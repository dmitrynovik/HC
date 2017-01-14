using NUnit.Framework;

namespace HotelMatcher.UnitTest
{
    [TestFixture]
    public class ThereaboutsHotelTest : HotelTestBase
    {
        protected override string SupplierCode => "HUH";

        [Test]
        public void When_Hotels_Are_Far_Away_They_Dont_Match()
        {
            var northPoleHilton  = CreateSupplierHotel(latitude: 90, longitude: 0);
            var southPoleHoldayInn = CreateHotel(latitude: -90, longitude: 0);
            Assert.IsFalse(Matcher.Macthes(northPoleHilton, southPoleHoldayInn));
        }

        [Test]
        public void When_Hotels_Are_CloseBy_TheyMatch()
        {
            Assert.IsTrue(Matcher.Macthes(CreateSupplierHotel(39.99999, 12.7777776), CreateHotel(40.00001, 12.777777)));
        }
    }
}
