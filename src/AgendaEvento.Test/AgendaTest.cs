using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace AgendaEvento.Test
{
    [TestClass]
    public class AgendaTest
    {
        [TestMethod]
        public void TestMethodAgenda()
        {
            Palestrante p1 = new Palestrante("Dr.Ruy Ramos", " Certificado de Atributo", 60);
            Palestrante p2 = new Palestrante("Dr.Fabiano Menke", "Diretivas da Assinatura Digital", 45);
            Palestrante p3 = new Palestrante("Luiz Carlos Zancanella Junior", "Carimbo de Tempo", 30);
            Palestrante p4 = new Palestrante("Ireneu Orth", "Case Tapera", 45);
            Palestrante p5 = new Palestrante("Dr.Renato Martini", "Visão da Presidência da República", 45);
            Palestrante p6 = new Palestrante("Antônio Gomes", "Visão do Estado do Rio Grande do Sul", 5);
            Palestrante p7 = new Palestrante("Famurs", "Visão dos Municipios", 60);
            Palestrante p8 = new Palestrante("Carlos Eduardo Wagner", "Certificado Digital no Banrisul", 45);
            Palestrante p9 = new Palestrante("Cynthia Anzanello", "Certificação na administração pública estadual do RS", 30);
            Palestrante p10 = new Palestrante("Paulo Roberto Kopschina", "Serviços da Jucergs que fazem uso do certificado digital", 30);
            Palestrante p11 = new Palestrante("Dr.Júlio César Fonseca", "A experiência do escritório Mattos Filho com certificado", 45);
            Palestrante p12 = new Palestrante("André Luiz Assis", "O uso do certificado ICP-Brasil no IGP-RS", 60);
            Palestrante p13 = new Palestrante("Pedro Paulo Lemos", "Mesa Aberta", 60);
            Palestrante p14 = new Palestrante("Nivaldo Cleto", "Apresentação AARB", 45);
            Palestrante p15 = new Palestrante("Regina Tupinambá", "A comunicação no mundo da certificação digital", 30);
            Palestrante p16 = new Palestrante("Junior Fuganholi", "Palestra Parcerias com as ARs –Startup Xml NFe Estadual", 30);
            Palestrante p17 = new Palestrante("Patrícia T Oliveira Leite", "Palestra de Compliance", 60);
            Palestrante p18 = new Palestrante("Maurício Coelho", "ICP - Brasil: Perspectivas e Números", 30);
            Palestrante p19 = new Palestrante("Adriano Carlos Gliorsi", "Certificação Digital na saúde", 30);

            TimeSpan horarioInicio = new TimeSpan(09, 00, 00);
            TimeSpan horarioFim = new TimeSpan(17, 00, 00);
            TimeSpan intervaloInicio = new TimeSpan(12, 00, 00);

            IList<Palestrante> lista = new List<Palestrante>();
            lista.Add(p1); lista.Add(p2); lista.Add(p3); lista.Add(p4); lista.Add(p5); lista.Add(p6); lista.Add(p7); lista.Add(p8);
            lista.Add(p9); lista.Add(p10); lista.Add(p11); lista.Add(p12); lista.Add(p13); lista.Add(p14); lista.Add(p15); lista.Add(p16);
            lista.Add(p17); lista.Add(p18); lista.Add(p19);

            Agenda agenda = new Agenda(2, horarioInicio, horarioFim, intervaloInicio, lista, TimeSpan.FromMinutes(20));
            StringBuilder ProgramacaoEvento = new StringBuilder();
            ProgramacaoEvento = agenda.MontaProgramacao(agenda, lista.Count, 1, ProgramacaoEvento);

            Console.WriteLine(ProgramacaoEvento.ToString());
        }
    }
}
