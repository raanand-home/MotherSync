using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace UnitTestProject1
{
    class DoneRealyBigJob
    {
    //    void Do()
    //    {
    //        DoSome d = Do;
    //        Action<int> a;
            
            
    //    }
    //    public delegate void DoSome(int a);

        public async Task<int> AsyncDo()
        {
            await Task.Delay(500);//Imagaing bigger
            return 3;
        }
    }


    [TestClass]
    public class AsyncTest
    {
        [TestMethod]
        public void TestAsync()
        {

            DoneRealyBigJob d = new DoneRealyBigJob();
            IAsyncResult a = d.AsyncDo();
            a.AsyncWaitHandle.WaitOne();
            int b = 3;
        }
    }
}
