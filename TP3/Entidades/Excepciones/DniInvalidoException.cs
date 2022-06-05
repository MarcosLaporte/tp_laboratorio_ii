using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
        {
        }

        public DniInvalidoException(string message) : base(message)
        {
        }

        public DniInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
