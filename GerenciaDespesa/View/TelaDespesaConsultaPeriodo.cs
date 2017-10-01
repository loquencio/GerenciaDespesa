using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using GerenciaDespesa.DB;
using GerenciaDespesa.Model;

namespace GerenciaDespesa.View
{
    class TelaDespesaConsultaPeriodo : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }
        
        public TelaDespesaConsultaPeriodo(Tela anterior)
        {
            this.anterior = anterior;
            this.Nome = "Despesas por Período";
        }

        public Tela mostra()
        {
            Console.WriteLine(">>> " + this.Nome + " <<<");
            Console.WriteLine();

            DateTime? dataInicial = null;

            while (dataInicial == null)
            {
                Console.WriteLine("Digite sua data inicial (ex: 05/08/2016): ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    dataInicial = Convert.ToDateTime(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    dataInicial = null;
                    Console.WriteLine("Data incorreta");
                }                
            }

            DateTime? dataFinal = null;

            while (dataFinal == null)
            {
                Console.WriteLine("Insira a sua data final (Ex: 05/03/2016): ");

                try
                {
                    CultureInfo cf = new CultureInfo("pt-BR");
                    dataFinal = Convert.ToDateTime(Console.ReadLine());

                    if (dataFinal < dataInicial)
                    {
                        dataFinal = null;
                        Console.WriteLine("Data incorreta!");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Data incorreta!");
                }
            }

            using (GranaContext ctx = new GranaContext())
            {
                DespesaRepositorio d = new DespesaRepositorio(ctx);

                List<Despesa> despesas = d.BuscaPorPeriodo(dataInicial.GetValueOrDefault(), dataFinal.GetValueOrDefault());


                int opt = -1;

                while (opt < 0 || opt > despesas.Count)
                {
                    for (int i = 0; i < despesas.Count; i++)
                     {
                        Console.WriteLine((i + 1) + ". " + despesas[i]);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Digite o número da despesa que deseja remover.");
                    Console.WriteLine("Digite 0 para voltar.");

                    try
                    {
                        opt = Convert.ToInt32(Console.ReadLine());
                    } 
                    catch (FormatException e)
                    {
                        Console.WriteLine("Opção inválida!");
                        continue;
                    }

                    if (opt < 0 || opt > despesas.Count)
                    {
                        Console.WriteLine("Opção inválida!");
                        continue;
                    }

                    if (opt != 0)
                    {
                        DespesaRepositorio dr = new DespesaRepositorio(ctx);

                        despesas.RemoveAt(opt - 1);

                        opt = -1;

                        ctx.SaveChanges();

                        Console.WriteLine();
                        Console.WriteLine("Despesa removida!");
                        Console.WriteLine();
                    }
                }

            
            }

            Console.WriteLine();
            return this.anterior;
           
        }
    }
}
