using System;

namespace Entidades.Excepciones
{
	[Serializable]
	public class NombreInvalidoException : ClienteInvalidoException
	{
		public NombreInvalidoException()
		{
		}

		public NombreInvalidoException(string message) : base(message)
		{
		}

		public NombreInvalidoException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
