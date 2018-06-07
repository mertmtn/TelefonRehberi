using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefonRehberi.CustomException
{
    public class YoneticiException:ApplicationException
    {
        public YoneticiException():base()
        {

        }
        public YoneticiException(String message) : base(message)
        {

        }
        public YoneticiException(String message, Exception InnerException) : base(message, InnerException)
        {

        }
    }
}