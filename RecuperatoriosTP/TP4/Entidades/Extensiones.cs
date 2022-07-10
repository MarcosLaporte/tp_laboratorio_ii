using System.Collections.Generic;

namespace Entidades
{
	public static class Extensiones
	{
		/// <summary>
		/// Recorre una cadena y copia cada uno de sus caracteres 
		/// hasta que encuentra el mismo pasado por parámetro.
		/// </summary>
		/// <param name="cadena">La cadena a recorrer.</param>
		/// <param name="caracter">El caracter a encontrar.</param>
		/// <returns>La nueva cadena cortada.</returns>
		public static string CortarEnCaracter(this string cadena, char caracter)
		{
			string nuevaCadena = "";
			for (int i = 0; i < cadena.Length; i++)
			{
				if (cadena[i] != caracter)
				{
					nuevaCadena += cadena[i];
				}
				else
				{
					break;
				}
			}

			return nuevaCadena;
		}

		/// <summary>
		/// Busca en la lista pasada por parámetro algún Producto que concuerde con el [id].
		/// </summary>
		/// <param name="id">El id que buscar.</param>
		/// <param name="lista">La lista donde buscar.</param>
		/// <returns>Retorna el Producto si lo encuentra; si no nulo.</returns>
		public static Producto GetProductoPorId(this int id, List<Producto> lista)
		{
			Producto miProducto = null;
			foreach (Producto producto in lista)
			{
				if (producto.Id == id)
				{
					miProducto = producto;
					break;
				}
			}

			return miProducto;
		}
	}
}
