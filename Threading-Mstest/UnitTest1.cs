using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Threading_EmployeePayroll;

namespace Threading_Mstest
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Creating List and Adding Values
        /// </summary>
        EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
        public List<EmployeeDetails> CreateList()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 1, EmployeeName: "KretikaArora", PhoneNumber: "9650925666", Address: "Street1", Department: "Hr", Gender: "F", BasicPay: 60000, Deductions: 1000, TaxablePay: 20000, Tax: 1000, NetPay: 58000, City: "Pune", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 2, EmployeeName: "Stanley", PhoneNumber: "9689850925", Address: "Street2", Department: "Operations", Gender: "M", BasicPay: 50000, Deductions: 1000, TaxablePay: 20000, Tax: 1000, NetPay: 48000, City: "Paris", Country: "France"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 3, EmployeeName: "Marco", PhoneNumber: "7750925666", Address: "Street3", Department: "Sales", Gender: "M", BasicPay: 40000, Deductions: 1000, TaxablePay: 10000, Tax: 500, NetPay: 38500, City: "Mumbai", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 4, EmployeeName: "Jeni", PhoneNumber: "6650925666", Address: "Street4", Department: "Hr", Gender: "F", BasicPay: 60000, Deductions: 1000, TaxablePay: 20000, Tax: 1000, NetPay: 58000, City: "Pune", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 5, EmployeeName: "Gabriyala", PhoneNumber: "8750925666", Address: "Street5", Department: "Marketing", Gender: "F", BasicPay: 230000, Deductions: 10000, TaxablePay: 20000, Tax: 4000, NetPay: 216000, City: "Newyork", Country: "USA"));
            return employeeDetails;
        }

        /// <summary>
        /// Given List Of Employees When Added To List Should Match The Entries without threading
        /// UC1
        /// </summary>
        [TestMethod]
        public void GivenListOfEmployeesWhenAddedToListShouldMatchTheEntriesWithoutThreading()
        { 
            ///Adding to list and database without threading
            List<EmployeeDetails>employeeDetails = CreateList();  
            ///timer
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayroll(employeeDetails);
            DateTime finishDateTime = DateTime.Now;
            Console.WriteLine("Duration with timer watch", finishDateTime - startDateTime);
            DateTime startDateTime1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeToDatabase(employeeDetails);
            DateTime finishDateTime1 = DateTime.Now;
            Console.WriteLine("Duration with timer watch", finishDateTime - startDateTime);
        }      

        /// <summary>
        /// Given List Of Employees When Added To List Should Match The Entries with threading
        /// UC2
        /// </summary>
        [TestMethod]
        public void GivenListOfEmployeesWhenAddedShouldMatchTheEntriesUsingThreading()
        {
            ///adding into list and database with threading
            List<EmployeeDetails> employeeDetails = CreateList();
            ///timer
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollUsingThreading(employeeDetails);
            DateTime finishDateTime = DateTime.Now;
            Console.WriteLine("Duration with timer watch", finishDateTime - startDateTime);
            DateTime startDateTime1 = DateTime.Now;
            employeePayrollOperations.addEmployeeToDataBaseWithThread(employeeDetails);
            DateTime finishDateTime1 = DateTime.Now;
            Console.WriteLine("Duration with timer watch", finishDateTime - startDateTime);
        }
    }
}
