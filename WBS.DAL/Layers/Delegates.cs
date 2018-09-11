using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Layers
{
    public delegate object GetCRUD(Type clientType, Type type);
    public delegate TimeSpan GetExpirationTime();
}
