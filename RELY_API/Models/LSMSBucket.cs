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
    
    public partial class LSMSBucket
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
        public string SenderId { get; set; }
        public string SMSType { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
    }
}
