CREATE proc sp_StudentRegistration  
@Name varchar(100)=null,  
@FatherName varchar(100)=null,  
@MotherName varchar(100)=null,  
@ParentPhone varchar(100)=null,  
@Email varchar(100)=null,  
@Mobile varchar(100)=null,  
@Gender varchar(100)=null,  
@ProfilePic nvarchar(max)=null,  
@City varchar(100)=null,  
@State varchar(100)=null,  
@Pincode varchar(100)=null,  
@Address varchar(100)=null,  
@Class varchar(100)=null,  
@Session varchar(100)=null,  
@AadharNo varchar(100)=null,  
@DOB varchar(100)=null,  
@CreatedBy  int=null,  
@UpdatedBy int=null,  
@UserType int=null,  
@DeletedBy int=null,  
@Fk_UserTypeId int=null  
as  
begin   
Declare @FK_MemId int,@LoginId nvarchar(max),@Password nvarchar(max)  
set @LoginId=(select('STU' + CAST(FLOOR(RAND() * 1000000 - 100000 + 100000) AS VARCHAR(6))))  
SET @Password = (select('PASS' + CAST(FLOOR(RAND() * 1000000 - 100000 + 100000) AS VARCHAR(6))))  
begin try  
if not exists(select Email,Name from Student Where Email=@Email)  
begin  
insert into Student(Name,FatherName,MotherName,ParentPhone,Email,Mobile,Gender,ProfilePic,City,State,PinCode,Address,AadharNo,Session,Class,CreatedDate,UpdatedDate,UpdatedBy,CreatedBy,IsDeleted,DOB)  
values(@Name,@FatherName,@MotherName,@ParentPhone,@Email,@Mobile,@Gender,@ProfilePic,@City,@State,@Pincode,@Address,@AadharNo,@Session,@Class,GETDATE(),GETDATE(),@UpdatedBy,@CreatedBy,0,@DOB);  
Set @FK_MemId=SCOPE_IDENTITY();  
insert into MemberLogin(Name,LoginId,Password,Fk_UserTypeId,ProfilePic,IsDeleted,CreatedBy,UpdatedBy,DeletedBy,CreatedDate,updatedDate,DeletedDate,FK_MemId) values  
(@Name,@LoginId,@Password,3,@ProfilePic,0,@CreatedBy,@UpdatedBy,@DeletedBy,GETDATE(),GETDATE(),GETDATE(),@FK_MemId);  
select 1 as Code,'Registration Success' as Remark,@LoginId as LoginId,@Password as Password  
end  
else  
begin   
select 0 as Code,'User Already Exists' as Remark  
  
end  
end try  
begin catch  
select 0 as Code,ERROR_MESSAGE() as Remark  
end catch  
end  
  
--select*from memberlogin  
--select*from memberDetails  
  
--select* from Student  
  
  
  
  