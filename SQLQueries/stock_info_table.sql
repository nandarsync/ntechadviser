USE [info_management]
GO

/****** Object:  Table [dbo].[stock_info]    Script Date: 08/12/2017 00:24:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[stock_info](
	[RecordID] [bigint] IDENTITY(1,1) NOT NULL,
	[DateCreated] [date] NOT NULL CONSTRAINT [DF_stock_info_Date]  DEFAULT (sysdatetime()),
	[CreatedBy] [nvarchar](50) NULL,
	[DateUpdated] [date] NOT NULL CONSTRAINT [DF_stock_info_DateUpdated]  DEFAULT (sysdatetime()),
	[UpdatedBy] [nvarchar](50) NULL,
	[Project] [nvarchar](50) NULL,
	[Particulars] [nvarchar](150) NULL,
	[SlipNo] [nvarchar](150) NULL,
	[InwardBillNo] [nvarchar](150) NULL,
	[Volume] [nvarchar](150) NULL,
	[Item] [nvarchar](50) NULL,
	[QuantityIn] [float] NULL,
	[QuantityOut] [float] NULL,
	[ItemSize] [nvarchar](50) NULL,
	[VehicleNo] [nvarchar](50) NULL,
	[Details] [nvarchar](300) NULL,
	[Tag] [nvarchar](300) NULL,
	[Reference] [nvarchar](300) NULL,
 CONSTRAINT [PK_stock_info] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


