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
					float debe = dataReader.GetFloat(4);

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
				comando.Parameters.AddWithValue("@dni", cliente.Dni);
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

		public static bool PagarDeuda(Cliente cliente)
		{
			return ClienteADO.PagarDeuda(cliente.Dni);
		}
		public static bool PagarDeuda(ulong dni)
		{
			bool ret = true;
			try
			{
				comando.Parameters.Clear();
				comando.CommandText = $"UPDATE clientes SET debe=0 WHERE dni=@dni";
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

		public static bool Eliminar(Cliente cliente)
		{
			return ClienteADO.Eliminar(cliente.Dni);
		}
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

	}
}
