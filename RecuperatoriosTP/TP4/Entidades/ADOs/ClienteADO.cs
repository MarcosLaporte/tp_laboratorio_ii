using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades.ADOs
{
	public class ClienteADO
	{
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
				ADO.Comando.CommandText = "SELECT * FROM clientes";
				ADO.Conexion.Open();
				SqlDataReader dataReader = ADO.Comando.ExecuteReader();

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
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				ADO.Conexion.Close();
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

				ADO.Comando.Parameters.Clear();
				ADO.Comando.CommandText = $"INSERT INTO clientes(nombre, apellido, telefono, dni, debe) VALUES(@nombre, @apellido, @telefono, @dni, @debe)";
				ADO.Comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
				ADO.Comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
				ADO.Comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
				ADO.Comando.Parameters.AddWithValue("@dni", (int)cliente.Dni);
				ADO.Comando.Parameters.AddWithValue("@debe", cliente.Debe);

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

		public static bool CambiarDeuda(Cliente cliente, float valor)
		{
			return ClienteADO.CambiarDeuda(cliente.Dni, valor);
		}

		/// <summary>
		/// Modifica la fila cuya columna [dni] concuerda con el dato pasado
		/// por parámetro y establece el valor en la columna [debe] en el del parámetro.
		/// </summary>
		/// <param name="dni">El valor a buscar en la columna [dni].</param>
		/// <returns>true si pudo modificarlo; false si no.</returns>
		public static bool CambiarDeuda(ulong dni, float valor)
		{
			bool ret = true;
			try
			{
				ADO.Comando.Parameters.Clear();
				ADO.Comando.CommandText = $"UPDATE clientes SET debe=@valor WHERE dni=@dni";
				ADO.Comando.Parameters.AddWithValue("@dni", (int)dni);
				ADO.Comando.Parameters.AddWithValue("@valor", valor);

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
				ADO.Comando.Parameters.Clear();
				ADO.Comando.CommandText = $"DELETE FROM clientes WHERE dni=@dni";
				ADO.Comando.Parameters.AddWithValue("@dni", (int)dni);
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

		/// <summary>
		/// Modifica la fila cuya columna [dni] concuerda con el dato pasado
		/// por parámetro y establece el valor en la columna [debe] en 0.
		/// </summary>
		/// <param name="cliente">El cliente a modificar.</param>
		/// <returns>true si pudo modificarlo; false si no.</returns>
		public static bool ModificarDatos(Cliente cliente)
		{
			bool ret = true;
			try
			{
				ADO.Comando.Parameters.Clear();
				ADO.Comando.CommandText = $"UPDATE clientes SET nombre=@nombre, apellido=@apellido, telefono=@telefono WHERE dni=@dni";
				ADO.Comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
				ADO.Comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
				ADO.Comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
				ADO.Comando.Parameters.AddWithValue("@dni", (int)cliente.Dni);

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
