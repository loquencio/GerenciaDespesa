using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GerenciaDespesa.View
{
    class TelaDespesaAdicionar : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaDespesaAdicionar(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = "Adicionar Despesa";
        }

        public Tela mostra()
        {
            Console.WriteLine(">>> " + this.Nome + " <<<");
            Console.WriteLine();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            double valor = -1;

            while (valor < 0)
            {
                Console.WriteLine("Digite o valor: ");

                try
                {
                    valor = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Valor incorreto");
                    continue;
                }

                if (valor < 0)
                {
                    Console.WriteLine("Valor incorreto");
                }
            }

            DateTime? data = null;

            while (data == null)
            {
                Console.WriteLine("Digite a data (ex: 05/08/2016): ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    data = Convert.ToDateTime(Console.ReadLine(), cf);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Data incorreta!");
                    data = null;
                    continue;
                }
            }

            Console.WriteLine();
            Dictionary<int, string> tipos = new Dictionary<int, string>();
            tipos.Add(1, "Aluguel");
            tipos.Add(2, "Alimentação");
            tipos.Add(3, "Transporte");
            tipos.Add(4, "Lazer");
            tipos.Add(5, "Outros");

            foreach (KeyValuePair<int, string> kvp in tipos)
            {
                Console.WriteLine(kvp.Key + ". " + kvp.Value);
            }

            int tipo = -1;

            while (tipo < 1 || tipo > 5)
            {
                Console.Write("Escolha o tipo (número de 1 a 5)");

                try
                {
                    tipo = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Tipo incorreto!");
                    continue
                }
            }
        }
    }
}
