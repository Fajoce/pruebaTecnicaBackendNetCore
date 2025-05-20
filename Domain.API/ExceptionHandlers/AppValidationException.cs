using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.API.ExceptionHandlers
{
    public class AppValidationException : Exception
    {
        public AppValidationException(string message) : base(message) { }

    }
}
