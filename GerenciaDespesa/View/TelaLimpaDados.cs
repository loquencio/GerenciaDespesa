using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaDespesa.DB;

namespace GerenciaDespesa.View
{
    class TelaLimpaDados : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaLimpaDados(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = "Limpa Dados";
        }

        public Tela mostra()
        {
            Console.WriteLine(">>> " + this.Nome + " <<<");
            Console.WriteLine();

            Console.WriteLine("Limpando dados...");

            using(GranaContext ctx = new GranaContext())
            {
                ctx.Database.ExecuteSqlCommand("DELETE FROM Despesas");
                ctx.Database.ExecuteSqlCommand("DELETE FROM Receitas");

                ctx.SaveChanges();
            }

            Console.WriteLine("Dados limpos");
            Console.WriteLine();

            return this.anterior;
        }
    }
}
