using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.AccesoDatos.Exceptions
{
    public class RigoRigoException : Exception
    {
        public RigoRigoException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
