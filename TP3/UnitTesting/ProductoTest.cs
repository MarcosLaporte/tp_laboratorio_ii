using Entidades;
using Entidades.Productos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				new Higiene("Jabón", 450), //Id = 1
				new Medicamento("Ibuprofeno", 400, 600, EUso.Analgesico), //Id = 2
				new Inyeccion("Sputnik", 1500, 15, EUso.Antibiotico) //Id = 3
			};

			//Act
			Producto actual = Producto.GetProductoPorId(lista, 0);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetProductoPorId_CuandoPasoIdExistente_DeberiaRetornarElProducto()
		{
			//Arrange
			Higiene higiene = new Higiene("Jabón", 450);
			Medicamento medicamento = new Medicamento("Ibuprofeno", 400, 600, EUso.Analgesico);
			Inyeccion inyeccion = new Inyeccion("Sputnik", 1500, 15, EUso.Antibiotico);

			Producto expected = medicamento;
			List<Producto> lista = new List<Producto>() { higiene, medicamento, inyeccion };

			//Act
			Producto actual = Producto.GetProductoPorId(lista, 2);

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
