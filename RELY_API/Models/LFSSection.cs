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
    using System.Collections.Generic;
    
    public partial class LFSSection
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string ChapterCode { get; set; }
        public string SectionName { get; set; }
        public string SectionCode { get; set; }
        public int Ordinal { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int UpdatedById { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
        public string InternalNotes { get; set; }
    
        public virtual LFinancialSurvey LFinancialSurvey { get; set; }
        public virtual LUser LUser { get; set; }
        public virtual LUser LUser1 { get; set; }
    }
}