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
    
    public partial class MMenuRole
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public string HelpFileUrl { get; set; }
    
        public virtual GMenu GMenu { get; set; }
        public virtual LRole LRole { get; set; }
    }
}
