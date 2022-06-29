using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
	public class Serializadora<T>
	{
		static string ruta;

		static Serializadora()
		{
			ruta = @"../../../../Entidades/Archivos";
		}

		public static void Escribir(T datos, string archivo)
		{
			string completa = $@"{ruta}\{archivo}.xml";

			try
			{
				if (!Directory.Exists(ruta))
				{
					Directory.CreateDirectory(ruta);
				}

				using (StreamWriter sw = new StreamWriter(completa))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
					xmlSerializer.Serialize(sw, datos);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public static T Leer(string nombre)
		{
			string archivo = null;

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
						using (StreamReader sr = new StreamReader(archivo))
						{
							XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
							datos = (T)xmlSerializer.Deserialize(sr);
						}
					}
				}

				return datos;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
