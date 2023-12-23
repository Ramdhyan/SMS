CREATE proc sp_ViewProfile  
@Pk_Id int   
as  
begin   
if exists(select 1 from Student)  
begin   
select  1 as Code,'Success' as Remark,pk_id,Pk_Sid,s.Name,FatherName,Mobile,MotherName,ParentPhone,Email,Gender,
s.ProfilePic,City,State,PinCode,Address,AadharNo,Session,Class,s.CreatedDate,DOB from Student as S
left join MemberLogin as ml on s.Pk_Sid=ml.FK_MemId where ml.Pk_Id=@Pk_Id  
end  
else  
begin   
select 0 as Code,ERROR_MESSAGE() as Remark  
end  
end  
  