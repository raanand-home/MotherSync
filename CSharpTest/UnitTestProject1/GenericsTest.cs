using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{


    public interface IContainer<T>
    {
        T GetObject();
        void SetObject(T value);
    }
    public class BasicIContainer<T> : IContainer<T>
    {
        T value;
        public T GetObject()
        {
            return value;
        }

        public void SetObject(T value)
        {
            this.value = value;
        }
    }

    public class StringContainer : IContainer<string>
    {
        private string _str;

        public string GetObject()
        {
            return _str;
        }

        public void SetObject(string value)
        {
            _str = value;
        }
    }

    [TestClass]
    public class GenericsTest
    {
        [TestMethod]
        public void GenericsTestTestMethod()
        {
            StringContainer col = new StringContainer();
            col.SetObject("Hello");
            Assert.AreEqual("Hello",col.GetObject() );
        }
        [TestMethod]
        public void BasicContainerTest()
        {
            BasicIContainer<string> col = new BasicIContainer<string>();
            col.SetObject("Hello");
            Assert.AreEqual("Hello", col.GetObject());
        }
    }
}
