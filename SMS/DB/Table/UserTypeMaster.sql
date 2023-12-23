--use sms
create table  UserTypeMaster
(
Pk_UserTypeId int Identity Primary key,
UserType nvarchar(100),
CreatedBy int,
DeletedBy int,
UpdatedBy int,
CreatedDate datetime,
UpdatedDate datetime,
DeletedDate datetime,
IsDeleted bit
);

--select*from UserTypeMaster
--insert into UserTypeMaster values('Management',null,null,null,GETDATE(),null,null,0);