Select SUBSTRING(emp_id,0,2) From Employees where emp_id = (select max(emp_id) from Employees); 

select max (emp_id) from employees where emp_id like '%F%'