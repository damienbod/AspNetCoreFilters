using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5
{
    public class CustomException : Exception
    {
        public CustomException (string message): base (message)
        {
        }
    }

}
