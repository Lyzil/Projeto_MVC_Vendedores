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

            for (int i = 0; i < max; i++)
            {
                this.OsVendedores[i] = new Vendedor();
            }
        }
        public int Max { get => max; set => max = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        internal Vendedor[] OsVendedores { get => osVendedores; set => osVendedores = value; }

        public bool addVendedor(Vendedor v)
        {
            foreach (Vendedor vend in this.OsVendedores)
            {
                if (vend.Id != -1 && vend.Id == v.Id)
                    return false;
            }

            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
                this.osVendedores[this.qtde++] = v;
            return podeAdicionar;
        }
        public bool delVendedor(Vendedor v)
        {
            Vendedor vendedorParaRemover = searchVendedor(v);

            if (vendedorParaRemover.Id == -1)
                return false;
            foreach (Venda venda in vendedorParaRemover.AsVendas)
            {
                if (venda.Qtde > 0)
                {
                    return false;
                }
            }
                int i = 0;
                while (i < this.max && this.osVendedores[i].Id != v.Id)
                {
                    i++;
                }
                for (int j = i; j < this.max - 1; j++)
                {
                    this.osVendedores[j] = this.osVendedores[j + 1];
                }
                this.osVendedores[this.max-1] = new Vendedor();
                this.qtde--;
                
                return true;
   
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
            double total = 0;
            foreach (Vendedor v in this.osVendedores)
            {
                if (v.Id != -1)
                    total += v.valorVendas();
            }
            return total;
        }
        public double valorComissao()
        {
            double total = 0;
            foreach (Vendedor v in this.osVendedores)
            {
                if (v.Id != -1)
                    total += v.valorComissao();
            }
            return total;
        }
    }
}
