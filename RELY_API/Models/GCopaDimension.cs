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
    
    public partial class GCopaDimension
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GCopaDimension()
        {
            this.MPobCopaMappings = new HashSet<MPobCopaMapping>();
        }
    
        public int Id { get; set; }
        public int Class { get; set; }
        public string CopaValue { get; set; }
        public string Description { get; set; }
        public string Dimension { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int UpdatedById { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
        public string DimentionClassDescription { get; set; }
        public string CompanyCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MPobCopaMapping> MPobCopaMappings { get; set; }
        public virtual LUser LUser { get; set; }
        public virtual LUser LUser1 { get; set; }
    }
}
