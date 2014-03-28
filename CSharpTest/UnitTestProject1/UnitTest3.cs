using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace UnitTestProject1
{
    
    class EmployCollection
    {
        Dictionary<string, Employee> list;
        public Employee this[string strKey]
        {
            get 
            {
                if(strKey== "Ruth")
                {
                    return new Employee();
                }
                else
                {
                    if (! list.ContainsKey(strKey))
                    {
                        throw new Exception("No Key");
                    }
                    else
                    {
                        return list[strKey];
                    }
                }
                
            }
            set
            {
                string key = strKey;
                Employee val = value;
                list[key] = val;
                
            }
            
        }
    }
    [TestClass]
    public class IndexerTest
    {
        [TestMethod]
        public void IndexerTestMethod()
        {
            EmployCollection empC = new EmployCollection();
            //Employee emp = empC["Ruth"];
            //empC["shoky "] = new Employee();
        }
    }
}
