USE [nandarte_ntechadviser]
GO

/****** Object:  StoredProcedure [dbo].[p_addAccountsData]    Script Date: 12/11/2017 16:46:54 ******/
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
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	insert into accounts_info (Project, Particulars, PayMode, BankDetails, PayModeReference, Debit, Credit, PendingDebit, PendingCredit, Details, Tag)
	VALUES (@Project,@Particulars, @PayMode, @BankDetails, @PayModeReference, @Debit, @Credit, @PendingDebit, @PendingCredit, @Details, @Tag);
END

GO


