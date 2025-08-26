using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Vendedores
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao = 0;
        private Venda[] asVendas;

        public Vendedor(): this(-1,"")
        {
            this.AsVendas = new Venda[31];
            for (int i = 0; i < 31; i++)
            {
                this.AsVendas[i] = new Venda();
            }
        }

        public Vendedor(int id) : this(id, "")
        {
            this.id = id;
            this.AsVendas = new Venda[31];
            for (int i = 0; i < 31; i++)
            {
                this.AsVendas[i] = new Venda();
            }
        }

        public Vendedor(int id, string nome) 
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = 0;
            this.AsVendas = new Venda[31];

            for (int i = 0; i < 31; i++) 
            {
                this.AsVendas[i] = new Venda();
            }
        }
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercComissao { get => percComissao; set => percComissao = value; }
        internal Venda[] AsVendas { get => asVendas; set => asVendas = value; }

        public void registrarVenda(int dia, Venda venda)
        {
            bool podeRegistrar = (dia < 31);
            if (podeRegistrar)
                this.asVendas[dia] = venda;
        }
        public double valorVendas()
        {
            double resTotal = 0.0;
            for (int i = 0; i < 31; i++) 
            {
              resTotal += AsVendas[i].value;
            }
            return resTotal;
        }
        public double valorComissao()
        {
            double resComi = 0.0;
            for (int i = 0; i < 31; i++) 
            {
              resComi += AsVendas[i].valorMedio();
            }
            return resComi;
        }

        public override bool Equals(object obj)
        {
            return (this.Id == ((Vendedor)obj).Id);
        }
    }
}

