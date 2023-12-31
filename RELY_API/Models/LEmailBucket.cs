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
    
    public partial class LEmailBucket
    {
        public int Id { get; set; }
        public string RecipientList { get; set; }
        public string CCList { get; set; }
        public string BCCList { get; set; }
        public string ReplyToList { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHTML { get; set; }
        public string EmailType { get; set; }
        public string Priority { get; set; }
        public string AttachmentList { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public int UpdatedById { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
        public int SenderConfigId { get; set; }
        public Nullable<System.DateTime> SentDateTime { get; set; }
    
        public virtual GEmailConfiguration GEmailConfiguration { get; set; }
        public virtual LUser LUser { get; set; }
        public virtual LUser LUser1 { get; set; }
    }
}
