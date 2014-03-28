using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;

namespace UnitTestProject1
{
     delegate  void SalaryChange(int NewSalary);

     class Employee
     {
         private int _salary = 0;
         public int Salary
         {
             get
             {
                 return _salary;
             }
             set
             {
                 _salary = value;
                 var localOnSalaryChanged = OnSalaryChanged;
                 if (localOnSalaryChanged != null)
                 {
                     localOnSalaryChanged(_salary);
                 }

             }
         }
         public event SalaryChange OnSalaryChanged;
     }

     class TelemetryArrived
     {
         List<Employee> list = new List<Employee>();
         public void WatchEmploy(Employee a)
         {
             list.Add(a);
             a.OnSalaryChanged+=a_OnSalaryChanged;
         }
         void Remove(Employee e)
         {
             list.Remove(e);
         }

         void a_OnSalaryChanged(int NewSalary)
         {

         }
     }
    
    [TestClass]
    public class UnitTestEvent
    {

        [TestMethod]
        public void EventTesting()
        {
            Employee emp = new Employee();
            
            emp.OnSalaryChanged +=new SalaryChange( emp_OnSalaryChanged);
            
            emp.Salary = 1;
            Assert.AreEqual(newSalary, 1);
        }
        int newSalary;
        void emp_OnSalaryChanged(int NewSalary)
        {
            newSalary = NewSalary;
        }


        
        
    }
}
