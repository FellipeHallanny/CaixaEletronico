using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Contratos
{
    public interface ISaqueService
    {
        string Saque(int valor);
    }
}
