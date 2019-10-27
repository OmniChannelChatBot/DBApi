using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Exception
{
    public class DBApiExection : System.Exception
    {
        public DBApiExection() : base() { }

        public DBApiExection(string message) : base(message) { }

        public DBApiExection(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
