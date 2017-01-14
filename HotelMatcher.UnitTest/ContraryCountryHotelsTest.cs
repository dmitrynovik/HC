using NUnit.Framework;
using System;

namespace HotelMatcher.UnitTest
{
    [TestFixture]
    public class ContraryCountryHotelsTest : HotelTestBase
    {
        protected override string SupplierCode => "GCC";

        [Test]
        public void When_Names_Have_Same_Words_In_Reverse_Order_Hotels_Match()
        {
            Assert.IsTrue(Matcher.IsMatch(CreateSupplierHotel("Manor Country Mayhew’s Ralph Lord"), CreateHotel("Lord Ralph Mayhew’s Country Manor")));
        }

        [Test]
        public void When_Names_Are_Empty_Hotels_Match()
        {
            Assert.IsTrue(Matcher.IsMatch(CreateSupplierHotel(""), CreateHotel("")));
        }

        [Test]
        public void When_Names_Are_Null_Hotels_Match()
        {
            Assert.IsTrue(Matcher.IsMatch(CreateSupplierHotel(null), CreateHotel(null)));
        }
    }
}
