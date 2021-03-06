using Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades.ADOs
{
	public class ProductoADO
	{
		/// <summary>
		/// Lee la base de datos y guarda los valores en una lista del tipo Producto.
		/// </summary>
		/// <returns>Una lista con los valores leídos, si no existe la tabla o
		/// hay algún problema, retorna una lista vacía.</returns>
		public static List<Producto> ObtenerTodos()
		{
			List<Producto> productos = new List<Producto>();

			try
			{
				ADO.Comando.CommandText = "SELECT * FROM productos";
				ADO.Conexion.Open();
				SqlDataReader dataReader = ADO.Comando.ExecuteReader();

				while (dataReader.Read())
				{
					int id = dataReader.GetInt32(0);
					string descripcion = dataReader.GetString(1);
					float precio = (float)dataReader.GetDouble(2);
					ETipo tipo = (ETipo)dataReader.GetInt32(3);

					Producto producto = tipo switch
					{
						ETipo.Medicamento => new Medicamento(id, descripcion, precio, dataReader.GetInt32(5), (EUso)dataReader.GetInt32(6)),
						ETipo.Inyeccion => new Inyeccion(id, descripcion, precio, dataReader.GetInt32(4), (EUso)dataReader.GetInt32(6)),
						_ => new Higiene(id, descripcion, precio),
					};

					productos.Add(producto);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				ADO.Conexion.Close();
			}

			return productos;
		}
	}
}
