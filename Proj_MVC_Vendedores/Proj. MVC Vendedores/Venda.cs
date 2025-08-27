using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj._MVC_Vendedores
{
    internal class Venda
    {
        private int qtde;
        private double valor;
        public Venda(int qtde, double valor)
        {
            Qtde = qtde;
            Valor = valor;
        }
        public Venda()
        {
            this.qtde = 0;
            this.valor = 0.0;
        }
        public int Qtde { get => qtde; set => qtde = value; }
        public double Valor { get => valor; set => valor = value; }

        public double ValorMedio()
        {
            return (valor / qtde);
        }

    }
}
