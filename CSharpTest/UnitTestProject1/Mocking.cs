using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IAmTest
{
    [TestClass]
    public class Mocking
    {
        public interface IPushToServer
        {
            string GetString();
            void Push(string someString);
            string LastPush { get; set; }
            void moreFunction();
        }

        class TestMeClass
        {
            IPushToServer _server;
            public TestMeClass(IPushToServer server)
            {
                _server = server;
            }
            public void Do()
            {
                foreach (int a in Enumerable.Range(0, 3))
                {
                    _server.Push(_server.GetString());
                }
            }
        }


        [TestMethod]
        public void MoqTest()
        {
            Moq.Mock<IPushToServer> moq = new Moq.Mock<IPushToServer>();
            TestMeClass testme = new TestMeClass(moq.Object);
            //setup
            moq.Setup(x => x.GetString()).Returns("Hello");

            //action
            testme.Do();

            //verify
            moq.Verify(x=>x.Push("Hello"),Moq.Times.AtLeast(3));
        }
    }
}
