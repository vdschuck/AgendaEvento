using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaEvento
{
    public class Agenda
    {
        public Guid Id { get; private set; }
        public int QuantidadeDias { get; private set; }
        public TimeSpan HorarioInicio { get; private set; }
        public TimeSpan HorarioFim { get; private set; }
        public TimeSpan IntervaloInicio { get; private set; }
        //Criado essa variavel para ter um tempo minimo que as palestras podem ter.
        public TimeSpan TempoMinPalestra { get; private set; }
        public IList<Palestrante> Palestrantes;
               

        public Agenda(int quantidadeDias, TimeSpan horarioInicio, TimeSpan horarioFim, TimeSpan intervaloInicio, IList<Palestrante> palestrantes, TimeSpan TempoMinPalestra)
        {
            this.Id = Guid.NewGuid();
            this.QuantidadeDias = quantidadeDias;
            this.HorarioInicio = horarioInicio;
            this.HorarioFim = horarioFim;
            this.IntervaloInicio = intervaloInicio;
            this.TempoMinPalestra = TempoMinPalestra;
            this.Palestrantes = palestrantes;
        }

        public StringBuilder MontaProgramacao(Agenda agenda, int PalestrantesLength, int dia, StringBuilder ProgramacaoEvento)
        { 
            int i = 0, naoAgendado = PalestrantesLength - 1;
            TimeSpan InicioPalestra = agenda.HorarioInicio;
            TimeSpan FimPalestra = InicioPalestra + TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo);

            ProgramacaoEvento.AppendLine(Sequencia(dia) + " Dia:");
            dia++;

            while (i < PalestrantesLength)
            {

                //Se horario do fim da palestra for perto ou igual a horario do intervalo.
                if (FimPalestra == agenda.IntervaloInicio || (FimPalestra >= (agenda.IntervaloInicio - agenda.TempoMinPalestra) && FimPalestra <= agenda.IntervaloInicio))
                {
                    ProgramacaoEvento.AppendLine(InicioPalestra + " " + agenda.Palestrantes[i].Nome + " " + agenda.Palestrantes[i].Tempo + "min");
                    agenda.Palestrantes[i].Agendado = true;
                    agenda.Palestrantes[i].Dia = dia;

                    InicioPalestra = agenda.IntervaloInicio + TimeSpan.FromMinutes(60);
                    i++;
                    FimPalestra = i < PalestrantesLength ? InicioPalestra + TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo) : TimeSpan.FromMinutes(0);
                    ProgramacaoEvento.AppendLine(agenda.IntervaloInicio + " Almoço");

                    naoAgendado--;
                }
                //Verifica o tempo da palestra com o tempo minimo.
                else if (FimPalestra > (agenda.HorarioFim - agenda.TempoMinPalestra) && FimPalestra <= agenda.HorarioFim && FimPalestra.Hours != agenda.IntervaloInicio.Hours)
                {
                    ProgramacaoEvento.AppendLine(InicioPalestra + " " + agenda.Palestrantes[i].Nome + " " + agenda.Palestrantes[i].Tempo + "min");
                    agenda.Palestrantes[i].Agendado = true;
                    agenda.Palestrantes[i].Dia = dia;

                    ProgramacaoEvento.AppendLine(FimPalestra + " Dúvidas e Debates");
                    InicioPalestra = agenda.HorarioInicio;
                    i++;
                    FimPalestra = i < PalestrantesLength ? InicioPalestra + TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo) : InicioPalestra;
                    naoAgendado--;
                }
                //Verifica se não passou do horario final e não é horaio de intervalo (Almoço).
                else if (FimPalestra <= agenda.HorarioFim && FimPalestra.Hours != agenda.IntervaloInicio.Hours)
                {
                    ProgramacaoEvento.AppendLine(InicioPalestra + " " + agenda.Palestrantes[i].Nome + " " + agenda.Palestrantes[i].Tempo + "min");
                    agenda.Palestrantes[i].Agendado = true;
                    agenda.Palestrantes[i].Dia = dia;

                    InicioPalestra += TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo);
                    i++;
                    FimPalestra += i < PalestrantesLength ? TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo) : TimeSpan.FromMinutes(0);

                    naoAgendado--;
                }
                //Se os palestrantes restantes passarem do horário de fim (17:00).
                else if (i == PalestrantesLength - 1)
                {
                    FimPalestra -= TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo);
                    ProgramacaoEvento.AppendLine(FimPalestra + " Dúvidas e Debates");
                    ProgramacaoEvento.AppendLine("");
                    i++;
                }
                else
                {
                    InicioPalestra -= TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo);
                    FimPalestra -= TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo);
                    i++;
                    FimPalestra += i < PalestrantesLength ? TimeSpan.FromMinutes(agenda.Palestrantes[i].Tempo) : TimeSpan.FromMinutes(0);
                }

            }

            //Se tiver algum palestrante não agendado.
            if (naoAgendado > 0)
            {
                agenda.Palestrantes = agenda.Palestrantes.Where(x => x.Agendado == false).ToList();
                MontaProgramacao(agenda, naoAgendado + 1, dia, ProgramacaoEvento);
            }

            return ProgramacaoEvento;
        }

        private static string Sequencia(int i)
        {
            string[] numeros = new string[6];

            numeros[1] = "Primeiro";
            numeros[2] = "Segundo";
            numeros[3] = "Terceiro";
            numeros[4] = "Quarto";
            numeros[5] = "Quinto";

            return numeros[i];
        }
    }
}

