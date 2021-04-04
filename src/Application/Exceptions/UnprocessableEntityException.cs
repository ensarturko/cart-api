using System;
using cart_api.Domain;
using Newtonsoft.Json;

namespace cart_api.Application.Exceptions
{
    public class UnprocessableEntityException : Exception
    {
        private ErrorCode ErrorCode { get; }
        public UnprocessableEntityException(string message) : base(message)
        {
        }
        public UnprocessableEntityException(string message, ErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { error = this.Message, errorCode = this.ErrorCode.ToString() });
        }
    }
}