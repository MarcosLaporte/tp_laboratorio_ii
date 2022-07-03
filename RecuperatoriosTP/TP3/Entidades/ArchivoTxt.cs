using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public class ArchivoTxt
	{
		static string ruta;

		static ArchivoTxt()
		{
			ruta = @"../../../../Entidades/Archivos";
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

        public static string Leer(string nombre)
        {
            string archivo = string.Empty;
            string datosLeidos = string.Empty;
            string nombreArchivo = $@"{ruta}\{nombre}.txt";

            try
            {
                if (Directory.Exists(ruta))
                {
                    string[] archivosEnElPath = Directory.GetFiles(ruta);
                    foreach (string ruta in archivosEnElPath)
                    {
                        if (ruta.Contains(nombreArchivo))
                        {
                            archivo = ruta;
                            break;
                        }
                    }

                    if (archivo is not null)
                    {
                        datosLeidos = File.ReadAllText(archivo);
                    }
                }

                return datosLeidos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el archivo ubicado en {ruta}\n{ex.Message}");
            }

        }
    }
}
