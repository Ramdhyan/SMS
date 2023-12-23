--use sms

create table MemberLogin(
Pk_Id int identity primary key,
Name varchar(100),
LoginId nvarchar(100),
Password nvarchar(100),
Fk_UserTypeId int,
ProfilePic nvarchar(max),
IsDeleted bit,
CreatedBy int,
UpdatedBy int,
DeletedBy int,
CreatedDate datetime,
updatedDate datetime,
DeletedDate datetime);
