using Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ADOs
{
	public static class ProductoADO
	{
		static string connectionStr;
		static SqlCommand comando;
		static SqlConnection conexion;

		static ProductoADO()
		{
			connectionStr = @"Data Source=.;Initial Catalog=FARMACIA_DB;Integrated Security=True";
			comando = new SqlCommand();
			conexion = new SqlConnection(connectionStr);

			comando.Connection = conexion;
			comando.CommandType = System.Data.CommandType.Text;
		}

		public static List<Producto> ObtenerTodos(ETipo tipo)
		{
			List<Producto> productos = new List<Producto>();

			try
			{
				comando.CommandText = "SELECT * FROM productos WHERE tipo=@tipo";
				comando.Parameters.AddWithValue("@tipo", (int)tipo);
				conexion.Open();
				SqlDataReader dataReader = comando.ExecuteReader();

				while (dataReader.Read())
				{
					int id = dataReader.GetInt32(0);
					string descripcion = dataReader.GetString(1);
					float precio = dataReader.GetFloat(2);
					int cc = dataReader.GetInt32(4);
					int mg = dataReader.GetInt32(5);
					EUso uso = (EUso)dataReader.GetInt32(6);

					Producto producto = tipo switch
									{
										ETipo.Medicamento => new Medicamento(id, descripcion, precio, mg, uso),
										ETipo.Inyeccion => new Inyeccion(id, descripcion, precio, cc, uso),
										_ => new Higiene(id, descripcion, precio),
									};

					productos.Add(producto);
				}
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				conexion.Close();
			}

			return productos;
		}
		
		/// <summary>
		/// Lee la base de datos y guarda estos en una lista del tipo Producto.
		/// </summary>
		/// <returns>Una lista con los valores leídos, si no existe la tabla o
		/// hay algún problema, retorna una lista vacía.</returns>
		public static List<Producto> ObtenerTodos()
		{
			List<Producto> productos = new List<Producto>();

			try
			{
				comando.CommandText = "SELECT * FROM productos";
				conexion.Open();
				SqlDataReader dataReader = comando.ExecuteReader();

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
			catch (Exception)
			{

				throw;
			}
			finally
			{
				conexion.Close();
			}

			return productos;
		}

		/// <summary>
		/// Agrega el objeto Producto pasado por parámetro a la base de datos.
		/// </summary>
		/// <param name="producto">El producto del cual toma los valores.</param>
		/// <returns>true si pudo agregarlo; false si no.</returns>
		public static bool Agregar(Producto producto)
		{
			bool ret = true;
			try
			{

				comando.Parameters.Clear();
				comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
				comando.Parameters.AddWithValue("@precio", producto.Precio);
				comando.Parameters.AddWithValue("@tipo", (int)producto.Tipo);

				if (producto is Inyeccion)
				{
					comando.CommandText = $"INSERT INTO productos(descripcion, precio, tipo, cc, uso) VALUES(@descripcion, @precio, @tipo, @cc, @uso)";
					comando.Parameters.AddWithValue("@cc", ((Inyeccion)producto).Cc);
					comando.Parameters.AddWithValue("@uso", (int)((Inyeccion)producto).Uso);
				}
				else if (producto is Medicamento)
				{
					comando.CommandText = $"INSERT INTO productos(descripcion, precio, tipo, mg, uso) VALUES(@descripcion, @precio, @tipo, @mg, @uso)";
					comando.Parameters.AddWithValue("@mg", ((Medicamento)producto).Mg);
					comando.Parameters.AddWithValue("@uso", (int)((Medicamento)producto).Uso);
				}
				else
				{
					comando.CommandText = $"INSERT INTO productos(descripcion, precio, tipo) VALUES(@descripcion, @precio, @tipo)";
				}

				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception)
			{
				ret = false;
				throw;
			}
			finally
			{
				conexion.Close();
			}

			return ret;
		}

		public static bool Eliminar(Producto producto)
		{
			return ProductoADO.Eliminar(producto.Id);
		}

		/// <summary>
		/// Elimina la fila cuya columna [id] concuerda con el dato pasado por parámetro.
		/// </summary>
		/// <param name="id">El valor a buscar en la columna [id].</param>
		/// <returns>true si pudo eliminarlo; false si no.</returns>
		public static bool Eliminar(int id)
		{
			bool ret = true;

			try
			{
				comando.Parameters.Clear();
				comando.CommandText = $"DELETE FROM productos WHERE id=@id";
				comando.Parameters.AddWithValue("@id", id);
				conexion.Open();
				comando.ExecuteNonQuery();

			}
			catch (Exception)
			{
				ret = false;
				throw;
			}
			finally
			{
				conexion.Close();
			}

			return ret;
		}
	}
}
