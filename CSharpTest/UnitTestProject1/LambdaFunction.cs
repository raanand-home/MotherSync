using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class LambdaFunction
    {
        public class A
        {
            public int Id;
        }
        public delegate bool Pred(A a);
        class B
        {
            
            
            private Pred _checkFunction;
            
            public B(Pred checkFunc)
            {
                _checkFunction = checkFunc;
            }

            public bool CheckIsOk(A a)
            {
                return _checkFunction(a);
            }
        }

        class BShort
        {
            private Func<A,bool> _checkFunction;

            public BShort(Func<A,bool> checkFunc)
            {
                _checkFunction = checkFunc;
            }

            public bool CheckIsOk(A a)
            {
                return _checkFunction(a);
            }
        }

        bool IsIdBiggerThen5(A a)
        {
            return a.Id > 5;
        }

        [TestMethod]
        public void TestLongB()
        {
            var b = new B(IsIdBiggerThen5);

            var a = new A { Id = 7 };
            Assert.IsTrue(b.CheckIsOk(a));
        }

        [TestMethod]
        public void TestShortB()
        {
            var b = new BShort(IsIdBiggerThen5);
            var a = new A { Id = 7 };
            Assert.IsTrue(b.CheckIsOk(a));
        }

        [TestMethod]
        public void TestLongBWithoutIsIdBiggerThen()
        {
            Pred checkingFunc = x => x.Id > 5;
            
            var b = new B(checkingFunc);
            
            var a = new A { Id = 7 };
            Assert.IsTrue(checkingFunc(a));
            Assert.IsTrue(b.CheckIsOk(a));
        }

        [TestMethod]
        public void FunctionWithoutParamters()
        {
            Func<bool> functionPointer = () => true;
            Assert.IsTrue(functionPointer()); 
        }

        [TestMethod]
        public void ActionNoParam()
        {
            int a = 0;
            Action noParamter = () => a++;
            Assert.AreEqual(1, a);
        }
    }
}
