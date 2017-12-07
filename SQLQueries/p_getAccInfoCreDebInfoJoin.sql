USE [nandarte_ntechadviser1]
GO

/****** Object:  StoredProcedure [dbo].[p_getAccInfoCreDebInfoJoin]    Script Date: 08/12/2017 00:27:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[p_getAccInfoCreDebInfoJoin] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	select 
accounts_info.RecordID "REC_ID_ACC_INFO",
accounts_info.DateUpdated "DATE_ACC_INFO",
accounts_info.UpdatedBy "UPDATED_BY_ACC_INFO",
accounts_info.Project "PROJ_ACC_INFO",
accounts_info.Particulars "PART_ACC_INFO",
accounts_info.PayMode "PAYMODE_ACC_INFO",
accounts_info.PayModeReference "PAY_REF_ACC_INFO",
accounts_info.BankDetails "BANK_DET_ACC_INFO",
accounts_info.Debit "DEBIT_ACC_INFO",
accounts_info.Credit "CREDIT_ACC_INFO",
accounts_info.Details "DETAILS_ACC_INFO",
accounts_info.Tag "TAG_ACC_INFO",
'account_info' "TABLE_REF"
from accounts_info
UNION select
credit_debit_info.CreDebRecID,
credit_debit_info.DateUpdated,
credit_debit_info.UpdatedBy,
credit_debit_info.Project,
credit_debit_info.Particulars,
null,
null,
null,
credit_debit_info.Debit,
credit_debit_info.Credit,
credit_debit_info.Details,
credit_debit_info.Tag,
'credit_debit_info'
from credit_debit_info;
END

GO


