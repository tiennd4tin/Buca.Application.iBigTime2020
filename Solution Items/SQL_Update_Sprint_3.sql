--===================================================================UPDATE TABLE STRUCTURE================================================================================================
DELETE FROM [dbo].[ReportList] WHERE [ReportID] = N'S51H'
DELETE FROM [dbo].[ReportList] WHERE [ReportID] = N'B03b_BCTC'
DELETE FROM [dbo].[ReportList] WHERE [ReportID] = N'N01_SDKP_DVDT'
DELETE FROM [dbo].[ReportList] WHERE [ReportID] = N'N02_SDKP_DVDT'
DELETE FROM [dbo].[ReportList] WHERE [ReportID] = N'CashInBankConfirmationBalanceSheet'
DELETE FROM ReportList WHERE ReportID = 'TUDT'

INSERT [dbo].[ReportList] ([ReportID], [ReportName], [Description], [ReportFile], [OutputAssembly], [InputTypeName], [FunctionReportName], [ProcedureName], [TableName], [TrackType], [ProcNameByLot], [ProcNameVoucherList], [Inactive], [PrintVoucherDefault], [LicenceType], [RefType], [Particularity], [SortOrder], [IsReportBeConfigured], [Standard], [AllowBatchPrinting], [GetParamFromDialog], [DataBandSortReportID], [ReportType], [ParentID], [Level], [Visible]) VALUES (N'S01_H', N'S01-H: Nhật ký sổ cái ', NULL, N'S03-H1.rst', NULL, N'CashReport', N'GetReportS01HLedger', N'uspReport_S03H1', N'GL_DETAIL', 0, NULL, NULL, 0, 0, 100, 0, 0, NULL, 0, 1, NULL, NULL, NULL, 0, N'2', 1, 1)
INSERT [dbo].[ReportList] ([ReportID], [ReportName], [Description], [ReportFile], [OutputAssembly], [InputTypeName], [FunctionReportName], [ProcedureName], [TableName], [TrackType], [ProcNameByLot], [ProcNameVoucherList], [Inactive], [PrintVoucherDefault], [LicenceType], [RefType], [Particularity], [SortOrder], [IsReportBeConfigured], [Standard], [AllowBatchPrinting], [GetParamFromDialog], [DataBandSortReportID], [ReportType], [ParentID], [Level], [Visible]) VALUES (N'S51H', N'S51-H: Sổ chi tiết doanh thu sản xuất, kinh doanh, dịch vụ', NULL, N'S51H.rst', NULL, N'ReportLedgerAccounting', N'GetReportS51H', N'uspReport_S51H', N'GL_DETAIL', 0, NULL, NULL, 0, 0, 100, 0, 0, NULL, 0, 1, NULL, NULL, NULL, 0, N'2', 1, 1)
INSERT [dbo].[ReportList] ([ReportID], [ReportName], [Description], [ReportFile], [OutputAssembly], [InputTypeName], [FunctionReportName], [ProcedureName], [TableName], [TrackType], [ProcNameByLot], [ProcNameVoucherList], [Inactive], [PrintVoucherDefault], [LicenceType], [RefType], [Particularity], [SortOrder], [IsReportBeConfigured], [Standard], [AllowBatchPrinting], [GetParamFromDialog], [DataBandSortReportID], [ReportType], [ParentID], [Level], [Visible]) VALUES (N'B03b_BCTC', N'B03b/BCTC: Báo cáo lưu chuyển tiền tệ (Theo phương pháp gián tiếp)', N'B03b/BCTC: Báo cáo lưu chuyển tiền tệ (Theo phương pháp gián tiếp)', N'B03b_BCTC.rst', NULL, N'FinacialReport', N'GetReportB03b_BCTC', N'uspReport_GetB03bBCTC', N'ReportData', 0, N'', N'', 0, 0, 100, 0, 0, N'', 0, 1, NULL, NULL, N'', 0, N'06', 1, 1)
INSERT [dbo].[ReportList] ([ReportID], [ReportName], [Description], [ReportFile], [OutputAssembly], [InputTypeName], [FunctionReportName], [ProcedureName], [TableName], [TrackType], [ProcNameByLot], [ProcNameVoucherList], [Inactive], [PrintVoucherDefault], [LicenceType], [RefType], [Particularity], [SortOrder], [IsReportBeConfigured], [Standard], [AllowBatchPrinting], [GetParamFromDialog], [DataBandSortReportID], [ReportType], [ParentID], [Level], [Visible]) VALUES (N'N01_SDKP_DVDT_2019', N'Mẫu số 01-SDKP/ĐVDT: Bảng đối chiếu dự toán kinh phí ngân sách tại Kho bạc', NULL, N'N01_SDKP_DVDT.rst', NULL, N'CashReport', N'GetN01_SDKP_DVDT', N'uspReport_N01_SDKP_DVDT', N'BALANCE_SHEET', 0, NULL, NULL, 0, 0, 78, 0, 0, NULL, 0, 0, NULL, NULL, NULL, 0, N'07', 1, 1)
INSERT [dbo].[ReportList] ([ReportID], [ReportName], [Description], [ReportFile], [OutputAssembly], [InputTypeName], [FunctionReportName], [ProcedureName], [TableName], [TrackType], [ProcNameByLot], [ProcNameVoucherList], [Inactive], [PrintVoucherDefault], [LicenceType], [RefType], [Particularity], [SortOrder], [IsReportBeConfigured], [Standard], [AllowBatchPrinting], [GetParamFromDialog], [DataBandSortReportID], [ReportType], [ParentID], [Level], [Visible]) VALUES (N'N02_SDKP_DVDT_2019', N'Mẫu số 02-SDKP/ĐVDT: Bảng đối chiếu tình hình sử dụng kinh phí ngân sách tại kho bạc nhà nước', NULL, N'N02_SDKP_DVDT_TT61.rst', NULL, N'CashReport', N'GetN02_SDKP_DVDT_TT77', N'uspReport_N02_SDKP_DVDT_TT77', N'BALANCE_SHEET', 0, NULL, NULL, 0, 0, 78, 0, 0, NULL, 0, 0, NULL, NULL, NULL, 0, N'07', 1, 1)
INSERT [dbo].[ReportList] ([ReportID], [ReportName], [Description], [ReportFile], [OutputAssembly], [InputTypeName], [FunctionReportName], [ProcedureName], [TableName], [TrackType], [ProcNameByLot], [ProcNameVoucherList], [Inactive], [PrintVoucherDefault], [LicenceType], [RefType], [Particularity], [SortOrder], [IsReportBeConfigured], [Standard], [AllowBatchPrinting], [GetParamFromDialog], [DataBandSortReportID], [ReportType], [ParentID], [Level], [Visible]) VALUES (N'CashInBankConfirmationBalanceSheet', N'Mẫu số: 05-ĐCSDTK/KBNN - Bảng xác nhận số dư tài khoản tiền gửi tại KBNN', N'Bảng xác nhận số dư tài khoản tiền gửi tại KBNN', N'CashInBankConfirmationBalanceSheet.rst', NULL, N'CashReport', N'GetCashInBankConfirmationBalanceSheet', N'uspReport_CashInBankConfirmationBalanceSheet', N'CashInBankConfirmationBalanceSheet', 0, NULL, NULL, 0, 0, 0, 0, 0, N'3.2', 0, 1, 0, NULL, NULL, 0, N'07', 1, 1)

--===================================================================END UPDATE TABLE STRUCTURE================================================================================================
--===================================================================UPDATE STORE PROCEDURE================================================================================================

/****** Object:  StoredProcedure [dbo].[uspReport_B02BCTC]    Script Date: 09/11/2018 19:29:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_B02BCTC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspReport_B02BCTC]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_GetB03bBCTC]    Script Date: 09/11/2018 19:29:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_GetB03bBCTC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspReport_GetB03bBCTC]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_N01_SDKP_DVDT_2019]    Script Date: 09/11/2018 19:29:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_N01_SDKP_DVDT_2019]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspReport_N01_SDKP_DVDT_2019]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_CashInBankConfirmationBalanceSheet]    Script Date: 09/11/2018 19:29:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_CashInBankConfirmationBalanceSheet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspReport_CashInBankConfirmationBalanceSheet]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_N02_SDKP_DVDT_2019]    Script Date: 09/11/2018 19:29:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_N02_SDKP_DVDT_2019]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspReport_N02_SDKP_DVDT_2019]
GO
/****** Object:  StoredProcedure [dbo].[uspDelete_GeneralLedger_ByAccountNumberAndRefType]    Script Date: 09/12/2018 11:08:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDelete_GeneralLedger_ByAccountNumberAndRefType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspDelete_GeneralLedger_ByAccountNumberAndRefType]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_S11H]    Script Date: 09/12/2018 11:08:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_S11H]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspReport_S11H]
GO
/****** Object:  StoredProcedure [dbo].[uspDelete_InventoryLedger_ByAccountNumberAndRefType]    Script Date: 09/13/2018 09:55:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDelete_InventoryLedger_ByAccountNumberAndRefType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspDelete_InventoryLedger_ByAccountNumberAndRefType]
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetVoucher_RealNameMethod]    Script Date: 09/13/2018 09:55:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_GetVoucher_RealNameMethod]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proc_GetVoucher_RealNameMethod]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_S03H1]    Script Date: 09/13/2018 15:05:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_S03H1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[uspReport_S03H1]
GO
/****** Object:  StoredProcedure [dbo].[uspReport_N02_SDKP_DVDT_2019]    Script Date: 09/13/2018 15:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_N02_SDKP_DVDT_2019]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		
-- Create date: 31/03/2018
-- Description:	BẢNG ĐỐI CHIẾU DỰ TOÁN KINH PHÍ NGÂN SÁCH TẠI KHO BẠC	
-- Update by: Tudt
-- Update Date: 22/08/2018											

--  [dbo].[uspReport_N02_SDKP_DVDT_2019] ''01-01-2018'', ''01-01-2018'', ''01-01-2018'', ''12-31-2018'',null,null,null,null,null,1,1,1,1,0,0,0
-- =============================================
CREATE PROCEDURE [dbo].[uspReport_N02_SDKP_DVDT_2019]
    @DBStartDate DATETIME ,
    @StartDate DATETIME ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @BudgetSourceID NVARCHAR(MAX) ,		--Nguồn
    @BudgetChapterCode NVARCHAR(20) = NULL ,		-- Chương
    @BudgetSubKindItemCode NVARCHAR(20) = NULL ,	-- Khoản
    @MethodDistributeID INT = NULL ,				-- Cấp phát
    @BudgetSourceKind INT = -1 ,
    @SummaryBudgetSource BIT ,
    @SummaryBudgetChapter BIT ,
    @SummaryBudgetSubKindItem BIT ,
    @SummaryMethodDistribute BIT ,
    @IsAdjustTemplete BIT ,						-- Mẫu tự chủ
    @IsPrintMonth13 BIT ,							-- In tháng chỉnh lý quyết toán
    @IsPrintAllYearAndMonth13 BIT  	  			-- Lấy số liệu của các chứng từ chỉnh lý quyết toán. (0: không lấy, 1: lấy)
AS
BEGIN

SET NOCOUNT ON;

	-- Liệt kê danh sách nguồn được chon
	DECLARE @BudgetSourceList AS TABLE
	(
		BudgetSourceID UNIQUEIDENTIFIER ,
		BudgetSourceCode NVARCHAR(20) ,
		BudgetSourceName NVARCHAR(255)
	)  
	
	IF @BudgetSourceID IS NOT NULL
	BEGIN
		INSERT INTO @BudgetSourceList
		SELECT  
			F.Value,
			BS.BudgetSourceCode,
			BS.BudgetSourceName
		FROM dbo.[Func_ConvertGUIStringIntoTable](@BudgetSourceID,'','') AS F
		INNER JOIN dbo.BudgetSource AS BS ON F.Value = BS.BudgetSourceID
	END
	ELSE IF @SummaryBudgetSource = 0 AND @BudgetSourceID IS NULL
	BEGIN
		INSERT INTO @BudgetSourceList
		SELECT  
			BudgetSourceID,			
			BudgetSourceCode,
			BudgetSourceName
		FROM dbo.BudgetSource
		WHERE IsActive = 1
	END
        
	CREATE TABLE #N01 
	(
		 BudgetChapterCode NVARCHAR(MAX)
		,BudgetSourceID NVARCHAR(MAX)
		,BudgetSubKindItemCode NVARCHAR(MAX)
		,MethodDistributeID NVARCHAR(MAX)
		,BudgetSourceKind INT
		,BudgettemCode NVARCHAR(20)
		,BudgetItemCode NVARCHAR(20)
		,BudgetSubItemCode NVARCHAR(20)
		,ProjectID NVARCHAR(50)
		,BudgetItemName NVARCHAR(300)
		,DebitAmount money
		,CreditAmount MONEY
		,SumDebit MONEY
		,SumCredit MONEY
	)

	CREATE TABLE #N02
	(
		 BudgetChapterCode NVARCHAR(MAX)
		,BudgetSourceID NVARCHAR(MAX)
		,BudgetSubKindItemCode NVARCHAR(MAX)
		,MethodDistributeID NVARCHAR(MAX)
		,BudgetSourceKind INT
		,BudgetItemCode NVARCHAR(20)
		,BudgetSubItemCode NVARCHAR(20)
		,ProjectID NVARCHAR(50)
		,BudgetItemName NVARCHAR(300)
		,DebitAmount money
		,CreditAmount MONEY
		,SumDebit MONEY
		,SumCredit MONEY
		,ItemType INT
		,Part INT
	)

	INSERT INTO #N01
	(	   	 
  		 BudgetChapterCode
  		,BudgetSourceID
  		,BudgetSubKindItemCode
  		,MethodDistributeID
  		,BudgetSourceKind
  		,ProjectID
  		,BudgetSubItemCode
  		,BudgetItemCode
  		,DebitAmount
  		,CreditAmount
  		,SumDebit
  		,SumCredit
	)

	-- Lấy số liệu cho các cột	
	---Cột 1: Phát sinh trong ky
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,SUM(ISNULL(CreditAmountOC,0)) AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND CashWithDrawTypeID IN (1,2) -- Tam ung trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 1: Phát sinh trong ky - thanh toan trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,SUM(ISNULL(CreditAmountOC,0)) AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND CashWithDrawTypeID IN (3) -- thanh toán trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 1: Phát sinh trong ky - nop tra trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,SUM(ISNULL(CreditAmountOC,0)) AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND CashWithDrawTypeID IN (8,9) -- nop tra trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 1: Phát sinh trong ky + 
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,SUM(ISNULL(CreditAmountOC,0)) AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''00611%'' OR AccountNumber LIKE ''00621%'' OR AccountNumber LIKE ''00911%'' OR AccountNumber LIKE ''00921%'' OR AccountNumber LIKE ''00931%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 2: So du tam ung
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,SUM(ISNULL(CreditAmountOC,0))  AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND CashWithDrawTypeID IN (1,2) -- Tam ung trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 2: Phát sinh trong ky - thanh toan trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,SUM(ISNULL(CreditAmountOC,0)) AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND CashWithDrawTypeID IN (3) -- thanh toán trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 2: Phát sinh trong ky - nop tra trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,SUM(ISNULL(CreditAmountOC,0)) AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND CashWithDrawTypeID IN (9) -- nop tra trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 2: Phát sinh trong ky + 
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,SUM(ISNULL(CreditAmountOC,0)) AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''00611%'' OR AccountNumber LIKE ''00621%'' OR AccountNumber LIKE ''00911%'' OR AccountNumber LIKE ''00921%'' OR AccountNumber LIKE ''00931%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 3: Phát sinh thuc chi trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,SUM(ISNULL(CreditAmountOC,0)) AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008212%''  OR AccountNumber LIKE ''008222%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND CashWithDrawTypeID = 4 -- thuc chi
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 3: Phát sinh trong ky - thanh toan trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,SUM(ISNULL(CreditAmountOC,0) * (-1)) AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND CashWithDrawTypeID IN (3) -- thanh toán trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 3: Phát sinh trong ky - nop tra trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,SUM(ISNULL(CreditAmountOC,0)) AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008212%''  OR AccountNumber LIKE ''008222%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND CashWithDrawTypeID IN (8) -- nop tra trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 3: Phát sinh trong ky + 
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,SUM(ISNULL(CreditAmountOC,0)) AS CreditAmount
		,0 AS SumDebit
		,0 AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''00612%'' OR AccountNumber LIKE ''00622%'' OR AccountNumber LIKE ''00912%'' OR AccountNumber LIKE ''00922%'' OR AccountNumber LIKE ''00932%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 4: Phát sinh thuc chi trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,SUM(ISNULL(CreditAmountOC,0)) AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008212%''  OR AccountNumber LIKE ''008222%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND CashWithDrawTypeID = 4 -- thuc chi
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 4: Phát sinh trong ky - thanh toan trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,SUM(ISNULL(CreditAmountOC,0)*(-1)) AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008221%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND CashWithDrawTypeID IN (3) -- thanh toán trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 4: Phát sinh trong ky - nop tra trong ky
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,SUM(ISNULL(CreditAmountOC,0)) AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''008212%''  OR AccountNumber LIKE ''008222%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND CashWithDrawTypeID IN (8) -- nop tra trong ky
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	---Cột 4: Phát sinh trong ky + 
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode		
		,CASE @SummaryMethodDistribute WHEN -1 THEN -1 ELSE ISNULL(MethodDistributeID,-1) END AS MethodDistributeID
		,1
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(BudgetSubItemCode,''00000000-0000-0000-0000-000000000000'') AS BudgetSubItemCode
		,BudgetItemCode AS BudgetItemCode
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS SumDebit
		,SUM(ISNULL(CreditAmountOC,0)) AS SumCredit		
	FROM GeneralLedger
	WHERE 
		(AccountNumber LIKE ''00612%'' OR AccountNumber LIKE ''00622%'' OR AccountNumber LIKE ''00912%'' OR AccountNumber LIKE ''00922%'' OR AccountNumber LIKE ''00932%'') 	
	AND PostedDate <= @ToDate 
	AND PostedDate >= @StartDate 
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)	
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	AND (MethodDistributeID = @MethodDistributeID OR @MethodDistributeID = -1)
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode

	--SELECT * FROM #N01
 -- [dbo].[uspReport_N02_SDKP_DVDT_2019] ''01-01-2018'', ''01-01-2018'', ''01-01-2018'', ''12-31-2018'',null,null,null,null,null,1,1,1,1,0,0,0

	-- Sau khi tính toán xong thì sum số liệu theo các tiêu chí
	INSERT INTO #N02
	(
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,BudgetSubKindItemCode 
  		,MethodDistributeID
  		,ProjectID
  		,BudgetItemCode
  		,BudgetSubItemCode
  		,DebitAmount
  		,CreditAmount
  		,SumDebit
  		,SumCredit
		,ItemType
		,Part
	)
	SELECT 
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,BudgetSubKindItemCode 
  		,MethodDistributeID
  		,ProjectID
  		,BudgetItemCode
  		,BudgetSubItemCode
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
		,3
		,4
	FROM #N01
	GROUP BY BudgetSourceID ,BudgetChapterCode, BudgetSubKindItemCode,MethodDistributeID,ProjectID,BudgetItemCode,BudgetSubItemCode
	
	-- Cong dong theo Chuong, Nguon
	INSERT INTO #N02
	(
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,DebitAmount
  		,CreditAmount
  		,SumDebit
  		,SumCredit
		,ItemType
		,Part
	)
	SELECT 
		 BudgetSourceID	 
  		,BudgetChapterCode
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
		,3
		,1
	FROM #N01
	GROUP BY BudgetChapterCode, BudgetSourceID
	
	-- Cong dong theo Chuong, Nguon, Mã ngành kt
	INSERT INTO #N02
	(
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,BudgetSubKindItemCode
  		,DebitAmount
  		,CreditAmount
  		,SumDebit
  		,SumCredit
		,ItemType
		,Part
	)
	SELECT 
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,BudgetSubKindItemCode
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
		,3
		,2
	FROM #N01
	GROUP BY BudgetChapterCode, BudgetSourceID, BudgetSubKindItemCode
	
	-- Cong dong theo Chuong, Nguon, Mã ngành kt, Mã muc
	INSERT INTO #N02
	(
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,BudgetSubKindItemCode
  		,BudgetItemCode
  		,DebitAmount
  		,CreditAmount
  		,SumDebit
  		,SumCredit
		,ItemType
		,Part
	)
	SELECT 
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,BudgetSubKindItemCode
  		,BudgetItemCode
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
		,3
		,3
	FROM #N01
	GROUP BY BudgetChapterCode, BudgetSourceID, BudgetSubKindItemCode, BudgetItemCode

	-- Dữ liệu trả về
	SELECT 
		 CASE m.BudgetChapterCode WHEN ''000'' THEN '''' WHEN ''111'' THEN '''' ELSE ISNULL(m.BudgetChapterCode,'''') END AS BudgetChapterCode
  		,CASE m.BudgetSourceID WHEN ''00000000-0000-0000-0000-000000000000'' THEN ''''
  			ELSE ISNULL(bs.BudgetSourceCode,'''') END AS BudgetSourceCode
  		,CASE m.BudgetSubKindItemCode WHEN ''00000000-0000-0000-0000-000000000000'' THEN '''' ELSE ISNULL(m.BudgetSubKindItemCode,'''') END AS BudgetSubKindItemCode
  		,ISNULL(p.ProjectCode,'''') AS ProjectCode
  		,ISNULL(m.MethodDistributeID,'''') AS MethodDistributeID
  		,ISNULL(m.BudgetItemCode,'''') AS BudgetItemCode
  		,ISNULL(m.BudgetSubItemCode,'''') AS BudgetSubItemCode
  		,m.DebitAmount AS Col1
  		,m.SumDebit AS Col2
  		,m.CreditAmount AS Col3
  		,m.SumCredit AS Col4
		,ISNULL(m.DebitAmount,0) + ISNULL(m.CreditAmount,0)  AS Col5 -- AS MovementAmount
		,ISNULL(m.SumDebit,0) + ISNULL(m.SumCredit,0)  AS Col6 -- AS ClosingAmount
		,m.ItemType	
		,m.Part
		,ISNULL(bi.BudgetItemName,'''') AS BudgetItemName
		,ISNULL(bi2.BudgetItemName,'''') AS BudgetSubItemName
		,ISNULL(bs.BudgetSourceName,'''') AS BudgetSourceName
		,ISNULL(bki.BudgetKindItemName,'''') AS BudgetKindItemName
	FROM #N02 AS m
	LEFT JOIN dbo.BudgetSource AS bs ON m.BudgetSourceID = bs.BudgetSourceID
	LEFT JOIN [dbo].[Project] p ON m.ProjectID = p.ProjectID
	LEFT JOIN dbo.BudgetItem AS bi ON m.BudgetItemCode = bi.BudgetItemCode
	LEFT JOIN dbo.BudgetKindItem AS bki ON m.BudgetSubKindItemCode = bki.BudgetKindItemCode	
	LEFT JOIN (SELECT BudgetItemCode, BudgetItemName FROM dbo.BudgetItem) bi2 ON m.BudgetSubItemCode = bi2.BudgetItemCode
	WHERE 
	NOT (m.DebitAmount = 0
	AND m.CreditAmount =   0
	AND m.SumDebit =  0
	AND m.SumCredit = 0
	AND (m.ItemType <> 0 AND m.ItemType <> 4)) 
ORDER BY m.BudgetChapterCode, bs.BudgetSourceCode, m.BudgetSubKindItemCode, m.BudgetItemCode, m.BudgetSubItemCode, p.ProjectCode, m.Part, m.ItemType

END 
--  [dbo].[uspReport_N02_SDKP_DVDT_2019] ''01-01-2018'', ''01-01-2018'', ''01-01-2018'', ''12-31-2018'',null,null,null,null,null,0,0,0,1,0,0,0


' 
END
GO
/****** Object:  StoredProcedure [dbo].[uspReport_CashInBankConfirmationBalanceSheet]    Script Date: 09/11/2018 19:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_CashInBankConfirmationBalanceSheet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		SonTV
-- Create date: 30/11/2017
-- Description:	Lay du lieu cho bao cao - "Bảng xác nhận số dư tài khoản tiền gửi tại KBNN"
-- [dbo].[uspReport_CashInBankConfirmationBalanceSheet] ''01-01-2017'',''12-31-2017'',NULL,NULL,0
-- exec uspReport_CashInBankConfirmationBalanceSheet @FromDate=''2018-01-01 00:00:00'',@ToDate=''2018-12-31 00:00:00'',@BankAccount=NULL,@pProjectID=NULL,@pIsSummaryProject=0
-- =============================================
CREATE PROCEDURE [dbo].[uspReport_CashInBankConfirmationBalanceSheet]
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @BankAccount NVARCHAR(50) ,
    @pProjectID UNIQUEIDENTIFIER ,
    @pIsSummaryProject BIT
AS 
    BEGIN
        SET NOCOUNT ON ;
        DECLARE @pProjectBucaCodeID NVARCHAR(200) ,
            @pProjectCode NVARCHAR(20)
        SELECT  @pProjectBucaCodeID = P.BUCACodeID ,
                @pProjectCode = P.ProjectCode
        FROM    dbo.Project AS P
        WHERE   P.ProjectID = @pProjectID
        
        DECLARE @AccountNumber112 NVARCHAR(20)
        SET @AccountNumber112 = ''112''
	
        DECLARE @Temp TABLE
            (
              BankAccount NVARCHAR(50) ,
              BankDistributionCode NVARCHAR(50) ,
              ProjectID UNIQUEIDENTIFIER ,
              OpeningBalance MONEY ,
              MovementDebitAmount MONEY ,
              MovementCreditAmount MONEY ,
              ClosingBalance MONEY ,
              OpenningBalance112 MONEY DEFAULT ( 0 ) ,
              MovementDebit112 MONEY DEFAULT ( 0 ) ,
              MovementCredit112 MONEY DEFAULT ( 0 ) ,
              ClosingBalance112 MONEY DEFAULT ( 0 )
            )				
      
        DECLARE @pBankAccount NVARCHAR(50) ,
            @pBankDistributionCode NVARCHAR(50) ,
            @pBankID UNIQUEIDENTIFIER
            	
        DECLARE curBankAccount CURSOR
        FOR
        SELECT  BankAccount, BankID
        FROM    dbo.Bank
        WHERE   BankAccount = @BankAccount
        OR @BankAccount IS NULL
        OPEN curBankAccount

        FETCH NEXT FROM curBankAccount INTO @pBankAccount,@pBankID
        WHILE @@FETCH_STATUS = 0 
            BEGIN
            	
            	PRINT(@pBankAccount)
            	PRINT(@pBankID)
                INSERT  INTO @Temp
                        ( BankAccount ,
                          BankDistributionCode ,
                          ProjectID ,
                          OpeningBalance ,
                          MovementDebitAmount ,
                          MovementCreditAmount ,
                          ClosingBalance
                        )
                        SELECT  @pBankAccount ,
                               null,
                                OAE.ProjectID ,
                                DebitAmount - CreditAmount AS OpeningBalance ,
                                $0 AS MovementDebitAmount ,
                                $0 AS MovementCreditAmount ,
                                $0 AS ClosingBalance
                        FROM    dbo.OpeningAccountEntry AS OAE
                                LEFT JOIN dbo.Project AS P
                                    ON P.ProjectID = OAE.ProjectID
                        WHERE   ( LEFT(OAE.AccountNumber,
                                       LEN(@AccountNumber112)) = @AccountNumber112
                                  OR @AccountNumber112 IS NULL
                                )
                                AND ( OAE.BankID = @pBankID )
                                AND ( ( P.BUCACodeID = @pProjectBucaCodeID
                                        OR ( LEFT(P.BUCACodeID,
                                                  LEN(@pProjectBucaCodeID) + 1) = @pProjectBucaCodeID
                                             + ''/'' )
                                      )
                                      OR @pProjectBucaCodeID IS NULL
                                    )
                        UNION ALL
                        SELECT  @pBankAccount ,
                                null ,
                                ProjectID ,
                                SUM(CASE WHEN Debit.PostedDate <= @FromDate
                                              - 1
                                         THEN ISNULL(Amount, 0)
                                              + ISNULL(TaxAmount, 0)
                                         ELSE 0
                                    END) AS OpeningBalance ,
                                SUM(CASE WHEN DEbit.PostedDate >= @FromDate
                                         THEN ISNULL(Amount, 0)
                                              + ISNULL(TaxAmount, 0)
                                         ELSE 0
                                    END) AS MovementDebitAmount ,
                                $0 AS MovementCreditAmount ,
                                $0 AS ClosingBalance
                        FROM    ( SELECT    OGL.ProjectID ,
                                            OGL.PostedDate ,
                                            CASE WHEN RefType IN ( 58, 108,
                                                              159, 251 )
                                                 THEN OrgPrice
                                                 ELSE Amount
                                            END AS Amount ,
                                            ISNULL(TaxAmount, 0) AS TaxAmount
                                  FROM      dbo.OriginalGeneralLedger AS OGL
                                            LEFT JOIN dbo.Project AS P
                                                ON P.ProjectID = OGL.ProjectID
                                  WHERE     ( OGL.PostedDate <= @ToDate )
                                            AND ( ( LEFT(OGL.DebitAccount,
                                                         LEN(@AccountNumber112)) = @AccountNumber112 )
                                                  OR @AccountNumber112 IS NULL
                                                )
                                            AND ( OGL.ToBankID = @pBankID )
                                            AND ( ( P.BUCACodeID = @pProjectBucaCodeID
                                                    OR ( LEFT(P.BUCACodeID,
                                                              LEN(@pProjectBucaCodeID)
                                                              + 1) = @pProjectBucaCodeID
                                                         + ''/'' )
                                                  )
                                                  OR @pProjectBucaCodeID IS NULL
                                                )
                                            AND ( OGL.RefType <> 162 )
                                  UNION ALL
                                  SELECT    OGL.ProjectID ,
                                            OGL.PostedDate ,
                                            ISNULL(Amount, 0) AS Amount ,
                                            0 AS TaxAmount
                                  FROM      dbo.OriginalGeneralLedger AS OGL
                                            LEFT JOIN dbo.Project AS P
                                                ON P.ProjectID = OGL.ProjectID
                                  WHERE     ( OGL.PostedDate <= @ToDate )
                                            AND ( ( LEFT(OGL.DebitAccount,
                                                         LEN(@AccountNumber112)) = @AccountNumber112 )
                                                  OR @AccountNumber112 IS NULL
                                                )
                                            AND ( OGL.ToBankID = @pBankID )
                                            AND ( ( P.BUCACodeID = @pProjectBucaCodeID
                                                    OR ( LEFT(P.BUCACodeID,
                                                              LEN(@pProjectBucaCodeID)
                                                              + 1) = @pProjectBucaCodeID
                                                         + ''/'' )
                                                  )
                                                  OR @pProjectBucaCodeID IS NULL
                                                )
                                            AND ( OGL.RefType = 162 )
                                ) Debit
                        GROUP BY ProjectID
                        UNION ALL
                        SELECT  @pBankAccount ,
                                @pBankDistributionCode ,
                                ProjectID ,
                                SUM(CASE WHEN Credit.PostedDate <= @FromDate
                                              - 1
                                         THEN ISNULL(-Amount, 0)
                                              + ISNULL(-TaxAmount, 0)
                                         ELSE 0
                                    END) AS OpeningBalance ,
                                $0 AS MovementDebitAmount ,
                                SUM(CASE WHEN Credit.PostedDate >= @FromDate
                                         THEN ISNULL(Amount, 0)
                                              + ISNULL(TaxAmount, 0)
                                         ELSE 0
                                    END) AS MovementCreditAmount ,
                                $0 AS ClosingBalance
                        FROM    ( SELECT    OGL.ProjectID ,
                                            OGL.PostedDate ,
                                            CASE WHEN RefType IN ( 58, 108,
                                                              159, 251 )
                                                 THEN OrgPrice
                                                 ELSE Amount
                                            END AS Amount ,
                                            ISNULL(TaxAmount, 0) AS TaxAmount
                                  FROM      dbo.OriginalGeneralLedger AS OGL
                                            LEFT JOIN dbo.Project AS P
                                                ON P.ProjectID = OGL.ProjectID
                                  WHERE     ( OGL.PostedDate <= @ToDate )
                                            AND ( ( LEFT(OGL.CreditAccount,
                                                         LEN(@AccountNumber112)) = @AccountNumber112 )
                                                  OR @AccountNumber112 IS NULL
                                                )
                                            AND ( OGL.BankID = @pBankID )
                                            AND ( ( P.BUCACodeID = @pProjectBucaCodeID
                                                    OR ( LEFT(P.BUCACodeID,
                                                              LEN(@pProjectBucaCodeID)
                                                              + 1) = @pProjectBucaCodeID
                                                         + ''/'' )
                                                  )
                                                  OR @pProjectBucaCodeID IS NULL
                                                )
                                            AND ( OGL.RefType <> 162 )
                                  UNION ALL
                                  SELECT    OGL.ProjectID ,
                                            OGL.PostedDate ,
                                            ISNULL(Amount, 0) AS Amount ,
                                            0 AS TaxAmount
                                  FROM      dbo.OriginalGeneralLedger AS OGL
                                            LEFT JOIN dbo.Project AS P
                                                ON P.ProjectID = OGL.ProjectID
                                  WHERE     ( OGL.PostedDate <= @ToDate )
                                            AND ( ( LEFT(OGL.CreditAccount,
                                                         LEN(@AccountNumber112)) = @AccountNumber112 )
                                                  OR @AccountNumber112 IS NULL
                                                )
                                            AND ( OGL.BankID = @pBankID )
                                            AND ( ( P.BUCACodeID = @pProjectBucaCodeID
                                                    OR ( LEFT(P.BUCACodeID,
                                                              LEN(@pProjectBucaCodeID)
                                                              + 1) = @pProjectBucaCodeID
                                                         + ''/'' )
                                                  )
                                                  OR @pProjectBucaCodeID IS NULL
                                                )
                                            AND ( OGL.RefType = 162 )
                                ) Credit
                        GROUP BY ProjectID
                --INSERT  INTO @Temp
                --        SELECT  @pBankAccount AS BankAccount ,
                --                @pBankDistributionCode AS BankDistributionCode ,
                --                dbo.Func_GetClosingDebitByBankAcountAndFund(@FromDate
                --                                              - 1,
                --                                              @AccountNumber112,
                --                                              DEFAULT,
                --                                              @pBankAccount,
                --                                              DEFAULT) AS OpeningBalance ,
                --                dbo.Func_GetMovementDebitByBankAccountAndFund(@FromDate,
                --                                              @ToDate,
                --                                              @AccountNumber112,
                --                                              DEFAULT,
                --                                              @pBankAccount,
                --                                              DEFAULT) AS MovementDebitAmount ,
                --                dbo.Func_GetMovementCreditByBankAccountAndFund(@FromDate,
                --                                              @ToDate,
                --                                              @AccountNumber112,
                --                                              DEFAULT,
                --                                              @pBankAccount,
                --                                              DEFAULT) AS MovementCreditAmount ,
                --                dbo.Func_GetClosingDebitByBankAcountAndFund(@ToDate,
                --                                              @AccountNumber112,
                --                                              DEFAULT,
                --                                              @pBankAccount,
                --                                              DEFAULT) AS ClosingBalance ,
                --                $0 AS OpenningBalance112 ,
                --                $0 AS MovementDebit112 ,
                --                $0 AS MovementCredit112 ,
                --                $0 AS ClosingBalance112
                       
                FETCH NEXT FROM curBankAccount INTO @pBankAccount,@pBankID
		    
            END
        CLOSE curBankAccount
        DEALLOCATE curBankAccount	
        UPDATE  @Temp
        SET     ClosingBalance = OpeningBalance + MovementDebitAmount
                - MovementCreditAmount
        SELECT  T.BankAccount ,
                --T.BankDistributionCode ,
                b.BudgetCode AS BankDistributionCode,
                CASE WHEN @pIsSummaryProject = 1 THEN ''''
                     ELSE CASE WHEN @pProjectID IS NULL THEN ISNULL(T.ProjectID,''00000000-0000-0000-0000-000000000000'')
                               ELSE @pProjectID
                          END
                END AS ProjectID ,
                CASE WHEN @pIsSummaryProject = 1 THEN ''''
                     ELSE CASE WHEN @pProjectID IS NULL THEN ISNULL(P.ProjectCode,''00000000-0000-0000-0000-000000000000'')
                               ELSE @pProjectCode
                          END
                END AS ProjectCode ,
                SUM(T.OpeningBalance) AS OpeningBalance ,
                SUM(T.MovementDebitAmount) AS MovementDebitAmount ,
                SUM(T.MovementCreditAmount) AS MovementCreditAmount ,
                SUM(T.ClosingBalance) AS ClosingBalance ,
                SUM(T.OpenningBalance112) AS OpenningBalance112 ,
                SUM(T.MovementDebit112) AS MovementDebit112 ,
                SUM(T.MovementCredit112) AS MovementCredit112 ,
                SUM(T.ClosingBalance112) AS ClosingBalance112
        FROM    @Temp T
                LEFT  JOIN dbo.Project AS P
                    ON P.ProjectID = T.ProjectID
                LEFT JOIN dbo.Bank AS b
					ON T.BankAccount = b.BankAccount
        GROUP BY T.BankAccount ,
                --T.BankDistributionCode ,
                b.BudgetCode,
                CASE WHEN @pIsSummaryProject = 1 THEN ''''
                     ELSE CASE WHEN @pProjectID IS NULL THEN ISNULL(T.ProjectID,''00000000-0000-0000-0000-000000000000'')
                               ELSE @pProjectID
                          END
                END ,
                CASE WHEN @pIsSummaryProject = 1 THEN ''''
                     ELSE CASE WHEN @pProjectID IS NULL THEN ISNULL(P.ProjectCode,''00000000-0000-0000-0000-000000000000'')
                               ELSE @pProjectCode
                          END
                END
        HAVING  SUM(T.OpeningBalance) <> 0
                OR SUM(T.MovementDebitAmount) <> 0
                OR SUM(T.MovementCreditAmount) <> 0
        ORDER BY BankAccount ,
                ProjectCode 
			   
    END' 
END
GO
/****** Object:  StoredProcedure [dbo].[uspReport_N01_SDKP_DVDT_2019]    Script Date: 09/11/2018 19:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_N01_SDKP_DVDT_2019]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		
-- Create date: 31/03/2018
-- Description:	BẢNG ĐỐI CHIẾU DỰ TOÁN KINH PHÍ NGÂN SÁCH TẠI KHO BẠC	
-- Update by: Tudt
-- Update Date: 22/08/2018											

--  [dbo].[uspReport_N01_SDKP_DVDT_2019] ''01-01-2018'', ''01-01-2018'', ''01-01-2018'', ''12-31-2018'',''91e02a45-a08a-483c-bba1-80bb73ef38e4,'', '''', '''',0,0,0,0,0,0,1
-- =============================================
CREATE PROCEDURE [dbo].[uspReport_N01_SDKP_DVDT_2019]
    @DBStartDate DATETIME ,
    @StartDate DATETIME ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @BudgetSourceID NVARCHAR(MAX) ,		            --Nguồn
    @BudgetChapterCode NVARCHAR(20) = NULL ,			-- Chương
    @BudgetSubKindItemCode NVARCHAR(20) = NULL ,		-- Khoản
    --@pMethodDistributeID INT = NULL ,					-- Cấp phát
    --@pBudgetSourceKind INT = -1 ,
    @SummaryBudgetSource BIT ,
    @SummaryBudgetChapter BIT ,
    @SummaryBudgetSubKindItem BIT ,
    --@pSummaryMethodDistribute BIT ,
    @IsAdjustTemplete BIT ,							-- Mẫu tự chủ
    @IsPrintMonth13 BIT ,							-- In tháng chỉnh lý quyết toán
    @IsPrintAllYearAndMonth13 BIT, 	  				-- Lấy số liệu của các chứng từ chỉnh lý quyết toán. (0: không lấy, 1: lấy)
    @IsStateTreasury BIT
AS
BEGIN

SET NOCOUNT ON;

	-- Liệt kê danh sách nguồn được chon
	DECLARE @BudgetSourceList AS TABLE
	(
		BudgetSourceID UNIQUEIDENTIFIER ,
		BudgetSourceCode NVARCHAR(20) ,
		BudgetSourceName NVARCHAR(255)
	)  
	
	IF @BudgetSourceID IS NOT NULL
	BEGIN
		INSERT INTO @BudgetSourceList
		SELECT  
			F.Value,
			BS.BudgetSourceCode,
			BS.BudgetSourceName
		FROM dbo.[Func_ConvertGUIStringIntoTable](@BudgetSourceID,'','') AS F
		INNER JOIN dbo.BudgetSource AS BS ON F.Value = BS.BudgetSourceID
	END
	ELSE IF @SummaryBudgetSource = 0 AND @BudgetSourceID IS NULL
	BEGIN
		INSERT INTO @BudgetSourceList
		SELECT  
			BudgetSourceID,			
			BudgetSourceCode,
			BudgetSourceName
		FROM dbo.BudgetSource
		WHERE IsActive = 1
	END
		
	CREATE TABLE #N01 
	(
		BudgetChapterCode NVARCHAR(MAX)
		,BudgetSourceID NVARCHAR(MAX)
		,BudgetSubKindItemCode NVARCHAR(MAX)
		,ProjectID NVARCHAR(MAX)
		,AccountNumber NVARCHAR(MAX)
		,DebitAmount money
		,CreditAmount MONEY
		,MovementDebitAmount MONEY
		,SumDebit MONEY
		,SumCredit MONEY
		,EarlySumDebit MONEY
		,Commitment MONEY
		,SumCommitment MONEY
		,Reserved MONEY
	)

	CREATE TABLE #N02
	(
		BudgetChapterCode NVARCHAR(MAX)
		,BudgetSourceID NVARCHAR(MAX)
		,BudgetSubKindItemCode NVARCHAR(MAX)
		,ProjectID NVARCHAR(MAX)
		,AccountNumber NVARCHAR(MAX)
		,DebitAmount money
		,CreditAmount MONEY
		,MovementDebitAmount MONEY
		,SumDebit MONEY
		,SumCredit MONEY
		,EarlySumDebit MONEY
		,Commitment MONEY
		,SumCommitment MONEY
		,Reserved MONEY
		,ItemType INT
		,Part INT
	)

	DELETE FROM #N01
	DELETE FROM #N02
	
	INSERT INTO #N01
	(	   	 
  		 BudgetChapterCode
  		,BudgetSourceID
  		,BudgetSubKindItemCode
  		,ProjectID
  		,AccountNumber
  		,DebitAmount
  		,CreditAmount
  		,MovementDebitAmount
  		,SumDebit
  		,SumCredit
  		,EarlySumDebit
  		,Commitment
		,SumCommitment
		,Reserved
	)	
	
	-- Lấy số liệu cho các cột
	---Cột 1: lấy dự toán năm trước
	SELECT	
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(ab.BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(ab.BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(ab.BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(ab.ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(ab.AccountNumber,''00000000-0000-0000-0000-000000000000'') AS AccountNumber
		,0 AS DebitAmount
		,0 AS CreditAmount
		,SUM(ISNULL(ab.DebitAmountOC,0)) - SUM(ISNULL(ab.CreditAmountOC,0)) AS MovementDebitAmount
		,0 AS SumDebit
		,0 AS SumCredit
		,0 AS EarlySumDebit
  		,0 AS Commitment
		,0 AS SumCommitment
		,0 AS Reserved
	FROM OpeningAccountEntry AS ab 
	WHERE 
		(ab.AccountNumber LIKE ''00811%'' OR ab.AccountNumber LIKE ''00812%'') 
	AND ab.PostedDate < @FromDate
	AND (ab.BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (ab.BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (ab.BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY ab.BudgetChapterCode,ab.BudgetSourceID, ab.BudgetSubKindItemCode, ab.ProjectID, ab.AccountNumber

	--Cột 2: lấy dự toán đầu năm
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(AccountNumber,''00000000-0000-0000-0000-000000000000'') AS AccountNumber
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS MovementDebitAmount
		,0 AS SumDebit
		,0 AS SumCredit
		,SUM(ISNULL(DebitAmount,0)) AS EarlySumDebit
  		,0 AS Commitment
		,0 AS SumCommitment
		,0 AS Reserved
	FROM GeneralLedger  
	WHERE 
		(AccountNumber LIKE ''00821%''  OR AccountNumber LIKE ''00822%'') 
	AND RefType = 51 
	AND PostedDate <= @ToDate 
	AND PostedDate >= @FromDate 
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,ProjectID,AccountNumber

	--1. Cột 3: lấy số liệu trong kỳ
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(gl.BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(gl.BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(gl.BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(gl.ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(gl.AccountNumber,''00000000-0000-0000-0000-000000000000'') AS AccountNumber
		,SUM(ISNULL(gl.DebitAmountOC,0)) AS DebitAmount
		,0 AS CreditAmount
		,0 AS MovementDebitAmount
		,0 AS SumDebit
		,0 AS SumCredit
		,0 AS EarlySumDebit
  		,0 AS Commitment
		,0 AS SumCommitment
		,0 AS Reserved	
	FROM GeneralLedger AS gl
	WHERE (gl.AccountNumber LIKE ''00821%''  OR gl.AccountNumber LIKE ''00822%'') AND gl.RefType IN (51,52)
	AND  gl.PostedDate <= @ToDate AND gl.PostedDate >= @FromDate
	AND (gl.BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (gl.BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (gl.BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY gl.BudgetChapterCode,gl.BudgetSourceID,gl.BudgetKindItemCode,gl.BudgetSubKindItemCode,gl.AccountNumber,gl.ProjectID

	--Cột 4: lấy lũy kế năm 
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(AccountNumber,''00000000-0000-0000-0000-000000000000'') AS AccountNumber
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS MovementDebitAmount
		,SUM(ISNULL(DebitAmountOC,0)) AS SumDebit
		,0 AS SumCredit
		,0 AS EarlySumDebit
  		,0 AS Commitment
		,0 AS SumCommitment
		,0 AS Reserved
	FROM GeneralLedger  
	WHERE (AccountNumber LIKE ''00821%''  OR AccountNumber LIKE ''00822%'') AND RefType IN (51,52) AND PostedDate <= @ToDate AND PostedDate >= @StartDate
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,ProjectID,AccountNumber--lũy kế nợ

	--2. Cột 6: lấy số liệu đã sử dụng trong kỳ
	UNION ALL 
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(gl.BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(gl.BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(gl.BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(gl.ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(gl.AccountNumber,''00000000-0000-0000-0000-000000000000'') AS AccountNumber
		,0 AS DebitAmount
		,SUM(ISNULL(gl.CreditAmountOC,0)) AS CreditAmount
		,0 AS MovementDebitAmount
		,0 AS SumDebit
		,0 AS SumCredit
		,0 AS EarlySumDebit
  		,0 AS Commitment
		,0 AS SumCommitment
		,0 AS Reserved
	FROM GeneralLedger AS gl
	WHERE (gl.AccountNumber LIKE ''008211%'' OR gl.AccountNumber LIKE ''008212%'' OR gl.AccountNumber LIKE ''008221%'' OR gl.AccountNumber LIKE ''008222%'')
	AND gl.PostedDate <= @ToDate AND gl.PostedDate >= @FromDate
	AND (gl.BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (gl.BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (gl.BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY gl.BudgetChapterCode,gl.BudgetSourceID,gl.BudgetKindItemCode,gl.BudgetSubKindItemCode,gl.AccountNumber,gl.ProjectID

	--Cột 7: lấy lũy kế đã sử dụng năm 
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,ISNULL(AccountNumber,''00000000-0000-0000-0000-000000000000'') AS AccountNumber
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS MovementDebitAmount
		,0 AS SumDebit
		,SUM(ISNULL(CreditAmount,0)) AS SumCredit
		,0 AS EarlySumDebit
  		,0 AS Commitment
		,0 AS SumCommitment
		,0 AS Reserved
	FROM GeneralLedger  
	WHERE (AccountNumber LIKE ''008211%''  OR AccountNumber LIKE ''008212%''  OR AccountNumber LIKE ''008221%''  OR AccountNumber LIKE ''008222%'')
	AND PostedDate >= @StartDate AND PostedDate <= @ToDate 
	AND (BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY BudgetChapterCode,BudgetSourceID,BudgetSubKindItemCode,ProjectID,AccountNumber--lũy kế nợ

	--Cam kết chi
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,''00000000-0000-0000-0000-000000000000'' AS AccountNumber
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS MovementDebitAmount	
		,0 AS SumDebit
		,0 AS SumCredit
		,0 AS EarlySumDebit
  		,SUM(ISNULL(AmountOC,0)) AS Commitment
		,0 AS SumCommitment
		,0 AS Reserved	
	FROM BUCommitmentRequestDetail d
	INNER JOIN BUCommitmentRequest m
	ON m.RefID = d.RefID
	WHERE m.RefType = 71 AND m.PostedDate <= @ToDate AND m.PostedDate >= @FromDate 
	AND (d.BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (d.BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (d.BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY d.BudgetChapterCode,d.BudgetSourceID,d.BudgetSubKindItemCode,d.ProjectID

	-- lũy kế Cam kết chi
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,''00000000-0000-0000-0000-000000000000'' AS AccountNumber
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS MovementDebitAmount	
		,0 AS SumDebit
		,0 AS SumCredit
		,0 AS EarlySumDebit
  		,0 AS Commitment
		,SUM(ISNULL(AmountOC,0))  AS SumCommitment
		,0 AS Reserved	
	FROM BUCommitmentRequestDetail d
	INNER JOIN BUCommitmentRequest m
	ON m.RefID = d.RefID
	WHERE m.RefType = 71 AND m.PostedDate <= @ToDate AND m.PostedDate >= @StartDate 
	AND (d.BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (d.BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (d.BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY d.BudgetChapterCode,d.BudgetSourceID,d.BudgetSubKindItemCode,d.ProjectID --lũy kế nợ

	-- Dự toán giữ lại
	UNION ALL
	SELECT 
		 CASE @SummaryBudgetChapter WHEN 1 THEN ''000'' ELSE ISNULL(BudgetChapterCode,''000'') END AS BudgetChapterCode
		,CASE @SummaryBudgetSource WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSourceID,''00000000-0000-0000-0000-000000000000'') END AS BudgetSourceID
		,CASE @SummaryBudgetSubKindItem WHEN 1 THEN ''00000000-0000-0000-0000-000000000000'' ELSE ISNULL(BudgetSubKindItemCode,''00000000-0000-0000-0000-000000000000'') END AS BudgetSubKindItemCode
		,ISNULL(ProjectID,''00000000-0000-0000-0000-000000000000'') AS ProjectID
		,''00000000-0000-0000-0000-000000000000'' AS AccountNumber
		,0 AS DebitAmount
		,0 AS CreditAmount
		,0 AS MovementDebitAmount	
		,0 AS SumDebit
		,0 AS SumCredit
		,0 AS EarlySumDebit
  		,0 AS Commitment
		,0 AS SumCommitment
		,SUM(ISNULL(AmountOC,0)) AS Reserved	
	FROM BUBudgetReserveDetail d
	INNER JOIN BUBudgetReserve m
	ON m.RefID = d.RefID
	WHERE m.RefType = 73 AND m.PostedDate <= @ToDate AND m.PostedDate >= @FromDate 
	AND (d.BudgetSourceID IN (SELECT BudgetSourceID FROM dbo.BudgetSource AS bs) OR @BudgetSourceID IS NULL)
	AND (m.BudgetChapterCode = @BudgetChapterCode OR @BudgetChapterCode IS NULL)
	AND (d.BudgetSubKindItemCode = @BudgetSubKindItemCode OR @BudgetSubKindItemCode IS NULL)  
	GROUP BY m.BudgetChapterCode,d.BudgetSourceID,d.BudgetSubKindItemCode,d.ProjectID --lũy kế nợ

	--SELECT * FROM #N01

	-- Sau khi tính toán xong thì sum số liệu theo các tiêu chí tổng hợp
	INSERT INTO #N02
	(
		 BudgetSourceID	 
  		,BudgetChapterCode
  		,BudgetSubKindItemCode  	
  		,DebitAmount
  		,CreditAmount
  		,MovementDebitAmount
  		,SumDebit
  		,SumCredit
  		,EarlySumDebit
  		,Commitment
		,SumCommitment
		,Reserved
		,ItemType
		,Part
	)
	SELECT 
		 BudgetSourceID
		,BudgetChapterCode
		,BudgetSubKindItemCode
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(MovementDebitAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
  		,SUM(EarlySumDebit)
  		,SUM(Commitment)
		,SUM(SumCommitment)
		,SUM(Reserved)
		,3
		,1
	FROM #N01
	GROUP BY BudgetChapterCode, BudgetSourceID ,BudgetSubKindItemCode

	--SELECT * FROM #N02
-- Chèn dòng tổng cộng theo Chương + Nguồn
	INSERT INTO #N02
	(
		 BudgetChapterCode
		,BudgetSourceID
  		,DebitAmount
  		,CreditAmount
  		,MovementDebitAmount
  		,SumDebit
  		,SumCredit
  		,EarlySumDebit
  		,Commitment
		,SumCommitment
		,Reserved
		,ItemType
		,Part
	)
	SELECT 
		 BudgetChapterCode
		,BudgetSourceID
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(MovementDebitAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
  		,SUM(EarlySumDebit)
  		,SUM(Commitment)
		,SUM(SumCommitment)
		,SUM(Reserved)
		,1
		,1
	FROM #N01
	GROUP BY BudgetChapterCode, BudgetChapterCode, BudgetSourceID

	-- Chèn dòng tổng cộng theo Chương + Nguồn + Khoản
	INSERT INTO #N02
	(
		 BudgetChapterCode
		,BudgetSourceID
		,BudgetSubKindItemCode
  		,DebitAmount
  		,CreditAmount
  		,MovementDebitAmount
  		,SumDebit
  		,SumCredit
  		,EarlySumDebit
  		,Commitment
		,SumCommitment
		,Reserved
		,ItemType
		,Part
	)
	SELECT 
		 BudgetChapterCode
		,BudgetSourceID
		,BudgetSubKindItemCode
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(MovementDebitAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
  		,SUM(EarlySumDebit)
  		,SUM(Commitment)
		,SUM(SumCommitment)
		,SUM(Reserved)
		,2
		,1
	FROM #N01
	GROUP BY BudgetChapterCode, BudgetSourceID, BudgetSubKindItemCode

	-- Chèn dòng tổng cộng cả báo cáo
	INSERT INTO #N02
	(
		 BudgetChapterCode
		,BudgetSourceID	
  		,DebitAmount
  		,CreditAmount
  		,MovementDebitAmount
  		,SumDebit
  		,SumCredit
  		,EarlySumDebit
  		,Commitment
		,SumCommitment
		,Reserved
		,ItemType
		,Part
	)
	SELECT 
		 BudgetChapterCode
		,''90000000-0000-0000-0000-000000000000''	
		,SUM(DebitAmount)
  		,SUM(CreditAmount)
  		,SUM(MovementDebitAmount)
  		,SUM(SumDebit)
  		,SUM(SumCredit)
  		,SUM(EarlySumDebit)
  		,SUM(Commitment)
		,SUM(SumCommitment)
		,SUM(Reserved)
		,1
		,2
	FROM #N02
	WHERE ItemType = 3
	GROUP BY BudgetChapterCode--, BudgetSourceID

	-- Thêm phần kho bạc nhà nước
	IF EXISTS(SELECT BudgetSourceID FROM #N02)
	BEGIN
		INSERT INTO #N02
	(
		 BudgetChapterCode
		,BudgetSourceID	 
  		,BudgetSubKindItemCode  	
  		,DebitAmount
  		,CreditAmount
  		,MovementDebitAmount
  		,SumDebit
  		,SumCredit
  		,EarlySumDebit
  		,Commitment
		,SumCommitment
		,Reserved
		,ItemType
		,Part
	)
	VALUES
	(
		''000''
		,''10000000-0000-0000-0000-000000000000''
		,''00000000-0000-0000-0000-000000000000''
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,3	
	)
	-- Thêm dòng trắng phần kho bạc nhà nước
	INSERT INTO #N02
	(
		 BudgetChapterCode
		,BudgetSourceID
		,BudgetSubKindItemCode  	
		,DebitAmount
		,CreditAmount
		,MovementDebitAmount
		,SumDebit
		,SumCredit
		,EarlySumDebit
		,Commitment
		,SumCommitment
		,Reserved
		,ItemType
		,Part
	)
	VALUES
	(
		 ''000''
		,''10000000-0000-0000-0000-000000000000''
		,''00000000-0000-0000-0000-000000000000''
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,4
		,3	
	)
	END
		
	IF (@IsStateTreasury = 1)
	BEGIN
		-- Thêm phần kho bạc nhà nước
		INSERT INTO #N02
		(
			 BudgetSourceID	 
  			,BudgetChapterCode
  			,BudgetSubKindItemCode  	
  			,DebitAmount
  			,CreditAmount
  			,MovementDebitAmount
  			,SumDebit
  			,SumCredit
  			,EarlySumDebit
  			,Commitment
			,SumCommitment
			,Reserved
			,ItemType
			,Part
		)
		SELECT 
			 BudgetSourceID	 
  			,BudgetChapterCode
  			,BudgetSubKindItemCode  	
  			,DebitAmount
  			,CreditAmount
  			,MovementDebitAmount
  			,SumDebit
  			,SumCredit
  			,EarlySumDebit
  			,Commitment
			,SumCommitment
			,Reserved
			,ItemType
			,4
		FROM #N02
		WHERE Part <> 3 AND Part <> 2
		UNION ALL
		SELECT 
			 BudgetSourceID	 
  			,BudgetChapterCode
  			,BudgetSubKindItemCode  	
  			,DebitAmount
  			,CreditAmount
  			,MovementDebitAmount
  			,SumDebit
  			,SumCredit
  			,EarlySumDebit
  			,Commitment
			,SumCommitment
			,Reserved
			,ItemType
			,5
		FROM #N02
		WHERE Part = 2
		-- Khi có số liệu phần KBNN thì xóa dòng trắng đi	
		DELETE FROM #N02 WHERE ItemType = 4
	END

	-- Dữ liệu trả về
	SELECT 
		 CASE m.BudgetChapterCode WHEN ''000'' THEN '''' WHEN ''111'' THEN '''' ELSE ISNULL(m.BudgetChapterCode,'''') END AS BudgetChapterCode
  		,CASE m.BudgetSourceID WHEN ''10000000-0000-0000-0000-000000000000'' THEN N''Phần KBNN ghi:'' 
  			WHEN ''90000000-0000-0000-0000-000000000000'' THEN N''Tổng cộng'' 
  			ELSE ISNULL(bs.BudgetSourceCode,'''') END AS BudgetSourceID
  		,CASE m.BudgetSubKindItemCode WHEN ''00000000-0000-0000-0000-000000000000'' THEN '''' ELSE ISNULL(m.BudgetSubKindItemCode,'''') END AS BudgetSubKindItemCode
  		,ISNULL(p.ProjectCode,'''') AS ProjectID
  		,ISNULL(m.AccountNumber,'''') AS AccountNumber
  		,m.DebitAmount
  		,m.CreditAmount
  		,m.MovementDebitAmount
  		,m.SumDebit
  		,m.SumCredit
  		,m.EarlySumDebit
  		,m.Commitment
		,m.SumCommitment
		,m.Reserved
		,ISNULL(m.MovementDebitAmount,0) + ISNULL(m.SumDebit,0) AS UseableAmount
		,ISNULL(m.MovementDebitAmount,0) + ISNULL(m.SumDebit,0) - ISNULL(m.SumCredit,0) - ISNULL(m.SumCommitment,0) AS RemainingAmount 
		,m.ItemType	
		,m.Part
	FROM #N02 AS m
	LEFT JOIN dbo.BudgetSource AS bs ON m.BudgetSourceID = bs.BudgetSourceID
	LEFT JOIN [dbo].[Project] p ON m.ProjectID = p.ProjectID
	WHERE 
	NOT (m.DebitAmount = 0
	AND m.CreditAmount =   0
	AND m.MovementDebitAmount =  0
	AND m.SumDebit =  0
	AND m.SumCredit = 0
	AND m.EarlySumDebit =  0
	AND m.Commitment =  0
	AND m.SumCommitment =  0
	AND m.Reserved =  0
	AND (m.ItemType <> 0 AND m.ItemType <> 4)) 
ORDER BY m.Part, m.BudgetChapterCode, bs.BudgetSourceCode, m.BudgetSubKindItemCode, p.ProjectCode, m.ItemType

END 
-- [dbo].[uspReport_N01_SDKP_DVDT_2019] ''01-01-2018'', ''01-01-2018'', ''01-01-2018'', ''12-31-2018'',null, null, null,0,0,0,0,0,0,1


' 
END
GO
/****** Object:  StoredProcedure [dbo].[uspReport_GetB03bBCTC]    Script Date: 09/11/2018 19:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_GetB03bBCTC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<TUDT>
-- Create date: <27/08/2018>
-- Description:	<Get Report B03b-BCTC >
-- [dbo].[uspReport_GetB03bBCTC] ''01-01-2018'',''01-01-2018'',''12-31-2018''
-- =============================================
CREATE PROCEDURE [dbo].[uspReport_GetB03bBCTC]

    @pStartDate DATETIME = ''2018/06/07'',
    @pFromDate DATETIME = ''2018/01/01'',
    @pToDate DATETIME = ''2018/12/31''
AS
    BEGIN
		/*ID báo cáo*/
        DECLARE @ReportID NVARCHAR(50);
        SET @ReportID = ''B03b_BCTC'';
        
        SELECT    
			ReportItemID ,
			ReportID ,
			ReportItemIndex,
			ReportItemName ,
			ReportItemCode ,
			IsBold ,
			SortOrder,
			Part
        FROM FRTemplate_Custom FRT
        WHERE ReportID = @ReportID
        ORDER BY SortOrder
    END;


' 
END
GO
/****** Object:  StoredProcedure [dbo].[uspReport_B02BCTC]    Script Date: 09/11/2018 19:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_B02BCTC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<tudt>
-- Create date: <28/03/2018>
-- Description:	Description: < Báo cáo kết quả hoạt động>
-- [uspReport_B02BCTC] ''2017-01-01'', ''2017-12-31'', ''USD''
-- =============================================
CREATE PROCEDURE [dbo].[uspReport_B02BCTC] 
	 @FromDate DATE
	,@ToDate DATE
	,@CurrencyCode NVARCHAR(50)
	,@BudgetChapterCode NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		DECLARE @FixedAssetID BIGINT;
		DECLARE @FixedAssetName NVARCHAR(255);
		DECLARE @YearOfUsing INT;
		DECLARE @FixedAssetCode NVARCHAR(20);
		DECLARE @Quantity SMALLINT;
		DECLARE @Unit NVARCHAR(255);
		DECLARE @OrgPrice MONEY;
		DECLARE @OrgPriceUSD MONEY
		DECLARE @OrgPriceCurrencyUSD MONEY
		DECLARE @TotalOrgPriceUSD MONEY
		DECLARE @Description NVARCHAR(255);
		DECLARE @SerialNumber NVARCHAR(100);
		DECLARE @CountryProduction NVARCHAR(255);
		DECLARE @OrderNumber VARCHAR(25);
		DECLARE @FACategoryCode VARCHAR(255);
		DECLARE @Grade INT;
		DECLARE @FACategoryID INT

		--create table
		CREATE TABLE #ReportFAIncrement 
		(
			 OrderNumber VARCHAR(25)
			,FixedAssetCategoryCode NVARCHAR(255)
			,FixedAssetID BIGINT
			,FixedAssetCode NVARCHAR(20)
			,FixedAssetName NVARCHAR(255)
			,ParentID INT
			,Unit NVARCHAR(255)
			,CountryProduction NVARCHAR(255)
			,YearOfUsing INT
			,AddressUsing NVARCHAR(255)
			,DepreciationRate DECIMAL(18,4)
			,PurchasedDate NVARCHAR(50)
			,CurrencyCode NVARCHAR(50)
			,SerialNumber NVARCHAR(100)
			,Quantity INT
			,OrgPrice MONEY
			,OrgPriceUSD MONEY
			,OrgPriceCurrencyUSD MONEY
			,TotalOrgPriceUSD MONEY
			,Description NVARCHAR(255)
			,Grade SMALLINT
		);
			
	--	--insert data to cursor
	--	DECLARE FAIncrementCursor CURSOR
	--	FOR SELECT 
	--		 fa.[FixedAssetID]+ 1000  FixedAssetID
	--		,fa.[FixedAssetCode] FixedAssetCode
	--		,fa.[FixedAssetName] FixedAssetName
	--		,fa.Unit
	--		,fal.CurrencyCode
	--		,YEAR(fa.[UsedDate]) YearOfUsing
	--		,fa.SerialNumber
	--		,fa.MadeIn AS CountryProduction
	--		,fac.FixedAssetCategoryCode
	--		,fac.Grade
	--		,fac.FixedAssetCategoryID
	--	FROM FixedAssetLedger fal
	--	INNER JOIN FixedAsset fa ON fal.FixedAssetID = fa.FixedAssetID
	--	INNER JOIN FixedAssetCategory fac ON fa.FixedAssetCategoryID = fac.FixedAssetCategoryID
	--	WHERE 
	--		CONVERT(DATE, fal.RefDate) >= CONVERT(DATE, @FromDate)
	--	AND 
	--		CONVERT(DATE, fal.RefDate) <= CONVERT(DATE, @ToDate)
	--	AND 
	--		fal.CurrencyCode = @CurrencyCode
	--	AND fal.RefTypeID = 500
	--	--AND fal.CurrencyCode IN (SELECT CurrencyCode FROM #FAReport)
	--	GROUP BY fa.FixedAssetID
	--		,FixedAssetCode
	--		,FixedAssetName
	--		,fa.Unit
	--		,fal.CurrencyCode
	--		,YEAR(fa.[UsedDate])
	--		,fa.SerialNumber
	--		,fa.MadeIn
	--		,fac.FixedAssetCategoryCode
	--		,fac.Grade
	--		,fac.FixedAssetCategoryID
	--	ORDER BY fac.FixedAssetCategoryCode
	--	OPEN FAIncrementCursor;
	--	FETCH NEXT FROM FAIncrementCursor INTO @FixedAssetID, @FixedAssetCode, @FixedAssetName, @Unit, 
	--	@CurrencyCode, @YearOfUsing, @SerialNumber, @CountryProduction, @FACategoryCode, @Grade, @FACategoryID
	--	WHILE @@FETCH_STATUS = 0
		
		
	--	BEGIN
	--		----insert parent good perfomance
	--		IF (
	--				SELECT COUNT(*)
	--				FROM #ReportFAIncrement
	--				WHERE FixedAssetCategoryCode = @FACategoryCode
	--				) = 0
	--		BEGIN
	--			WITH FAReport (
	--				FixedAssetCategoryID
	--				,ParentID
	--				,FixedAssetCategoryName
	--				,FixedAssetCategoryCode
	--				,Grade
	--				)
	--			AS (
	--				-- Mệnh đề đệ quy
	--				SELECT /* Thông tin chung có thể joine với các bảng khác */
	--					e.FixedAssetCategoryID
	--					,e.ParentID
	--					,e.FixedAssetCategoryName
	--					,e.FixedAssetCategoryCode
	--					,
	--					/* Bậc bắt đầu tính */
	--					@Grade AS UnitGrade
	--					/* Chỉ tiêu sắp xếp dử liệu */
	--				FROM FixedAssetCategory e
	--				WHERE FixedAssetCategoryID = @FACategoryID
	--				-- Ràng buộc đệ quy
					
	--				UNION ALL
					
	--				SELECT /* Thông tin chung có thể joine với các bảng khác */
	--					e.FixedAssetCategoryID
	--					,e.ParentID
	--					,e.FixedAssetCategoryName
	--					,e.FixedAssetCategoryCode
	--					,
	--					/* Bậc sẻ được tăng lên dần */
	--					d.Grade - 1 AS UnitGrade
	--				FROM FixedAssetCategory e
	--				-- Bắt buộc của đệ quy là kết quả phải đi đến giới hạn
	--				INNER JOIN FAReport d ON e.FixedAssetCategoryID = d.ParentID
	--				)
	--			INSERT INTO #ReportFAIncrement (
	--				FixedAssetID
	--				,OrderNumber
	--				,FixedAssetCategoryCode
	--				,ParentID
	--				,FixedAssetName
	--				,Grade
	--				)
	--			SELECT FixedAssetCategoryID
	--				,FixedAssetCategoryCode
	--				,FixedAssetCategoryCode
	--				,ParentID
	--				,FixedAssetCategoryName
	--				,Grade
	--			FROM FAReport
	--			WHERE FixedAssetCategoryID NOT IN (
	--					SELECT rcr.FixedAssetCategoryID
	--					FROM FAReport rcr
	--					INNER JOIN #ReportFAIncrement TEMP ON rcr.FixedAssetCategoryID = TEMP.FixedAssetID
	--					)
	--		END
	--		BEGIN
	--			--DECLARE 
	--			DECLARE @QuantityIncrement SMALLINT= 0;
	--			DECLARE @OrgPriceIncrement MONEY= 0;
	--			DECLARE @OrgPriceExchangeIncrement MONEY= 0;
	--			DECLARE @DepreciationRate DECIMAL(18,4);
	--			DECLARE @AddressUsing NVARCHAR(255);

	--			-- Get thong tin 
	--			BEGIN
	--	    		SELECT
	--	    		@DepreciationRate = fa.DepreciationRate,
	--	    		@AddressUsing  = d.DepartmentCode
	--	    	FROM
	--	    		FixedAsset AS fa LEFT JOIN Department AS d ON d.DepartmentID = fa.DepartmentID
	--	    	WHERE fa.FixedAssetID  + 1000 = @FixedAssetID 
	--			END
				
	--			-- Get @Quantity
	--			BEGIN
	--				SELECT 
						
	--					@Quantity = ISNULL(SUM(fal.Quantity), 0)
	--				FROM FixedAssetLedger fal INNER JOIN FixedAsset fa ON fa.FixedAssetID = fal.FixedAssetID
	--				WHERE fal.FixedAssetID+ 1000  = @FixedAssetID
	--					AND CONVERT(DATE, fal.RefDate) >= CONVERT(DATE, @FromDate)
	--					AND CONVERT(DATE, fal.RefDate) <= CONVERT(DATE, @ToDate)
	--					AND fal.CurrencyCode = @CurrencyCode
	--					AND fal.RefTypeID = 500
	--			END
				
	--			-- Get OrgPrice
	--			BEGIN
	--				SELECT 
	--					@OrgPriceIncrement = ISNULL(SUM(fal.OrgPriceDebitAmount), 0)
	--					,@OrgPriceExchangeIncrement = ISNULL(SUM(fal.OrgPriceDebitAmountExchange), 0)
	--				FROM FixedAssetLedger fal INNER JOIN FixedAsset fa ON fa.FixedAssetID = fal.FixedAssetID
	--				WHERE fal.FixedAssetID+ 1000  = @FixedAssetID
	--					AND CONVERT(DATE, fal.RefDate) >= CONVERT(DATE, @FromDate)
	--					AND CONVERT(DATE, fal.RefDate) <= CONVERT(DATE, @ToDate)
	--					AND fal.CurrencyCode = @CurrencyCode
	--					AND fal.RefTypeID = 500
	--					--AND fal.OrgPriceAccount = 211
	--			END
	--			--Set 
	--			IF (@CurrencyCode <> ''USD'')
	--			BEGIN
	--				SET @OrgPrice = @OrgPriceIncrement
	--				SET @OrgPriceCurrencyUSD = @OrgPriceExchangeIncrement 
	--				SET @OrgPriceUSD = 0
	--				SET @TotalOrgPriceUSD = @OrgPriceCurrencyUSD + @OrgPriceUSD
	--			END
	--			ELSE
	--			BEGIN
	--				SET @OrgPrice = 0
	--				SET @OrgPriceCurrencyUSD = 0
	--				SET @OrgPriceUSD = @OrgPriceIncrement 
	--				SET @TotalOrgPriceUSD = @OrgPriceCurrencyUSD + @OrgPriceUSD
	--			END
	--		END
			
	--		--print @TotalOrgPriceUSD
	--		--insert child
	--		SET @OrderNumber = @FixedAssetCode;
	--		SET @Grade = @Grade + 1;
	--		INSERT INTO #ReportFAIncrement (
	--			 FixedAssetID
	--			,ParentID
	--			,FixedAssetName
	--			,FixedAssetCode
	--			,FixedAssetCategoryCode
	--			,Unit
	--			,CurrencyCode
	--			,YearOfUsing
	--			,AddressUsing
	--			,DepreciationRate
	--			,Quantity
	--			,OrgPrice
	--			,OrgPriceUSD
	--			,OrgPriceCurrencyUSD
	--			,TotalOrgPriceUSD
	--			,Description
	--			,CountryProduction
	--			,SerialNumber
	--			,OrderNumber
	--			,Grade
	--			)
	--		VALUES (
	--			 @FixedAssetID
	--			,@FACategoryID
	--			,''---'' + @FixedAssetName
	--			,@FixedAssetCode
	--			,@FACategoryCode
	--			,@Unit
	--			,@CurrencyCode
	--			,@YearOfUsing
	--			,@AddressUsing
	--			,@DepreciationRate
	--			,@Quantity
	--			,@OrgPrice
	--			,@OrgPriceUSD
	--			,@OrgPriceCurrencyUSD
	--			,@TotalOrgPriceUSD
	--			,@Description
	--			,@CountryProduction
	--			,@SerialNumber
	--			,@OrderNumber
	--			,@Grade
	--			);

	--	FETCH NEXT FROM FAIncrementCursor INTO @FixedAssetID, @FixedAssetCode, @FixedAssetName, @Unit, 
	--	@CurrencyCode, @YearOfUsing, @SerialNumber, @CountryProduction, @FACategoryCode, @Grade, @FACategoryID
	--END

	----clear cursor
	--CLOSE FAIncrementCursor;
	--DEALLOCATE FAIncrementCursor;
	

	----sum tong
	--	DECLARE @pFixedAssetID BIGINT;
	--	DECLARE ReportCursor CURSOR
	--	FOR
	--	SELECT FixedAssetID
	--	FROM #ReportFAIncrement
	--	WHERE ParentID IS NULL
	--	----
	--	OPEN ReportCursor;

	--	FETCH NEXT
	--	FROM ReportCursor
	--	INTO @pFixedAssetID

	--	WHILE @@FETCH_STATUS = 0
	--	BEGIN
	--		WITH CTE
	--		AS (
	--			SELECT c.FixedAssetID
	--				,c.ParentID
	--				,c.Quantity
	--				,c.OrgPrice
	--				,c.OrgPriceUSD
	--				,c.OrgPriceCurrencyUSD
	--				,c.TotalOrgPriceUSD
	--			FROM #ReportFAIncrement c
	--			WHERE c.FixedAssetID = @pFixedAssetID
				
	--			UNION ALL
				
	--			SELECT c.FixedAssetID
	--				,c.ParentID
	--				,c.Quantity
	--				,c.OrgPrice
	--				,c.OrgPriceUSD
	--				,c.OrgPriceCurrencyUSD
	--				,c.TotalOrgPriceUSD
	--			FROM CTE p
	--			INNER JOIN #ReportFAIncrement c ON c.ParentID = p.FixedAssetID
	--			)
	--			,Explode
	--		AS (
	--			SELECT FixedAssetID AS major
	--				,FixedAssetID AS minor
	--				,Quantity
	--				,OrgPrice
	--				,OrgPriceUSD
	--				,OrgPriceCurrencyUSD
	--				,TotalOrgPriceUSD
	--			FROM CTE
				
	--			UNION ALL
				
	--			SELECT MJ.major
	--				,MN.FixedAssetID
	--				,MN.Quantity
	--				,MN.OrgPrice
	--				,MN.OrgPriceUSD
	--				,MN.OrgPriceCurrencyUSD
	--				,MN.TotalOrgPriceUSD
	--			FROM Explode AS MJ
	--			JOIN #ReportFAIncrement AS MN ON MJ.minor = MN.ParentID
	--			)
	--		UPDATE #ReportFAIncrement
	--		SET Quantity = i.SumQuantity
	--			,OrgPrice = i.SumOrgPrice
	--			,OrgPriceUSD = i.SumOrgPriceUSD
	--			,OrgPriceCurrencyUSD = i.SumOrgPriceCurrencyUSD
	--			,TotalOrgPriceUSD = i.SumTotalOrgPriceUSD
	--		FROM (
	--			SELECT major
	--				,SUM(Quantity) AS SumQuantity
	--				,SUM(OrgPrice) AS SumOrgPrice
	--				,SUM(OrgPriceUSD) AS SumOrgPriceUSD
	--				,SUM(OrgPriceCurrencyUSD) AS SumOrgPriceCurrencyUSD
	--				,SUM(TotalOrgPriceUSD) AS SumTotalOrgPriceUSD
	--			FROM Explode
	--			GROUP BY major
	--			) i
	--		WHERE FixedAssetID = i.major
	--		OPTION (MAXRECURSION 0)

	--		--------
	--		FETCH NEXT
	--		FROM ReportCursor
	--		INTO @pFixedAssetID
		
	--	END
	--	--CLOSE ReportCursor;
	--	--DEALLOCATE ReportCursor;

	--	BEGIN
	--		WITH Tree AS
	--		(
	--			SELECT 
	--				 FixedAssetID
	--				,OrderNumber
	--				,ParentID
	--				,FixedAssetCategoryCode
	--				,FixedAssetName
	--				,Unit
	--				,YearOfUsing
	--				,AddressUsing
	--				,DepreciationRate
	--				,FixedAssetCode
	--				,Quantity
	--				,OrgPrice
	--				,OrgPriceUSD
	--				,OrgPriceCurrencyUSD
	--				,TotalOrgPriceUSD
	--				,Description
	--				,SerialNumber
	--				,CountryProduction
	--				,Grade
	--				,CONVERT(VARCHAR(MAX), ROW_NUMBER() OVER (ORDER BY FixedAssetID)) SortOrder
	--			FROM #ReportFAIncrement
	--			WHERE ParentID IS NULL
	--			UNION ALL
	--			SELECT
	--				 rfa.FixedAssetID
	--				,rfa.OrderNumber
	--				,rfa.ParentID
	--				,rfa.FixedAssetCategoryCode
	--				,rfa.FixedAssetName
	--				,rfa.Unit
	--				,rfa.YearOfUsing
	--				,rfa.AddressUsing
	--				,rfa.DepreciationRate
	--				,rfa.FixedAssetCode
	--				,rfa.Quantity
	--				,rfa.OrgPrice
	--				,rfa.OrgPriceUSD
	--				,rfa.OrgPriceCurrencyUSD
	--				,rfa.TotalOrgPriceUSD
	--				,rfa.Description
	--				,rfa.SerialNumber
	--				,rfa.CountryProduction
	--				,rfa.Grade
	--				,SortOrder + ''/'' + CONVERT(VARCHAR(MAX), ROW_NUMBER() OVER (ORDER BY Tree.FixedAssetID)) SortOrder
	--			FROM #ReportFAIncrement rfa 
	--			INNER JOIN Tree ON rfa.ParentID = Tree.FixedAssetID
	--		)
	--		SELECT 
	--			 SortOrder
	--			,FixedAssetID
	--			,OrderNumber
	--			,ParentID
	--			,FixedAssetCategoryCode
	--			,FixedAssetName
	--			,Unit
	--			,YearOfUsing
	--			,AddressUsing
	--			,DepreciationRate
	--			,FixedAssetCode
	--			,Quantity
	--			,OrgPrice
	--			,OrgPriceUSD
	--			,OrgPriceCurrencyUSD
	--			,TotalOrgPriceUSD
	--			,Description
	--			,SerialNumber
	--			,CountryProduction
	--			,Grade
	--		FROM Tree
	--		ORDER BY SortOrder
	--	END
			
	--	----end
	--	----get data
	--	--SELECT Sort
	--	--	,FixedAssetID
	--	--	,ParentID
	--	--	,FixedAssetCategoryCode
	--	--	,FixedAssetName
	--	--	,Unit
	--	--	,CurrencyCode
	--	--	,YearOfUsing
	--	--	,FixedAssetCode
	--	--	,Quantity
	--	--	,OrgPrice
	--	--	,OrgPriceUSD
	--	--	,OrgPriceCurrencyUSD
	--	--	,TotalOrgPriceUSD
	--	--	,Description
	--	--	,SerialNumber
	--	--	,CountryProduction
	--	--	,CASE 
	--	--		WHEN OrderNumber = 0
	--	--			THEN NULL
	--	--		ELSE OrderNumber
	--	--		END OrderNumber
	--	--	,Grade
	--	--FROM #ReportFAIncrement
	--	--ORDER BY 
	--	--	CASE
	--	--		WHEN Grade > 0 THEN FixedAssetCategoryCode 
	--	--	END ASC
	--	--	, Grade
	END TRY

	BEGIN CATCH
		-- Rollback any active or uncommittable transactions before

		IF CURSOR_STATUS(''global'', ''FAIncrementCursor'') >= - 1
		BEGIN
			CLOSE FAIncrementCursor;
			DEALLOCATE FAIncrementCursor;
		END
		
		IF CURSOR_STATUS(''global'', ''ReportCursor'') >= - 1
		BEGIN
			CLOSE ReportCursor;
			DEALLOCATE ReportCursor;
		END
		EXECUTE [dbo].[uspLogError];
	END CATCH;
END' 
END
GO

/****** Object:  StoredProcedure [dbo].[uspReport_S11H]    Script Date: 09/12/2018 11:08:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspReport_S11H]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'---- =============================================
-- Author:		
-- Create date: 
-- Description:	<Get all data for S11H>
-- exec uspReport_S11H @pStartDate=''2018-01-01 00:00:00'',@pFromDate=''2018-01-01 00:00:00'',@pToDate=''2018-12-31 23:59:59'',@pAccountNumber=N''1111'',@pBudgetChapterCode=NULL,@IsSummaryBudgetChapter=1,@IsSummaryFund=0,@FundID=NULL,@ShowAccountingObjectInfo=0,@pBudgetSourceID=NULL,@pIsSummarySource=1,@pBudgetSubKindItemCode=NULL,@pSummaryBudgetSubKindItem=1
---- =============================================
CREATE PROCEDURE [dbo].[uspReport_S11H]
    @pStartDate DATETIME ,
    @pFromDate DATETIME ,
    @pToDate DATETIME ,
    @pAccountNumber NVARCHAR(20) ,
    @pBudgetChapterCode NVARCHAR(20) ,
    @IsSummaryBudgetChapter BIT ,
    @IsSummaryFund BIT ,
    @FundID AS UNIQUEIDENTIFIER ,
    @ShowAccountingObjectInfo BIT = 0 ,
    @pBudgetSourceID NVARCHAR(MAX) ,
    @pIsSummarySource BIT ,
    @pBudgetSubKindItemCode NVARCHAR(20) ,
    @pSummaryBudgetSubKindItem BIT
AS
    SET NOCOUNT ON;
    DECLARE @ReportID NVARCHAR(50)
    SET @ReportID = ''S11-H''
    
	-- Liệt kê danh sách nguồn được chon
    DECLARE @TbListBudgetSource AS TABLE
        (
          BudgetSourceID UNIQUEIDENTIFIER ,
          BudgetSourceCode NVARCHAR(20) ,
          BudgetSourceName NVARCHAR(255)
        )  
    IF @pBudgetSourceID IS NOT NULL
        BEGIN
            INSERT  INTO @TbListBudgetSource
                    SELECT  F.Value ,
                            BS.BudgetSourceCode ,
                            BS.BudgetSourceName
                    FROM    dbo.[Func_ConvertGUIStringIntoTable](@pBudgetSourceID,
                                                              '','') AS F
                            INNER JOIN dbo.BudgetSource AS BS ON F.Value = BS.BudgetSourceID
        END
	  
    DECLARE @CountRowOfBudgetSource INT
    SELECT  @CountRowOfBudgetSource = COUNT(1)
    FROM    @TbListBudgetSource 

    DECLARE @StartOfQuater DATETIME
    SET @StartOfQuater = DATEADD(DAY, -( DAY(@pFromDate) - 1 ), @pFromDate)
    
    SET @StartOfQuater = DATEADD(MONTH,
                                 -( MONTH(@StartOfQuater)
                                    - ROUND(( MONTH(@StartOfQuater) - 1 ) / 3,
                                            0) * 3 - 1 ), @StartOfQuater)
    
    DECLARE @pAccountName NVARCHAR(255)
    SELECT  @pAccountName = A.AccountName
    FROM    dbo.Account AS A
    WHERE   A.AccountNumber = @pAccountNumber
    
    --Check detail by fund
    DECLARE @DetailByFund BIT
    SELECT  @DetailByFund = A.DetailByFund
    FROM    dbo.Account AS A
    WHERE   A.AccountNumber = @pAccountNumber


	  -- Mã nguồn ngân sách
    DECLARE @pBudgetSourceCode NVARCHAR(20)
    DECLARE @pBudgetSourceName NVARCHAR(255)

    SELECT TOP ( 1 )
            @pBudgetSourceCode = BudgetSourceCode ,
            @pBudgetSourceName = BudgetSourceName
    FROM    @TbListBudgetSource

    DECLARE @S11_Temp TABLE
        (
          StartOfMONTH DATETIME ,
          OrderType INT ,
          RefID UNIQUEIDENTIFIER ,
          RefType INT ,
          PostedDate DATETIME ,
          RefNo NVARCHAR(20) ,
          RefDate DATETIME ,
          JournalMemo NVARCHAR(255) ,
          AccountNumber NVARCHAR(20) ,
          AccountName NVARCHAR(255) ,
          FundCode NVARCHAR(20) ,
          FundName NVARCHAR(255) ,
          BudgetChapterCode NVARCHAR(20) ,
          BudgetSourceCode NVARCHAR(20) ,
          BudgetSourceName NVARCHAR(255) ,
          BudgetSubKindItemCode NVARCHAR(20) ,
          AccountingObjectName NVARCHAR(255) ,
          SortOrder NVARCHAR(20) ,
          Cot1 MONEY , --so du
          Cot2 MONEY ,   --psno
          AccCot2 MONEY ,
          QuyCot2 MONEY ,
          Cot3 MONEY ,	--psco
          AccCot3 MONEY ,
          QuyCot3 MONEY
        )
    DECLARE @S11 TABLE
        (
          StartOfMONTH DATETIME ,
          OrderType INT ,
          RefID UNIQUEIDENTIFIER ,
          RefType INT ,
          PostedDate DATETIME ,
          RefNo NVARCHAR(20) ,
          RefDate DATETIME ,
          JournalMemo NVARCHAR(255) ,
          AccountNumber NVARCHAR(20) ,
          AccountName NVARCHAR(255) ,
          FundCode NVARCHAR(20) ,
          FundName NVARCHAR(255) ,
          BudgetChapterCode NVARCHAR(20) ,
          BudgetSourceCode NVARCHAR(20) ,
          BudgetSourceName NVARCHAR(255) ,
          BudgetSubKindItemCode NVARCHAR(20) ,
          AccountingObjectName NVARCHAR(255) ,
          SortOrder NVARCHAR(20) ,
          Cot1 MONEY , --so du
          Cot2 MONEY ,   --psno
          AccCot2 MONEY ,
          QuyCot2 MONEY ,
          Cot3 MONEY ,	--psco
          AccCot3 MONEY ,
          QuyCot3 MONEY
        )
        
    INSERT  INTO @S11_Temp
            SELECT  CASE WHEN GL.PostedDate <= @pFromDate - 1
                         THEN DATEADD(DAY, -( DAY(@pFromDate) - 1 ),
                                      @pFromDate)
                         ELSE DATEADD(DAY, -( DAY(GL.PostedDate) - 1 ),
                                      GL.PostedDate)
                    END AS StartOfMONTH ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN 1
                         ELSE 3
                    END AS OrderType ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefID
                    END AS RefID ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefType
                    END AS RefType ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.PostedDate
                    END AS PostedDate ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefNo
                    END AS RefNo ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefDate
                    END AS RefDate ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.JournalMemo
                    END AS JournalMemo ,
                    @pAccountNumber ,
                    @pAccountName ,
                    CASE WHEN @IsSummaryFund = 1 THEN NULL
                         WHEN @DetailByFund = 0 THEN NULL
                         ELSE '''' --F.FundCode
                    END FundCode ,
                    CASE WHEN @IsSummaryFund = 1 THEN N''<<Tổng hợp>>''
                         WHEN @DetailByFund = 0 THEN NULL
                         ELSE '''' --F.FundName
                    END FundName ,
                    CASE WHEN @IsSummaryBudgetChapter = 1 THEN NULL
                         ELSE GL.BudgetChapterCode
                    END AS BudgetChapterCode ,

					CASE WHEN @pIsSummarySource = 1 THEN NULL
                         WHEN @pIsSummarySource = 0
                              AND @pBudgetSourceID IS NULL
                         THEN BS.BudgetSourceCode
                         ELSE CASE WHEN @CountRowOfBudgetSource = 1
                                   THEN @pBudgetSourceCode
                                   ELSE NULL
                              END
                    END AS BudgetSourceCode ,
                    CASE WHEN @pIsSummarySource = 1 THEN NULL
                         WHEN @pIsSummarySource = 0
                              AND @pBudgetSourceID IS NULL
                         THEN BS.BudgetSourceName
                         ELSE CASE WHEN @CountRowOfBudgetSource = 1
                                   THEN @pBudgetSourceName
                                   ELSE NULL
                              END
                    END AS BudgetSourceName ,

                    CASE WHEN @pSummaryBudgetSubKindItem = 1 THEN NULL
                         WHEN @pBudgetSubKindItemCode IS NOT NULL
                         THEN @pBudgetSubKindItemCode
                         ELSE GL.BudgetSubKindItemCode
                    END AS BudgetSubKindItemCode ,
                    CASE @ShowAccountingObjectInfo
                      WHEN 1 THEN AO.AccountingObjectName
                      ELSE ''''
                    END AS AccountingObjectName ,
                    '''' AS SortOrder ,
                    SUM(CASE WHEN GL.PostedDate <= @pFromDate - 1
                             THEN GL.DebitAmount - GL.CreditAmount
                             ELSE 0
                        END) AS Cot1 ,
                    SUM(CASE WHEN GL.PostedDate BETWEEN @pFromDate AND @pTodate
                             THEN GL.DebitAmount
                             ELSE 0
                        END) AS Cot2 ,
                    SUM(CASE WHEN GL.PostedDate BETWEEN @pStartDate
                                                AND     @pFromDate - 1
                             THEN GL.DebitAmount
                             ELSE 0
                        END) AS AccCot2 ,
                    SUM(CASE WHEN GL.PostedDate BETWEEN @StartOfQuater
                                                AND     @pFromDate - 1
                             THEN GL.DebitAmount
                             ELSE 0
                        END) AS QuyCot2 ,
                    SUM(CASE WHEN GL.PostedDate BETWEEN @pFromDate AND @pTodate
                             THEN GL.CreditAmount
                             ELSE 0
                        END) AS Cot3 ,
                    SUM(CASE WHEN GL.PostedDate BETWEEN @pStartDate
                                                AND     @pFromDate - 1
                             THEN GL.CreditAmount
                             ELSE 0
                        END) AS AccCot3 ,
                    SUM(CASE WHEN GL.PostedDate BETWEEN @StartOfQuater
                                                AND     @pFromDate - 1
                             THEN GL.CreditAmount
                             ELSE 0
                        END) AS QuyCot3
            FROM    [dbo].[ufnGetGeneralLedger](NULL,
                                                  @pBudgetChapterCode, DEFAULT,
                                                  @pBudgetSubKindItemCode,
                                                  DEFAULT, DEFAULT, DEFAULT,
                                                  DEFAULT, DEFAULT, DEFAULT,
                                                  DEFAULT, DEFAULT) AS GL
												   LEFT JOIN @TbListBudgetSource LBS ON LEFT(GL.BudgetSourceCode , LEN(LBS.BudgetSourceCode)) = LBS.BudgetSourceCode
												   --GL.BudgetSourceCode LIKE LBS.BudgetSourceCode+ ''%''
                    --LEFT JOIN dbo.Fund AS F ON F.FundID = GL.FundID
                    LEFT JOIN dbo.BudgetSource BS ON BS.BudgetSourceID = GL.BudgetSourceID
                    LEFT JOIN dbo.AccountingObject AS AO ON GL.AccountingObjectID = AO.AccountingObjectID
            WHERE   GL.PostedDate <= @pTodate
                    AND LEFT(GL.AccountNumber, LEN(@pAccountNumber)) = @pAccountNumber
                    --AND (GL.FundID = @FundID OR @FundID IS NULL) 
                    AND (@pBudgetSourceID IS NULL OR LBS.BudgetSourceCode IS NOT NULL )
            GROUP BY CASE WHEN GL.PostedDate <= @pFromDate - 1
                          THEN DATEADD(DAY, -( DAY(@pFromDate) - 1 ),
                                       @pFromDate)
                          ELSE DATEADD(DAY, -( DAY(GL.PostedDate) - 1 ),
                                       GL.PostedDate)
                     END ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN 1
                         ELSE 3
                    END ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefID
                    END ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefType
                    END ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefNo
                    END ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.PostedDate
                    END ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.RefDate
                    END ,
                    CASE WHEN GL.PostedDate <= @pFromDate - 1 THEN NULL
                         ELSE GL.JournalMemo
                    END ,                    
                    CASE WHEN @IsSummaryBudgetChapter = 1 THEN NULL
                         ELSE GL.BudgetChapterCode
                    END ,
                  	CASE WHEN @pIsSummarySource = 1 THEN NULL
                         WHEN @pIsSummarySource = 0
                              AND @pBudgetSourceID IS NULL
                         THEN BS.BudgetSourceCode
                         ELSE CASE WHEN @CountRowOfBudgetSource = 1
                                   THEN @pBudgetSourceCode
                                   ELSE NULL
                              END
                    END  ,
                    CASE WHEN @pIsSummarySource = 1 THEN NULL
                         WHEN @pIsSummarySource = 0
                              AND @pBudgetSourceID IS NULL
                         THEN BS.BudgetSourceName
                         ELSE CASE WHEN @CountRowOfBudgetSource = 1
                                   THEN @pBudgetSourceName
                                   ELSE NULL
                              END
                    END  ,
                    CASE WHEN @pSummaryBudgetSubKindItem = 1 THEN NULL
                         WHEN @pBudgetSubKindItemCode IS NOT NULL
                         THEN @pBudgetSubKindItemCode
                         ELSE GL.BudgetSubKindItemCode
                    END ,
                    CASE @ShowAccountingObjectInfo
                      WHEN 1 THEN AO.AccountingObjectName
                      ELSE ''''
                    END
   --Lấy khách hàng vãng lai lên sổ quỹ (chỉ gõ trên phần người nộp trên master)
    IF @ShowAccountingObjectInfo = 1
        BEGIN
            DECLARE @RefID UNIQUEIDENTIFIER
            DECLARE @RefType INTEGER

            DECLARE cur CURSOR
            FOR
                SELECT DISTINCT
                        RefID ,
                        RefType
                FROM    @S11_Temp
                WHERE   AccountingObjectName IS NULL
            OPEN cur
            FETCH NEXT FROM cur INTO @RefID, @RefType
            WHILE @@FETCH_STATUS = 0
                BEGIN
                    DECLARE @AccountingObjectName NVARCHAR(255) ,
                        @MasterTableName NVARCHAR(100) ,
                        @SQL NVARCHAR(MAX)
                    DECLARE @param NVARCHAR(255)
                    SET @param = ''@Result NVARCHAR(255) output''
                    SET @AccountingObjectName = ''''
	
                    SELECT  @MasterTableName = MasterTableName
                    FROM    dbo.RefType
                    WHERE   dbo.RefType.RefTypeID = @RefType
	
                    IF EXISTS ( SELECT  *
                                FROM    sys.columns C
                                        LEFT JOIN sys.tables T ON C.Object_id = T.Object_id
                                WHERE   T.Name = @MasterTableName
                                        AND C.Name = ''AccountingObjectName'' )
                        BEGIN
                            SET @SQL = ''SELECT Top 1 @Result=AccountingObjectName FROM ''
                                + @MasterTableName + '' where RefID=''''''
                                + CONVERT(NVARCHAR(100), @RefID) + ''''''''
                            EXEC sp_executesql @SQL, @param,
                                @AccountingObjectName OUTPUT
			
                            UPDATE  @S11_Temp
                            SET     AccountingObjectName = @AccountingObjectName
                            WHERE   RefID = @RefID
                                    AND RefType = @RefType
                                    AND AccountingObjectName IS NULL
                        END	
		
                    FETCH NEXT FROM cur INTO @RefID, @RefType
                END
            CLOSE cur
            DEALLOCATE cur
        END
--cần cộng gộp lại để nhóm đối tượng master và detail
    INSERT  INTO @S11
            ( StartOfMONTH ,
              OrderType ,
              RefID ,
              RefType ,
              PostedDate ,
              RefNo ,
              RefDate ,
              JournalMemo ,
              AccountNumber ,
              AccountName ,
              FundCode ,
              FundName ,
              BudgetChapterCode ,
              BudgetSourceCode ,
              BudgetSourceName ,
              BudgetSubKindItemCode ,
              AccountingObjectName ,
              SortOrder ,
              Cot1 ,
              Cot2 ,
              AccCot2 ,
              QuyCot2 ,
              Cot3 ,
              AccCot3 ,
              QuyCot3
            )
            SELECT  StartOfMONTH ,
                    OrderType ,
                    RefID ,
                    RefType ,
                    PostedDate ,
                    RefNo ,
                    RefDate ,
                    JournalMemo ,
                    AccountNumber ,
                    AccountName ,
                    FundCode ,
                    FundName ,
                    BudgetChapterCode ,
                    BudgetSourceCode ,
                    BudgetSourceName ,
                    BudgetSubKindItemCode ,
                    AccountingObjectName ,
                    SortOrder ,
                    SUM(Cot1) AS Cot1 ,
                    SUM(Cot2) AS Cot2 ,
                    SUM(AccCot2) AS AccCot2 ,
                    SUM(QuyCot2) AS QuyCot2 ,
                    SUM(Cot3) AS Cot3 ,
                    SUM(AccCot3) AS AccCot3 ,
                    SUM(QuyCot3) AS QuyCot3
            FROM    @S11_Temp
            GROUP BY StartOfMONTH ,
                    OrderType ,
                    RefID ,
                    RefType ,
                    PostedDate ,
                    RefNo ,
                    RefDate ,
                    JournalMemo ,
                    AccountNumber ,
                    AccountName ,
                    FundCode ,
                    FundName ,
                    BudgetChapterCode ,
                    BudgetSourceCode ,
                    BudgetSourceName ,
                    BudgetSubKindItemCode ,
                    AccountingObjectName ,
                    SortOrder
------------------------------------------------------
     --bổ sung thêm các tháng trung gian
    DECLARE @tblDate TABLE ( PerMonth DATETIME )
    DECLARE @BeginDate DATETIME
    SET @BeginDate = DATEADD(DAY, -( DAY(@pFromDate) - 1 ), @pFromDate)
    DECLARE @EndDate DATETIME
    SET @EndDate = DATEADD(DAY, -( DAY(@pTodate) - 1 ), @pTodate) 	                                      
    WHILE @BeginDate <= @EndDate
        BEGIN
            INSERT  INTO @tblDate
                    ( PerMonth )
            VALUES  ( @BeginDate )
            SET @BeginDate = DATEADD(MONTH, 1, @BeginDate)		          
        END
   
    INSERT  INTO @S11
            SELECT  TD.PerMonth AS StartOfMONTH ,
                    2 AS OrderType ,
                    NULL AS RefID ,
                    NULL AS RefType ,
                    NULL PostedDate ,
                    NULL RefNo ,
                    NULL RefDate ,
                    NULL JournalMemo ,
                    AccountNumber ,
                    AccountName ,
                    FundCode ,
                    FundName ,
                    BudgetChapterCode ,
                    BudgetSourceCode ,
                    BudgetSourceName ,
                    BudgetSubKindItemCode ,
                    '''' AS AccountingObjectName ,
                    '''' SortOrder ,
                    $0 AS Cot1 ,
                    $0 AS Cot2 ,
                    $0 AS AccCot2 ,
                    $0 AS QuyCot2 ,
                    $0 AS Cot3 ,
                    $0 AS AccCot3 ,
                    $0 AS QuyCot3
            FROM    ( SELECT DISTINCT
                                AccountNumber ,
                                AccountName ,
                                FundCode ,
                                FundName ,
                                BudgetChapterCode ,
                                BudgetSourceCode ,
                                BudgetSourceName ,
                                BudgetSubKindItemCode
                      FROM      @S11
                    ) BU
                    CROSS JOIN @tblDate AS TD 
    
     --end bổ sung thêm các tháng trung gian
    SELECT  DATEADD(MONTH,
                    -( MONTH(StartOfMonth) - ROUND(( MONTH(StartOfMonth) - 1 )
                                                   / 3, 0) * 3 - 1 ),
                    StartOfMonth) AS StartOfQuater ,
            * ,
            ( CASE WHEN @IsSummaryBudgetChapter = 1 THEN 1
                   ELSE 0
              END ) AS IsOneBudgetChapterCode ,
            ( CASE WHEN @pIsSummarySource = 1 THEN 1
                   ELSE 0
              END ) AS IsOneBudgetSourceCode ,
            ( CASE WHEN @pSummaryBudgetSubKindItem = 1 THEN 1
                   ELSE 0
              END ) AS IsOneBudgetSubKindItemCode ,
            CAST(@DetailByFund AS INT) AS DetailByFund
    FROM    @S11
    ORDER BY BudgetChapterCode ,
            BudgetSourceCode ,
            BudgetSubKindItemCode ,
            OrderType ,
            StartOfMonth ,
            SortOrder ,
            PostedDate ,
            CASE WHEN Cot2 > 0 THEN 0
                 ELSE 1
            END ,
            CASE WHEN RefType IN ( 101, 102, 103, 104, 105, 114 ) -- phiếu thu lên trước
                      THEN 0
                 WHEN RefType BETWEEN 106 AND 113				-- tiếp theo là đến phiếu chi
                      THEN 1
                 ELSE 2											-- rồi đến những thằng khác
            END ,
            RefNo




' 
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelete_GeneralLedger_ByAccountNumberAndRefType]    Script Date: 09/12/2018 11:08:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDelete_GeneralLedger_ByAccountNumberAndRefType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ==========================================
-- Author:	<Tudt>
-- Create date:	<12/09/2018>
-- Description:	<Delete GeneralLedger by refid>
-- ==========================================
create PROCEDURE [dbo].[uspDelete_GeneralLedger_ByAccountNumberAndRefType]
	 @AccountNumber NVARCHAR(20)
	,@RefType INT
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		DELETE FROM [dbo].[GeneralLedger]
		WHERE 
			AccountNumber = @AccountNumber
		AND RefType = @RefType
		
	END TRY
	BEGIN CATCH
		-- inserting information in the ErrorLog
		EXECUTE [dbo].[uspLogError];
	END CATCH;
END
' 
END
GO

/****** Object:  StoredProcedure [dbo].[Proc_GetVoucher_RealNameMethod]    Script Date: 09/13/2018 09:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proc_GetVoucher_RealNameMethod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Proc_GetVoucher_RealNameMethod]
    @InventoryItemID UNIQUEIDENTIFIER ,
    @RefDate DATETIME , -- DNThang 25/5/2012: Bổ sung thêm tham số ngày để lấy số tồn theo ngày tháng
    @RefOrder INT ,
    @UnitPriceDecimalDigitNumber INT --Số chữ số thập phân của đơn giá
AS
    BEGIN
		-- Nhập kho
        SELECT  DISTINCT
                I.RefID ,
                I.RefDetailID ,
                I.RefNo ,
                I.RefDate ,
                I.StockID ,
                I.InventoryItemID ,
                ISNULL(S.StockCode, '''') AS StockCode ,
                ISNULL(I.UnitPrice, 0) AS MainUnitPrice ,
                ISNULL(I.UnitPriceBalance, 0) AS UnitPrice ,
                ISNULL(I.InwardQuantityBalance, 0) AS Quantity ,
                ISNULL(I.InwardAmountBalance, 0) AS InwardAmount ,
                I.ExpiryDate ,
                I.LotNo,
                I.Unit
        FROM    [dbo].[Func_IN_GetInwardBalanceForRealName](@RefDate, @RefOrder, CAST(@InventoryItemID AS NVARCHAR(50)),NULL,1,1, @UnitPriceDecimalDigitNumber) AS I
                INNER JOIN dbo.Stock AS S ON S.StockID = I.StockID
        WHERE   I.InwardQuantityBalance > 0 --lấy các nhập còn tồn
                AND I.InwardQuantity > 0 -- Chỉ lấy dữ chứng từ đích danh là dòng chứng từ Nhâp
			


    END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelete_InventoryLedger_ByAccountNumberAndRefType]    Script Date: 09/13/2018 09:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uspDelete_InventoryLedger_ByAccountNumberAndRefType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ==========================================
-- Author:	<ThangND>
-- Create date:	<18/10/2017 >
-- Description:	<Delete Bank transfer detail by refid>
-- ==========================================
CREATE PROCEDURE [dbo].[uspDelete_InventoryLedger_ByAccountNumberAndRefType]
	 @AccountNumber NVARCHAR(20)
	,@RefType INT 
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		DELETE FROM [dbo].[InventoryLedger]
		WHERE 
			AccountNumber = @AccountNumber
		AND RefType = @RefType
	END TRY
	BEGIN CATCH
		-- inserting information in the ErrorLog
		EXECUTE [dbo].[uspLogError];
	END CATCH;
END
' 
END
GO
