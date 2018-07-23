using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Exceptions
{
    public class RefreshTokenExpiredException : Exception
    {
        public RefreshTokenExpiredException() { }

        public RefreshTokenExpiredException(string message) : base(message)
        {

        }
    }
}
