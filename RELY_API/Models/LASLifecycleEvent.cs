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
    
    public partial class LASLifecycleEvent
    {
        public int Id { get; set; }
        public int AccountingScenarioId { get; set; }
        public int Ordinal { get; set; }
        public int NatureId { get; set; }
        public int EventId { get; set; }
        public string Notes { get; set; }
    
        public virtual LAccountingScenario LAccountingScenario { get; set; }
        public virtual LDropDownValue LDropDownValue { get; set; }
        public virtual LDropDownValue LDropDownValue1 { get; set; }
    }
}
