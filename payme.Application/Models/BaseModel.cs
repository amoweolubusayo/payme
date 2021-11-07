using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payme.Application.Models
{
    public class BaseModel<T>
    {
         public bool Status { get;set;}
        public string Message { get;set;}
        // public string Data { get;set;}
         
         public T Data { get; set; }

        public static BaseModel<T> Success(T data, string message = null)
        {
            return new BaseModel<T>()
            {
                Status = true,
                Message = message ?? "Request was Successful",
                Data = data
            };
        }
    }
}
