// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Threading_EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To Employee Payroll Using Threading");
            ///adding into list and database with threading
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 101, EmployeeName: "KretikaArora", PhoneNumber: "9650925666", Address: "Street1", Department: "Hr", Gender: "F", BasicPay: 60000, Deductions: 1000, TaxablePay: 20000, Tax: 1000, NetPay: 58000, City: "Pune", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 102, EmployeeName: "Stanley", PhoneNumber: "9689850925", Address: "Street2", Department: "Operations", Gender: "M", BasicPay: 50000, Deductions: 1000, TaxablePay: 20000, Tax: 1000, NetPay: 48000, City: "Paris", Country: "France"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 103, EmployeeName: "Marco", PhoneNumber: "7750925666", Address: "Street3", Department: "Sales", Gender: "M", BasicPay: 40000, Deductions: 1000, TaxablePay: 10000, Tax: 500, NetPay: 38500, City: "Mumbai", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 104, EmployeeName: "Jeni", PhoneNumber: "6650925666", Address: "Street4", Department: "Hr", Gender: "F", BasicPay: 60000, Deductions: 1000, TaxablePay: 20000, Tax: 1000, NetPay: 58000, City: "Pune", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 105, EmployeeName: "Gabriyala", PhoneNumber: "8750925666", Address: "Street5", Department: "Marketing", Gender: "F", BasicPay: 230000, Deductions: 10000, TaxablePay: 20000, Tax: 4000, NetPay: 216000, City: "Newyork", Country: "USA"));
            
           
            ///timer
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.addEmployeeToDataBaseWithThreadAndSynchronisation(employeeDetails);
            DateTime finishDateTime = DateTime.Now;
            Console.WriteLine("Duration with timer watch {0}", finishDateTime - startDateTime);

        }
    }
}
