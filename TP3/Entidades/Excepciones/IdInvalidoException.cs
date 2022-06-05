using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class IdInvalidoException : Exception
    {
        public IdInvalidoException()
        {
        }

        public IdInvalidoException(string message) : base(message)
        {
        }

        public IdInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
