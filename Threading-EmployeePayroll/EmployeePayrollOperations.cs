using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Threading_EmployeePayroll
{
    public class EmployeePayrollOperations
    {
        public static string connectionString = @"Data Source=LAPTOP-TAR1C56T\MSSQLSERVER01;Initial Catalog=payroll_services;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();
        public void AddEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData => 
            {
                Console.WriteLine("Employee being added to list"+employeeData.EmployeeName);
                AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added to list " + employeeData.EmployeeName);
            });

        }
        public void AddEmployeePayroll(EmployeeDetails employee)
        {
            employeePayrollDetailList.Add(employee);
        }

        public void AddEmployeeToPayrollUsingThreading(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added to list" + employeeData.EmployeeName);
                    AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added to list " + employeeData.EmployeeName);
                });
                thread.Start();
            });
        }
        public void AddEmployeeToDatabase(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added to database" + employeeData.EmployeeName);
                AddEmployeeDataBase(employeeData);
                Console.WriteLine("Employee added to database" + employeeData.EmployeeName);
            });

        }
        public void addEmployeeToDataBaseWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                    this.AddEmployeeDataBase(employeeData);
                    Console.WriteLine("Employee added" + employeeData.EmployeeName);
                });
                thread.Start();
            });
        }
        public void AddEmployeeDataBase(EmployeeDetails employeeDetails)
        {
         
        SqlCommand command = new SqlCommand("spDataInsertion", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeId", employeeDetails.EmployeeID);
            command.Parameters.AddWithValue("@EmployeeName", employeeDetails.EmployeeName);
            command.Parameters.AddWithValue("@PhoneNumber", employeeDetails.PhoneNumber);
            command.Parameters.AddWithValue("@Address", employeeDetails.Address);
            command.Parameters.AddWithValue("@Department", employeeDetails.Department);
            command.Parameters.AddWithValue("@Gender", employeeDetails.Gender);
            command.Parameters.AddWithValue("@Basicpay", employeeDetails.BasicPay);
            command.Parameters.AddWithValue("@Deductions", employeeDetails.Deductions);
            command.Parameters.AddWithValue("@Taxablepay", employeeDetails.TaxablePay);
            command.Parameters.AddWithValue("@Tax", employeeDetails.Tax);
            command.Parameters.AddWithValue("@Netpay", employeeDetails.NetPay);
            command.Parameters.AddWithValue("@City", employeeDetails.City);
            command.Parameters.AddWithValue("@Country", employeeDetails.Country);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
