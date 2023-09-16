using System;

namespace At.Heranca.Banco.Classes
{
    internal class Conta
    {
        public int Num { get; set; }
        public string Agencia { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; set; }

        public Conta(int num, string agencia, string titular, double saldo)
        {
            Num = num;
            Agencia = agencia;
            Titular = titular;
            Saldo = saldo;
        }

        public virtual void Sacar (double valor)
        {
            if ((Saldo - valor) <= 0)
            {
                Console.WriteLine("Saldo insulficiente para o saque");
            }
            else
            {
                Saldo = Saldo - valor;
                Console.WriteLine($"O valor de R${valor} foi sacado com sucesso");
            }
        }
        public void Depositar (double valor)
        {
            Saldo += valor;
        }

    }
}
