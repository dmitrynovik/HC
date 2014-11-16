using NUnit.Framework;
using System;

namespace HotelMatcher.UnitTest
{
    [TestFixture]
    public class SuperfluousHotelTest : HotelTestBase
    {
        protected override string SupplierCode
        {
            get { return "SUP"; }
        }

        [Test]
        public void When_Names_And_Addresses_Without_Punctuation_Match_Hotels_Match()
        {
            Assert.IsTrue(Matcher.IsMatch(CreateSupplierHotel(@" !?^&Good*-Times! HOTEL Dubbo;\?/---_  ", @"22 *Carrington-Square, Dubbo, NSW."),
                CreateHotel(@"Good Times HOTEL Dubbo", @"22 Carrington Square, Dubbo, NSW.")));
        }

        [Test]
        public void When_Hotel_Name_Is_Null_And_Supplier_Name_Is_Null_Hotels_Match()
        {
            Assert.IsTrue(Matcher.IsMatch(CreateSupplierHotel(null), CreateHotel(null)));
        }

        [Test]
        public void When_Hotel_Name_Is_Empty_And_Supplier_Name_Is_Empty_Hotels_Match()
        {
            Assert.IsTrue(Matcher.IsMatch(CreateSupplierHotel(""), CreateHotel("")));
        }

        [Test]
        public void When_Addresses_DoNot_Match_Hotels_DoNot_Match()
        {
            Assert.IsFalse(Matcher.IsMatch(CreateSupplierHotel(null), CreateHotel(null, "a")));
        }

        [Test]
        public void When_Names_DoNot_Match_Hotels_DoNot_Match()
        {
            Assert.IsFalse(Matcher.IsMatch(CreateSupplierHotel("a", ""), CreateHotel("", "")));
        }
    }
}
