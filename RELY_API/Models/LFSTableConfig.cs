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
    
    public partial class LFSTableConfig
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string TableCode { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public string QuestionCode { get; set; }
        public string ItemText { get; set; }
        public Nullable<int> ItemTypeId { get; set; }
        public string ShowOnQuestionCode { get; set; }
        public string ShowOnAnswerOption { get; set; }
        public bool IsResponseAutoGenerated { get; set; }
        public string SumOfQuestions { get; set; }
        public string Operator { get; set; }
        public Nullable<int> SumValue { get; set; }
        public string AutomatedResponseTrueValue { get; set; }
        public string AutomatedResponseFalseValue { get; set; }
        public string ShowResponseFromQuestionCode { get; set; }
    
        public virtual LFSItemType LFSItemType { get; set; }
    }
}