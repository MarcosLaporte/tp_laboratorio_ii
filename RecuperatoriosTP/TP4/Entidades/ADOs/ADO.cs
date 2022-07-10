using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ADOs
{
	public class ADO
	{
		static readonly string connectionStr;
		static readonly SqlCommand comando;
		static readonly SqlConnection conexion;

		static ADO()
		{
			connectionStr = @"Data Source=.;Initial Catalog=FARMACIA_DB;Integrated Security=True";
			comando = new SqlCommand();
			conexion = new SqlConnection(connectionStr);

			comando.Connection = conexion;
			comando.CommandType = System.Data.CommandType.Text;
		}

		public static string ConnectionStr => connectionStr;
		public static SqlCommand Comando => comando;
		public static SqlConnection Conexion => conexion;
	}
}
