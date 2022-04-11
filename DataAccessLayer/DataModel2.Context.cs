﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TestVariousInfo_WithDataEntities : DbContext
    {
        public TestVariousInfo_WithDataEntities()
            : base("name=TestVariousInfo_WithDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgingFileInfo> AgingFileInfoes { get; set; }
        public virtual DbSet<AgingInvoice> AgingInvoices { get; set; }
        public virtual DbSet<AppSetting> AppSettings { get; set; }
        public virtual DbSet<Bcad_Capacity> Bcad_Capacity { get; set; }
        public virtual DbSet<Bcad_Crane> Bcad_Crane { get; set; }
        public virtual DbSet<Bcad_CraneConfig> Bcad_CraneConfig { get; set; }
        public virtual DbSet<Bcad_CraneCoordinate> Bcad_CraneCoordinate { get; set; }
        public virtual DbSet<Bcad_CraneData> Bcad_CraneData { get; set; }
        public virtual DbSet<Bcad_ElevationInfo> Bcad_ElevationInfo { get; set; }
        public virtual DbSet<Bcad_PickChartCoordinate> Bcad_PickChartCoordinate { get; set; }
        public virtual DbSet<Bcad_ProjectName> Bcad_ProjectName { get; set; }
        public virtual DbSet<Bcad_Radius> Bcad_Radius { get; set; }
        public virtual DbSet<Bcad_Site> Bcad_Site { get; set; }
        public virtual DbSet<Bcad_SiteInfo> Bcad_SiteInfo { get; set; }
        public virtual DbSet<ColorEmailDescription> ColorEmailDescriptions { get; set; }
        public virtual DbSet<ColorSetting> ColorSettings { get; set; }
        public virtual DbSet<CommunicationLog> CommunicationLogs { get; set; }
        public virtual DbSet<CommunityBoard> CommunityBoards { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CRVExpensesInvoice> CRVExpensesInvoices { get; set; }
        public virtual DbSet<CRVTimeInvoice> CRVTimeInvoices { get; set; }
        public virtual DbSet<DocTypicalCategoryList> DocTypicalCategoryLists { get; set; }
        public virtual DbSet<DocTypicalListItem> DocTypicalListItems { get; set; }
        public virtual DbSet<DrawingLog> DrawingLogs { get; set; }
        public virtual DbSet<EmailRecord> EmailRecords { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeDetails_Depre> EmployeeDetails_Depre { get; set; }
        public virtual DbSet<ImportTimeSheetData> ImportTimeSheetDatas { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceAction> InvoiceActions { get; set; }
        public virtual DbSet<JobList> JobLists { get; set; }
        public virtual DbSet<JobTracking> JobTrackings { get; set; }
        public virtual DbSet<JobTrackInvoiceDetail> JobTrackInvoiceDetails { get; set; }
        public virtual DbSet<JobTrackInvoiceRateDetail> JobTrackInvoiceRateDetails { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<MasterItem> MasterItems { get; set; }
        public virtual DbSet<MasterTrackSet> MasterTrackSets { get; set; }
        public virtual DbSet<MasterTrackSubItem> MasterTrackSubItems { get; set; }
        public virtual DbSet<SendEmailRecord> SendEmailRecords { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaskList> TaskLists { get; set; }
        public virtual DbSet<TrackSubItemAccount> TrackSubItemAccounts { get; set; }
        public virtual DbSet<TS_Expences> TS_Expences { get; set; }
        public virtual DbSet<TS_MasterItem> TS_MasterItem { get; set; }
        public virtual DbSet<TS_Time> TS_Time { get; set; }
        public virtual DbSet<VBCDDatabase> VBCDDatabases { get; set; }
        public virtual DbSet<VBFormInfo> VBFormInfoes { get; set; }
        public virtual DbSet<VBNetApplicantInfo> VBNetApplicantInfoes { get; set; }
        public virtual DbSet<VersionDescription> VersionDescriptions { get; set; }
        public virtual DbSet<VersionTable> VersionTables { get; set; }
        public virtual DbSet<VETask> VETasks { get; set; }
        public virtual DbSet<ActivityInfo> ActivityInfoes { get; set; }
        public virtual DbSet<ColorHistory> ColorHistories { get; set; }
        public virtual DbSet<PMInfo> PMInfoes { get; set; }
        public virtual DbSet<EmailJobPendingList> EmailJobPendingLists { get; set; }
        public virtual DbSet<InvoiceJobList> InvoiceJobLists { get; set; }
        public virtual DbSet<InvoicePreview> InvoicePreviews { get; set; }
        public virtual DbSet<InvoicePreview_1> InvoicePreview_1 { get; set; }
        public virtual DbSet<MasterTrackSubDisplay> MasterTrackSubDisplays { get; set; }
        public virtual DbSet<rptInvoiceExpens> rptInvoiceExpenses { get; set; }
        public virtual DbSet<rptInvoiceTime> rptInvoiceTimes { get; set; }
        public virtual DbSet<SysDatabasesView> SysDatabasesViews { get; set; }
        public virtual DbSet<view_Temp> view_Temp { get; set; }
        public virtual DbSet<vw_Item_Time_Expense> vw_Item_Time_Expense { get; set; }
        public virtual DbSet<VW_PandingList> VW_PandingList { get; set; }
        public virtual DbSet<vwJobListDefaultValue> vwJobListDefaultValues { get; set; }
        public virtual DbSet<vWordTran> vWordTrans { get; set; }
    
        [DbFunction("TestVariousInfo_WithDataEntities", "SplitString")]
        public virtual IQueryable<SplitString_Result> SplitString(string input, string character)
        {
            var inputParameter = input != null ?
                new ObjectParameter("Input", input) :
                new ObjectParameter("Input", typeof(string));
    
            var characterParameter = character != null ?
                new ObjectParameter("Character", character) :
                new ObjectParameter("Character", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<SplitString_Result>("[TestVariousInfo_WithDataEntities].[SplitString](@Input, @Character)", inputParameter, characterParameter);
        }
    
        public virtual ObjectResult<proc_GetBillableJobDisableSearchData_Result> proc_GetBillableJobDisableSearchData(Nullable<int> nOCreditColor, Nullable<int> greenColor, Nullable<int> yellowColor, Nullable<int> orangeColor, Nullable<int> redColor, Nullable<int> blackColor, Nullable<decimal> defaultAmount)
        {
            var nOCreditColorParameter = nOCreditColor.HasValue ?
                new ObjectParameter("NOCreditColor", nOCreditColor) :
                new ObjectParameter("NOCreditColor", typeof(int));
    
            var greenColorParameter = greenColor.HasValue ?
                new ObjectParameter("GreenColor", greenColor) :
                new ObjectParameter("GreenColor", typeof(int));
    
            var yellowColorParameter = yellowColor.HasValue ?
                new ObjectParameter("yellowColor", yellowColor) :
                new ObjectParameter("yellowColor", typeof(int));
    
            var orangeColorParameter = orangeColor.HasValue ?
                new ObjectParameter("OrangeColor", orangeColor) :
                new ObjectParameter("OrangeColor", typeof(int));
    
            var redColorParameter = redColor.HasValue ?
                new ObjectParameter("RedColor", redColor) :
                new ObjectParameter("RedColor", typeof(int));
    
            var blackColorParameter = blackColor.HasValue ?
                new ObjectParameter("BlackColor", blackColor) :
                new ObjectParameter("BlackColor", typeof(int));
    
            var defaultAmountParameter = defaultAmount.HasValue ?
                new ObjectParameter("DefaultAmount", defaultAmount) :
                new ObjectParameter("DefaultAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_GetBillableJobDisableSearchData_Result>("proc_GetBillableJobDisableSearchData", nOCreditColorParameter, greenColorParameter, yellowColorParameter, orangeColorParameter, redColorParameter, blackColorParameter, defaultAmountParameter);
        }
    
        public virtual ObjectResult<proc_GetBillableJobSearchData_Result> proc_GetBillableJobSearchData(Nullable<int> nOCreditColor, Nullable<int> greenColor, Nullable<int> yellowColor, Nullable<int> orangeColor, Nullable<int> redColor, Nullable<int> blackColor, Nullable<decimal> defaultAmount)
        {
            var nOCreditColorParameter = nOCreditColor.HasValue ?
                new ObjectParameter("NOCreditColor", nOCreditColor) :
                new ObjectParameter("NOCreditColor", typeof(int));
    
            var greenColorParameter = greenColor.HasValue ?
                new ObjectParameter("GreenColor", greenColor) :
                new ObjectParameter("GreenColor", typeof(int));
    
            var yellowColorParameter = yellowColor.HasValue ?
                new ObjectParameter("yellowColor", yellowColor) :
                new ObjectParameter("yellowColor", typeof(int));
    
            var orangeColorParameter = orangeColor.HasValue ?
                new ObjectParameter("OrangeColor", orangeColor) :
                new ObjectParameter("OrangeColor", typeof(int));
    
            var redColorParameter = redColor.HasValue ?
                new ObjectParameter("RedColor", redColor) :
                new ObjectParameter("RedColor", typeof(int));
    
            var blackColorParameter = blackColor.HasValue ?
                new ObjectParameter("BlackColor", blackColor) :
                new ObjectParameter("BlackColor", typeof(int));
    
            var defaultAmountParameter = defaultAmount.HasValue ?
                new ObjectParameter("DefaultAmount", defaultAmount) :
                new ObjectParameter("DefaultAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_GetBillableJobSearchData_Result>("proc_GetBillableJobSearchData", nOCreditColorParameter, greenColorParameter, yellowColorParameter, orangeColorParameter, redColorParameter, blackColorParameter, defaultAmountParameter);
        }
    
        public virtual ObjectResult<proc_GetBillableJobSearchDataTest_Result> proc_GetBillableJobSearchDataTest(Nullable<int> nOCreditColor, Nullable<int> greenColor, Nullable<int> yellowColor, Nullable<int> orangeColor, Nullable<int> redColor, Nullable<int> blackColor, Nullable<decimal> defaultAmount)
        {
            var nOCreditColorParameter = nOCreditColor.HasValue ?
                new ObjectParameter("NOCreditColor", nOCreditColor) :
                new ObjectParameter("NOCreditColor", typeof(int));
    
            var greenColorParameter = greenColor.HasValue ?
                new ObjectParameter("GreenColor", greenColor) :
                new ObjectParameter("GreenColor", typeof(int));
    
            var yellowColorParameter = yellowColor.HasValue ?
                new ObjectParameter("yellowColor", yellowColor) :
                new ObjectParameter("yellowColor", typeof(int));
    
            var orangeColorParameter = orangeColor.HasValue ?
                new ObjectParameter("OrangeColor", orangeColor) :
                new ObjectParameter("OrangeColor", typeof(int));
    
            var redColorParameter = redColor.HasValue ?
                new ObjectParameter("RedColor", redColor) :
                new ObjectParameter("RedColor", typeof(int));
    
            var blackColorParameter = blackColor.HasValue ?
                new ObjectParameter("BlackColor", blackColor) :
                new ObjectParameter("BlackColor", typeof(int));
    
            var defaultAmountParameter = defaultAmount.HasValue ?
                new ObjectParameter("DefaultAmount", defaultAmount) :
                new ObjectParameter("DefaultAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_GetBillableJobSearchDataTest_Result>("proc_GetBillableJobSearchDataTest", nOCreditColorParameter, greenColorParameter, yellowColorParameter, orangeColorParameter, redColorParameter, blackColorParameter, defaultAmountParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<SP_GetInvoiceDetailByJobNumber_Result> SP_GetInvoiceDetailByJobNumber(string jobNumber, string name)
        {
            var jobNumberParameter = jobNumber != null ?
                new ObjectParameter("JobNumber", jobNumber) :
                new ObjectParameter("JobNumber", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetInvoiceDetailByJobNumber_Result>("SP_GetInvoiceDetailByJobNumber", jobNumberParameter, nameParameter);
        }
    
        public virtual ObjectResult<SP_GetInvoiceDetailByJobNumber_All_Result> SP_GetInvoiceDetailByJobNumber_All()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetInvoiceDetailByJobNumber_All_Result>("SP_GetInvoiceDetailByJobNumber_All");
        }
    
        public virtual ObjectResult<SP_GetInvoiceDetailByJobNumber_All_New_Result> SP_GetInvoiceDetailByJobNumber_All_New(string jobNumber, string name, string invoiceNo, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo)
        {
            var jobNumberParameter = jobNumber != null ?
                new ObjectParameter("JobNumber", jobNumber) :
                new ObjectParameter("JobNumber", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("dateFrom", dateFrom) :
                new ObjectParameter("dateFrom", typeof(System.DateTime));
    
            var dateToParameter = dateTo.HasValue ?
                new ObjectParameter("dateTo", dateTo) :
                new ObjectParameter("dateTo", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetInvoiceDetailByJobNumber_All_New_Result>("SP_GetInvoiceDetailByJobNumber_All_New", jobNumberParameter, nameParameter, invoiceNoParameter, dateFromParameter, dateToParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_InvoiceDetailReduction_Result> sp_InvoiceDetailReduction(Nullable<int> jobTrackDetailId, Nullable<decimal> reduction, Nullable<bool> itemReduc, Nullable<bool> timeReduc, Nullable<bool> expenseReduc)
        {
            var jobTrackDetailIdParameter = jobTrackDetailId.HasValue ?
                new ObjectParameter("JobTrackDetailId", jobTrackDetailId) :
                new ObjectParameter("JobTrackDetailId", typeof(int));
    
            var reductionParameter = reduction.HasValue ?
                new ObjectParameter("Reduction", reduction) :
                new ObjectParameter("Reduction", typeof(decimal));
    
            var itemReducParameter = itemReduc.HasValue ?
                new ObjectParameter("ItemReduc", itemReduc) :
                new ObjectParameter("ItemReduc", typeof(bool));
    
            var timeReducParameter = timeReduc.HasValue ?
                new ObjectParameter("TimeReduc", timeReduc) :
                new ObjectParameter("TimeReduc", typeof(bool));
    
            var expenseReducParameter = expenseReduc.HasValue ?
                new ObjectParameter("ExpenseReduc", expenseReduc) :
                new ObjectParameter("ExpenseReduc", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InvoiceDetailReduction_Result>("sp_InvoiceDetailReduction", jobTrackDetailIdParameter, reductionParameter, itemReducParameter, timeReducParameter, expenseReducParameter);
        }
    
        public virtual ObjectResult<sp_InvoiceDetailReductioTesting_Result> sp_InvoiceDetailReductioTesting(Nullable<long> jobTrackDetailId, string invoiceNo, Nullable<decimal> reduction, Nullable<bool> itemReduc, Nullable<bool> timeReduc)
        {
            var jobTrackDetailIdParameter = jobTrackDetailId.HasValue ?
                new ObjectParameter("JobTrackDetailId", jobTrackDetailId) :
                new ObjectParameter("JobTrackDetailId", typeof(long));
    
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            var reductionParameter = reduction.HasValue ?
                new ObjectParameter("Reduction", reduction) :
                new ObjectParameter("Reduction", typeof(decimal));
    
            var itemReducParameter = itemReduc.HasValue ?
                new ObjectParameter("ItemReduc", itemReduc) :
                new ObjectParameter("ItemReduc", typeof(bool));
    
            var timeReducParameter = timeReduc.HasValue ?
                new ObjectParameter("TimeReduc", timeReduc) :
                new ObjectParameter("TimeReduc", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InvoiceDetailReductioTesting_Result>("sp_InvoiceDetailReductioTesting", jobTrackDetailIdParameter, invoiceNoParameter, reductionParameter, itemReducParameter, timeReducParameter);
        }
    
        public virtual ObjectResult<sp_InvoiceReportItems_Result> sp_InvoiceReportItems(Nullable<long> jobTrackDetailId, string invoiceNo, Nullable<decimal> reduction, Nullable<bool> itemReduc, Nullable<bool> timeReduc, Nullable<bool> expReduc)
        {
            var jobTrackDetailIdParameter = jobTrackDetailId.HasValue ?
                new ObjectParameter("JobTrackDetailId", jobTrackDetailId) :
                new ObjectParameter("JobTrackDetailId", typeof(long));
    
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            var reductionParameter = reduction.HasValue ?
                new ObjectParameter("Reduction", reduction) :
                new ObjectParameter("Reduction", typeof(decimal));
    
            var itemReducParameter = itemReduc.HasValue ?
                new ObjectParameter("ItemReduc", itemReduc) :
                new ObjectParameter("ItemReduc", typeof(bool));
    
            var timeReducParameter = timeReduc.HasValue ?
                new ObjectParameter("TimeReduc", timeReduc) :
                new ObjectParameter("TimeReduc", typeof(bool));
    
            var expReducParameter = expReduc.HasValue ?
                new ObjectParameter("ExpReduc", expReduc) :
                new ObjectParameter("ExpReduc", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InvoiceReportItems_Result>("sp_InvoiceReportItems", jobTrackDetailIdParameter, invoiceNoParameter, reductionParameter, itemReducParameter, timeReducParameter, expReducParameter);
        }
    
        public virtual ObjectResult<sp_InvoiceReportItemsTesting_Result> sp_InvoiceReportItemsTesting(Nullable<long> jobTrackDetailId, string invoiceNo, Nullable<decimal> reduction, Nullable<bool> itemReduc, Nullable<bool> timeReduc)
        {
            var jobTrackDetailIdParameter = jobTrackDetailId.HasValue ?
                new ObjectParameter("JobTrackDetailId", jobTrackDetailId) :
                new ObjectParameter("JobTrackDetailId", typeof(long));
    
            var invoiceNoParameter = invoiceNo != null ?
                new ObjectParameter("InvoiceNo", invoiceNo) :
                new ObjectParameter("InvoiceNo", typeof(string));
    
            var reductionParameter = reduction.HasValue ?
                new ObjectParameter("Reduction", reduction) :
                new ObjectParameter("Reduction", typeof(decimal));
    
            var itemReducParameter = itemReduc.HasValue ?
                new ObjectParameter("ItemReduc", itemReduc) :
                new ObjectParameter("ItemReduc", typeof(bool));
    
            var timeReducParameter = timeReduc.HasValue ?
                new ObjectParameter("TimeReduc", timeReduc) :
                new ObjectParameter("TimeReduc", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_InvoiceReportItemsTesting_Result>("sp_InvoiceReportItemsTesting", jobTrackDetailIdParameter, invoiceNoParameter, reductionParameter, itemReducParameter, timeReducParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<SP_ShowJobList_Result> SP_ShowJobList(Nullable<System.DateTime> todayDate, Nullable<int> selectQuery)
        {
            var todayDateParameter = todayDate.HasValue ?
                new ObjectParameter("TodayDate", todayDate) :
                new ObjectParameter("TodayDate", typeof(System.DateTime));
    
            var selectQueryParameter = selectQuery.HasValue ?
                new ObjectParameter("SelectQuery", selectQuery) :
                new ObjectParameter("SelectQuery", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ShowJobList_Result>("SP_ShowJobList", todayDateParameter, selectQueryParameter);
        }
    
        public virtual ObjectResult<SP_ShowJobTrackingList_Result> SP_ShowJobTrackingList(Nullable<System.DateTime> todayDate, Nullable<int> selectQuery, string jobListID_Collection)
        {
            var todayDateParameter = todayDate.HasValue ?
                new ObjectParameter("TodayDate", todayDate) :
                new ObjectParameter("TodayDate", typeof(System.DateTime));
    
            var selectQueryParameter = selectQuery.HasValue ?
                new ObjectParameter("SelectQuery", selectQuery) :
                new ObjectParameter("SelectQuery", typeof(int));
    
            var jobListID_CollectionParameter = jobListID_Collection != null ?
                new ObjectParameter("JobListID_Collection", jobListID_Collection) :
                new ObjectParameter("JobListID_Collection", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ShowJobTrackingList_Result>("SP_ShowJobTrackingList", todayDateParameter, selectQueryParameter, jobListID_CollectionParameter);
        }
    
        public virtual ObjectResult<string> SP_TaskGetJobNumber(Nullable<System.DateTime> queryDate, string selectQuery)
        {
            var queryDateParameter = queryDate.HasValue ?
                new ObjectParameter("QueryDate", queryDate) :
                new ObjectParameter("QueryDate", typeof(System.DateTime));
    
            var selectQueryParameter = selectQuery != null ?
                new ObjectParameter("SelectQuery", selectQuery) :
                new ObjectParameter("SelectQuery", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_TaskGetJobNumber", queryDateParameter, selectQueryParameter);
        }
    
        public virtual int SP_UpdateConvertInvoiceExpenses(string xmlString, string billState)
        {
            var xmlStringParameter = xmlString != null ?
                new ObjectParameter("xmlString", xmlString) :
                new ObjectParameter("xmlString", typeof(string));
    
            var billStateParameter = billState != null ?
                new ObjectParameter("billState", billState) :
                new ObjectParameter("billState", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateConvertInvoiceExpenses", xmlStringParameter, billStateParameter);
        }
    
        public virtual int SP_UpdateConvertInvoiceItem(string xmlString, string billState, Nullable<int> jobListID)
        {
            var xmlStringParameter = xmlString != null ?
                new ObjectParameter("xmlString", xmlString) :
                new ObjectParameter("xmlString", typeof(string));
    
            var billStateParameter = billState != null ?
                new ObjectParameter("billState", billState) :
                new ObjectParameter("billState", typeof(string));
    
            var jobListIDParameter = jobListID.HasValue ?
                new ObjectParameter("jobListID", jobListID) :
                new ObjectParameter("jobListID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateConvertInvoiceItem", xmlStringParameter, billStateParameter, jobListIDParameter);
        }
    
        public virtual int SP_UpdateConvertInvoiceTime(string xmlString, string billState)
        {
            var xmlStringParameter = xmlString != null ?
                new ObjectParameter("xmlString", xmlString) :
                new ObjectParameter("xmlString", typeof(string));
    
            var billStateParameter = billState != null ?
                new ObjectParameter("billState", billState) :
                new ObjectParameter("billState", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateConvertInvoiceTime", xmlStringParameter, billStateParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spUndoInvoiceDetails(Nullable<int> jobTrackDetailId, Nullable<bool> isUndo)
        {
            var jobTrackDetailIdParameter = jobTrackDetailId.HasValue ?
                new ObjectParameter("JobTrackDetailId", jobTrackDetailId) :
                new ObjectParameter("JobTrackDetailId", typeof(int));
    
            var isUndoParameter = isUndo.HasValue ?
                new ObjectParameter("IsUndo", isUndo) :
                new ObjectParameter("IsUndo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUndoInvoiceDetails", jobTrackDetailIdParameter, isUndoParameter);
        }
    
        public virtual int spUndoInvoiceDetailsTetsing(Nullable<int> jobTrackDetailId, Nullable<bool> isUndo)
        {
            var jobTrackDetailIdParameter = jobTrackDetailId.HasValue ?
                new ObjectParameter("JobTrackDetailId", jobTrackDetailId) :
                new ObjectParameter("JobTrackDetailId", typeof(int));
    
            var isUndoParameter = isUndo.HasValue ?
                new ObjectParameter("IsUndo", isUndo) :
                new ObjectParameter("IsUndo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUndoInvoiceDetailsTetsing", jobTrackDetailIdParameter, isUndoParameter);
        }
    }
}