using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_PiratasDelCaribe;

namespace TestPiratasDelCaribe
{
    [TestClass]
    public class TestPirata
    {
        Guerrero jones = new Guerrero(50, 10, 100);
        Navegador elizabeth = new Navegador(100, 4);
        static List<string> ingredientesCocinero = new List<string> { "leche","salsagolf","agua" };
        Cocinero will = new Cocinero(60, 40,ingredientesCocinero);
        JackSparrow jack = new JackSparrow();
        [TestMethod]
        public void TestGuerrero()
        {
            Assert.AreEqual(1000,jones.PoderDeMando());
        }
        [TestMethod]
        public void TestNavegador()
        {
            Assert.AreEqual(16, elizabeth.PoderDeMando());
        }
        [TestMethod]
        public void TestCocinero()
        {
            Assert.AreEqual(120, will.PoderDeMando());
        }
        [TestMethod]
        public void TestJack()
        {
            Assert.AreEqual(30000000, jack.PoderDeMando());
        }
        [TestMethod]
        public void TestJackTomaRonConOtro()
        {
            jack.TomaRonCon(will);
            Assert.AreEqual(36000000, jack.PoderDeMando());
            Assert.AreEqual(10, will.EnergiaInicial());
            Assert.AreEqual(2, jack.Ingredientes().Count());
            Assert.AreEqual(2, will.Ingredientes().Count());
        }
    }
}
