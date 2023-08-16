﻿using RELY_API.Models;
using RELY_API.Utilities;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity.Validation;
using System.Data.Entity.Core.Objects;

namespace RELY_API.Controllers
{
    [CustomExceptionFilter]
    public class LRolesController : ApiController
    {
        private RELYDevDbEntities db = new RELYDevDbEntities();

        [HttpGet]
        public IHttpActionResult GetRoleAccessListByControllerAction(string ControllerName, string MethodName, string CompanyCode)
        {
            string SqlString = "select mmr.RoleId,lr.RoleName from MMenuRoles mmr join LRoles lr on lr.id = mmr.RoleId where menuid in "
                + " (select menuid from MMenusAuthorizableObjects where AuthorizableObjectId in "
                + " (select id from GAuthorizableObjects where ControllerName = {0} and MethodName = {1})) and CompanyCode= {2}";
            var RoleList = db.Database.SqlQuery<PageAccessRoleViewModel>(SqlString, ControllerName, MethodName, CompanyCode).ToList();
            return Ok(RoleList);
        }
        
        public IHttpActionResult GetLRolesByCompanyCode(string CompanyCode, string UserName, string WorkFlow)
        {
            var xx = (from aa in db.LRoles.Where(r => r.RoleName != "L2Admin")
                      select new { aa.Id, aa.CompanyCode, aa.RoleName }).Where(aa => aa.CompanyCode == CompanyCode).OrderBy(p => p.RoleName);
            return Ok(xx);
        }

        [HttpGet]
        public IHttpActionResult GetByRoleName(string RoleName,string CompanyCode, string UserName, string WorkFlow)
        {
            var xx = (from aa in db.LRoles
                      select new { aa.Id, aa.CompanyCode, aa.RoleName }).Where(aa=>aa.RoleName == RoleName).Where(aa=>aa.CompanyCode==CompanyCode).OrderBy(p => p.RoleName).FirstOrDefault();
            return Ok(xx);
        }
        [HttpGet]
        public IHttpActionResult GetById(int Id, string CompanyCode, string UserName, string WorkFlow)
        {
            var xx = (from aa in db.LRoles
                      select new { aa.Id, aa.CompanyCode, aa.RoleName }).Where(aa => aa.Id == Id).Where(aa => aa.CompanyCode == CompanyCode).FirstOrDefault();
            return Ok(xx);
        }

        [HttpGet]
        public IHttpActionResult GetUserRolesForEditPage(string CompanyCode, int UserId, string WorkFlow)
        {
            var ExistingRoles = db.MUserRoles.Where(p => p.UserId == UserId).Select(p => p.RoleId).ToList();
            var xx = (from aa in db.LRoles
                      select new { aa.Id, aa.CompanyCode, aa.RoleName, Select = ExistingRoles.Contains(aa.Id) ? true : false }).Where(r => r.RoleName != "L2Admin").Where(aa => aa.CompanyCode == CompanyCode).OrderBy(p => p.RoleName);
            return Ok(xx);
        }
        
        [ResponseType(typeof(LRole))]
        public async Task<IHttpActionResult> PostLRole(LRole LRole)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(Globals.BadRequestErrorMessage, "CREATE", "ROLE")));
            }
            try
            {
                if (db.LRoles.Where(p => p.Id == LRole.Id).Where(p => p.CompanyCode == LRole.CompanyCode).Count() > 0)
                {
                    LRole.MFAEnabled = false;
                    db.Entry(LRole).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    LRole.Id = 0;//To override the Id generated by grid
                    LRole.MFAEnabled = false;
                    db.LRoles.Add(LRole);
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
            return CreatedAtRoute("DefaultApi", new { id = LRole.Id }, LRole);
        }

        //Below code is commented by Rakhi Singh on 27th july 2018 during code review by Vikas.
        // GET: api/LRoles/5
        //[ResponseType(typeof(LRole))]
        //public async Task<IHttpActionResult> GetLRole(Nullable<int> id, string UserName, string WorkFlow)
        //{
        //    var LRole = db.LRoles.Where(p => p.Id == id).Select(aa => new { aa.Id, aa.CompanyCode, aa.RoleName }).FirstOrDefault();
        //    if (LRole == null)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Globals.NotFoundErrorMessage, "ROLE")));
        //    }
        //    return Ok(LRole);
        //}
        // GET: api/LRoles
        //Method to Get Requested Data by user for Edit
        //[ResponseType(typeof(LRole))]
        //public async Task<IHttpActionResult> GetLRoles(string CompanyCode, string Name)
        //{
        //    var LRole = db.LRoles.Where(p => p.CompanyCode == CompanyCode && p.RoleName == Name).Select(x => new { x.Id, x.CompanyCode, x.RoleName }).First();
        //    if (LRole == null)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Globals.NotFoundErrorMessage, "Role")));
        //    }
        //    return Ok(LRole);
        //}

        // PUT: api/LRoles/5
        //[ResponseType(typeof(LRole))]
        //public async Task<IHttpActionResult> PutLRole(int id, LRole LRole, string UserName, string WorkFlow)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(Globals.BadRequestErrorMessage, "UPDATE", "ROLE")));
        //    }

        //    if (!LRoleExists(id))
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Globals.NotFoundErrorMessage, "ROLE")));
        //    }

        //    if (id != LRole.Id)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(Globals.BadRequestErrorMessage, "UPDATE", "ROLE")));
        //    }
        //    try
        //    {
        //        db.Entry(LRole).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbEntityValidationException dbex)
        //    {
        //        var errorMessage = Globals.GetEntityValidationErrorMessage(dbex);
        //        throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, errorMessage));//type 2 error
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.GetBaseException().GetType() == typeof(SqlException))//check for exception type
        //        {
        //            //Throw this as HttpResponse Exception to let user know about the mistakes they made, correct them and retry.
        //            throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, GetCustomizedErrorMessage(ex)));//type 2 error
        //        }
        //        else
        //        {
        //            throw ex;//This exception will be handled in FilterConfig's CustomHandler
        //        }
        //    }
        //    // return StatusCode(HttpStatusCode.NoContent);
        //    return Ok(LRole);
        //}




        // DELETE: api/LRoles/5
        //[ResponseType(typeof(LRole))]
        //public async Task<IHttpActionResult> DeleteLRole(int id, string UserName, string WorkFlow)
        //{
        //    LRole LRole = await db.LRoles.FindAsync(id);
        //    if (LRole == null)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format(Globals.NotFoundErrorMessage, "ROLE")));
        //    }
        //    try
        //    {
        //        db.LRoles.Remove(LRole);
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbEntityValidationException dbex)
        //    {
        //        var errorMessage = Globals.GetEntityValidationErrorMessage(dbex);
        //        throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, errorMessage));//type 2 error
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.GetBaseException().GetType() == typeof(SqlException))//check for exception type
        //        {
        //            //Throw this as HttpResponse Exception to let user know about the mistakes they made, correct them and retry. 
        //            throw new HttpResponseException(Request.CreateErrorResponse((HttpStatusCode)Globals.ExceptionType.Type2, GetCustomizedErrorMessage(ex)));//type 2 error
        //        }
        //        else
        //        {
        //            throw ex;
        //        }
        //    }
        //    return Ok(LRole);
        //}

        //private bool LRoleExists(int id)
        //{
        //    return db.LRoles.Count(e => e.Id == id) > 0;
        //}

        private string GetCustomizedErrorMessage(Exception ex)
        {
            //Convert the exception to SqlException to get the error message returned by database.
            var SqEx = ex.GetBaseException() as SqlException;
            //Depending upon the constraint failed return appropriate error message 
            if (SqEx.Message.IndexOf("FK_LRoles_LAccountingScenarios_WFRequesterRoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "ACCOUNTING SCENARIO"));
            else if (SqEx.Message.IndexOf("FK_LRoles_LLocalPob_RequesterRoleid", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "LOCAL POB"));
            else if (SqEx.Message.IndexOf("FK_LRoles_LReferences_WFRequesterRoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "REFERENCES"));
            else if (SqEx.Message.IndexOf("FK_LRoles_LRequests_WFRequesterRoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "REQUESTS"));           
            else if (SqEx.Message.IndexOf("FK_LRoles_LSupportingDocuments_CreatedByRoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "SUPPORTING DOCUMENTS"));
            else if (SqEx.Message.IndexOf("FK_LRoles_MAuthorizableObjectsLRoles_RoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "AUTHORIZABLEOBJECTS ROLES"));
            else if (SqEx.Message.IndexOf("FK_LRoles_MMenuRoles_RoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "MENU ROLES"));
            else if (SqEx.Message.IndexOf("FK_LRoles_MUserRoles_RoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "USER ROLES"));           
            else if (SqEx.Message.IndexOf("FK_LRoles_LScenarioDemand_WFRequesterRoleId", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CanNotUpdateDeleteErrorMessage, "ROLES", "SCENARIO DEMAND"));
            else if (SqEx.Message.IndexOf("UQ_LRoles_CompanyCode_RoleName", StringComparison.OrdinalIgnoreCase) >= 0)
                return (string.Format(Globals.CannotInsertDuplicateErrorMessage, "ROLES"));
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