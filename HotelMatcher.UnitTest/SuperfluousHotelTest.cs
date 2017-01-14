using NUnit.Framework;

namespace HotelMatcher.UnitTest
{
    [TestFixture]
    public class SuperfluousHotelTest : HotelTestBase
    {
        protected override string SupplierCode => "SUP";

        [Test]
        public void When_Names_And_Addresses_Without_Punctuation_Match_Hotels_Match()
        {
            var supplierHotel = CreateSupplierHotel(@" !?^&Good*-Times! HOTEL Dubbo;\?/---_  ", @"22 *Carrington-Square, Dubbo, NSW.");
            var inventoryHotel = CreateHotel(@"Good Times HOTEL Dubbo", @"22 Carrington Square, Dubbo, NSW.");

            Assert.IsTrue(Matcher.Macthes(supplierHotel, inventoryHotel));
        }

        [Test]
        public void When_Hotel_Name_Is_Null_And_Supplier_Name_Is_Null_Hotels_Match()
        {
            Assert.IsTrue(Matcher.Macthes(CreateSupplierHotel(null), CreateHotel(null)));
        }

        [Test]
        public void When_Hotel_Name_Is_Empty_And_Supplier_Name_Is_Empty_Hotels_Match()
        {
            Assert.IsTrue(Matcher.Macthes(CreateSupplierHotel(""), CreateHotel("")));
        }

        [Test]
        public void When_Addresses_DoNot_Match_Hotels_DoNot_Match()
        {
            Assert.IsFalse(Matcher.Macthes(CreateSupplierHotel(null), CreateHotel(null, "some address")));
        }

        [Test]
        public void When_Names_DoNot_Match_Hotels_DoNot_Match()
        {
            Assert.IsFalse(Matcher.Macthes(CreateSupplierHotel("some name", ""), CreateHotel("", "")));
        }
    }
}
