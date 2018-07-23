using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.API.Helpers
{
    public class ResponseError
    {
        public string Error { get; }
        public ResponseError(string error)
        {
            Error = error;
        }
    }
}
