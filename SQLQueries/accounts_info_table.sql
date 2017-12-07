USE [nandarte_ntechadviser1]
GO

/****** Object:  Table [dbo].[accounts_info]    Script Date: 08/12/2017 00:22:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[accounts_info](
	[RecordID] [bigint] IDENTITY(1,1) NOT NULL,
	[DateCreated] [date] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[DateUpdated] [date] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[Project] [nvarchar](50) NULL,
	[Particulars] [nvarchar](150) NULL,
	[PayMode] [nvarchar](50) NULL,
	[PayModeReference] [nvarchar](100) NULL,
	[BankDetails] [nvarchar](50) NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[Details] [nvarchar](300) NULL,
	[Tag] [nvarchar](300) NULL,
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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Any comments you have to remember anytime?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Details'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional field to use in future.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info', @level2type=N'COLUMN',@level2name=N'Tag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Accounts Information Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'accounts_info'
GO


