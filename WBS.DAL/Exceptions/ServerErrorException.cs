using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.DAL.Exceptions
{
    public class ServerErrorException : Exception
    {
        public ServerErrorException() { }

        public ServerErrorException(string message) : base(message)
        {

        }
    }
}
