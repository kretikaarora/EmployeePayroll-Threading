// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeModel.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Threading_EmployeePayroll
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal Tax { get; set; }
        public decimal NetPay { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public EmployeeDetails(int EmployeeID, string EmployeeName, string PhoneNumber, string Address, string Department, string Gender, decimal BasicPay, decimal Deductions, decimal TaxablePay, decimal Tax, decimal NetPay, string City, string Country)
        {
            this.EmployeeID = EmployeeID;
            this.EmployeeName = EmployeeName;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.Department = Department;
            this.Gender = Gender;
            this.BasicPay = BasicPay;
            this.Deductions = Deductions;
            this.TaxablePay = TaxablePay;
            this.Tax = Tax;
            this.NetPay = NetPay;
            this.City = City;
            this.Country = Country;
        }
    }
}
