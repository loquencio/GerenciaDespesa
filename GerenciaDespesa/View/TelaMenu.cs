using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaDespesa.View
{
    class TelaMenu : Tela
    {
        public string Nome { get; set; }
        private List<Tela> filhas = new List<Tela>();

        public TelaMenu(string Nome)
        {
            this.Nome = Nome;
        }

        public Tela Mostra()
        {
            Console.WriteLine(">>> " + this.Nome + " <<<");
            Console.WriteLine();

            for (int i = 0; i < this.filhas.Count; i++)
                Console.WriteLine((i + 1) + ". " + this.filhas[i].Nome);

            Console.WriteLine();
            Console.Write("Escolha a opção: ");
            int indiceOp = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine();

            return this.filhas[indiceOp];
        }

        public void AdicionaFilha(Tela tela)
        {
            this.filhas.Add(tela);
        }
    }
}
