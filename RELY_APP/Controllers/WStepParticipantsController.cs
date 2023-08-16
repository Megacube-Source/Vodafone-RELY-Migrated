﻿using RELY_APP.Helper;
using RELY_APP.Utilities;
using RELY_APP.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static RELY_APP.Utilities.Globals;

namespace RELY_APP.Controllers
{

    [SessionExpire]
    [HandleCustomError]
    public class WStepParticipantsController : Controller
    {
        IWStepParticipantRestClient RestClient = new WStepParticipantRestClient();
        // GET: WSteps
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BindTypeDropDown()
        {
            //string[] SI = { "Role","User" };
            var valuesList = new List<LDropDownValueViewModel>();
            valuesList.Add(new LDropDownValueViewModel { Value = "Role", Id=1 });
            valuesList.Add(new LDropDownValueViewModel { Value = "User", Id=2 });
            var TypeDropDownValues = new SelectList(valuesList);
            return Json(TypeDropDownValues, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByStepId(int StepId)
        {
            var ApiData = RestClient.GetByStepId(StepId);
            return Json(ApiData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        //[ControllerActionFilter]
        public JsonResult SaveData(object[] GridData, int StepId)
        {
            string CompanyCode = Convert.ToString(System.Web.HttpContext.Current.Session["CompanyCode"]);
            try
            {
                IWStepRestClient WFRC = new WStepRestClient();
                var WfDetails = WFRC.GetById(StepId);
                if (WfDetails == null)
                {
                    var OutputJson2 = new { ErrorMessage = "Step Not Found", PopupMessage = "", RedirectToUrl = "" };
                    return Json(OutputJson2, JsonRequestBehavior.AllowGet);
                }
                if (GridData != null && GridData.Length > 0)
                {
                    foreach (string[] Data in GridData)
                    {
                        var GridArray = Data;
                        var model = new WStepParticipantViewModel
                        {
                            Id = Convert.ToInt32(GridArray[0]),
                            ParticipantId = Convert.ToInt32(GridArray[1]),
                            Type = String.IsNullOrEmpty(GridArray[2]) ? null : GridArray[2],
                            IsDefault = Convert.ToBoolean(GridArray[3]),
                            Description = String.IsNullOrEmpty(GridArray[4]) ? null : GridArray[4],
                            WStepId = StepId
                        };
                        RestClient.Add(model, null);
                    }

                }
                var OutputJson = new { Success = "Create Step Participants", ErrorMessage = "", PopupMessage = "", RedirectToUrl = "/RWorkFlows/Index" };
                return Json(OutputJson, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // If exception generated from Api redirect control to view page where actions will be taken as per error type.
                if (!string.IsNullOrEmpty(ex.Data["ErrorMessage"] as string))
                {
                    switch ((int)ex.Data["ErrorCode"])
                    {
                        case (int)ExceptionType.Type1:
                            //redirect user to gneric error page
                            var OutputJson1 = new { ErrorMessage = "", PopupMessage = "", RedirectToUrl = Globals.ErrorPageUrl };
                            return Json(OutputJson1, JsonRequestBehavior.AllowGet);
                        case (int)ExceptionType.Type2:
                            //redirect user (with appropriate errormessage) to same page (using viewmodel,controller nameand method name) from where request was initiated 
                            var OutputJson2 = new { ErrorMessage = ex.Data["ErrorMessage"] as string, PopupMessage = "", RedirectToUrl = "" };
                            return Json(OutputJson2, JsonRequestBehavior.AllowGet);
                        case (int)ExceptionType.Type3:
                            //Send Ex.Message to the error page which will be displayed as popup
                            var OutputJson3 = new { ErrorMessage = "", PopupMessage = ex.Data["ErrorMessage"] as string, RedirectToUrl = ex.Data["RedirectToUrl"] as string };
                            return Json(OutputJson3, JsonRequestBehavior.AllowGet);
                        case (int)ExceptionType.Type4:
                            var OutputJson4 = new { ErrorMessage = "", PopupMessage = ex.Data["ErrorMessage"] as string, RedirectToUrl = "" };
                            return Json(OutputJson4, JsonRequestBehavior.AllowGet);
                    }
                    var OutputJson = new { ErrorMessage = ex.Data["ErrorMessage"] as string, PopupMessage = "", RedirectToUrl = "" };
                    return Json(OutputJson, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //If exception does not match any type. Make an entry in GErrorLog as it may be an exception generated from Web App
                    TempData["Error"] = "Record could not be updated";
                    throw ex;
                }
            }
        }

        public JsonResult DeleteById(int Id,int StepId)
        {
            try
            {
                RestClient.Delete(Id, StepId, null);
                var OutputJson = new { ErrorMessage = "", PopupMessage = "", RedirectToUrl = "/RWorkFlows/Index" };
                return Json(OutputJson, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // If exception generated from Api redirect control to view page where actions will be taken as per error type.
                if (!string.IsNullOrEmpty(ex.Data["ErrorMessage"] as string))
                {
                    switch ((int)ex.Data["ErrorCode"])
                    {
                        case (int)ExceptionType.Type1:
                            //redirect user to gneric error page
                            var OutputJson1 = new { ErrorMessage = "", PopupMessage = "", RedirectToUrl = Globals.ErrorPageUrl };
                            return Json(OutputJson1, JsonRequestBehavior.AllowGet);
                        case (int)ExceptionType.Type2:
                            //redirect user (with appropriate errormessage) to same page (using viewmodel,controller nameand method name) from where request was initiated 
                            var OutputJson2 = new { ErrorMessage = ex.Data["ErrorMessage"] as string, PopupMessage = "", RedirectToUrl = "" };
                            return Json(OutputJson2, JsonRequestBehavior.AllowGet);
                        case (int)ExceptionType.Type3:
                            //Send Ex.Message to the error page which will be displayed as popup
                            var OutputJson3 = new { ErrorMessage = "", PopupMessage = ex.Data["ErrorMessage"] as string, RedirectToUrl = ex.Data["RedirectToUrl"] as string };
                            return Json(OutputJson3, JsonRequestBehavior.AllowGet);
                        case (int)ExceptionType.Type4:
                            var OutputJson4 = new { ErrorMessage = "", PopupMessage = ex.Data["ErrorMessage"] as string, RedirectToUrl = "" };
                            return Json(OutputJson4, JsonRequestBehavior.AllowGet);
                    }
                    var OutputJson = new { ErrorMessage = ex.Data["ErrorMessage"] as string, PopupMessage = "", RedirectToUrl = "" };
                    return Json(OutputJson, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //If exception does not match any type. Make an entry in GErrorLog as it may be an exception generated from Web App
                    TempData["Error"] = "Record could not be updated";
                    throw ex;
                }
            }
        }

    }
}