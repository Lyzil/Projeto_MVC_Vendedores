// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography;
using Proj._MVC_Vendedores;
using static System.Runtime.InteropServices.JavaScript.JSType;

int opcao;
Vendedores meusVendedores = new Vendedores();

do
{
    Console.WriteLine("Menu de opções " +
        "\n0. Sair " +
        "\n1. Cadastrar vendedor " +
        "\n2. Consultar vendedor " +
        "\n3. Excluir vendedor  " +
        "\n4. Registrar venda " +
        "\n5. Listar vendedores " + 
        "\nEscolhe a opção que deseja: ");

    string inputOpcao = Console.ReadLine();
    if (!int.TryParse(inputOpcao, out opcao))
    {
        Console.WriteLine("Ocorreu um erro, verifique se digitou corretamente.\n");
        continue;
    }
    switch (opcao)
    {
        case 0:
            break;
        case 1:
            Console.WriteLine("\ndigite o ID: ");
            if (!int.TryParse(Console.ReadLine(), out int addID))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine("digite o Nome: "); 
            string addNome = Console.ReadLine();

            Console.WriteLine("digite o percentual(%) da comissão do vendedor: ");
            if (!double.TryParse(Console.ReadLine(), out double addPerc))
            {
                Console.WriteLine("Percentual inválido!\n");
                break;
            }
            Console.WriteLine(meusVendedores.addVendedor(new Vendedor(addID, addNome, addPerc)) ? "adicionado com sucesso!\n" : "Não foi possivel adicionar\n");
            break;
        case 2:
            Console.WriteLine("\ndigite o ID a ser consultado");
            if (!int.TryParse(Console.ReadLine(), out int idConsulta))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Vendedor vendedorConsultado = meusVendedores.searchVendedor(new Vendedor(idConsulta));
            if (vendedorConsultado.Id != -1)
            {
                Console.WriteLine($"ID: {vendedorConsultado.Id}\n" +
                               $"Nome: {vendedorConsultado.Nome}\n" +
                               $"Venda: R${vendedorConsultado.valorVendas():F2}\n" +
                               $"Comissão: R${vendedorConsultado.valorComissao():F2}\n");
                Console.WriteLine("Valores Médios das vendas diárias:");
                for (int i = 0; i < 31; i++)
                {
                    if (vendedorConsultado.AsVendas[i].Qtde > 0)
                    {
                        Console.WriteLine($"Dia {i + 1}: R${vendedorConsultado.AsVendas[i].ValorMedio():F2}\n");
                    }
                }
            }
            else { Console.WriteLine("Vendedor não encontrado!\n"); }
            break;
        case 3:
            Console.WriteLine("\ndigite o ID: ");
            if (!int.TryParse(Console.ReadLine(), out int delID))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine(meusVendedores.delVendedor(new Vendedor(delID)) ? "Deletado com sucesso!\n" : "Não foi possível deletar (vendedor possui vendas ou não existe)\n");            
            break;
        case 4:
            Console.WriteLine("\nDigite o Id do funcionario: ");
            if (!int.TryParse(Console.ReadLine(), out int IdRegistrar))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Vendedor vendedorAchado = meusVendedores.searchVendedor(new Vendedor(IdRegistrar));
            if (vendedorAchado.Id != -1)
            {
                Console.WriteLine("Digite o dia do mes (Numero): ");
                if (!int.TryParse(Console.ReadLine(), out int dia) || dia < 1 || dia > 31)
                {
                    Console.WriteLine("Dia inválido!\n");
                    break;
                }
                Console.WriteLine("Digite a quantidade: ");
                if (!int.TryParse(Console.ReadLine(), out int qtde) || qtde <= 0)
                {
                    Console.WriteLine("Quantidade inválida!\n");
                    break;
                }
                Console.WriteLine("Digite o valor total: ");
                if (!double.TryParse(Console.ReadLine(), out double vlTotal) || vlTotal <= 0)
                {
                    Console.WriteLine("Valor inválido!\n");
                    break;
                }
                vendedorAchado.registrarVenda(dia, new Venda(qtde, vlTotal));
                Console.WriteLine("Venda registrada com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado!\n");
            }
            break;
        case 5:
            foreach (Vendedor v in meusVendedores.OsVendedores)
            {
                if (v.Id == -1) continue;

                Console.WriteLine($"ID: {v.Id}\n" +
                               $"Nome: {v.Nome}\n" +
                               $"Venda: R${v.valorVendas():F2}\n" +
                               $"Comissão: R${v.valorComissao():F2}\n");
            }

            Console.WriteLine($"Valor total da venda de todos os vendedores: R${meusVendedores.valorVendas():F2}");
            Console.WriteLine($"Valor total da comissão de todos os vendedores: R${meusVendedores.valorComissao():F2}\n");

            break;
        default:
            Console.WriteLine("\nOcorreu um erro, verifique se digitou corretamente.\n");
            break;
    }
} while (opcao != 0);