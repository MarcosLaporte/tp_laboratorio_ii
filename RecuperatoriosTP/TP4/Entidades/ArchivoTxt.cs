using System;
using System.IO;

namespace Entidades
{
	public class ArchivoTxt
	{
		static readonly string ruta;

		static ArchivoTxt()
		{
			ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		}

		public static void Escribir(string datos, string archivo)
		{
			string nombreArchivo = $@"{ruta}\{archivo}.txt";
			try
			{
				if (!Directory.Exists(ruta))
				{
					Directory.CreateDirectory(ruta);
				}

				File.WriteAllText(nombreArchivo, datos);
			}
			catch (Exception ex)
			{
				throw new Exception($"Error en el archivo ubicado en {ruta}\n{ex.Message}");
			}
		}
	}
}
