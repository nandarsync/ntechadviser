USE [info_management]
GO

/****** Object:  Table [dbo].[accounts_info]    Script Date: 12/11/2017 16:43:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[accounts_info](
	[RecordID] [bigint] IDENTITY(1,1) NOT NULL,
	[DateCreated] [date] NOT NULL CONSTRAINT [DF_accounts_info_Date]  DEFAULT (sysdatetime()),
	[CreatedBy] [nvarchar](50) NULL,
	[DateUpdated] [date] NOT NULL CONSTRAINT [DF_accounts_info_DateUpdated]  DEFAULT (sysdatetime()),
	[UpdatedBy] [nvarchar](50) NULL,
	[Project] [nvarchar](50) NULL,
	[Particulars] [nvarchar](150) NULL,
	[PayMode] [nvarchar](50) NULL,
	[PayModeReference] [nvarchar](100) NULL,
	[BankDetails] [nvarchar](50) NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[PendingDebit] [money] NULL,
	[PendingCredit] [money] NULL,
	[Details] [nvarchar](300) NULL,
	[Tag] [nvarchar](300) NULL,
	[StockCargoID] [bigint] NULL,
 CONSTRAINT [PK_accounts_info] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Current date when this field is entered.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'DateCreated'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Project Name - eg. Amritha School' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Project'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details of entry - eg. Venkatesh Mason' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Particulars'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cheque/Cash/AccountTransfer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'PayMode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details of transfer - Say ChequeNo./If Account transfer then transaction number, etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'PayModeReference'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Debited money' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Debit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Credited money' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Credit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pending amount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'PendingDebit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pending amount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'PendingCredit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments you have to remember anytime?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Details'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional field to use in future.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Tag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Accounts Information Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info'
GO


