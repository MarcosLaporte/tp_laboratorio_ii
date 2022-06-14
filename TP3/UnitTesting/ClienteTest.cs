using Entidades;
using Entidades.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTesting
{
	[TestClass]
	public class ClienteTest
	{
		[TestMethod]
		public void GetClientePorDni_CuandoPasoDniInexistente_DeberiaRetornarNull()
		{
			//Arrange
			Cliente expected = null;
			List<Cliente> lista = new List<Cliente>()
			{
				new Cliente("NombreUno", "ApellidoUno", "11111111", 11111111),
				new Cliente("NombreDos", "ApellidoDos", "22222222", 22222222),
			};

			//Act
			Cliente actual = Cliente.GetClientePorDni(lista, 0);

			//Assert
			Assert.AreEqual(expected, actual);
		}

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
			bool actual = Cliente.CadenaEsValida(cadena);

			//Assert
			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void AgregarCliente_CuandoPasoUnaLista_DeberiaGuardarElClienteEnEsta()
		{
			//Arrange
			Cliente cliente1 = new Cliente("NombreUno", "ApellidoUno", "11111111", 11111111);
			Cliente cliente2 = new Cliente("NombreDos", "ApellidoDos", "22222222", 22222222);
			Cliente cliente3 = new Cliente("NombreTres", "ApellidoTres", "33333333", 33333333);
			List<Cliente> listExpected = new List<Cliente>() { cliente1, cliente2, cliente3 };
			int expected = listExpected.Count;

			//Act
			List<Cliente> listActual = new List<Cliente>() { cliente1, cliente2 };
			Cliente.AgregarCliente(ref listActual, cliente3);
			int actual = listActual.Count;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
