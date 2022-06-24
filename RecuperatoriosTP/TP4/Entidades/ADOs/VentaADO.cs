using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Entidades.ADOs
{
	//Deshabilitada por el momento...
	public class VentaADO
	{
		/*static string connectionStr;
		static SqlCommand comando;
		static SqlConnection conexion;

		static VentaADO()
		{
			connectionStr = @"Data Source=.;Initial Catalog=FARMACIA_DB;Integrated Security=True";
			comando = new SqlCommand();
			conexion = new SqlConnection(connectionStr);

			comando.Connection = conexion;
			comando.CommandType = System.Data.CommandType.Text;
		}

		public static List<Venta> ObtenerTodos()
		{
			List<Venta> ventas = new List<Venta>();

			try
			{
				comando.CommandText = "SELECT * FROM ventas";
				conexion.Open();
				SqlDataReader dataReader = comando.ExecuteReader();
				XmlReader xmlReader = comando.ExecuteXmlReader();

				while (dataReader.Read())
				{
					float precio = dataReader.GetFloat(0);
					float senia = dataReader.GetFloat(1);
					int dniCliente = dataReader.GetInt32(2);
					List<Producto> productos = Serializadora<List<Producto>>.Leer(dataReader.GetSqlXml(3));

					ventas.Add(new Venta());
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

			return ventas;
		}

		public static bool Agregar(Venta venta)
		{
			bool ret = true;
			try
			{

				comando.Parameters.Clear();
				comando.CommandText = $"INSERT INTO ventas(descripcion, precio, tipo, cc, mg, uso) VALUES(@descripcion, @precio, @tipo, @cc, @mg, @uso)";
				comando.Parameters.AddWithValue("@descripcion", venta.Descripcion);
				comando.Parameters.AddWithValue("@precio", venta.Precio);
				comando.Parameters.AddWithValue("@tipo", (int)venta.Tipo);

				if (venta is Inyeccion)
				{
					comando.Parameters.AddWithValue("@cc", ((Inyeccion)venta).Cc);
					comando.Parameters.AddWithValue("@uso", (int)((Inyeccion)venta).Uso);
				}
				else if (venta is Medicamento)
				{
					comando.Parameters.AddWithValue("@mg", ((Medicamento)venta).Mg);
					comando.Parameters.AddWithValue("@uso", (int)((Medicamento)venta).Uso);
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

		public static bool Eliminar(Venta venta)
		{
			return VentaADO.Eliminar(venta.Id);
		}
		public static bool Eliminar(int id)
		{
			bool ret = true;

			try
			{
				comando.Parameters.Clear();
				comando.CommandText = $"DELETE FROM ventas WHERE id=@id";
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
		}*/
	}
}
