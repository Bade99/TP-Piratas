using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP_PiratasDelCaribe
{
    public class Barco
    {
        int resistencia;
        int poderDeFuego;
        int municiones;
        List<Pirata> tripulacion = new List<Pirata>();
        IBando bando;

        public Barco(int _resistencia,int _poderdeFuego,int _municiones,List<Pirata> _tripulacion,IBando _bando)
        {
            resistencia = _resistencia;
            poderDeFuego = _poderdeFuego;
            municiones = _municiones;
            tripulacion = _tripulacion;
            bando = _bando;
            bando.Bonus(this);
        }

        public int Resistencia() { return resistencia; }

        public int Municiones() { return municiones; }

        public int PoderDeFuego() { return poderDeFuego; }

        public List<Pirata> Tripulacion() { return tripulacion; }

        public bool ValoresEnCero()
        {
            return municiones==0 && poderDeFuego==0 && resistencia==0;
        }

        public Pirata Capitan()
        {   //metodo no muy óptimo
            return tripulacion.OrderByDescending(tripulante => tripulante.PoderDeMando()).First();
        }
        public int Fuerza()
        {
            return tripulacion.Sum(tripulante=>tripulante.PoderDeMando());
        }
        public void EnfrentarCon(Barco barco)
        {
            if (this.Fuerza() >= barco.Fuerza()) barco.Perder(this);
            else this.Perder(barco);
        }
        public void Perder(Barco barco)
        {
            barco.AgregarTripulantes(this.PiratasFuertes());
            this.Herir();
            this.Desolado();
            tripulacion.Clear();
        }
        public List<Pirata> PiratasFuertes()
        {
            return tripulacion.FindAll(tripulante=>tripulante.PoderDeMando()>100);
        }
        public void Herir()
        {
            foreach(Pirata p in tripulacion)
            {
                p.Herir();
            }
        }
        public void Desolado()
        {
            resistencia=0;
            poderDeFuego = 0;
            municiones = 0;
        }
        public void AgregarTripulantes(List<Pirata> nuevosTripulantes)
        {
            foreach(Pirata p in nuevosTripulantes) tripulacion.Add(p);
        }

        public void DispararA(Barco barco,int cantidad)
        {
            if (cantidad <= municiones)
            {
                municiones -= cantidad;
                barco.RecibirCanionazos(cantidad);
            }
            else throw new Exception("No tiene la cantidad suficiente");
        }
        public void RecibirCanionazos(int cantidad)
        {
            resistencia -= cantidad * 50;
            this.EliminarTripulacionDebil();
        }
        public void EliminarTripulacionDebil()
        {
            tripulacion.RemoveAll(tripulante=>tripulante.esDebil());
        }

        public void AumentarMuniciones(double porcentaje)
        {
            municiones+= Convert.ToInt32(municiones*porcentaje);
        }
        public void AumentarPoderDeFuego(int cantidad)
        {
            poderDeFuego += cantidad;
        }
        public void DuplicarTripulacion()
        {
            tripulacion.AddRange(tripulacion);
        }
    }
}
