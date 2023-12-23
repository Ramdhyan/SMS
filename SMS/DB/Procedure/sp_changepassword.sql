alter proc sp_changepassword --1,'AD543216','987654','123456','123456',null
@Pk_Id int,
@LoginId nvarchar(100),
@OldPassword  nvarchar(100),
@NewPassword  nvarchar(100),
@ConfirmPassword  nvarchar(100),
@CreatedBy int=null
as
begin 
if not exists(select*from MemberLogin where Pk_Id=@Pk_Id and LoginId=@LoginId and Password=@OldPassword and IsDeleted=0)
begin 
select 0 as Code,'Enter Correct Old Password' as Remark
end
else if(@NewPassword<>@ConfirmPassword)
begin 
select 0 as Code ,'Password do not match 'as Remark
end
else
begin 
declare @Remark nvarchar(100)
set @Remark=(@OldPassword + ' '+ 'Password is Changed to '+ ' '+ @NewPassword)
update MemberLogin set Password=@NewPassword,UpdatedBy=@CreatedBy,updatedDate=GETDATE() where Pk_Id=@Pk_Id
select 1 as Code, 'Password changed successfully ' as Remark
end
end