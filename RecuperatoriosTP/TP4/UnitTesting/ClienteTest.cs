using Entidades;
using Entidades.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
	[TestClass]
	public class ClienteTest
	{
		[TestMethod]
		[ExpectedException(typeof(NombreInvalidoException))]
		public void ConstructorCliente_CuandoPasoNombreConDigitoNoAlfa_DeberiaLanzarNombreInvalidoException()
		{
			//Arrange
			string nombre = "Nombre1";

			//Act
			new Cliente(nombre, "Apellido", "1111111", 11111111);
		}

		[TestMethod]
		[ExpectedException(typeof(DniInvalidoException))]
		public void ConstructorCliente_CuandoPasoDniMenorASieteDigitos_DeberiaLanzarDniInvalidoException()
		{
			//Arrange
			ulong dni = 123456;

			//Act
			new Cliente("Nombre", "Apellido", "1111111", dni);
		}

		[TestMethod]
		public void CadenaEsValida_CuandoCadenaTieneNumero_DeberiaRetornarFalso()
		{
			//Arrange
			string cadena = "Casd34a";

			//Act
			bool condition = Cliente.CadenaEsValida(cadena);

			//Assert
			Assert.IsFalse(condition);
		}
	}
}
