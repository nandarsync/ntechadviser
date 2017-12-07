USE [nandarte_ntechadviser1]
GO

/****** Object:  Table [dbo].[credit_debit_info]    Script Date: 08/12/2017 00:23:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[credit_debit_info](
	[CreDebRecID] [bigint] IDENTITY(1,1) NOT NULL,
	[Project] [nvarchar](50) NULL,
	[Particulars] [nvarchar](150) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[DateCreated] [date] NULL CONSTRAINT [DF_debit_info_DateCreated]  DEFAULT (sysdatetime()),
	[UpdatedBy] [nvarchar](50) NULL,
	[DateUpdated] [date] NULL CONSTRAINT [DF_debit_info_DateUpdated]  DEFAULT (sysdatetime()),
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[Details] [nvarchar](300) NULL,
	[Tag] [nvarchar](300) NULL,
 CONSTRAINT [PK_credit_debit_info] PRIMARY KEY CLUSTERED 
(
	[CreDebRecID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


