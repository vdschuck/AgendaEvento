using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEvento
{
    public class Palestrante
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Assunto { get; private set; }
        public int Tempo { get; private set; }
        public TimeSpan Horario { get; set; }
        public int Dia { get; set; }
        public bool Agendado { get; set; }

        public Palestrante(string nome, string assunto, int tempo)
        {
            this.Id = Guid.NewGuid();
            this.Horario = new TimeSpan(00, 00, 00);
            this.Dia = 0;
            this.Nome = nome;
            this.Assunto = assunto;
            this.Tempo = tempo;
            this.Agendado = false;
        }
    }
}
