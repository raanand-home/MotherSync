using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    public class MyResource : IDisposable
    {
        private IntPtr _someUnmanagedResource;
        private List<long> _someManagedResource = new List<long>();

        IntPtr AllocateSomeMemory()
        {
            return IntPtr.Zero;
        }

        public MyResource()
        {
            _someUnmanagedResource = AllocateSomeMemory();
 
            for (long i = 0; i < 100; i++)
                _someManagedResource.Add(i);
        }

        // The finalizer will call the internal dispose method, telling it not to free managed resources.
        ~MyResource()
        {
            this.Dispose(false);
        }

        // The internal dispose method.
        private void Dispose(bool isDisposeInterfaceIsRunning)
        {
            if (isDisposeInterfaceIsRunning)
            {
                // Clean up managed resources
                _someManagedResource.Clear();
            }

            // Clean up unmanaged resources
            FreeSomeMemory(_someUnmanagedResource);
        }

        private void FreeSomeMemory(IntPtr _someUnmanagedResource)
        {
            throw new NotImplementedException();
        }

        // The public dispose method will call the internal dispose method, telling it to free managed resources.
        public void Dispose()
        {
            this.Dispose(true);
            // Tell the garbage collector to not call the finalizer because we have already freed resources.
            GC.SuppressFinalize(this);
        }
    }


    [TestClass]
    public class DisposePattern
    {
        [TestMethod]
        public void DisposePatternTestMethod()
        {
            MyResource a = new MyResource();
            a.Dispose();
            MyResource b = new MyResource();
        }
    }
}
