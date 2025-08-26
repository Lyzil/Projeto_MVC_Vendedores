// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;
using Proj._MVC_Vendedores;

int opcao;
Vendedores meusVendedores = new Vendedores();

do{
    Console.WriteLine("Menu de opções " +
        "\n0. Sair " +
        "\n1. Cadastrar vendedor " +
        "\n2. Consultar vendedor " +
        "\n3. Excluir vendedor  " +
        "\n4. Registrar venda " +
        "\n5. Listar vendedores " + 
        "\nescolhe a opção que deseja: ");
    opcao = Convert.ToInt32(Console.ReadLine());
    switch (opcao)
    {
        case 0:
            break;
        case 1:
            Console.WriteLine("digite o ID: "); int addID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("digite o Nome: "); string addNome = Console.ReadLine();

            Console.WriteLine(meusVendedores.addVendedor(new Vendedor(addID, addNome)) ? "adicionado com sucesso!" : "Não foi possivel adicionar");
            break;
        case 2:
            Console.WriteLine("digite o ID a ser consultado"); int idConsulta = Convert.ToInt32(Console.ReadLine());

            Vendedor vendedorConsultado = meusVendedores.searchVendedor(new Vendedor(idConsulta));
            Console.WriteLine($"ID: {vendedorConsultado.Id}\n" +
                               $"Nome: {vendedorConsultado.Nome}\n" +
                               $"Venda: {vendedorConsultado.valorVendas()}\n" +
                               $"Comissão: {vendedorConsultado.valorComissao()}\n" +
                               $"Valor Médio: teste");
            break;
        case 3:
            Console.WriteLine(meusVendedores.delVendedor(new Vendedor()) ? "deletado com sucesso!" : "Não foi possivel encontrar");
            break;
        case 4:
            Console.WriteLine("Digite o Id do funcionario: "); int IdRegistrar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o dia do mes (Numero): "); int dia= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a quantidade: "); int qtde = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o valor total: "); int vlTotal = Convert.ToInt32(Console.ReadLine());

            meusVendedores.OsVendedores[IdRegistrar].registrarVenda(dia - 1, new Venda(qtde, vlTotal));
            // add dps para add variaveis
            break;
        case 5:
            /*foreach(Vendedor v in meusVendedores) 
            {
                Vendedor vendedorListado = meusVendedores.searchVendedor(new Vendedor(v));
                Console.WriteLine($"ID: {vendedorListado.Id}\n" +
                                   $"Nome: {vendedorListado.Nome}\n" +
                                   $"Venda: {vendedorListado.valorVendas()}\n" +
                                   $"Comissão: {vendedorListado.valorComissao()}\n" +
                                   $"Valor Médio: teste");
            }*/
            break;
        default:
            Console.WriteLine("Ocorreu um erro, verifique se digitou corretamente");
            break;
    }
} while (opcao != 0);