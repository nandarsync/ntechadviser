USE [info_management]
GO

/****** Object:  StoredProcedure [dbo].[p_updateStockData]    Script Date: 08/12/2017 00:28:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		Nandakumar
-- Create date: 01 Sep 2017
-- Description:	Procedure for adding a record to 
-- =============================================
CREATE PROCEDURE [dbo].[p_updateStockData] 
	-- Add the parameters for the stored procedure here
	@RecordID bigint,
	@Project nvarchar(50),
	@Particulars nvarchar(150),
	@UpdatedBy nvarchar(50),
	@UpdatedDate date,
	@Item nvarchar(50),
	@SlipNo nvarchar(150),
	@InwardBillNo nvarchar(150),
	@Volume nvarchar(150),
	@QuantityIn float,
	@QuantityOut float,
	@Reference nvarchar(300),
	@ItemSize nvarchar(50),
	@VehicleNo nvarchar(50),
	@Credit money,
	@Debit money,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE stock_info SET Project=@Project, 
	Particulars=@Particulars, UpdatedBy=@UpdatedBy, Item=@Item, SlipNo=@SlipNo, InwardBillNo=@InwardBillNo, Volume=@Volume, Reference=@Reference, QuantityIn=@QuantityIn, QuantityOut=@QuantityOut, ItemSize=@ItemSize, VehicleNo=@VehicleNo, DateUpdated=@UpdatedDate, Debit=@Debit, Credit=@Credit, Details=@Details, Tag=@Tag WHERE
	RecordID=@RecordID;
END





GO


