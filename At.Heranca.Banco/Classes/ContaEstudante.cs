using System;

namespace At.Heranca.Banco.Classes
{
    internal class ContaEstudante : Conta
    {
        public double LCE { get; set; }
        public string Cpf { get; set; }
        public string NI { get; set; }
        public ContaEstudante(double lCE, string cpf, string nI, int num, string agencia, string titular, double saldo) : base(num, agencia, titular, saldo)
        {
            LCE = lCE;
            Cpf = cpf;
            NI = nI;
        }
        public override void Sacar(double valor)
        {
            if (valor <= (Saldo + LCE))
            {
                Saldo = Saldo - valor;
                Console.WriteLine($"O valor de R${valor} foi sacado com sucesso");
            }
            else
            {
                Console.WriteLine("Saldo insulficiente para o saque");
            }

        }
    }
}
