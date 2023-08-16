//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RELY_API.Models
{
    using System;
    
    public partial class SPRPTRequestDetails_Result
    {
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string SysCatName { get; set; }
        public string BusinessCategory { get; set; }
        public string ContractDuration { get; set; }
        public Nullable<decimal> ProductSSP { get; set; }
        public Nullable<System.DateTime> ProductStartDate { get; set; }
        public Nullable<bool> IsAccMemoBuilt { get; set; }
        public Nullable<bool> IsMgmtSummaryBuilt { get; set; }
        public string SurveyName { get; set; }
        public Nullable<int> SspId { get; set; }
        public Nullable<int> ProductPobId { get; set; }
        public Nullable<decimal> Pay_ { get; set; }
        public Nullable<int> LocalPobId { get; set; }
        public string LocalPobsName { get; set; }
        public string LocalPobsDescription { get; set; }
        public Nullable<int> LocalPobsVersion { get; set; }
        public string SpecialIndicator { get; set; }
        public string ArticleNumber { get; set; }
        public Nullable<decimal> PobSSP { get; set; }
        public Nullable<System.DateTime> PobStartDate { get; set; }
        public Nullable<bool> PobIndicator { get; set; }
        public Nullable<bool> UsageIndicator { get; set; }
        public Nullable<bool> BundleIndicator { get; set; }
        public Nullable<int> SspId1 { get; set; }
        public string Copa_Description { get; set; }
        public string GlobalPOBSName { get; set; }
    }
}