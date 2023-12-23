create table MemberDetails
(
Fk_MemId int,
Name nvarchar(100),
FatherName nvarchar(100),
MotherName nvarchar(100),
Email nvarchar(100),
MobileNo nvarchar(100),
Gender nvarchar(100),
DOB nvarchar(100),
Age int,
MeritalStatus nvarchar(100),
ProfilePic nvarchar(max),
Qualification nvarchar(100),
City nvarchar(100),
State nvarchar(100),
Address nvarchar(100),
Designation nvarchar(100),
PinCode nvarchar(100),
IsDeleted bit,
IsUpdated bit,
CreatedDate datetime,
UpdatedDate Datetime,
Fk_UserTypeId int
);


--select*from MemberLogin