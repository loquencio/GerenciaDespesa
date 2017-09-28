using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaDespesa.Model
{
    class Receita
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }

        public override string ToString()
        {
            return this.Nome + " - " + this.Valor + " - " + this.Tipo + " - " + this.Data.ToString("dd/MM/yyyy");
        }
    }
}
