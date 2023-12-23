
alter Procedure sp_ConfirmForgetPassword  
 -- Add the parameters for the stored procedure here  
@LoginId varchar(50)=null,  
@Email varchar(50) =null,  
@NewPassword varchar(50)  
AS  
BEGIN  
 if exists(select 1 from MemberLogin inner join MemberDetails on MemberLogin.Pk_Id=MemberDetails.Fk_MemId  where LoginId=@LoginId and MemberDetails.Email=@Email)  
 begin  
  Update MemberLogin  set Password=@NewPassword where LoginId=@LoginId   
  if @@ROWCOUNT>0  
  begin  
   select 1 as Code,'Your Password Successfully Updated'as Remark  
  end  
  else  
  begin  
   select 0 as Code,'Unable to Update'as Remark  
  end  
 end  
 else  
 begin  
  select 0 as Code,'LoginId Or Email Is Incorrect'as Remark  
 end  
   
END  
  
  
  
  
  