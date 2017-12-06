USE [nandarte_ntechadviser]
GO

/****** Object:  StoredProcedure [dbo].[p_updateDebitData]    Script Date: 12/11/2017 16:49:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nandakumar
-- Create date: 01 Sep 2017
-- Description:	Procedure for adding a record to 
-- =============================================
CREATE PROCEDURE [dbo].[p_updateDebitData] 
	-- Add the parameters for the stored procedure here
	@CreDebRecID bigint,
	@Project nvarchar(50),
	@Particulars nvarchar(150),
	@UpdatedBy nvarchar(50),
	@Credit money,
	@Debit money,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE credit_debit_info SET Project=@Project, 
	Particulars=@Particulars, UpdatedBy=@UpdatedBy, DateUpdated=GETDATE(), Debit=@Debit, Credit=@Credit, Details=@Details, Tag=@Tag WHERE
	CreDebRecID=@CreDebRecID;
END



GO


