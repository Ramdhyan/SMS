create table Teachers
(
Pk_Tid int identity primary key,
Name nvarchar(100),
Email nvarchar(100),
Mobile nvarchar(100),
Gender nvarchar(100),
DOB Datetime,
ProfilePic nvarchar(max),
Qualification nvarchar(100),
Address nvarchar(max),
JoningDate datetime,
SpecificSubject nvarchar(100),
Salary decimal(18,2),
Experience int,
City nvarchar(100),
State nvarchar(100),
PinCode int,
CreatedDate Datetime,
UpdatedDate datetime,
UpdatedBy int,
CreatedBy int,
IsDeleted bit
);
