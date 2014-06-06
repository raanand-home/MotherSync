using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    public interface ISomeSize
    {
        int Height { get; set; }
        int Width { get; set; }
    }

     class SomeStruct :ISomeSize
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

     class Rect : ISomeSize
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public static class MyExtensions
    {
        public static int Size(this ISomeSize s)
        {
            return s.Height * s.Width;
        }
        public static string Repeat(this string str, int times)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < times; i++)
                sb.Append(str);

            return sb.ToString();
        }
        // to be continued...
    }
    
    
    [TestClass]
    public class ExtentionMethod
    {
        [TestMethod]
        public void ExtentionMethodTestMethod()
        {
            SomeStruct s = new SomeStruct() { Width = 4, Height = 3 };
            Assert.AreEqual(12, s.Size() );
            Rect r = new Rect() { Width = 4, Height = 3 };
            Assert.AreEqual(12, r.Size());
            
        }

        [TestMethod]
        public void TestRepeat()
        {
            string hello = "Hello ";
            var Longhello = hello.Repeat(58);
        }

    }
}
