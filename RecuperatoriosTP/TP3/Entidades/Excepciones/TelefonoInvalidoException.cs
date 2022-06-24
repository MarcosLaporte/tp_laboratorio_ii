using System;

namespace Entidades.Excepciones
{
	[Serializable]
	public class TelefonoInvalidoException : ClienteInvalidoException
	{
		public TelefonoInvalidoException()
		{
		}

		public TelefonoInvalidoException(string message) : base(message)
		{
		}

		public TelefonoInvalidoException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}