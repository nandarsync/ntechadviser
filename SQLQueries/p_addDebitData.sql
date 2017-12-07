USE [nandarte_ntechadviser1]
GO

/****** Object:  StoredProcedure [dbo].[p_addDebitData]    Script Date: 08/12/2017 00:26:37 ******/
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
	@DateCreated date,
	@DateUpdated date,
	@Credit money,
	@Debit money,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	insert into credit_debit_info (Project, Particulars, CreatedBy, UpdatedBy, Debit, Credit, Details, Tag, DateCreated, DateUpdated)
	VALUES (@Project,@Particulars, @CreatedBy, @UpdatedBy, @Debit, @Credit, @Details, @Tag, @DateCreated, @DateUpdated);
END



GO


