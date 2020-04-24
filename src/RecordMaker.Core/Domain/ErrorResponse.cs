using System.Collections.Generic;

namespace RecordMaker.Core.Domain
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; }=new List<ErrorModel>();
    }
}