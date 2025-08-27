﻿using System;
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
        private double percComissao;
        private Venda[] asVendas;

        public Vendedor(): this(-1,"",0)
        {
            this.AsVendas = new Venda[31];
            for (int i = 0; i < 31; i++)
            {
                this.AsVendas[i] = new Venda();
            }
        }

        public Vendedor(int id) : this(id, "",0)
        {
            this.id = id;
            this.AsVendas = new Venda[31];
            for (int i = 0; i < 31; i++)
            {
                this.AsVendas[i] = new Venda();
            }
        }

        public Vendedor(int id, string nome, double percComissao) 
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
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
            bool podeRegistrar = (dia < 31 && dia >= 0);
            if (podeRegistrar)
                this.asVendas[dia] = venda;
        }
        public double valorVendas()
        {
            double resTotal = 0.0;
            for (int i = 0; i < 31; i++) 
            {
              resTotal += AsVendas[i].Valor;
            }
            return resTotal;
        }
        public double valorComissao()
        {
            return valorVendas() * (this.percComissao / 100);
        }
        public override bool Equals(object obj)
        {
            return (this.Id == ((Vendedor)obj).Id);
        }
    }
}
