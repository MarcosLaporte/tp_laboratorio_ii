using System;

namespace Entidades.Excepciones
{
	[Serializable]
	public class DniInvalidoException : ClienteInvalidoException
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
