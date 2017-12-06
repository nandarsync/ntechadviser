USE [info_management]
GO

/****** Object:  Table [dbo].[stock_cargo_info]    Script Date: 12/11/2017 16:45:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[stock_cargo_info](
	[StockID] [bigint] IDENTITY(1,1) NOT NULL,
	[DateCreated] [date] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[DateUpdated] [date] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[Project] [nvarchar](50) NULL,
	[Particulars] [nvarchar](50) NULL,
	[MeasurementIn] [decimal](18, 3) NULL,
	[MeasurementOut] [decimal](18, 3) NULL,
	[Unit] [nvarchar](10) NULL,
	[PickupPoint] [nvarchar](150) NULL,
	[DropPoint] [nvarchar](150) NULL,
	[PickupDate] [date] NULL,
	[DropDate] [date] NULL,
	[VehicleType] [nvarchar](25) NULL,
	[VehicleNumber] [nvarchar](50) NULL,
	[PayMode] [nvarchar](50) NULL,
	[PayModeReference] [nvarchar](100) NULL,
	[BankDetails] [nvarchar](50) NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[VehicleRent] [nchar](10) NULL,
	[VehicleRentPaymentMode] [nvarchar](50) NULL,
	[VehicleRentPayModeRef] [nchar](10) NULL,
	[VehicleRentBankDetails] [nchar](10) NULL,
	[VehicleRentDebit] [nchar](10) NULL,
	[VehicleRentCredit] [nchar](10) NULL,
	[Details] [nvarchar](300) NULL,
	[Tag] [nvarchar](300) NULL,
 CONSTRAINT [PK_stock_cargo_info] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


