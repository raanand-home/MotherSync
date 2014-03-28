using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    class DoSomeClass
    {
        public DoSomeClass()
        {

        }
      
        public void DoSome()
        {

        }
    }

    class GenBase<T>
        where T : DoSomeClass,new()
    {
        public void  DoSome(T a)
        {
            a.DoSome();
        }
        public T CreateNew()
        {
            return new T();
        }
    }


    [TestClass]
    public class GenericConstrains
    {
        [TestMethod]
        public void GenericConstrainsTestMethod()
        {
            GenBase<DoSomeClass> l = new GenBase<DoSomeClass>();
            var newedClass = l.CreateNew();
            l.DoSome(newedClass);

        }
    }
}
