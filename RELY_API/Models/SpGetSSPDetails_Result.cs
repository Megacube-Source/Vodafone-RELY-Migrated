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
    
    public partial class SpGetSSPDetails_Result
    {
        public int Id { get; set; }
        public int SspId { get; set; }
        public decimal SspAmount { get; set; }
        public System.DateTime EffectiveStartDate { get; set; }
        public System.DateTime EffectiveEndDate { get; set; }
        public string CompanyCode { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int UpdatedById { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
    }
}