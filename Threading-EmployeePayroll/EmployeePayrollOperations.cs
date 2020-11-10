using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Threading_EmployeePayroll
{
    /// <summary>
    ///  Employee Payroll Operations
    /// </summary>
    public class EmployeePayrollOperations
    {
        ///Creating connection with database
        public static string connectionString = @"Data Source=LAPTOP-TAR1C56T\MSSQLSERVER01;Initial Catalog=payroll_services;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();

        /// <summary>
        /// Adding employee details to list
        /// UC1
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void AddEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData => 
            {
                Console.WriteLine("Employee being added to list"+employeeData.EmployeeName);
                AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added to list " + employeeData.EmployeeName);
            });

        }
    

        /// <summary>
        /// Adding to list 
        /// called by AddEmployeeToPayroll and AddEmployeeToPayrollUsingThreading
        /// UC1
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployeePayroll(EmployeeDetails employee)
        {
            employeePayrollDetailList.Add(employee);
        }

        /// <summary>
        /// Adding Employee To Database
        /// UC1
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void AddEmployeeToDatabase(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added to database" + employeeData.EmployeeName);
                AddEmployeeDataBase(employeeData);
                Console.WriteLine("Employee added to database" + employeeData.EmployeeName);
            });

        }
        
        /// <summary>
        /// Add EmployeeDataBase Bing called by above two functions to perform operation
        /// UC1
        /// </summary>
        /// <param name="employeeDetails"></param>
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
            ///opening connection
            connection.Open();
            ///reading data in connected architecture
            command.ExecuteNonQuery();
            ///closing connectiom
            connection.Close();
        }
    }
}
