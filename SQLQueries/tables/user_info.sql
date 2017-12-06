USE [info_management]
GO

/****** Object:  Table [dbo].[user_info]    Script Date: 12/11/2017 16:45:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_info](
	[UserID] [int] IDENTITY(1000,1) NOT NULL,
	[UserEmail] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Password] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_info] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'administrator-1; general user-0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'user_info', @level2type=N'COLUMN',@level2name=N'Type'
GO


