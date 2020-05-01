using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Program
    {
        public static void Main()
        {
            IDictionary<int, Conta> contasCadastradas = new Dictionary<int, Conta>();

        Inicio:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            StringBuilder menuPrincipal = new StringBuilder("\n|  Bem vindo ao Banco  |\n");
            menuPrincipal.Insert(0, "=", 24);
            menuPrincipal.Insert(50, "=", 24);
            menuPrincipal.Append("\n\n╔═══════════════════════════════════════════╗\n");
            menuPrincipal.Append("║* Tecle 1 para abrir conta                 ║\n");
            menuPrincipal.Append("║═══════════════════════════════════════════║\n");
            menuPrincipal.Append("║* Tecle 2 para encerrar conta              ║\n");
            menuPrincipal.Append("║═══════════════════════════════════════════║\n");
            menuPrincipal.Append("║* Tecle 3 para consultar saldo             ║\n");
            menuPrincipal.Append("║═══════════════════════════════════════════║\n");
            menuPrincipal.Append("║* Tecle 4 para efetuar saque               ║\n");
            menuPrincipal.Append("║═══════════════════════════════════════════║\n");
            menuPrincipal.Append("║* Tecle 5 para efetuar depósito            ║\n");
            menuPrincipal.Append("║═══════════════════════════════════════════║\n");
            menuPrincipal.Append("║* Tecle 6 para efetuar transferência       ║\n");
            menuPrincipal.Append("║═══════════════════════════════════════════║\n");
            menuPrincipal.Append("║* Tecle 7 para consultar dados do cliente  ║\n");
            menuPrincipal.Append("╚═══════════════════════════════════════════╝\n");

            Console.WriteLine(menuPrincipal);
            int.TryParse(Console.ReadLine(), out int flagMenuPrincipal);

            try
            {
                switch (flagMenuPrincipal)
                {
                    case 1:
                        var menuAbrirConta = new StringBuilder("ABERTURA DE CONTA:\n\n");
                        menuAbrirConta.Append("* Tecle 1 para abrir Conta Corrente\n");
                        menuAbrirConta.Append("* Tecle 2 para abrir Conta Poupanca\n");

                        Console.Clear();
                        Console.WriteLine(menuAbrirConta);
                        int.TryParse(Console.ReadLine(), out int flagMenuAbrirConta);

                        switch (flagMenuAbrirConta)
                        {
                            case 1:
                                var contaCorrente = new ContaCorrente(Cliente.Cadastrar());
                                contasCadastradas.Add(contaCorrente.Numero, contaCorrente);

                                Console.Clear();
                                Console.WriteLine("\nConta aberta! Seguem os dados:");
                                contaCorrente.MostrarDados();
                                Console.ReadKey();
                                goto Inicio;

                            case 2:
                                var contaPoupanca = new ContaPoupanca(Cliente.Cadastrar());
                                contasCadastradas.Add(contaPoupanca.Numero, contaPoupanca);

                                Console.Clear();
                                Console.WriteLine("Conta aberta! Seguem os dados:");
                                contaPoupanca.MostrarDados();
                                Console.ReadKey();
                                goto Inicio;
                        }
                        Console.ReadKey();
                        goto Inicio;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("ENCERRAR CONTA:\n");
                        Console.WriteLine("Digite o número da conta:");
                        int.TryParse(Console.ReadLine(), out int numConta);

                        if (contasCadastradas.ContainsKey(numConta))
                        {
                            contasCadastradas.Remove(numConta);
                            Console.WriteLine("\nConta encerrada.");
                        }
                        else
                            Console.WriteLine("\nConta nao encontrada.");

                        Console.ReadKey();
                        goto Inicio;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("CONSULTA DE SALDO:\n");
                        Console.WriteLine("Digite o número da conta:");
                        int.TryParse(Console.ReadLine(), out numConta);

                        if (contasCadastradas.ContainsKey(numConta))
                        {
                            var buscaConta = contasCadastradas[numConta];
                            buscaConta.ConsultarSaldo();
                        }
                        else
                            Console.WriteLine("\nConta não encontrada.");

                        Console.ReadKey();
                        goto Inicio;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("SAQUE:\n");
                        Console.WriteLine("Digite o numero da conta:");
                        int.TryParse(Console.ReadLine(), out numConta);

                        if (contasCadastradas.ContainsKey(numConta))
                        {
                            Console.WriteLine("\nDigite o valor do saque:");
                            double.TryParse(Console.ReadLine(), out double valorSaque);

                            var buscaConta = contasCadastradas[numConta];
                            buscaConta.Sacar(valorSaque);
                            buscaConta.ConsultarSaldo();
                        }
                        else
                            Console.WriteLine("\nConta não encontrada.");

                        Console.ReadKey();
                        goto Inicio;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("DEPOSITO:\n");
                        Console.WriteLine("Digite o numero da conta:");
                        int.TryParse(Console.ReadLine(), out numConta);

                        Console.WriteLine("\nDigite o valor do deposito:");
                        Double.TryParse(Console.ReadLine(), out double valorDeposito);

                        if (contasCadastradas.ContainsKey(numConta))
                        {
                            var buscaConta = contasCadastradas[numConta];
                            buscaConta.Depositar(valorDeposito);
                            buscaConta.ConsultarSaldo();
                        }
                        else
                            Console.WriteLine("\nConta não encontrada.");

                        Console.ReadKey();
                        goto Inicio;

                    case 6:
                        Console.Clear();

                        Conta contaOrigem = null, contaDestino = null;

                        Console.WriteLine("TRANSFERENCIA:\n");
                        Console.WriteLine("Digite o numero da conta de origem:");
                        int.TryParse(Console.ReadLine(), out int chave1);
                        if (contasCadastradas.ContainsKey(chave1))
                            contaOrigem = contasCadastradas[chave1];
                        else
                        {
                            Console.WriteLine("\nConta não encontrada.");
                            Console.ReadKey();
                            goto Inicio;
                        }

                        Console.WriteLine("Digite o numero da conta de Destino:");
                        int.TryParse(Console.ReadLine(), out int chave2);
                        if (contasCadastradas.ContainsKey(chave2))
                            contaDestino = contasCadastradas[chave2];
                        else
                        {
                            Console.WriteLine("\nConta não encontrada.");
                            Console.ReadKey();
                            goto Inicio;
                        }

                        Console.WriteLine("\nDigite o valor a ser transferido:");
                        Double.TryParse(Console.ReadLine(), out double valorTransferencia);
                        contaOrigem.Transferir(valorTransferencia, contaDestino);


                        Console.ReadKey();
                        goto Inicio;

                    case 7:
                        StringBuilder menuConsultaCliente = new StringBuilder("CONSULTA - CLIENTE:\n\n");
                        menuConsultaCliente.Append("* Tecle 1 para pesquisar pelo numero da conta\n");
                        menuConsultaCliente.Append("* Tecle 2 para pesquisar pelo nome do titular\n");
                        menuConsultaCliente.Append("* Tecle 3 para pesquisar pelo CPF\n");

                        Console.Clear();
                        Console.WriteLine(menuConsultaCliente);
                        int.TryParse(Console.ReadLine(), out int flagMenuConsultaCliente);

                        switch (flagMenuConsultaCliente)
                        {

                            case 1:
                                Console.Clear();
                                Console.WriteLine("Digite o numero da conta:");
                                int.TryParse(Console.ReadLine(), out int buscaNum);

                                if (contasCadastradas.ContainsKey(buscaNum))
                                    contasCadastradas[buscaNum].MostrarDados();
                                else
                                    Console.WriteLine("\nConta não encotrada.");

                                Console.ReadKey();
                                goto Inicio;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("Digite o nome:");

                                string buscaNome = Console.ReadLine();

                                var filtroNome = contasCadastradas.Values.Where(item => item.Titular.Nome.Contains(buscaNome));
                                foreach (var conta in filtroNome)
                                    conta.MostrarDados();

                                if (filtroNome.Count() == 0)
                                    Console.WriteLine("\nConta não encontrada.");

                                Console.ReadKey();
                                goto Inicio;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("Digite o numero do CPF:");

                                double.TryParse(Console.ReadLine(), out double buscaCpf);

                                var filtroCpf = contasCadastradas.Values.Where(item => item.Titular.Cpf == buscaCpf);
                                filtroCpf.ElementAt(0).MostrarDados();

                                if (filtroCpf.Count() == 0)
                                    Console.WriteLine("\nConta não encotrada.");

                                Console.ReadKey();
                                goto Inicio;
                        }

                        Console.ReadKey();
                        goto Inicio;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadKey();
                goto Inicio;
            }
        }
    }
}
