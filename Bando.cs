using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_PiratasDelCaribe
{
    public interface IBando
    {
        void Bonus(Barco barco);
    }

    public class ArmadaInglesa : IBando
    {
        public void Bonus(Barco barco)
        {
            barco.AumentarMuniciones(0.3);
        } 
    }

    public class UnionPirata: IBando
    {
        public void Bonus(Barco barco)
        {
            barco.AumentarPoderDeFuego(60);
        }
    }

    public class HolandesHerrante : IBando
    {
        public void Bonus(Barco barco)
        {
            barco.DuplicarTripulacion();
        }
    }
}
