USE [info_management]
GO

/****** Object:  StoredProcedure [dbo].[p_addUnlockKey]    Script Date: 08/12/2017 00:27:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nandakumar
-- Create date: 01 Sep 2017
-- Description:	Procedure for adding a record to 
-- =============================================
CREATE PROCEDURE [dbo].[p_addUnlockKey] 
	-- Add the parameters for the stored procedure here
	@AdminUnlockKey nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	delete from admin_unlockkey;
	insert into admin_unlockkey (AdminUnlockKey) VALUES (@AdminUnlockKey);
	commit;
END


GO


