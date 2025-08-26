using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Vendedores
{
    internal class Vendedores
    {
        private int max;
        private int qtde;
        private Vendedor[] osVendedores;

        public Vendedores()
        {
            this.Max = 10;
            this.Qtde = 0;
            this.OsVendedores = new Vendedor[max];

            for (int i = 0; i < 10; i++)
            {
                this.OsVendedores[i] = new Vendedor();
            }
        }
        public int Max { get => max; set => max = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        internal Vendedor[] OsVendedores { get => osVendedores; set => osVendedores = value; }

        public bool addVendedor(Vendedor v)
        {
            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
                this.osVendedores[this.qtde++] = v;
            return podeAdicionar;
        }
        public bool delVendedor(Vendedor v)
        {
            int j;
            bool poderemover = (searchVendedor(v).Id != -1);

            if (poderemover)
            {
                int i = 0;
                while (i < this.max && this.osVendedores[i].Id != v.Id)
                {
                    i++;
                }
                for (j = i; j < this.max; j++) 
                {
                    this.osVendedores[j] = this.osVendedores[j+1];
                }
                this.osVendedores[j] = new Vendedor();
                this.qtde--;
            }
            return poderemover;
        }
        public Vendedor searchVendedor(Vendedor v)
        {
            Vendedor vendedorAchado =  new Vendedor();
            foreach(Vendedor vendedor in this.OsVendedores)
            {
                if(vendedor.Equals(v))
                {
                    vendedorAchado = vendedor;
                    break;
                }
            }
            return vendedorAchado;
        }
        public double valorVendas()
        {
            return 424.2;
        }
        public double valorComissao()
        {
            return 424.2;
        }
    }
}
