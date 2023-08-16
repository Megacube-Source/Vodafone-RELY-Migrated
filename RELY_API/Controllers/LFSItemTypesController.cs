﻿using RELY_API.Models;
using RELY_API.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RELY_API.Controllers
{
    [CustomExceptionFilter]
    public class LFSItemTypesController : ApiController
    {
        private RELYDevDbEntities db = new RELYDevDbEntities();

        // GET: api/LFSItemTypes? CompanyCode = DE
        //Method to Get Data in Grid

        public IHttpActionResult GetLFSItemTypesByCompanyCode(string CompanyCode, string UserName, string WorkFlow)
        {
            var xx = (from aa in db.LFSItemTypes.Where(p => p.CompanyCode == CompanyCode)
                      select new
                      {
                          aa.Id,
                          aa.CompanyCode,
                          aa.Name,
                          aa.Description,
                          aa.IsUserRespondable,
                          aa.IsQuestion
                          //aa.WordStyle,
                          //aa.BGColor,
                          //aa.TextColor,
                          //aa.Font,
                          //aa.FontSize
                      }).OrderBy(p => p.Name);
            return Ok(xx);
        }
        [ResponseType(typeof(LFSItemType))]
        public IHttpActionResult GetItemTypeIdbyName(string Name)
        {

            var xx = db.LFSItemTypes.Where(p => p.Name == Name).Select(a => a.Id).FirstOrDefault();
            return Ok(xx);
        }

        // POST: api/LFSItemTypes
        //Method to Post Data from app to db
        [ResponseType(typeof(LFSItemType))]

        public async Task<IHttpActionResult> PostLFSItemTypes(LFSItemType LFSItemType, string UserName, string WorkFlow)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(Globals.BadRequestErrorMessage, "CREATE", "ItemType")));
            }

            try
            {
                if (db.LFSItemTypes.Where(p => p.Id == LFSItemType.Id).Where(p => p.CompanyCode == LFSItemType.CompanyCode).Count() > 0)
                {
                    db.Entry(LFSItemType).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    LFSItemType.Id = 0;
                    db.LFSItemTypes.Add(LFSItemType);
                    await db.SaveChangesAsync();
                }
            }
            catch (DbEntityValidationException dbex)
            {
                var errorMessage = Globals.GetEntityValidationErrorMessage(dbex);
                throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, errorMessage));//type 2 error
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))//check for exception type
                {
                    //Throw this as HttpResponse Exception to let user know about the mistakes they made, correct them and retry.
                    throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, GetCustomizedErrorMessage(ex)));//type 2 error
                }
                else
                {
                    throw ex;//This exception will be handled in FilterConfig's CustomHandler
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = LFSItemType.Id }, LFSItemType);
        }

        // GET: api/LFSItemTypes?CompanyCode=DE&Name=System1
        //Method to Get Requested Data by user for Edit

        [ResponseType(typeof(LFSItemType))]
        public async Task<IHttpActionResult> GetLFSItemType(string CompanyCode, string Name, string UserName, string WorkFlow)
        {
            var LFSItemType = db.LFSItemTypes.Where(p => p.CompanyCode == CompanyCode && p.Name == Name).Select(x =>
                              new
                              {
                                  x.Id,
                                  x.CompanyCode,
                                  x.Name,
                                  x.Description,
                                  x.IsUserRespondable,
                                  x.IsQuestion
                                  //x.WordStyle,
                                  //x.BGColor,
                                  //x.TextColor,
                                  //x.Font,
                                  //x.FontSize
                              }).First();

            if (LFSItemType == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Globals.NotFoundErrorMessage, "ItemType")));
            }

            return Ok(LFSItemType);
        }

        // PUT: api/LFSItemTypes?CompanyCode=DE&Name=System(updated name)
        //Method to update Requested Data by User in db

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLFSItemTypes(string CompanyCode, string Name, LFSItemType LFSItemType)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(Globals.BadRequestErrorMessage, "UPDATE", "ITEMTYPE")));
            }

            if (!LFSItemTypesExists(CompanyCode) && !LFSItemTypesExists(Name))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Globals.NotFoundErrorMessage, "ITEMTYPE")));
            }

            if (CompanyCode != LFSItemType.CompanyCode && Name != LFSItemType.Name)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(Globals.BadRequestErrorMessage, "UPDATE", "ITEMTYPE")));
            }

            try
            {
                db.Entry(LFSItemType).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbex)
            {
                var errorMessage = Globals.GetEntityValidationErrorMessage(dbex);
                throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, errorMessage));//type 2 error
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))//check for exception type
                {
                    //Throw this as HttpResponse Exception to let user know about the mistakes they made, correct them and retry.
                    throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, GetCustomizedErrorMessage(ex)));//type 2 error
                }
                else
                {
                    throw ex;//This exception will be handled in FilterConfig's CustomHandler
                }
            }

            return Ok(LFSItemType);
        }

        // Delete: api/LFSItemTypes?id
        [ResponseType(typeof(LFSItemType))]
        public async Task<IHttpActionResult> DeleteLFSItemTypes(int id, string UserName, string WorkFlow)
        {
            LFSItemType LFSItemType = await db.LFSItemTypes.FindAsync(id);
            if (LFSItemType == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Globals.NotFoundErrorMessage, "Item Type")));
            }

            try
            {
                db.LFSItemTypes.Remove(LFSItemType);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))//check for exception type
                {
                    //Throw this as HttpResponse Exception to let user know about the mistakes they made, correct them and retry. 
                    throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, GetCustomizedErrorMessage(ex)));//type 2 error
                }
                else
                {
                    throw ex;
                }
            }

            return Ok(LFSItemType);
        }

        private bool LFSItemTypesExists(string CompanyCode)
        {
            return db.LFSItemTypes.Count(e => e.CompanyCode == CompanyCode) > 0;
        }

        private string GetCustomizedErrorMessage(Exception ex)
        {
            //Convert the exception to SqlException to get the error message returned by database.
            var SqEx = ex.GetBaseException() as SqlException;
            //Depending upon the constraint failed return appropriate error message
            if (SqEx.Message.IndexOf("FK_LFSItemTypes_LFSQuestionBank_ItemTypeId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ITEM TYPE", "QUESTION BANK"));
            else if (SqEx.Message.IndexOf("FK_LFSItemTypes_LFSSectionItems_ItemTypeId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ITEM TYPE", "SECTION ITEMS"));
            else if
                (SqEx.Message.IndexOf("UQ_LFSItemTypes_CompanyCode_Name", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CannotInsertDuplicateErrorMessage, "ITEM TYPE"));
            else
            {
                //Something else failed return original error message as retrieved from database
                //Add complete Url in description
                var UserName = "";//System.Web.HttpContext.Current.Session["UserName"] as string;
                string UrlString = Convert.ToString(Request.RequestUri.AbsolutePath);
                var ErrorDesc = "";
                var Desc = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
                if (Desc.Count() > 0)
                    ErrorDesc = string.Join(",", Desc);
                string[] s = Request.RequestUri.AbsolutePath.Split('/');//This array will provide controller name at 2nd and action name at 3 rd index position
                //db.SpLogError("RELY-API", s[2], s[3], SqEx.Message, UserName, "Type2", ErrorDesc, "resolution", "L2Admin", "field", 0, "New");
                //return Globals.SomethingElseFailedInDBErrorMessage;

             ObjectParameter Result = new ObjectParameter("Result", typeof(int)); //return parameter is declared
                db.SpLogError("RELY-API", s[2], s[3], SqEx.Message, UserName, "Type2", ErrorDesc, "resolution", "L2Admin", "field", 0, "New", Result).FirstOrDefault();
                int errorid = (int)Result.Value; //getting value of output parameter
                //return Globals.SomethingElseFailedInDBErrorMessage;
                return (string.Format(Globals.SomethingElseFailedInDBErrorMessage, errorid));
            }
        }
    }
}
