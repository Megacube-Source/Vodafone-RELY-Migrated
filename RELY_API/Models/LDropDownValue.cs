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
    
    public partial class LDropDownValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LDropDownValue()
        {
            this.LAccountingScenarios = new HashSet<LAccountingScenario>();
            this.LASLifecycleEvents = new HashSet<LASLifecycleEvent>();
            this.LASLifecycleEvents1 = new HashSet<LASLifecycleEvent>();
            this.LScenarioDemands = new HashSet<LScenarioDemand>();
        }
    
        public int Id { get; set; }
        public int DropDownId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LAccountingScenario> LAccountingScenarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LASLifecycleEvent> LASLifecycleEvents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LASLifecycleEvent> LASLifecycleEvents1 { get; set; }
        public virtual LDropDown LDropDown { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LScenarioDemand> LScenarioDemands { get; set; }
    }
}
