alter proc sp_StudentDetails 
@Pk_Id int 
as
begin 
if exists(select 1 from Student)
begin 
select  1 as Code,'Success' as Remark,Pk_Sid,Name,FatherName,Mobile,MotherName,ParentPhone,Email,Gender,ProfilePic,City,State,PinCode,Address,AadharNo,Session,Class,CreatedDate,DOB from Student where Pk_Sid=@Pk_Id
end
else
begin 
select 0 as Code,ERROR_MESSAGE() as Remark
end
end


