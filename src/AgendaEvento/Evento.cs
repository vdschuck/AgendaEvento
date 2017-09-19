using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEvento
{
    public class Evento
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int QuantidadeDias { get; private set; }

        public Evento(string nome, int quantidadeDias)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.QuantidadeDias = quantidadeDias;
        }
    }
}
