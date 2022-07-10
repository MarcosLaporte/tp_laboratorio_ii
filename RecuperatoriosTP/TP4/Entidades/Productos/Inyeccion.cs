namespace Entidades.Productos
{
	public class Inyeccion : Producto, IUsoDelProducto
	{
		private int cc;
		private EUso uso;

		public Inyeccion()
		{

		}
		public Inyeccion(int id, string descripcion, float precio, int medida, EUso uso)
			: base(id, descripcion, precio, ETipo.Inyeccion)
		{
			this.Cc = medida;
			this.Uso = uso;
		}

		public int Cc
		{
			get { return this.cc; }
			set { this.cc = value; }
		}
		public EUso Uso
		{
			get { return this.uso; }
			set { this.uso = value; }
		}

		/// <summary>
		/// Clasifica los valores de los atributos [uso] y [cc] y, dependiendo de qué
		/// condición cumplan, retorna cada cuantas horas debe administrarse el medicamento.
		/// </summary>
		/// <param name="uso">El valor del enumerado EUso.</param>
		/// <returns>Un entero que representa años.</returns>
		public int AdministrarDosis(EUso uso)
		{
			//Cada cuantos años
			int ret = 1;
			if (uso == EUso.Analgesico || uso == EUso.Antibiotico && this.cc >= 5)
			{
				ret = 3;
			}
			else if (uso == EUso.Antibiotico || uso == EUso.Antialergico && this.cc <= 2)
			{
				ret = 2;
			}
			else if (uso == EUso.Antialergico && this.cc >= 3)
			{
				ret = 5;
			}
			return ret;
		}

		public override string ToString()
		{
			return this.Datos() + $"Inyección de {this.cc:D}cc\n"
				+ $"Cada {this.AdministrarDosis(this.uso)} años.\n";
		}
	}
}
