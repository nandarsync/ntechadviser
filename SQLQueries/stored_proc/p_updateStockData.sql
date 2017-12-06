USE [nandarte_ntechadviser]
GO

/****** Object:  StoredProcedure [dbo].[p_updateStockData]    Script Date: 12/11/2017 16:50:10 ******/
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
	@Item nvarchar(50),
	@UnitsIn float,
	@UnitsOut float,
	@VehicleNo nvarchar(50),
	@Credit money,
	@Debit money,
	@Details nvarchar(300),
	@Tag nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE stock_info SET Project=@Project, 
	Particulars=@Particulars, UpdatedBy=@UpdatedBy, Item=@Item, UnitsIn=@UnitsIn, @UnitsOut=@UnitsOut, VehicleNo=@VehicleNo, DateUpdated=GETDATE(), Debit=@Debit, Credit=@Credit, Details=@Details, Tag=@Tag WHERE
	RecordID=@RecordID;
END

GO


