using System;
using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        public int NumeroConta { get; }
        public string Titular { get; set; }
        private double _saldo;

        public ContaBancaria(int numeroConta, string titular, double depositoInicial = 0.0)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            _saldo = depositoInicial;
        }

        public double Saldo
        {
            get { return _saldo; }
        }

        public void Deposito(double valor)
        {
            if (valor > 0)
            {
                _saldo += valor;
            }
            else
            {
                Console.WriteLine("O valor do depósito deve ser positivo.");
            }
        }

        public void Saque(double valor)
        {
            if (valor > 0)
            {
                _saldo -= (valor + 3.50);
            }
            else
            {
                Console.WriteLine("O valor do saque deve ser positivo.");
            }
        }

        public override string ToString()
        {
            return $"Conta {NumeroConta}, Titular: {Titular}, Saldo: $ {_saldo:F2}";
        }
    }
}
