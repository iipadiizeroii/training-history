Select et.*
From External_training ET
INNER JOIN Expert_detail_out EDO 
on EDO.trainingEx_id = ET.trainingEx_id
where EDO.trainingEx_id = '1909001'

Select *
From Expert EX
INNER JOIN Expert_detail_out EDO 
on EDO.expert_id = EX.expert_id
where EDO.trainingEx_id = '1909001'

Select * 
From Expert_detail_out EDO 
INNER JOIN External_training ET  ON (ET.trainingEx_id=EDO.trainingEx_id)
INNER JOIN Expert EX  ON (EX.expert_id=EDO.expert_id)
where EDO.trainingEx_id = '1909001'

---------------------------------------------

Select * 
From External_training_history ETH
INNER JOIN Employees E  ON (E.emp_id = ETH.emp_id)
INNER JOIN External_training ET ON (ET.trainingEx_id = ETH.trainingEx_id)
where ETH.trainingEx_id = '1909001'


Select *
from Employees E ,Internal_training IT
inner join Internal_training_history ITH on (ITH.trainingIn_id = IT.trainingIn_id)
where IT.course_id = '19023'
 


Select IT.trainingIn_id,IT.course_id,E.emp_id,E.emp_name,E.emp_lastname,E.emp_level,E.emp_position,E.emp_department,E.emp_division
from Internal_training_history ITH
inner join Employees E on (E.emp_id = ITH.emp_id)
inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id)
where IT.course_id = '19023'
 

 select *
 from Employees
 where emp_id != 'F1908001'
 (Select E.emp_id
from Employees E
inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id)
inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id)
where IT.course_id = '19010' );


Select IT.course_id, E.emp_id,E.emp_name,E.emp_lastname,E.emp_level,E.emp_position,E.emp_department,E.emp_division
from Employees E
inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id)
inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id)
where IT.course_id != '19011' 




SELECT DISTINCT  *
from  Employees E 
LEFT join Internal_training_history ITH  on (E.emp_id = ITH.emp_id)
where ITH.course_id !='19010'


select *
from Employees
where emp_id not in
(Select E.emp_id
from Employees E
inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id)
inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id)
where IT.course_id = '19001' );

select Ei.Expert,EI.Food_expert,EI.Snack,EI.Course,EI.Total 
from Expenses_in EI
inner join Internal_training IT on EI.trainingIn_id = IT.trainingIn_id
where Ei.trainingIn_id = '1910007'


select *
from Expenses_in
where Date_in  between '2019/10/01' and '2019/10/30'



select ITH.trainingIn_id
from Internal_training_history ITH
inner join Employees E on ITH.emp_id = E.emp_id
where E.emp_id = 'F1908001'


select C.course_id,C.course_name,f.format_name,g.group_name,T.type_name
from Course C
inner join format_course F on F.format_id = C.format_id
inner join group_course G on G.group_id = C.group_id
inner join type_course T on t.type_id = C.type_id 
where C.course_id in
(select it.course_id
from Internal_training IT
inner join Internal_training_history ITH on (ITH.trainingIn_id = it.trainingIn_id)
inner join Employees E on (ITH.emp_id = E.emp_id)
where E.emp_id = 'F1908001')



select C.course_id,C.course_name,f.format_name,g.group_name,T.type_name
from Course C
inner join format_course F on F.format_id = C.format_id
inner join group_course G on G.group_id = C.group_id
inner join type_course T on t.type_id = C.type_id 
where C.course_id in
(select ET.course_id
from External_training ET
inner join External_training_history ETH on (ETH.trainingEx_id = Et.trainingEx_id)
inner join Employees E on (ETH.emp_id = E.emp_id)
where E.emp_id = 'F1908001')


select *
from Employees
where emp_id in
(Select E.emp_id
from Employees E
inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id)
inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id)
where IT.course_id = '19001' );





select *
from Employees
where emp_department = 'เครื่องกล' and emp_id not in
(Select E.emp_id
from Employees E
inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id)
inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id)
where IT.course_id = '19001' );



select *
from Employees				
where emp_department = 'สต็อควัตถุดิบ' and emp_id in
(Select E.emp_id
from Employees E
inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id)
inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id)
where IT.course_id = '19001' );
