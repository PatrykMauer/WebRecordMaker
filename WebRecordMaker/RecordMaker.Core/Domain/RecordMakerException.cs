using System;

namespace RecordMaker.Core.Domain
{
    public abstract class RecordMakerException : Exception
    {
        public string Code { get; }
        
        protected RecordMakerException()
        {
        }

        public RecordMakerException(string code)
        {
            Code = code;
        }
        
        public RecordMakerException(string message, params object[] args)
            :this(string.Empty, message, args)
        {
        }

        public RecordMakerException(string code,string message, params object[] args)
            :this(null, code, message, args)
        {
        }
        
        public RecordMakerException(Exception innerException,string message, params object[] args)
        :this(innerException,string.Empty,message, args)
        {
        }
        
        public RecordMakerException(Exception innerException,string code, string message, params object[] args)
            :base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}