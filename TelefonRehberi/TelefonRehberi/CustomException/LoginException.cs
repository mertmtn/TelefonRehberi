using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefonRehberi.CustomException
{
    public class LoginException:ApplicationException
    {
        public LoginException():base()
        {

        }

        public LoginException(String message) : base(message)
        {

        }
        public LoginException(String message, Exception InnerException) : base(message, InnerException)
        {

        }
    }
}