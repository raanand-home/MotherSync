using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    class TestParametersClass
    {
        public int func1()
        {
            int veriable = 1;
            return veriable;
        }
        int field = 1;
        System.Boolean boolParam = true;


        public void MethodIncriment(int a)
        {
            a++;
        }

        public void MethodIncriment(DataBlockClass a)
        {
            a.field++;
        }

        public void MethodIncriment(DataBlockStruct a)
        {
            a.field++;
        }
        /// <summary>
        /// out - have to assign to this retrun param
        /// 
        /// </summary>
        /// <param name="a"></param>
        public void OutFunction(out int a)
        {
            a = 1; 
        }
        /// <summary>
        ///  ref is parameter input and output
        /// </summary>
        /// <param name="a"></param>
        public void RefFunction(ref int a)
        {
            a++;
        }
    }

    class DataBlockClass
    {
        public int field;
    }

    struct DataBlockStruct
    {
        public int field;
    }


    [TestClass]
    public class ParametersTest
    {
        
        [TestMethod]
        public void TestParameters()
        {
            
            Assert.AreEqual(A.func1(), 1);
        }
        
        TestParametersClass A = new TestParametersClass();
        int x;

        [TestMethod]
        public void TestParametersIncCompare()
        {
            int a = 1;
            A.MethodIncriment(a);
            Assert.AreEqual(a, 1);
        }
        
        [TestMethod]
        public void TestParametersIncCompareStractVsClass()
        {
            DataBlockClass a = new DataBlockClass();
            a.field = 1;

            A.MethodIncriment(a);
            Assert.AreEqual(a.field, 2);
        }

        [TestMethod]
        public void TestParametersIncCompareStractVsClassContinue()
        {
            DataBlockStruct a;
            a.field = 1;

            A.MethodIncriment(a);
            Assert.AreEqual(a.field, 1);
        }

        [TestMethod]
        public void TestOutFunction()
        {
            int a;
            A.OutFunction(out a);
            Assert.AreEqual(a, 1);
        }

        [TestMethod]
        public void TestRefFunction()
        {
            int a = 5;
            A.RefFunction(ref a);
            Assert.AreEqual(a, 6);
            bool xxx;
        }

        [TestMethod]
        public void TestBoxing()
        {
            int a = 5;
            object b = a;
            int c = (int)b;
            Assert.AreEqual(c, 5);
        }



    }
}
