using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class ContaPoupanca : Conta
    {
        private int numSaques = 0;

        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
        }

        public override bool Sacar(double valor)
        {
            numSaques++;
            if (numSaques < 3)
                return base.Sacar(valor);
            else
                return base.Sacar(valor + 2.00);
        }
    }
}
