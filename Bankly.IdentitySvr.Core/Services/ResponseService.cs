using System;
using Bankly.IdentitySvr.Core.Factory;

namespace Bankly.IdentitySvr.Core.Services
{
    public interface IResponseService
    {
        ExecutionResponse<T> ExecutionResponse<T>(string message, T data = null, bool status = false) where T : class;
    }

    public class ResponseService : IResponseService
    {
        public ExecutionResponse<T>
             ExecutionResponse<T>(string message, T data = null, bool status = false) where T : class
        {
            return new ExecutionResponse<T>
            {
                Status = status,
                Message = message,
                Data = data

            };
        }
    }
}
