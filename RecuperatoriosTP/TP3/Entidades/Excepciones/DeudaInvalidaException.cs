using System;

namespace Entidades.Excepciones
{
	[Serializable]
	public class DeudaInvalidaException : ClienteInvalidoException
	{
		public DeudaInvalidaException()
		{
		}

		public DeudaInvalidaException(string message) : base(message)
		{
		}

		public DeudaInvalidaException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}