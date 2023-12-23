create table Student (
Pk_Sid int identity primary key,
Name nvarchar(100),
FatherName nvarchar(100),
MotherName nvarchar(100),
ParentPhone nvarchar(100),
Email nvarchar(100),
Mobile nvarchar(100),
Gender nvarchar(100),
ProfilePic nvarchar(max),
City nvarchar(100),
State nvarchar(100),
PinCode nvarchar(100),
Address nvarchar(100),
CreatedDate Datetime,
UpdatedDate datetime,
UpdatedBy int,
CreatedBy int,
IsDeleted bit
);

