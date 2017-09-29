using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaDespesa.View
{
    class TelaSair : Tela
    {
        public string Nome { get; set; }

        public TelaSair()
        {
            this.Nome = "Sair";
        }

        public Tela mostra()
        {
            return null;
        }
    }
}
