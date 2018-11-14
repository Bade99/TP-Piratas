using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Piratas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

abstract class Pirata
{
    int energiaInicial;

    abstract public int PoderDeMando();

    public void ReducirEnergia(int cantidad) { energiaInicial -= cantidad; }

    public virtual void TomaRon(JackSparrow pirata) {
        this.ReducirEnergia(50);
    }
}

class Guerrero : Pirata
{
    int poderDePelea;
    int vitalidad;
    public override int PoderDeMando() {
        return poderDePelea * vitalidad;
    }
}

class Navegador : Pirata
{
    int inteligencia;
    public override int PoderDeMando() {
        return inteligencia*inteligencia;
    }
}

class Cocinero : Pirata
{
    int moral;
    List<string> ingredientes = new List<string>(); //@new string[cantidad] lista (o cantidad o lista)

    public override int PoderDeMando() {
        return moral * ingredientes.Count;
    }

    public override void TomaRon(JackSparrow pirata) {
        base.TomaRon(pirata);
        private Random rnd = new Random();
        int posicion = rnd.Next(ingredientes.Count);
        pirata.AgregarIngrediente(ingredientes[posicion]);
        ingredientes.RemoveAt(posicion);
    }

}

class JackSparrow : Pirata
{
    int energiaInicial = 500;
    int poderDePelea = 200;
    int inteligencia = 300;
    List<string> ingredientes = new List<string>() {"ron"};

    public override int PoderDeMando() {
        return energiaInicial * poderDePelea * inteligencia;
    }

    public void AgregarIngrediente(string ingrediente) {
        ingredientes.Add(ingrediente);
    }

    public void TomaRonCon(Pirata pirata) {
        energiaInicial += 100;
        pirata.TomaRon(this);
    }

    }