using System;

namespace Entidades.Excepciones
{
	[Serializable]
	public class IdInvalidoException : ClienteInvalidoException
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
