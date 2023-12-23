alter proc sp_GetAllStudent
 @Name NVARCHAR(100) = NULL,
 @Email NVARCHAR(100) = NULL,
  @Mobile NVARCHAR(100) = NULL,
   @Gender NVARCHAR(100) = NULL

as
begin 
select*from Student where (ISNULL(@Name,'')=''  or Name like '%'+@Name+ '%') AND (ISNULL(@Email,'')='' or Email like '%'+@Email+ '%') AND
(ISNULL(@Mobile,'')='' or Mobile like '%'+@Mobile+ '%') AND (ISNULL(@Gender,'')='' or GEnder like '%'+@Gender+ '%')

end