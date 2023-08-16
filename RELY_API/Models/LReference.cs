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
    
    public partial class LReference
    {
        public int Id { get; set; }
        public int ReferenceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> WFOrdinal { get; set; }
        public string WFStatus { get; set; }
        public string WFType { get; set; }
        public string WFComments { get; set; }
        public Nullable<int> WFRequesterId { get; set; }
        public Nullable<int> WFAnalystId { get; set; }
        public Nullable<int> WFManagerId { get; set; }
        public Nullable<int> WFCurrentOwnerId { get; set; }
        public Nullable<int> WFRequesterRoleId { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int UpdatedById { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> WFStatusDateTime { get; set; }
        public Nullable<System.DateTime> WFIsReadyDateTime { get; set; }
        public string ExtractFileName { get; set; }
        public int Version { get; set; }
        public string CompanyCode { get; set; }
    
        public virtual LReferenceType LReferenceType { get; set; }
        public virtual LRole LRole { get; set; }
        public virtual LUser LUser { get; set; }
        public virtual LUser LUser1 { get; set; }
        public virtual LUser LUser2 { get; set; }
        public virtual LUser LUser3 { get; set; }
        public virtual LUser LUser4 { get; set; }
        public virtual LUser LUser5 { get; set; }
    }
}
