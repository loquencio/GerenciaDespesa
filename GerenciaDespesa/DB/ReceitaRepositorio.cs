using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaDespesa.Model;

namespace GerenciaDespesa.DB
{
    class ReceitaRepositorio
    {
        private GranaContext ctx;

        public ReceitaRepositorio(GranaContext ctx)
        {
            this.ctx = ctx;
        }

        public void Adiciona(Receita r)
        {
            this.ctx.Receitas.Add(r);
        }

        public void Remove(Receita r)
        {
            this.ctx.Receitas.Remove(r);
        }

        public double? SomaReceitasAte(DateTime ate)
        {
            return this.ctx.Receitas.Where(x => x.Data <= ate).Sum(x => x.Valor);
        }

        public double? SomaReceitas(DateTime de, DateTime ate)
        {
            return this.ctx.Receitas.Where(x => x.Data >= de && x.Data <= ate).Sum(x => x.Valor);
        }

        public List<Receita> BuscaPorPeriodo(DateTime de, DateTime ate)
        {
            return this.ctx.Receitas.Where(x => x.Data >= de && x.Data <= ate).toList();
        }

        public List<Receita> BuscaRecentes()
        {
            return this.ctx.Receitas.OrderBy(x => x.Data).Take(10).ToList();
        }
    }
}
