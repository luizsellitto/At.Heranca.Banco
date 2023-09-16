using System;

namespace At.Heranca.Banco.Classes
{
    internal class ContaEmpresarial : Conta
    {
        public double Anuidade { get; set; }
        public double LE { get; set; }
        public double TE { get; set; }
        public ContaEmpresarial(double anuidade, double lE, double tE, int num, string agencia, string titular, double saldo) : base(num, agencia, titular, saldo)
        { 
            Anuidade = anuidade;
            LE = lE;
            TE = tE;
        }
        public void FazerEmprestimo(double valor)
        {
            if (LE-TE <= valor)
            {
                if (LE <= valor)
                {
                    Saldo = +valor;
                    TE += valor;
                    Console.WriteLine($"O empréstimo do valor de R${valor} foi realizado com sucesso");
                }
                else
                {
                    Console.WriteLine($"O valor de R${valor} supera o limite de empréstimo, empréstimo não realizado");
                }
            }
            else
            {
                Console.WriteLine($"O valor de R${valor} supera o limite de empréstimo, empréstimo não realizado");
            }
        }
        public virtual void Sacar(double valor)
        {
            if (valor > 5000)
            {
                if (valor <= Saldo)
                {
                    Saldo = Saldo - (valor+5);
                    Console.WriteLine($"O valor de R${valor+5} foi sacado com sucesso");
                }
                else
                {
                    Console.WriteLine("Saldo insulficiente para o saque");
                }
            }
            else
            {
                if (valor <= Saldo)
                {
                    Saldo = Saldo - (valor);
                    Console.WriteLine($"O valor de R${valor} foi sacado com sucesso");
                }
                else
                {
                    Console.WriteLine("Saldo insulficiente para o saque");
                }
            }
        }
    }
}
