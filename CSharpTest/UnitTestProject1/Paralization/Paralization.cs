using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;


namespace UnitTestProject1.Paralization
{
    [TestClass]
    public class Paralization
    {
        private class Person
        {
            public Person()
            {
                Grade = 12;
            }
            public int Grade{get;set;}
        }
        List<Person> list;
        [TestInitialize]
        public void SetUp()
        {
            list = CreateList();
        }
        void WriteForConsole(Person value)
        {
            Console.WriteLine(value.Grade);
        }

        int FaxWriter(Person a)
        {
            return a.Grade;
        }
        int SendByEthernet(Person a)
        {
            return a.Grade;
        }

        [TestMethod]
        public void ManyAction()
        {
            List<Func<Person,int>> personAction = new List<Func<Person,int>>();
            personAction.Add(FaxWriter);
            personAction.Add(SendByEthernet);

            var per = new Person();

            var sd=  personAction.AsParallel().Select(actionFromTheList => actionFromTheList(per)).ToList();
           
            
            //var listAsParallel =  list.AsParallel();
            //ParallelEnumerable.ForAll(listAsParallel, WriteForConsole);
            list.AsParallel().Take(155).TakeWhile(
                (person) =>
                { 
                    return person.Grade < 4;
                });
            //list.AsParallel().ForAll(WriteForConsole);
            Parallel.ForEach(list,WriteForConsole);

            Action<int> x = (index)=>{};

            List<int> Resault = new List<int>();
            Action<int,ParallelLoopState> xWithPa = (index, loopState) => 
            {
                lock(this)
                {
                    Resault.Add(index);
                }
                if (index > 50)
                {
                    throw new Exception("sdfsf");
                    loopState.Break();
                }
            };
            Parallel.For(0, 100, x);
            try
            {
                Parallel.For(0, 100, xWithPa);
            }
            catch(Exception e)
            {

            }
        }


        [TestMethod]
        public void Linq()
        {
            var onlyMod2 = from x in list
                           where x.Grade % 2 == 0
                           select x;
            
            
        }

        private static List<Person> CreateList()
        {
            List<Person> a = new List<Person>();
            for (int count = 0; count < 5; count++)
            {
                a.Add(new Person() { Grade = count });

            }
            return a;
        }
    }
}
