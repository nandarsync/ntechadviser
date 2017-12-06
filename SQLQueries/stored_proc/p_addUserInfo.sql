-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
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
