using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Results
{
    public class Result<T>
    {
        public bool? Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Token { get; set; }

        public static Result<T> SuccessResult(T data)
        {
            return new Result<T> { Success = true, Data = data };
        }
        //public static Result<T> SuccessResult(T data, T token)
        //{
        //    return new Result<T> { Success = true, Data = data, Token = token };
        //}

        public static Result<T> ErrorResult(string errorMessage)
        {
            return new Result<T> { Success = false, ErrorMessage = errorMessage };
        }
    }

}
