create procedure spDataInsertion
(
@EmployeeId int,
@EmployeeName varchar(150),
@PhoneNumber varchar(150),
@Address varchar(150),
@Department varchar(150),
@Gender varchar(2) ,
@BasicPay decimal,
@Deductions decimal ,
@TaxablePay decimal,
@Tax decimal,
@NetPay decimal,
@City varchar(150) , 
@Country varchar(150) 
)
 as begin
insert into Threading_Payroll
values(@EmployeeId,@EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,@Deductions,@TaxablePay,@Tax,@NetPay,@City,@Country);
end