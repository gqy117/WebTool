CREATE PROC [dbo].[SelectUser]
@UserId INT ,
@UserName NVARCHAR(50) = ''
AS 
begin 

SELECT * FROM [dbo].[Users] WHERE UserId = @UserId
END