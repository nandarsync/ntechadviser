USE [info_management]
GO

/****** Object:  StoredProcedure [dbo].[p_addUserInfo]    Script Date: 08/12/2017 00:27:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nandakumar
-- Create date: 01 Sep 2017
-- Description:	Procedure for adding a record to 
-- =============================================
CREATE PROCEDURE [dbo].[p_addUserInfo] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(50),
	@UserEmail nvarchar(50),
	@Type int,
	@Password nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	insert into user_info (UserName, UserEmail, Type, Password)
	VALUES (@UserName,@UserEmail, @Type, @Password);
END


GO


