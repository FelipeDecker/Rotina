using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Rotina.DomainService.Helpers
{
    public class ApiException : Exception
    {
        private string Environment { get; set; }

        public ApiException()
        {

        }

        public ApiException(string environment)
        {
            Environment = environment;
        }

        public static void GenerateError(string environment, string error)
        {
            List<string> errorList = new();
            errorList.Add(error);

            var anonymousObject = new
            {
                Environment = environment,
                Error = errorList
            };

            throw new Exception(JsonConvert.SerializeObject(anonymousObject));
        }

        public static void GenerateError(string environment, List<string> error)
        {
            var anonymousObject = new
            {
                Environment = environment,
                ErrorList = error
            };

            throw new Exception(JsonConvert.SerializeObject(anonymousObject));
        }

        public void GenerateError(string error)
        {
            List<string> errorList = new();
            errorList.Add(error);

            var anonymousObject = new
            {
                Environment,
                ErrorList = errorList
            };

            throw new Exception(JsonConvert.SerializeObject(anonymousObject));
        }

        public void GenerateError(List<string> error)
        {
            var anonymousObject = new
            {
                Environment,
                ErrorList = error
            };

            throw new Exception(JsonConvert.SerializeObject(anonymousObject));
        }
    }
}
