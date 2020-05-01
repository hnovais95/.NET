using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public abstract class Conta
    {
        public Cliente Titular;
        public int Numero { get; protected set; }
        public double Saldo { get; protected set; }
        public double Limite { get; protected set; }
        protected static int NumProximaConta = 10000;

        public Conta(Cliente cliente)
        {
            Titular = cliente;
            Numero = NumProximaConta;
            NumProximaConta++;
            Console.WriteLine("\nRenda Mensal: ");
            double rendaMensal = Convert.ToDouble(Console.ReadLine());

            if (rendaMensal < 1000)
                Limite = 800;
            else
                Limite = rendaMensal;
            Console.WriteLine($"\nLimte:  {Limite:C2}");
        }

        public virtual bool Sacar(double valor)
        {
            if (valor <= (Saldo + Limite))
            {
                Saldo -= valor;
                if (Saldo < 0)
                {
                    Limite -= valor;
                }
                return true;
            }
            else
            {
                Console.WriteLine("\nSaldo Insuficiente.");
                return false;
            }
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public void Transferir(double valor, Conta outraConta)
        {
            bool saque = this.Sacar(valor);

            if (saque)
                outraConta.Depositar(valor);
            else
                Console.WriteLine("\nNao foi possivel concluir transferencia;");

            Console.WriteLine("\n=====================================\n");
            Console.WriteLine($"Conta de origem: {Numero,19}\nTitular: {Titular.Nome,19}");
            this.ConsultarSaldo();
            Console.WriteLine($"Conta de Destino: {outraConta.Numero,19}\nTitular: {outraConta.Titular.Nome,19}");
            outraConta.ConsultarSaldo();
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"\nSaldo = {this.Saldo, 19 :C2}");
            Console.WriteLine($"Limite = {this.Limite, 18 :C2}");
        }

        public void MostrarDados()
        {
            Console.WriteLine($"\nNome do titular: {this.Titular.Nome, 59}");
            //Formatação CPF
            string strcpf = Convert.ToString(this.Titular.Cpf);
            StringBuilder sbCpf = new StringBuilder(strcpf);
            sbCpf.Insert(3, ".");
            sbCpf.Insert(7, ".");
            sbCpf.Insert(11, "-");

            Console.WriteLine($"CPF: {sbCpf, 71}");
            Console.WriteLine($"Idade: {this.Titular.Idade, 69}");
            Console.WriteLine($"Numero da conta: {this.Numero, 59}");
            Console.WriteLine($"Saldo: {this.Saldo, 69:C2}");
            Console.WriteLine($"Limite: {this.Limite, 68:C2}");
        }
    }
}
