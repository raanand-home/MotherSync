using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IAmTest
{
    [TestClass]
    public class LinqTest
    {
        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Score { get; set; }
        }
        List<Person> data;
        
        [TestInitialize]
        public void Setup()
        {
            data = new List<Person>();
            System.Random rand = new Random();
            foreach (var x in Enumerable.Range(1,20))
            {
                data.Add(new Person() { Id = x, Name = "Ruth" + x.ToString(), Score = rand.Next(0,100) });
            }
        }
        
        [TestMethod]
        public void BasicSelect()
        {
            var result = from x in data
                         where x.Score < 90
                         select x; //Only Quary
            //iterate only in use
            Assert.IsTrue(result.Count() > 1);        
        }
    }
}
