using DecentralizationGovUa.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Models
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public Status Status { get; set; }
        public string Message {  get; set; }
    }
}
