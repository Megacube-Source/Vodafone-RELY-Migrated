﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RELY_API.Models
{
    public class LProductViewModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public Nullable<int> RequestId { get; set; }
        public string ProductCode { get; set; }
        public string Product { get; set; }
        public string Name { get; set; }
        public string SysCat { get; set; }
        public string SelecterType { get; set; }
        public int SysCatId { get; set; }
        //public int Version { get; set; }
        public string AttributeC01 { get; set; }
        public string AttributeC02 { get; set; }
        public string AttributeC03 { get; set; }
        public string AttributeC04 { get; set; }
        public string AttributeC05 { get; set; }
        public string AttributeC06 { get; set; }
        public string AttributeC07 { get; set; }
        public string AttributeC08 { get; set; }
        public string AttributeC09 { get; set; }
        public string AttributeC10 { get; set; }
        public string AttributeC11 { get; set; }
        public string AttributeC12 { get; set; }
        public string AttributeC13 { get; set; }
        public string AttributeC14 { get; set; }
        public string AttributeC15 { get; set; }
        public string AttributeC16 { get; set; }
        public string AttributeC17 { get; set; }
        public string AttributeC18 { get; set; }
        public string AttributeC19 { get; set; }
        public string AttributeC20 { get; set; }
        public string AttributeM01 { get; set; }
        public string AttributeM02 { get; set; }
        public string AttributeM03 { get; set; }
        public string AttributeM04 { get; set; }
        public string AttributeM05 { get; set; }
        public Nullable<int> AttributeI01 { get; set; }
        public Nullable<int> AttributeI02 { get; set; }
        public Nullable<int> AttributeI03 { get; set; }
        public Nullable<int> AttributeI04 { get; set; }
        public Nullable<int> AttributeI05 { get; set; }
        public Nullable<int> AttributeI06 { get; set; }
        public Nullable<int> AttributeI07 { get; set; }
        public Nullable<int> AttributeI08 { get; set; }
        public Nullable<int> AttributeI09 { get; set; }
        public Nullable<int> AttributeI10 { get; set; }
        public Nullable<decimal> AttributeN01 { get; set; }
        public Nullable<decimal> AttributeN02 { get; set; }
        public Nullable<decimal> AttributeN03 { get; set; }
        public Nullable<decimal> AttributeN04 { get; set; }
        public Nullable<decimal> AttributeN05 { get; set; }
        public Nullable<decimal> AttributeN06 { get; set; }
        public Nullable<decimal> AttributeN07 { get; set; }
        public Nullable<decimal> AttributeN08 { get; set; }
        public Nullable<decimal> AttributeN09 { get; set; }
        public Nullable<decimal> AttributeN10 { get; set; }
        public Nullable<System.DateTime> AttributeD01 { get; set; }
        public Nullable<System.DateTime> AttributeD02 { get; set; }
        public Nullable<System.DateTime> AttributeD03 { get; set; }
        public Nullable<System.DateTime> AttributeD04 { get; set; }
        public Nullable<System.DateTime> AttributeD05 { get; set; }
        public Nullable<System.DateTime> AttributeD06 { get; set; }
        public Nullable<System.DateTime> AttributeD07 { get; set; }
        public Nullable<System.DateTime> AttributeD08 { get; set; }
        public Nullable<System.DateTime> AttributeD09 { get; set; }
        public Nullable<System.DateTime> AttributeD10 { get; set; }
        public Nullable<bool> AttributeB01 { get; set; }
        public Nullable<bool> AttributeB02 { get; set; }
        public Nullable<bool> AttributeB03 { get; set; }
        public Nullable<bool> AttributeB04 { get; set; }
        public Nullable<bool> AttributeB05 { get; set; }
        public Nullable<bool> AttributeB06 { get; set; }
        public Nullable<bool> AttributeB07 { get; set; }
        public Nullable<bool> AttributeB08 { get; set; }
        public Nullable<bool> AttributeB09 { get; set; }
        public Nullable<bool> AttributeB10 { get; set; }
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
        public bool IsAccMemoBuilt { get; set; }
        public bool IsMgmtSummaryBuilt { get; set; }

        public Nullable<int> SurveyId { get; set; }
        public int? SourceProductId { get; set; }
        public int? SspId { get; set; }

        public DateTime? WFStatusDateTime { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
    }


    public partial class ProductForRequestDetailViewModel
    {
        public int ProductCount { get; set; }
        public string SelecterType { get; set; }
    }
}