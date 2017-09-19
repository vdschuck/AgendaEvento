using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgendaEvento.Test
{
    [TestClass]
    public class EventoTest
    {
        [TestMethod]
        public void TestMethodEvento()
        {
            Evento e1 = new Evento("1ª Jornada de Atualização em Certificação Digital", 2);

            Console.WriteLine(e1.Id);
            Console.WriteLine(e1.Nome + ", duração de " + e1.QuantidadeDias + " dias.");
        }
    }
}
