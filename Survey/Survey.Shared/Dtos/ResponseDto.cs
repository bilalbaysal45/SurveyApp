using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
    }
}