USE [nandarte_ntechadviser1]
GO

/****** Object:  StoredProcedure [dbo].[p_updateDebitData]    Script Date: 08/12/2017 00:28:16 ******/
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
	@UpdatedDate date,
	@Credit money,
	@Debit money,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE credit_debit_info SET Project=@Project, 
	Particulars=@Particulars, UpdatedBy=@UpdatedBy, DateUpdated=@UpdatedDate, Debit=@Debit, Credit=@Credit, Details=@Details, Tag=@Tag WHERE
	CreDebRecID=@CreDebRecID;
END




GO


