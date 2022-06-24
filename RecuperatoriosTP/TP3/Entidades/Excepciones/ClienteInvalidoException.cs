using System;
using System.Runtime.Serialization;

namespace Entidades.Excepciones
{
	[Serializable]
	public class ClienteInvalidoException : Exception
	{
		public ClienteInvalidoException()
		{
		}

		public ClienteInvalidoException(string message) : base(message)
		{
		}

		public ClienteInvalidoException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ClienteInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}