using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Farmacia<T, U, V>
        where T : Cliente
        where U : Compra
        where V : Producto
    {
        private List<T> listaClientes;
        private List<U> listaCompras;
        private List<V> listaProductos;

        public Farmacia()
        {
            this.ListaClientes = new List<T>();
            this.ListaCompras = new List<U>();
            this.ListaProductos = new List<V>();
        }

        public List<T> ListaClientes
        {
            get { return this.listaClientes; }
            set { this.listaClientes = value; }
        }
        public List<U> ListaCompras
        {
            get { return this.listaCompras; }
            set { this.listaCompras = value; }
        }
        public List<V> ListaProductos
        {
            get { return this.listaProductos; }
            set { this.listaProductos = value; }
        }

        public Cliente GetClientePorDni(Farmacia<T, U, V> farmacia, string dni)
        {
            Cliente miCliente = null;
            foreach (Cliente cliente in farmacia.listaClientes)
            {
                if(cliente.Dni == dni)
                {
                    miCliente = cliente;
                    break;
                }
            }

            return miCliente;
        }
        public Producto GetProductoPorId(Farmacia<T, U, V> farmacia, int id)
        {
            Producto miProducto = null;
            foreach (Producto producto in farmacia.listaProductos)
            {
                if(producto.Id == id)
                {
                    miProducto = producto;
                    break;
                }
            }

            return miProducto;
        }
        public Compra GetCompraPorId(Farmacia<T, U, V> farmacia, int id)
        {
            Compra miProducto = null;
            foreach (Compra compra in farmacia.listaCompras)
            {
                if(compra.Id == id)
                {
                    miProducto = compra;
                    break;
                }
            }

            return miProducto;
        }

		#region Sobrecargas T
		public static bool operator ==(Farmacia<T, U, V> f, T t)
        {
            bool ret = false;
            if (f is not null)
            {
                foreach (T item in f.listaClientes)
                {
                    if (item.Equals(t))
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }
        public static bool operator !=(Farmacia<T, U, V> f, T t)
        {
            return !(f == t);
        }
        public static Farmacia<T, U, V> operator +(Farmacia<T, U, V> f, T t)
        {
            if(f != t)
            {
                f.listaClientes.Add(t);
                Console.WriteLine("Agregado!");
            }
            else
            {
                Console.WriteLine("Ya existe.");
            }

            return f;
        }
        public static Farmacia<T, U, V> operator -(Farmacia<T, U, V> f, T t)
        {
            if(f == t)
            {
                f.listaClientes.Remove(t);
                Console.WriteLine("Eliminado!");
            }
            else
            {
                Console.WriteLine("No existe.");
            }

            return f;
        }
        #endregion

        #region Sobrecargas U
        public static bool operator ==(Farmacia<T, U, V> f, U u)
        {
            bool ret = false;
            if (f is not null)
            {
                foreach (U item in f.listaCompras)
                {
                    if (item.Equals(u))
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }
        public static bool operator !=(Farmacia<T, U, V> f, U u)
        {
            return !(f == u);
        }
        public static Farmacia<T, U, V> operator +(Farmacia<T, U, V> f, U u)
        {
            if(f != u)
            {
                f.listaCompras.Add(u);
                Console.WriteLine("Agregado!");
            }
            else
            {
                Console.WriteLine("Ya existe.");
            }

            return f;
        }
        #endregion

        #region Sobrecargas V
        public static bool operator ==(Farmacia<T, U, V> f, V v)
        {
            bool ret = false;
            if (f is not null)
            {
                foreach (V item in f.listaProductos)
                {
                    if (item.Equals(v))
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }
        public static bool operator !=(Farmacia<T, U, V> f, V v)
        {
            return !(f == v);
        }
        public static Farmacia<T, U, V> operator +(Farmacia<T, U, V> f, V v)
        {
            if(f != v)
            {
                f.listaProductos.Add(v);
                Console.WriteLine("Agregado!");
            }
            else
            {
                Console.WriteLine("Ya existe.");
            }

            return f;
        }
        #endregion

    }
}
