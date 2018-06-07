using System;

namespace TelefonRehberi.CustomException
{
    public class PersonelException:ApplicationException
    {
        public PersonelException():base()
        {

        }
        public PersonelException(String message) : base(message)
        {

        }
        public PersonelException(String message, Exception InnerException) : base(message, InnerException)
        {

        }
    }
}