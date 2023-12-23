--use sms

--sp_helptext checkuserlogin


alter proc CheckUserLogin  
@UserName nvarchar(100),  
@Password nvarchar(100)  
as  
begin   
begin try  
  
if exists(select Pk_id,profilePic from MemberLogin where LoginId=@UserName and Password=@Password and IsDeleted=0)  
  BEGIN
select 'Success' as Remark,'1' as Code,um.UserType,Pk_Id,profilepic,name,loginId,Password,Fk_UserTypeId,ml.IsDeleted from MemberLogin as  ml join UserTypeMaster as um on ml.Fk_UserTypeId=um.Pk_UserTypeId where LoginId=@UserName and Password=@Password
end
else
begin 
RAISERROR('LoginId and Password not Correct', 12, 1);
end
end try  
begin catch  
select 0 as Code,ERROR_MESSAGE() as Remark  
end catch  
end


--select*from MemberLogin