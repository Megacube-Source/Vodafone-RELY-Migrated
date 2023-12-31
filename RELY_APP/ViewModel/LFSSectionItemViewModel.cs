﻿using RELY_APP.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RELY_APP.ViewModel
{
    public class LFSSectionItemViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Display(Name = "Survey Id")]
        [Required(ErrorMessage = "Survey Id is required")]
        public int SurveyId { get; set; }

        [RestrictSpecialChar]
        //[RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Only Alphabets , Numbers and Underscore are allowed.")]
        [Display(Name = "Chapter Code")]
        [Required(ErrorMessage = "Chapter Code  is required")]
        [MaxLength(20, ErrorMessage = " Chapter Code can be maximum 20 characters")]
        public string ChapterCode { get; set; }
        public string Response { get; set; }
        public bool IsQuestion { get; set; }
        public string ToolTip { get; set; }
        public string QuestionName { get; set; }
        public string Survey { get; set; }

        public string TableCode { get; set; }
        [Display(Name = "Section Code")]
        [Required(ErrorMessage = "Section Code is required")]
        public string SectionCode { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Question Code")]
        [Required(ErrorMessage = "Question Code is required")]
        [MaxLength(20, ErrorMessage = " Chapter Code can be maximum 20 characters")]
        public string QuestionCode { get; set; }

        
        public string SectionName { get; set; }
        public string SectionNumber { get; set; }


        [Display(Name = "Item Type Id")]
        [Required(ErrorMessage = "Item Type Id is required")]
        public int ItemTypeId { get; set; }

        public string ItemTypeName { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Item Text")]
        [Required(ErrorMessage = "Item Text  is required")]
        public string ItemText { get; set; }

        [Display(Name = "Ordinal")]
        [Required(ErrorMessage = "Ordinal is required")]
        public int Ordinal { get; set; }

        [Display(Name = "Nesting Level")]
        [Required(ErrorMessage = "Nesting Level is required")]
        public int NestingLevel { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "IsResponseMandatory")]
        [Required(ErrorMessage = "IsResponseMandatory is required")]
        public bool IsResponseMandatory { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "IsReponseAutoGenerated")]
        [Required(ErrorMessage = "IsReponseAutoGenerated is required")]
        public bool IsReponseAutoGenerated { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Show On Question Code")]
        [Required(ErrorMessage = "Show On Question Code  is required")]
        [MaxLength(20, ErrorMessage = " Show On Question Code can be maximum 20 characters")]
        public string ShowOnQuestionCode { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Show On Answer Option")]
        [Required(ErrorMessage = "Show On Answer Option  is required")]
        [MaxLength(255, ErrorMessage = " Show On Answer Option can be maximum 255 characters")]
        public string ShowOnAnswerOption { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Sum Of Questions")]
        [Required(ErrorMessage = "Sum Of Questions  is required")]
        [MaxLength(255, ErrorMessage = " Sum Of Questions can be maximum 255 characters")]
        public string SumOfQuestions { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Operator")]
        [Required(ErrorMessage = "Operator  is required")]
        [MaxLength(1, ErrorMessage = " Operator can be maximum 1 characters")]
        public string Operator { get; set; }

        [Display(Name = "Sum Value")]
        [Required(ErrorMessage = "Sum Value is required")]
        public int? SumValue { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Automated Response True Value")]
       
        [MaxLength(4000, ErrorMessage = " Automated Response True Value can be maximum 4000 characters")]
        public string AutomatedResponseTrueValue { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Automated Response False Value")]
        [MaxLength(4000, ErrorMessage = " Automated Response False Value can be maximum 4000 characters")]
        public string AutomatedResponseFalseValue { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Related Question Code")]
        [Required(ErrorMessage = "Related Question Code  is required")]
        [MaxLength(20, ErrorMessage = " Related Question Code can be maximum 20 characters")]
        public string RelatedQuestionCode { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Show On Accounting Memo")]
        [Required(ErrorMessage = "Show On Accounting Memo is required")]
        public bool ShowOnAccountingMemo { get; set; }

        [Display(Name = "Created By Id")]
        [Required(ErrorMessage = "CreatedById is required")]
        public int CreatedById { get; set; }


        [Display(Name = "Created Date Time")]
        [Required(ErrorMessage = "Created Date Time is Required.")]
        public DateTime CreatedDateTime { get; set; }

        [Display(Name = "Updated By Id")]
        [Required(ErrorMessage = "UpdatedById is required")]
        public int UpdatedById { get; set; }

        [Display(Name = "Updated Date Time")]
        [Required(ErrorMessage = "Updated Date Time is Required.")]
        public DateTime UpdatedDateTime { get; set; }

        [RestrictSpecialChar]
        [Display(Name = "Internal Notes")]
        
        [MaxLength(4000, ErrorMessage = " Internal Notes can be maximum 4000 characters")]
        public string InternalNotes { get; set; }


    }
}