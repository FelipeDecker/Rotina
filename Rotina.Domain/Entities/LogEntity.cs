using System;
using System.Collections.Generic;

namespace Rotina.Domain.Entities
{
    public class LogEntity
    {
        public string TraceId { get; set; }
        public string UserMessage { get; set; }
        public string Error { get; set; }
        public string InnerException { get; set; }
        public List<string> ErrorList { get; set; }
        public string Solution { get; set; }
        public int Severity { get; set; }
        public string Environment { get; set; }
        public DateTime Date { get; set; }
        public string StackTrace { get; set; }

        public LogEntity()
        {

        }

        public LogEntity(string traceId, string userMessage, string error, string innerException, List<string> errorList,
            string solution, int severity, string environment, string stackTrace)
        {
            TraceId = traceId;
            UserMessage = userMessage;
            Error = error;
            InnerException = innerException;
            ErrorList = errorList;
            Solution = solution;
            Severity = severity;
            Environment = environment;
            Date = DateTime.UtcNow;
            StackTrace = stackTrace;
        }
    }
}
