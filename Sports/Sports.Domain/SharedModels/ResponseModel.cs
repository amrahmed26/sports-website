using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.SharedModels
{
    public record ResponseModel
    {
        public int StatusCode { get; set; }
        public bool IsSucceeded { get; set; }=false;
        public object Data { get; set; }=false;
    }
}
