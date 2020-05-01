using System;

namespace Banco
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public double Cpf { get; private set; }
        public int Idade { get; private set; }

        public static Cliente Cadastrar()
        {
            var cliente = new Cliente();
            Console.WriteLine("\nNome do titular:");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("\nCPF:");
            cliente.Cpf = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nIdade:");
            cliente.Idade = Convert.ToInt32(Console.ReadLine());
            return cliente;
        }
    }
}
