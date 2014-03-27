using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    
    
    [TestClass]
    public class YieldTest
    {
        
        /// <summary>
        /// yield return each time one number and after return the next
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetNextYield()
        {
            for (int a = 0; a < 1; a++)
            {
                yield return a;
            }
       
            yield return 34;
        }
        void Func1()
        {

        }
        void InnerFunc()
        {
            try
            {
                //something wrong
            }
            catch(Exception ex)
            {
                //some cleanup .
                throw ex;
            }
        }

        IEnumerable<int> GetArray()
        {
            var l = new int[1];
            for (int a = 0; a < 1; a++)
            {
                l[a] = a;
            }
            return l;
        }

        [TestMethod]
        public void YieldTestMethod()
        {
            var enumarator = GetNextYield();
            
            var enume = enumarator.GetEnumerator();
            enume.MoveNext();
            var a = enume.Current;
            enume.MoveNext();
            var b = enume.Current;

                
        }
    }
}
