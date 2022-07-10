using Entidades;
using Entidades.Productos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTesting
{
	[TestClass]
	public class ProductoTest
	{
		[TestMethod]
		public void GetProductoPorId_CuandoPasoIdInexistente_DeberiaRetornarNull()
		{
			//Arrange
			Producto expected = null;
			List<Producto> lista = new List<Producto>()
			{
				new Higiene(1, "Jabón", 450),
				new Medicamento(2, "Ibuprofeno", 400, 600, EUso.Analgesico),
				new Inyeccion(3, "Sputnik", 1500, 15, EUso.Antibiotico)
			};

			//Act
			int id = 0;
			Producto actual = id.GetProductoPorId(lista);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetProductoPorId_CuandoPasoIdExistente_DeberiaRetornarElProducto()
		{
			//Arrange
			Higiene higiene = new Higiene(1, "Jabón", 450);
			Medicamento medicamento = new Medicamento(2, "Ibuprofeno", 400, 600, EUso.Analgesico);
			Inyeccion inyeccion = new Inyeccion(3, "Sputnik", 1500, 15, EUso.Antibiotico);

			Producto expected = medicamento;
			List<Producto> lista = new List<Producto>() { higiene, medicamento, inyeccion };

			//Act
			int id = 2;
			Producto actual = id.GetProductoPorId(lista);

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
