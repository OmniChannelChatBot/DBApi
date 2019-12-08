using System;
using System.Globalization;

namespace DB.Core.Exceptions
{
    public class DBException : Exception
    {
        public DBException() : base() { }

        public DBException(string message) : base(message) { }

        public DBException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
