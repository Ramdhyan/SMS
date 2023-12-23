--[dbo].[ForgetPassword]   
alter Procedure sp_ForgetPassword   
@Email varchar(50)=null,  
@LoginId varchar(50)=null  
AS  
BEGIN  
    if exists(select MemberLogin.Pk_Id from MemberDetails inner Join  MemberLogin on MemberLogin.Pk_Id=MemberDetails.Fk_MemId where ( Email=@Email ) and MemberLogin.LoginId=@LoginId)  
 begin  
 select 1 as Code ,error_message() as Remark,LoginId,MemberLogin.Name ,Password,MemberDetails.Email,MemberDetails.Email as Email  
 from MemberLogin inner join MemberDetails on MemberLogin.Pk_Id=MemberDetails.Fk_MemId where  MemberLogin.isdeleted=0  and LoginId=@LoginId  
 end  
 else  
 Select 0 as Code,'Login Id  Or Email Invalid' as Remark  
 End  
  
  
  
  
  
  
  
  