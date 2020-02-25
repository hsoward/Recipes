using System;
using System.Collections.Generic;

namespace Recipes.Models
{
    public class OperationStatus
    {
        public string httpStatus { get; set; }
        public List<OperationErrors> operatingErrors { get; set; }
    }

    public class OperationErrors
    {
        public string detailErrorMessages { get; set; }
        public string exceptionMessage { get; set; }
        public ErrorDefinition errorDefinition { get; set; }
    }

    public class ErrorDefinition
    {
        public string description { get; set; }
        public string descriptionSimple { get; set; }
        public int id { get; set; }
    }
}
