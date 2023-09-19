using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;
using At.Heranca.Banco.Classes;
using Microsoft.VisualBasic;

class Program
    {
    static void Main(string[] args)
    {
        int num = 0;
            List<Conta> contas = new List<Conta>();

            while (true)
            {
                Console.WriteLine("Escolha uma das opções abaixo: ");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Mostrar Contas");
                Console.WriteLine("3 - Realizar Saque");
                Console.WriteLine("4 - Realizar Depósito");
                Console.WriteLine("5 - Realizar Empréstimo");
                Console.WriteLine("6 - Verificar Conta Específica");
                Console.WriteLine("7 - Sair");
                Console.Write("Escolha uma opção: ");

                try
                {
                    int menu = int.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            CriarConta(contas, num);
                            num++;
                            break;
                        case 2:
                            MostrarContas(contas);
                            break;
                        case 3:
                            RealizarSaque(contas);
                            break;
                        case 4:
                            RealizarDeposito(contas);
                            break;
                        case 5:
                            RealizarEmprestimo(contas);
                            break;
                        case 6:
                            VerificarConta(contas);
                            break;
                        case 7:
                        goto exit;
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Digito inválido, escreva novamente. Digite um número");
                }
            }exit:;
        }

        static void CriarConta(List<Conta> contas, int num)
        {
            Console.WriteLine("Escolha o tipo de conta: ");
            Console.WriteLine("1 - Conta Empresarial");
            Console.WriteLine("2 - Conta Estudantil");
            Console.WriteLine("3 - Conta Padrão");
            int menu2 = int.Parse(Console.ReadLine());

    yea:;
        try
        {
        exit3:;
            Console.Write("Digite o nome do titular: ");
            string titular = Console.ReadLine();
            if (titular == "")
            {
                Console.WriteLine("O nome do titular não pode ficar vazio, digite um nome válido");
                goto exit3;
            }
        exit4:;
            Console.Write("Digite o saldo: ");
            double saldo = double.Parse(Console.ReadLine());
            if (saldo < 0)
            {
                Console.WriteLine("O saldo inicial de uma conta não pode ser negativo");
                goto exit4;
            }

            switch (menu2)
            {
                case 1:
                exit7:;
                    Console.Write("Digite a taxa de anuidade: ");
                    double anuidade = double.Parse(Console.ReadLine());
                    if (anuidade < 0)
                    {
                        Console.WriteLine("A taxa de anuidade de uma conta não pode ser negativa");
                        goto exit7;
                    }
                exit8:;
                    Console.Write("Digite o limite de empréstimo: ");
                    double lE = double.Parse(Console.ReadLine());
                    if (lE < 0)
                    {
                        Console.WriteLine("O limite de empréstimo de uma conta não pode ser negativo");
                        goto exit8;
                    }
                    ContaEmpresarial novaContaEm = new ContaEmpresarial(anuidade, lE, 0, num, "BB", titular, saldo);
                    contas.Add(novaContaEm);
                    Console.WriteLine("A Conta Empresarial foi criada.");
                    break;
                case 2:
                exit9:;
                    Console.Write("Digite o limite do cheque especial: ");
                    double lCE = double.Parse(Console.ReadLine());
                    if (lCE < 0)
                    {
                        Console.WriteLine("O limite do cheque especial de uma conta não pode ser negativo");
                        goto exit9;
                    }
                exit10:;
                    Console.Write("Digite o CPF: ");
                    string cpf = Console.ReadLine();
                    if (cpf == "")
                    {
                        Console.WriteLine("O CPF não pode ficar vazio, digite um CPF válido");
                        goto exit10;
                    }
                exit11:;
                    Console.Write("Digite o nome da instituição de ensino: ");
                    string nI = Console.ReadLine();
                    if (nI == "")
                    {
                        Console.WriteLine("O nome da intituição de ensino não pode ficar vazio, digite um nome válido");
                        goto exit11;
                    }

                    ContaEstudante novaContaEs = new ContaEstudante(lCE, cpf, nI, num, "BB", titular, saldo);
                    contas.Add(novaContaEs);
                    Console.WriteLine("A Conta Estudantil foi criada.");
                    break;
                case 3:
                    Conta novaConta = new Conta(num, "BB", titular, saldo);
                    contas.Add(novaConta);
                    Console.WriteLine("A Conta Padrão foi criada.");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Digito inválido, escreva novamente");
            goto yea;
        }
        }

        static void MostrarContas(List<Conta> contas)
        {
            if (contas.Count > 0)
            {
                Console.WriteLine("Contas Existentes:");
                foreach (var conta in contas)
                {
                    Console.WriteLine($"Conta número {conta.Num} - Titular: {conta.Titular} - Agência: {conta.Agencia}");
                }
            }
            else
            {
                Console.WriteLine("Ainda não há contas existentes");
            }
        }

        static void RealizarSaque(List<Conta> contas)
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int numConta = int.Parse(Console.ReadLine());

                var conta = contas.Find(c => c.Num == numConta);    //No lugar de SingleOrDefault, ele procura em lista, sem ser 
                                                                    //criando em classe específica e retorna null caso não tenha
                                                                    //caso tenha, ele retorna o obj do id

            if (conta != null)
                {
                    Console.Write("Digite o valor do saque: ");
                    double valor = double.Parse(Console.ReadLine());

                    conta.Sacar(valor);
                }
                else
                {
                    Console.WriteLine("Número não corresponde a nenhuma conta");
                }
            }
            catch (Exception ax)
            {
                Console.WriteLine("Digito inválido, escreva novamente");
            }
        }

        static void RealizarDeposito(List<Conta> contas)
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int numConta = int.Parse(Console.ReadLine());

                var conta = contas.SingleOrDefault(c => c.Num == numConta);

                if (conta != null)
                {
                    Console.Write("Digite o valor do depósito: ");
                    double valor = double.Parse(Console.ReadLine());

                    if (valor > 0)
                    {
                        conta.Depositar(valor);
                    }
                    else
                    {
                        Console.WriteLine("O valor inserido não pode ser negativo");
                    }
                }
                else
                {
                    Console.WriteLine("Número não corresponde a nenhuma conta");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Digito inválido, escreva novamente");
            }
        }

        static void RealizarEmprestimo(List<Conta> contas)
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int numConta = int.Parse(Console.ReadLine());

                var conta = contas.Find(c => c.Num == numConta);

                if (conta != null)
                {
                    if (conta is ContaEmpresarial contaEmpresarial) // o is verifica se a conversão é possível e
                                                                    // depois o converte
                    {
                        Console.Write("Digite o valor do empréstimo desejado: ");
                        double valor = double.Parse(Console.ReadLine());

                        contaEmpresarial.FazerEmprestimo(valor);
                    }
                    else
                    {
                        Console.WriteLine("Sua conta não é empresarial");
                    }
                }
                else
                {
                    Console.WriteLine("Número não corresponde a nenhuma conta");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Digito inválido, escreva novamente");
            }
        }

        static void VerificarConta(List<Conta> contas)
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int numConta = int.Parse(Console.ReadLine());

                var conta = contas.Find(c => c.Num == numConta);

                if (conta != null)
                {
                    Console.WriteLine($"Conta número {conta.Num} - Titular: {conta.Titular} - Agência: {conta.Agencia} - Saldo: R${conta.Saldo.ToString("0.00")}");
                }
                else
                {
                    Console.WriteLine("Número não corresponde a nenhuma conta");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não se pode escrever letras no número da conta");
            }
        }

}