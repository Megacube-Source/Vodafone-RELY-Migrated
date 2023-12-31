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
    
    public partial class LFSQuestionBank
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public int ItemTypeId { get; set; }
        public string QuestionCode { get; set; }
        public string QuestionName { get; set; }
        public string Comments { get; set; }
        public string ReadableName { get; set; }
        public string QuestionText { get; set; }
        public string ToolTip { get; set; }
        public string VGAPReference { get; set; }
        public string IFRSReference { get; set; }
        public bool IsActive { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int UpdatedById { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
        public string InternalNotes { get; set; }
    
        public virtual LFSItemType LFSItemType { get; set; }
        public virtual LUser LUser { get; set; }
        public virtual LUser LUser1 { get; set; }
    }
}
