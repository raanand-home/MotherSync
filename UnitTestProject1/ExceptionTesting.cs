using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    
    class MyException : Exception
    {
        public MyException(string Message)
            : base(Message)
        {

        }
    }
    

    [TestClass]
    public class ExceptionTesting 
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                ParametersTest a = new ParametersTest();
                a.TestParameters();
                throw new MyException("fail ...");
                Console.WriteLine("I would not be here");
            }
            catch (MyException ex)
            {

            }
         }
    }
}
