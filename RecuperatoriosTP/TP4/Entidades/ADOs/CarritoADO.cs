using Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades.ADOs
{
	public class CarritoADO
	{
		public static List<Producto> ObtenerProductosDeVenta(int idVenta)
		{
			List<Producto> productos = new List<Producto>();

			try
			{
				ADO.Comando.Parameters.Clear();
				ADO.Comando.CommandText = "SELECT p.* FROM productos p INNER JOIN carrito c ON c.id_venta=@idVenta AND c.id_producto=p.id";
				ADO.Comando.Parameters.AddWithValue("@idVenta", idVenta);

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

		public static bool Agregar(int idVenta, int idProducto)
		{
			bool ret = true;
			try
			{
				ADO.Comando.Parameters.Clear();
				ADO.Comando.CommandText = $"INSERT INTO carrito(id_venta, id_producto) VALUES(@idVenta, @idProducto)";
				ADO.Comando.Parameters.AddWithValue("@idVenta", idVenta);
				ADO.Comando.Parameters.AddWithValue("@idProducto", idProducto);

				ADO.Conexion.Open();
				ADO.Comando.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				ret = false;
				throw new Exception(ex.Message);
			}
			finally
			{
				ADO.Conexion.Close();
			}

			return ret;
		}
	}
}
