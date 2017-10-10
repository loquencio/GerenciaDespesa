using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GerenciaDespesa.View
{
    class TelaReceitaAdicionar : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaReceitaAdicionar(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = "Adicionar Receita";
        }

        public Tela Mostra()
        {
            Console.WriteLine(">>> " + this.Nome + " <<<");
            Console.WriteLine();

            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            double valor = -1;

            while (valor < 0)
            {
                Console.WriteLine("Digite o valor: ");

                try
                {
                    valor = Convert.ToDouble(Console.ReadLine());
                } catch (FormatException e)
                {
                    Console.WriteLine("Valor inválido!");
                    continue;
                }

                if (valor < 0)
                {
                    Console.WriteLine("Valor inválido!");
                }
            }

            DateTime? data = null;

            while (data == null)
            {
                Console.WriteLine("Insira a data: ");

                try
                {
                    CultureInfo cf = new CultureInfo("PT-BR");
                    Convert.ToDateTime(data);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Data inválida!");
                }
            }

            Console.WriteLine();
            Dictionary<int, string> tipos = new Dictionary<int, string>();
            tipos.Add(1, "Salário");
            tipos.Add(2, "Vale Alimentação");
            tipos.Add(3, "Vale Refeição");
            tipos.Add(4, "Aluguel");
            tipos.Add(5, "Outros");

            foreach (KeyValuePair<int, string> value in tipos)
            {
                Console.WriteLine(value.Key + ". " + value.Value);
            }

            int tipo = -1;

            while (tipo < 1 || tipo > 5)
            {
                Console.WriteLine("Escolha o tipo (número de 1 ao 5): ");
            }
        }
    }
}
