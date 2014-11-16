using NUnit.Framework;
using System;

namespace HotelMatcher.UnitTest
{
    [TestFixture]
    public class ThereaboutsHotelTest : HotelTestBase
    {
        protected override string SupplierCode
        {
            get { return "HUH"; }
        }

        [Test]
        public void When_Hotels_Are_Far_They_Dont_Match()
        {
            Assert.IsFalse(Matcher.IsMatch(CreateSupplierHotel(90, 180), CreateHotel(-90, -180)));
        }

        [Test]
        public void When_Hotels_Are_CloseBy_TheyMatch()
        {
            Assert.IsTrue(Matcher.IsMatch(CreateSupplierHotel(39.99999, 12.7777776), CreateHotel(40.00001, 12.777777)));
        }
    }
}
