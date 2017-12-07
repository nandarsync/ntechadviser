USE [nandarte_ntechadviser1]
GO

/****** Object:  StoredProcedure [dbo].[p_addStockAndAccountsData]    Script Date: 08/12/2017 00:26:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:		Nandakumar
-- Create date: 01 Sep 2017
-- Description:	Procedure for adding a record to 
-- =============================================
CREATE PROCEDURE [dbo].[p_addStockAndAccountsData] 
	-- Add the parameters for the stored procedure here
	@Project nvarchar(50),
	@Particulars nvarchar(150),
	@Item nvarchar(50),
	@SlipNo nvarchar(150),
	@InwardBillNo nvarchar(150),
	@Volume nvarchar(150),
	@QuantityIn float,
	@QuantityOut float,
	@Reference nvarchar(300),
	@ItemSize nvarchar(50),
	@CreatedBy nvarchar(50),
	@UpdatedBy nvarchar(50),
	@CreatedDate date,
	@UpdatedDate date,
	@VehicleNo nvarchar(50),
	@PayMode nvarchar(50),
	@BankDetails nvarchar(50),
	@PayModeReference nvarchar(100),
	@Debit money,
	@Credit money,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	insert into stock_info (Project, Particulars, Item, SlipNo, InwardBillNo, Volume, QuantityIn, QuantityOut, Reference, VehicleNo, Details, Tag, ItemSize, CreatedBy, UpdatedBy, DateCreated, DateUpdated)
	VALUES (@Project,@Particulars, @Item, @SlipNo, @InwardBillNo, @Volume, @QuantityIn, @QuantityOut, @Reference, @VehicleNo, @Details, @Tag, @ItemSize, @CreatedBy, @UpdatedBy, @CreatedDate, @UpdatedDate);

	insert into accounts_info (Project, Particulars, PayMode, BankDetails, PayModeReference, Debit, Credit, Details, Tag, CreatedBy, UpdatedBy, DateCreated, DateUpdated)
	VALUES (@Project,@Particulars, @PayMode, @BankDetails, @PayModeReference, @Debit, @Credit, @Details, @Tag, @CreatedBy, @UpdatedBy, @CreatedDate, @UpdatedDate);


END









GO


