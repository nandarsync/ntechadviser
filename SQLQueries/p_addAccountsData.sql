USE [info_management]
GO

/****** Object:  StoredProcedure [dbo].[p_addAccountsData]    Script Date: 08/12/2017 00:26:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		Nandakumar
-- Create date: 01 Sep 2017
-- Description:	Procedure for adding a record to 
-- =============================================
CREATE PROCEDURE [dbo].[p_addAccountsData] 
	-- Add the parameters for the stored procedure here
	@Project nvarchar(50),
	@Particulars nvarchar(150),
	@PayMode nvarchar(50),
	@BankDetails nvarchar(50),
	@PayModeReference nvarchar(100),
	@Debit money,
	@Credit money,
	@PendingDebit money,
	@PendingCredit money,
	@CreatedBy nvarchar(50),
	@UpdatedBy nvarchar(50),
	@DateCreated date,
	@DateUpdated date,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	insert into accounts_info (Project, Particulars, CreatedBy, UpdatedBy, PayMode, BankDetails, PayModeReference, Debit, Credit, Details, Tag, DateCreated, DateUpdated)
	VALUES (@Project,@Particulars, @CreatedBy, @UpdatedBy, @PayMode, @BankDetails, @PayModeReference, @Debit, @Credit, @Details, @Tag, @DateCreated, @DateUpdated);

	insert into credit_debit_info (Project, Particulars, CreatedBy, UpdatedBy, Debit, Credit, Details, Tag, DateCreated, DateUpdated)
	VALUES (@Project, @Particulars, @CreatedBy, @UpdatedBy, @PendingDebit, @PendingCredit, @Details, @Tag, @DateCreated, @DateUpdated);
END


GO


