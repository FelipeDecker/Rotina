using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rotina.Domain.Entities;
using Rotina.DomainService.Helpers;
using Rotina.DomainService.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rotina.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public abstract class GenericController : ControllerBase
    {
        protected readonly IMessageService _svcMessage;

        public GenericController(IMessageService svcMessage)
        {
            _svcMessage = svcMessage;
        }

        protected JsonResult Success(dynamic retorno)
        {
            return new JsonResult(retorno);
        }

        protected async Task<JsonResult> Error(Exception ex)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            var porta = Request.HttpContext.Connection.RemotePort.ToString();

            IPHostEntry host = Dns.GetHostEntry(ip);

            var teste3 = Request.HttpContext.Connection.Id.ToString();
            var teste4 = Request.HttpContext.Connection.ClientCertificate;

            var query = Request.HttpContext.Request.Query;
            var queryString = Request.HttpContext.Request.QueryString;

            var cultureName = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture?.ToString();

            var aaa = Request.HttpContext.User; // PARA TESTAR AS CLAIN DELEs

            string traceId = Request.HttpContext.TraceIdentifier;
            string userMessage = "Unexpected error, contact the development team";
            string error = ex.Message;
            List<string> errorList = new();
            string solution = default;
            string environment = "Undefined";
            int gravity = 1;

            // Gravity level

            // 0 - For basic errors of incorrectly filled in fields and repeated registrations
            // 1 - Everything that must be communicated to the entire development team

            try
            {
                #region Data Base

                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY"))
                    {
                        Response.StatusCode = 500;
                        error = "Primary key is repeated";
                        solution = "Generate another id for the object";
                        gravity = 1;
                    }

                    if (ex.InnerException.Message.Contains("Arithmetic overflow error converting numeric to data type numeric."))
                    {
                        Response.StatusCode = 500;
                        error = "One or more fields may be receiving a value greater than the threshold (numeric fields)";
                        solution = "Check the maximum size that the fields must have";
                        gravity = 1;
                    }

                    if (ex.InnerException.Message.Contains("String or binary data would be truncated."))
                    {
                        Response.StatusCode = 500;
                        error = "One or more fields may be receiving a value greater than the threshold (string fields)";
                        solution = "Check the maximum size that the fields must have";
                        gravity = 1;
                    }
                }

                if (ex.Message.Contains("Format of the initialization string does not conform to specification starting at index 0"))
                {
                    Response.StatusCode = 400;
                    error = "The connection string is not set correctly";
                    solution = "Check which context is being used and check the connection string writing";
                    gravity = 1;
                }

                #endregion

                #region Dependecy Register

                if (ex.Message.Contains("Unable to resolve service for type")
                    && ex.Message.Contains("while attempting to activate")
                    && ex.Message.Contains("Service")
                    && ex.Message.Contains("Controller")
                    && ex.Source.Contains("Microsoft.Extensions.DependencyInjection.Abstractions"))
                {
                    Response.StatusCode = 500;
                    string interfaceService = ex.Message.Split("'")[1].Split(".").Last();
                    error = "Algum metodo que utiliza injeção de dependencia não esta sendo assinado";
                    solution = "In the CrossCutting Project Insert the Service Interface: " + interfaceService + " with the implementation of the service: " + interfaceService[1..];
                    gravity = 1;
                }

                #endregion

                #region Services

                if (ex.Message.Contains("Environment") && ex.Message.Contains("Service"))
                {
                    var logEntity = JsonConvert.DeserializeObject<LogEntity>(ex.Message);

                    error = "Service error";

                    environment = logEntity.Environment;

                    errorList.AddRange(logEntity.ErrorList);

                    userMessage = "Error";

                    gravity = 0;
                }

                #endregion

                #region Validators

                if (ex.Message.Contains("Environment") && ex.Message.Contains("Validator"))
                {
                    var logEntity = JsonConvert.DeserializeObject<LogEntity>(ex.Message);

                    error = "Validation error";

                    environment = logEntity.Environment;

                    errorList.AddRange(logEntity.ErrorList);

                    userMessage = "some fields are unexpectedly filled";

                    gravity = 0;
                }

                #endregion
            }
            catch(Exception excption)
            {
                Response.StatusCode = 500;
                error = $"Error in error handling: {excption.Message}";
                solution = "Logic error, review the code";
                userMessage = "Unexpected error. Contact the development team";
                gravity = 1;
            }

            if (gravity > 0)
            {
                LogEntity erroEntity = new(traceId, userMessage, error, ex?.InnerException?.Message, errorList, solution, gravity, environment, ex.StackTrace);

                await _svcMessage.SendEmail();

                await _svcMessage.SendSms();

                await _svcMessage.SendWhatsApp();

                LogErrorFile(erroEntity);
            }

            return new JsonResult(new RetornoEntity(userMessage, errorList));
        }

        private static void LogErrorFile(LogEntity log)
        {
            #region Create directory

            var applicationDirectory = Directory.GetCurrentDirectory();

            var pathSplited = applicationDirectory.Split(@"\");

            string newPath = "";

            for (int i = 0; i < pathSplited.Length - 1; i++)
            {
                newPath += $@"{pathSplited[i]}\";
            }

            string logPastePath = $@"{newPath}Log\{DateTime.Now.Year}\{DateTime.Now.Month}\{DateTime.Now.Day}\{DateTime.Now.Hour}";

            Directory.CreateDirectory(logPastePath);

            string fileDirectory = $@"{logPastePath}\{log.TraceId}.xml";

            System.IO.File.Create(fileDirectory).Close();

            #endregion

            #region Fill file

            var writer = new StreamWriter(fileDirectory);

            var serializer = new XmlSerializer(typeof(LogEntity));

            serializer.Serialize(writer, log);

            writer.Close();

            #endregion
        }
    }
}
