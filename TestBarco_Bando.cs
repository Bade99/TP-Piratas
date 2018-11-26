using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_PiratasDelCaribe;

namespace TestPiratasDelCaribe
{
    [TestClass]
    public class TestBarco_Bando
    {
        static Guerrero jones = new Guerrero(50, 10, 100);
        static Navegador elizabeth = new Navegador(100, 4);
        static List<string> ingredientesCocinero = new List<string> { "leche", "salsagolf", "agua" };
        static Cocinero will = new Cocinero(60, 40, ingredientesCocinero);
        static JackSparrow jack = new JackSparrow();
        static Guerrero barbossa = new Guerrero(100,10,100);
        static List<Pirata> tripulantes1 = new List<Pirata> { jones, jack };
        static List<Pirata> tripulantes2 = new List<Pirata> { elizabeth, will };
        static List<Pirata> tripulantes3 = new List<Pirata> { barbossa };
        static ArmadaInglesa bando_inglesa = new ArmadaInglesa();
        static UnionPirata bando_pirata = new UnionPirata();
        static HolandesHerrante bando_holandes = new HolandesHerrante();
        Barco ingles = new Barco(300,50,10,tripulantes1,bando_inglesa);
        Barco pirata = new Barco(80,40,20,tripulantes2,bando_pirata);
        Barco holandes = new Barco(120, 30, 50, tripulantes3, bando_holandes);

        [TestMethod]
        public void TestLucha()
        {
            ingles.EnfrentarCon(holandes);
            Assert.AreEqual(4, ingles.Tripulacion().Count,"fallo 1");
            Assert.AreEqual(0, holandes.Tripulacion().Count,"fallo 2");
            Assert.IsTrue(holandes.ValoresEnCero(), "fallo 4");
        }

        [TestMethod]
        public void TestBonus()
        {
            Assert.AreEqual(13, ingles.Municiones());
            Assert.AreEqual(100, pirata.PoderDeFuego());
            Assert.AreEqual(2, holandes.Tripulacion().Count);
        }

        [TestMethod]
        public void TestCanion()
        {
            pirata.DispararA(ingles,5);
            Assert.AreEqual(15, pirata.Municiones());
            Assert.AreEqual(50,ingles.Resistencia());
            Assert.AreEqual(2, ingles.Tripulacion().Count);
        }
    }
}
