using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Exceptions
{
    public class NoPermissionsException : Exception
    {
        public NoPermissionsException() { }

        public NoPermissionsException(string message) : base(message)
        {

        }
    }
}
