using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades.ADOs
{
	public class VentaADO
	{
		public static List<Venta> ObtenerTodas()
		{
			List<Venta> ventas = new List<Venta>();

			try
			{
				ADO.Comando.CommandText = "SELECT * FROM ventas";
				ADO.Conexion.Open();
				SqlDataReader dataReader = ADO.Comando.ExecuteReader();

				while (dataReader.Read())
				{
					int id = dataReader.GetInt32(0);
					float precio = (float)dataReader.GetDouble(1);
					float senia = (float)dataReader.GetDouble(2);
					ulong dniCliente = (ulong)dataReader.GetInt32(3);
					List<Producto> productos = new List<Producto>();

					ventas.Add(new Venta(id, precio, senia, dniCliente, productos));
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

			return ventas;
		}

		public static bool Agregar(Venta venta)
		{
			bool ret = true;
			try
			{

				ADO.Comando.Parameters.Clear();
				ADO.Comando.CommandText = $"INSERT INTO ventas(precio, senia, dniCliente) VALUES(@precio, @senia, @dniCliente)";
				ADO.Comando.Parameters.AddWithValue("@precio", venta.Precio);
				ADO.Comando.Parameters.AddWithValue("@senia", venta.Senia);
				ADO.Comando.Parameters.AddWithValue("@dniCliente", (int)venta.DniCliente);

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

		public static int ObtenerUltimaVenta()
		{
			int maxId = 0;
			try
			{
				ADO.Comando.CommandText = "SELECT MAX(id) FROM ventas";
				ADO.Conexion.Open();
				SqlDataReader dataReader = ADO.Comando.ExecuteReader();

				while (dataReader.Read())
				{
					maxId = dataReader.GetInt32(0);
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

			return maxId;
		}
	}
}
