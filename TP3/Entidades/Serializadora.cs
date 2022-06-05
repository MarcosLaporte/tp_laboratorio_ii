using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;



namespace Entidades
{
	public class Serializadora<T>
	{
        static string ruta;

		static Serializadora()
		{
            //ruta = AppDomain.CurrentDomain.BaseDirectory;
			ruta = @"../../../../Entidades/JSON";
		}

		public static void Escribir_JSON(T datos, string archivo)
		{
			string completa = $@"{ruta}\{archivo}.json";

			try
			{
				if (!Directory.Exists(ruta))
				{
					Directory.CreateDirectory(ruta);
				}

				string objetoJson = JsonSerializer.Serialize(datos);
				File.AppendAllText(completa, objetoJson);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error en el archivo {completa}.");
			}
		}
		public static T Leer_Json(string nombre)
		{
			string archivo = string.Empty;

			T datos = default;

			try
			{
				if (Directory.Exists(ruta))
				{
					string[] archivosEnRuta = Directory.GetFiles(ruta);

					foreach (string archivoEnRuta in archivosEnRuta)
					{
						if (archivoEnRuta.Contains(nombre))
						{
							archivo = archivoEnRuta;
							break;
						}
					}

					if (archivo is not null)
					{
						string archivoJson = File.ReadAllText(archivo);

						datos = JsonSerializer.Deserialize<T>(archivoJson);
					}
				}
				else
				{
					throw new Exception("No existe la carpeta.");
				}

				return datos;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error en el archivo {archivo}.");
			}
		}
	}
}
