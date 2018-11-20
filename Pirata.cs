using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_PiratasDelCaribe
{
    public abstract class Pirata
    {
        int energiaInicial;

        public Pirata(int _energiaInicial)
        {
            energiaInicial = _energiaInicial;
        }

        public int EnergiaInicial()
        {
            return energiaInicial;
        }

        abstract public int PoderDeMando();

        abstract public void Herir();

        public void ReducirEnergia(int cantidad) { energiaInicial -= cantidad; }

        public void AumentarEnergia(int cantidad) { energiaInicial += cantidad; }

        public virtual void TomaRon(JackSparrow pirata)
        {
            this.ReducirEnergia(50);
        }

        public bool esDebil()
        {
            return energiaInicial <= 20;
        }
    }

    public class Guerrero : Pirata
    {
        int poderDePelea;
        int vitalidad;

        public Guerrero(int _energiaInicial,int _poderDePelea,int _vitalidad) : base(_energiaInicial)
        {
            poderDePelea = _poderDePelea;
            vitalidad = _vitalidad;
        }

        public int PoderDePelea() { return poderDePelea; }

        public override int PoderDeMando()
        {
            return poderDePelea * vitalidad;
        }
        public override void Herir()
        {
            poderDePelea /= 2;
        }
    }

    public class Navegador : Pirata
    {
        int inteligencia;

        public Navegador(int _energiaInicial, int _inteligencia) : base(_energiaInicial)
        {
            inteligencia = _inteligencia;
        }

        public override int PoderDeMando()
        {
            return inteligencia * inteligencia;
        }

        public override void Herir()
        {
            inteligencia /= 2;
        }
    }

    public class Cocinero : Pirata
    {
        int moral;
        List<string> ingredientes = new List<string>();

        public Cocinero(int _energiaInicial, int _moral,List<string> _ingredientes) : base(_energiaInicial)
        {
            moral = _moral;
            ingredientes.AddRange(_ingredientes);
        }

        public List<string> Ingredientes()
        {
            return ingredientes;
        }

        public override int PoderDeMando()
        {
            return moral * ingredientes.Count;
        }

        public override void TomaRon(JackSparrow pirata)
        {
            base.TomaRon(pirata);
            Random rnd = new Random();
            int posicion = rnd.Next(ingredientes.Count);
            pirata.AgregarIngrediente(ingredientes[posicion]);
            ingredientes.RemoveAt(posicion);
        }

        public override void Herir()
        {
            moral /= 2;
        }

    }

    public class JackSparrow : Pirata
    {
        int poderDePelea = 200;
        int inteligencia = 300;
        List<string> ingredientes = new List<string>() { "ron" };

        public JackSparrow() : base(500) { }

        public List<string> Ingredientes()
        {
            return ingredientes;
        }

        public override int PoderDeMando()
        {
            return this.EnergiaInicial() * poderDePelea * inteligencia;
        }

        public void AgregarIngrediente(string ingrediente)
        {
            ingredientes.Add(ingrediente);
        }

        public void TomaRonCon(Pirata pirata)
        {
            this.AumentarEnergia(100);
            pirata.TomaRon(this);
        }

        public override void Herir()
        {
            poderDePelea /= 2;
            inteligencia /= 2;
        }

    }

    public class Humanoide : Pirata
    {
        int poderDePelea;

        public Humanoide(int _energiaInicial, int _poderDePelea) : base(_energiaInicial)
        {
            poderDePelea = _poderDePelea;
        }

        public override void Herir()
        {
            poderDePelea /= 2;
        }

        public override int PoderDeMando()
        {
            return poderDePelea;
        }
    }
}
