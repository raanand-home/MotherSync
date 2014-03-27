using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTestProject1
{
    /// <summary>
    /// This delegate defines the signature of the appropriate method
    /// </summary>
    public delegate void ContractHandler(Employee sender);

    public class Employee
    {
        /// <summary>
        ///     Field for the info whether or not the Employee is engaged
        /// </summary>
        public bool m_bIsEngaged {set; get;}
        /// <summary>
        ///     Age of the employee
        /// </summary>
        public  int m_iAge {set; get;}
        /// <summary>
        ///     Name of the employee
        /// </summary>
        private String m_strName = null;

        public string Name { set { m_strName = Name; } get { return m_strName; } }
        /// <summary>
        /// *** The our event *** 
        /// Is a collection of methods that will be called when it fires
        /// </summary>
        public event ContractHandler Engaged;        /// <summary>
        ///     Standard constructor
        /// </summary>
        public Employee()
        {
            m_bIsEngaged = false;
            // Here, we are adding a new method with appropriate signature (defined by delegate)
            // note: when a event not have any method and it was fired, it causes a exception!
            //       for all effects when programming with events, assign one private method to event
            //       or simply do a verification before fire it! --> if (event != null)
            this.Engaged += new ContractHandler(this.OnEngaged);
        }
        /// <summary>
        ///     Event handler for the "engaged" event
        /// </summary>
        /// <param name="sender">
        ///     Sender object
        /// </param>
        private void OnEngaged(Employee sender)
        {
            Debug.WriteLine("private void OnEngaged was called! this employee is engaged now!");
        }
 
 

    }
    
    [TestClass]
    public class UnitTestEvent
    {
        [TestMethod]
        public void TestMethod1()
        {
            Employee employee = new Employee();
            employee.Name = "zzz";
            employee.m_iAge = 16;
            employee.Engaged += new ContractHandler(SimpleEmployee_Engaged);
            employee.m_bIsEngaged = true;
            employee.Name = "rrr";
        }

        // <summary>
        ///     Event handler for the registered "engaged" event
        /// </summary>
        /// <param name="sender">
        ///     Event sender
        /// </param>
        static void SimpleEmployee_Engaged(Employee sender)
        {
            Debug.WriteLine("The employee {0} is happy!", sender.Name);
        }
    }
}
