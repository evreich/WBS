using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Exceptions
{
    public class DependencyNotFoundException : Exception
    {
        public DependencyNotFoundException(string message):base(message)
        {
        }
    }
}
