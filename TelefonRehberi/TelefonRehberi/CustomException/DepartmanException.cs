using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefonRehberi.CustomException
{
    public class DepartmanException : ApplicationException
    {
        public DepartmanException() : base()
        {

        }

        public DepartmanException(String message) : base(message)
        {

        }

        public DepartmanException(String message, Exception InnerException) : base(message, InnerException)
        {

        }
    }
}