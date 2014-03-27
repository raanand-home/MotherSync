using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class enumBasicTest
    {
        enum color
        {
            red,
            blue,
            brown,
        }
        [TestMethod]
        public void EnumBasic()
        {
            color a = color.blue;
            if (a != color.blue)
                Assert.Fail("should be blue");
        }
        [TestMethod]
        public void EnumToString()
        {
            color a = color.blue;
            if (a != color.blue)
                Assert.AreEqual(a.ToString(),"blue");
        }
        [TestMethod]
        public void EnumToParse()
        {
            color a = (color)Enum.Parse(typeof(color), "blue");
            if (a != color.blue)
                Assert.Fail("should be blue");
        }
    }
}
