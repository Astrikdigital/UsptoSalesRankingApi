using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectsLayer.Entities
{
    public class ResponseModel
    {
        public bool Response { get; set; }
        public string Message { get; set; } 
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public bool IsSuccess { get; set; } = true;
    }

    public class UsptoLeadModel
    {
        public string? SearchString { get; set; }
        public int? SearchType { get; set; }
        public string? FilingDateFrom { get; set; }
        public string? FilingDateTo { get; set; }
        public string? AbandonedDateFrom { get; set; }
        public string? AbandonedDateTo { get; set; }
        public int? IsAssign { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public class OwnFileSerialNumber
    { 
        public int? Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? Json { get; set; }
    }
}
