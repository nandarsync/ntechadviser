USE [nandarte_ntechadviser]
GO

/****** Object:  StoredProcedure [dbo].[p_addDebitData]    Script Date: 12/11/2017 16:47:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Nandakumar
-- Create date: 01 Sep 2017
-- Description:	Procedure for adding a record to 
-- =============================================
CREATE PROCEDURE [dbo].[p_addDebitData] 
	-- Add the parameters for the stored procedure here
	@Project nvarchar(50),
	@Particulars nvarchar(150),
	@CreatedBy nvarchar(50),
	@UpdatedBy nvarchar(50),
	@Credit money,
	@Debit money,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	insert into credit_debit_info (Project, Particulars, CreatedBy, UpdatedBy, Debit, Credit, Details, Tag)
	VALUES (@Project,@Particulars, @CreatedBy, @UpdatedBy, @Debit, @Credit, @Details, @Tag);
END


GO


