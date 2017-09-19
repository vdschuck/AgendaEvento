using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgendaEvento.Test
{
    [TestClass]
    public class PalestrantesTest
    {
        [TestMethod]
        public void TestMethodPalestrantes()
        {
            Palestrante p1 = new Palestrante("Dr.Ruy Ramos", " Certificado de Atributo", 60);

            Console.WriteLine(p1.Id);
            Console.WriteLine(p1.Nome + ": " + p1.Assunto + " " + p1.Tempo + "min");
        }
    }
}
