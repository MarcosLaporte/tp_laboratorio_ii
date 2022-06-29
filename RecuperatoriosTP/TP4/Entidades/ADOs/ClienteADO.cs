using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ADOs
{
	public static class ClienteADO
	{
		static string connectionStr;
		static SqlCommand comando;
		static SqlConnection conexion;

		static ClienteADO()
		{
			connectionStr = @"Data Source=.;Initial Catalog=FARMACIA_DB;Integrated Security=True";
			comando = new SqlCommand();
			conexion = new SqlConnection(connectionStr);

			comando.Connection = conexion;
			comando.CommandType = System.Data.CommandType.Text;
		}

		/// <summary>
		/// Lee la base de datos y guarda estos en una lista del tipo Cliente.
		/// </summary>
		/// <returns>Una lista con los valores leídos, si no existe la tabla o
		/// hay algún problema, retorna una lista vacía.</returns>
		public static List<Cliente> ObtenerTodos()
		{
			List<Cliente> clientes = new List<Cliente>();

			try
			{
				comando.CommandText = "SELECT * FROM clientes";
				conexion.Open();
				SqlDataReader dataReader = comando.ExecuteReader();

				while (dataReader.Read())
				{
					string nombre = dataReader.GetString(0);
					string apellido = dataReader.GetString(1);
					string telefono = dataReader.GetString(2);
					ulong dni = (ulong)dataReader.GetInt32(3);
					float debe = (float)dataReader.GetDouble(4);

					clientes.Add(new Cliente(nombre, apellido, telefono, dni, debe));
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

			return clientes;
		}

		/// <summary>
		/// Agrega el objeto Cliente pasado por parámetro a la base de datos.
		/// </summary>
		/// <param name="cliente">El cliente del cual toma los valores.</param>
		/// <returns>true si pudo agregarlo; false si no.</returns>
		public static bool Agregar(Cliente cliente)
		{
			bool ret = true;
			try
			{

				comando.Parameters.Clear();
				comando.CommandText = $"INSERT INTO clientes(nombre, apellido, telefono, dni, debe) VALUES(@nombre, @apellido, @telefono, @dni, @debe)";
				comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
				comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
				comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
				comando.Parameters.AddWithValue("@dni", (int)cliente.Dni);
				comando.Parameters.AddWithValue("@debe", cliente.Debe);

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

		public static bool CambiarDeuda(Cliente cliente, float valor)
		{
			return ClienteADO.CambiarDeuda(cliente.Dni, valor);
		}

		/// <summary>
		/// Modifica la fila cuya columna [dni] concuerda con el dato pasado
		/// por parámetro y establece el valor en la columna [debe] en 0.
		/// </summary>
		/// <param name="dni">El valor a buscar en la columna [dni].</param>
		/// <returns>true si pudo modificarlo; false si no.</returns>
		public static bool CambiarDeuda(ulong dni, float valor)
		{
			bool ret = true;
			try
			{
				comando.Parameters.Clear();
				comando.CommandText = $"UPDATE clientes SET debe=@valor WHERE dni=@dni";
				comando.Parameters.AddWithValue("@dni", (int)dni);
				comando.Parameters.AddWithValue("@valor", valor);

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

		public static bool Eliminar(Cliente cliente)
		{
			return ClienteADO.Eliminar(cliente.Dni);
		}

		/// <summary>
		/// Elimina la fila cuya columna [dni] concuerda con el dato pasado por parámetro.
		/// </summary>
		/// <param name="dni">El valor a buscar en la columna [dni].</param>
		/// <returns>true si pudo eliminarlo; false si no.</returns>
		public static bool Eliminar(ulong dni)
		{
			bool ret = true;

			try
			{
				comando.Parameters.Clear();
				comando.CommandText = $"DELETE FROM clientes WHERE dni=@dni";
				comando.Parameters.AddWithValue("@dni", dni);
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

		/// <summary>
		/// Elimina todos los valores de la base de datos y escribe los de la lista pasada por parámetros.
		/// </summary>
		/// <param name="nuevosClientes">La lista cuyos datos se escriben en la lista.</param>
		public static void Sobreescribir(List<Cliente> nuevosClientes)
		{
			try
			{
				comando.CommandText = $"DELETE FROM clientes";
				conexion.Open();
				comando.ExecuteNonQuery();

			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				conexion.Close();
				nuevosClientes.ForEach((cliente) => ClienteADO.Agregar(cliente));
			}
		}
	}
}
