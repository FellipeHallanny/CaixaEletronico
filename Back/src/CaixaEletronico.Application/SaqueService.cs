using CaixaEletronico.Application.Contratos;
using CaixaEletronico.Domain;
using CaixaEletronico.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Application
{
    public class SaqueService : ISaqueService
    {
        
        public string Saque(int valor)
        {
            return sacar(valor);
        }

        public string sacar(int v)
        {
            int[] notas = { 50, 20, 10, 5, 2 };
            int[] aux = new int[5];
            string resultado = "";
            int resto;

            //SE O VALOR FOR = 0 ELE  VALOR É INVÁLIDO;
            if (v <= 0)
            {
                resultado = "Valor inválido";
            }

            for (int i = 0; i < notas.Length; i++)
            {
                if (v >= notas[i])
                {
                    //PEGA O VALOR E DIVIDE PELAS NOTAS QUE TEM NO ARRAY.
                    //EXEMPLO: 150 >>>> 150 / 100(POSIÇÃO[0]) VAI E JOGA 1 PARA O ARRAY AUX;
                    aux[i] = v / notas[i];
                    v = v % notas[i]; // EXEMPLO: 150 % 100 vai pegar e armazena o 50 no 'V';  
                }
            }
            // ESSE LAÇO VAI VERIFICAR A POSIÇÃO QUE ESTÁ DIFERENTE DE 0 PARA PODER "PRINTAR"
            for (int i = 0; i < aux.Length; i++)
            {

                if (aux[i] != 0 && aux[i] >= 1)
                {
                    //EXEMPLO AUX[0] = 1(VAI FICAR notade100: 1") 
                    resultado += "notade" + notas[i].ToString() + ": " + aux[i].ToString();
                }
            }
            if (v <= 0)
                return resultado;
            else
                return "Cédula indisponível";

            return resultado;
        }
    }
}
