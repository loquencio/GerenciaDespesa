using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GerenciaDespesa.Model;

namespace GerenciaDespesa.DB
{
    class GranaContext : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }

        public GranaContext()
        {
            DropCreateDatabaseIfModelChanges<GranaContext> init = new DropCreateDatabaseIfModelChanges<GranaContext>();
            Database.SetInitializer<GranaContext>(init);
        }
    }
}
