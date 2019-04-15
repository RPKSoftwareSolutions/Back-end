using System;

namespace TKD.Framework.Core
{
    public class DomainException : ApplicationException
    {
        public int Code { get; private set; }
        public DomainException(int code, string errorMessage) : base(errorMessage)
        {
            Code = code;
        }
    }
}
