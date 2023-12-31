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
    
    public partial class LFSSurveyLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LFSSurveyLevel()
        {
            this.LFinancialSurveys = new HashSet<LFinancialSurvey>();
            this.LRequests = new HashSet<LRequest>();
            this.MLFSQuestionBankLFSSurveyLevels = new HashSet<MLFSQuestionBankLFSSurveyLevel>();
        }
    
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LFinancialSurvey> LFinancialSurveys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LRequest> LRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MLFSQuestionBankLFSSurveyLevel> MLFSQuestionBankLFSSurveyLevels { get; set; }
        public virtual LUser LUser { get; set; }
        public virtual LUser LUser1 { get; set; }
    }
}
