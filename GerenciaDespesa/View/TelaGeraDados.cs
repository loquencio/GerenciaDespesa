using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaDespesa.DB;
using GerenciaDespesa.Model;

namespace GerenciaDespesa.View
{
    class TelaGeraDados : Tela
    {
        private Tela anterior;
        public string Nome { get; set; }

        public TelaGeraDados(string Nome, Tela anterior)
        {
            this.Nome = "Gera Dados";
            this.anterior = anterior;       
        }

        public Tela Mostra()
        {
            Console.WriteLine(">>> " + this.Nome + " <<<");
            Console.WriteLine();

            Console.WriteLine("Gerando dados...");

            using(GranaContext ctx = new GranaContext())
            {
                ReceitaRepositorio r = new ReceitaRepositorio(ctx);
                DespesaRepositorio d = new DespesaRepositorio(ctx);

                for (int i = 0; i < 36; i++)
                {
                    Receita rec = new Receita();
                    rec.Nome = "Salário K19";
                    rec.Tipo = "Salário";
                    rec.Valor = 8000.0;

                    DateTime data = new DateTime(2014, 1, 10);
                    data = data.AddMonths(i);
                    rec.Data = data;

                    r.Adiciona(rec);
                }

                for (int i = 0; i < 36; i++)
                {
                    Receita rec = new Receita();
                    rec.Nome = "VA";
                    rec.Tipo = "Vale Alimentação";
                    rec.Valor = 400.00;

                    DateTime data = new DateTime(2014, 1, 10);
                    data = data.AddMonths(i);
                    rec.Data = data;

                    r.Adiciona(rec);
                }

                for (int i = 0; i < 36; i++)
                {
                    Receita rec = new Receita();
                    rec.Nome = "Aluguel Casa BH";
                    rec.Tipo = "Aluguel";
                    rec.Valor = 1000.0;

                    DateTime data = new DateTime(2014, 1, 10);
                    data = data.AddMonths(i);
                    rec.Data = data;

                    r.Adiciona(rec);
                }

                for (int i = 0; i < 36; i++)
                {
                    Despesa desp = new Despesa();
                    desp.Nome = "Aluguel Apto SP";
                    desp.Tipo = "Aluguel";
                    desp.Valor = 1800.0;

                    DateTime data = new DateTime(2014, 1, 10);
                    data = data.AddMonths(i);
                    desp.Data = data;

                    d.Adiciona(desp);
                }

                for (int i = 0; i < 36; i++)
                {
                    Despesa desp = new Despesa();
                    desp.Nome = "Compras Supermercado";
                    desp.Tipo = "Alimentação";
                    desp.Valor = 1000.0;

                    DateTime data = new DateTime(2014, 1, 10);
                    data = data.AddMonths(i);
                    desp.Data = data;

                    d.Adiciona(desp);
                }

                for (int i = 0; i < 36; i++)
                {
                    Despesa desp = new Despesa();
                    desp.Nome = "Combustível";
                    desp.Tipo = "Transporte";
                    desp.Valor = 400.0;

                    DateTime data = new DateTime(2014, 1, 10);
                    data = data.AddMonths(i);
                    desp.Data = data;

                    d.Adiciona(desp);
                }

                for (int i = 0; i < 36; i++)
                {
                    Despesa desp = new Despesa();
                    desp.Nome = "Cinema";
                    desp.Tipo = "Lazer";
                    desp.Valor = 200.0;

                    DateTime data = new DateTime(2014, 1, 10);
                    data = data.AddMonths(i);
                }
            }

            return null;
        }
    }
}
