// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeePayrollOperations.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
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
        private static Mutex mut = new Mutex();

        /// <summary>
        /// Adding employee details to list
        /// UC1
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void AddEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added to list" + employeeData.EmployeeName);
                AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added to list " + employeeData.EmployeeName);
            });          
        }


        /// <summary>
        /// Add Employee To List Using Threading
        /// UC2
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void AddEmployeeToPayrollUsingThreading(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Employee being added to list  is " + employeeData.EmployeeName);
                    AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added to list  is " + employeeData.EmployeeName);
                    Console.WriteLine("Thread Number is : " + Thread.CurrentThread.ManagedThreadId);
                });
                thread.Start();
                thread.Join();
            });
        }

        /// <summary>
        /// Add Employee To Payroll Using Threading With Synchronisation
        /// UC3
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void AddEmployeeToPayrollUsingThreadingWithSynchronisation(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    mut.WaitOne();
                    Console.WriteLine("Employee being added to list  is " + employeeData.EmployeeName);
                    AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added to list  is " + employeeData.EmployeeName);
                    Console.WriteLine("Thread Number is : " + Thread.CurrentThread.ManagedThreadId);
                    mut.ReleaseMutex();
                });
                thread.Start();
                thread.Wait();
            });
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
        /// Add Employee To DataBase With Threading
        /// UC2
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void addEmployeeToDataBaseWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                    this.AddEmployeeDataBase(employeeData);                  
                    Console.WriteLine("Employee added" + employeeData.EmployeeName);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                });
                thread.Start();
                thread.Wait();
            });
        }

        /// <summary>
        /// add Employee To DataBase With Thread And Synchronisation
        /// UC3
        /// </summary>
        /// <param name="employeePayrollDataList"></param>
        public void addEmployeeToDataBaseWithThreadAndSynchronisation(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    ///mutex basically blocks other threads to execute 
                    ///it does give signal when current thread is complete
                    mut.WaitOne();
                    Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                    this.AddEmployeeDataBase(employeeData);
                    Console.WriteLine("Employee added" + employeeData.EmployeeName);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    ///releases the current thread , for execution of new thread
                    mut.ReleaseMutex();
                });
                thread.Start();
                ///one thread at a time , blocks other thread
                thread.Wait();
            });
        }


        /// <summary>
        /// Adding to list 
        /// called by AddEmployeeToPayroll and AddEmployeeToPayrollUsingThreading
        /// UC1,UC2
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployeePayroll(EmployeeDetails employee)
        {
            employeePayrollDetailList.Add(employee);
        }

       
        /// <summary>
        /// Add EmployeeDataBase Bing called by above two functions to perform operation
        /// UC1,UC2
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