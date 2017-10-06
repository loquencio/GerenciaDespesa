using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaDespesa.DB;
using GerenciaDespesa.Model;

namespace GerenciaDespesa.View
{
    class TelaDespesaconsultaRecentes
    {
        private Tela anterior { get; set; }

        public string Nome { get; set; }

        public TelaDespesaconsultaRecentes(Tela anterior)
        {
            this.Nome = "Últimas Despesas Adicionadas";
            this.anterior = anterior;
        }

        public Tela Mostra()
        {
            Console.WriteLine(">>> " + this.Nome + " <<<");
            Console.WriteLine();
            
            using(GranaContext ctx = new GranaContext())
            {
                DespesaRepositorio dr = new DespesaRepositorio(ctx);
                List<Despesa> despesas = dr.BuscaRecente();

                int opt = -1;

                while (opt < 0 || opt > despesas.Count)
                {
                    for (int i = 0; i < despesas.Count; i++)
                        Console.WriteLine("{0} | {1} - {2} - {3}", (i + 1), despesas[i].Data, despesas[i].Nome, despesas[i].Valor);

                    Console.WriteLine();
                    Console.WriteLine("Digite o número da despesa que deseja remover.");
                    Console.WriteLine("Digite 0 para sair:");

                    try
                    {
                        opt = Convert.ToInt32(Console.ReadLine());
                    } 
                    catch (FormatException e)
                    {
                        Console.WriteLine("Opção inválida!");
                    }

                    if (opt < 0 || opt > 1000)
                    {
                        Console.WriteLine("Opção incorreta!");
                    }

                    if (opt != 0)
                    {
                        dr.Remove(despesas[opt - 1]);

                        despesas.RemoveAt(opt - 1);

                        opt = -1;

                        ctx.SaveChanges();

                        Console.WriteLine();
                        Console.WriteLine("Despesa Removida");
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();

                return this.anterior;
            }

            return anterior;
        }
    }
}
