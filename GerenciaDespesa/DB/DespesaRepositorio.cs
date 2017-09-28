using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciaDespesa.Model;

namespace GerenciaDespesa.DB
{
    class DespesaRepositorio
    {

        private GranaContext ctx;

        public DespesaRepositorio(GranaContext ctx)
        {
            this.ctx = ctx;
        }

        public void Adiciona(Despesa despesa)
        {
            this.ctx.Despesas.Add(despesa);
        }

        public void Remove(Despesa despesa)
        {
            this.ctx.Despesas.Remove(despesa);
        }

        public double? SomaDespesasAte(DateTime data)
        {
            return this.ctx.Despesas.Where(x => x.Data <= data).Sum(x => x.Valor);
        }

        public double? SomaDespesas(DateTime de, DateTime ate)
        {
            return this.ctx.Despesas.Where(x => x.Data >= de && x.Data <= ate).Sum(x => x.Valor);
        }

        public List<Despesa> BuscaPorPeriodo(DateTime de, DateTime ate)
        {
            return this.ctx.Despesas.Where(x => x.Data >= de && x.Data <= ate).ToList();
        }

        public List<Despesa> BuscaRecente()
        {
            return this.ctx.Despesas.OrderBy(x => x.Data).Take(10).ToList();
        }
    }
}
