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
    
    public partial class GEmailConfiguration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GEmailConfiguration()
        {
            this.LEmailBuckets = new HashSet<LEmailBucket>();
        }
    
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountDescription { get; set; }
        public string EmailId { get; set; }
        public string DisplayName { get; set; }
        public string ReplyTo { get; set; }
        public string SmtpHost { get; set; }
        public int PortNumber { get; set; }
        public string SmtpLoginId { get; set; }
        public string SmtpPassword { get; set; }
        public bool RequiresSSL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LEmailBucket> LEmailBuckets { get; set; }
    }
}