using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            RoundHole hole = new RoundHole { Radius = 15 };
            SquarePegAdapter adapter = new SquarePegAdapter(new SquarePeg { Width = 10 });
            if (hole.fits(adapter))
            {
                Console.WriteLine("Кол забить можно");
            }
            else
            {
                Console.WriteLine("Кол забить нельзя");
            }
        }
    }
    class RoundHole
    {
        public int Radius { set; get; }
        public bool fits(RoundPeg peg)
        {
            return peg.getRadius() <= Radius;
        }
    }
    class RoundPeg
    {
        public int Radius { set; get; }
        public virtual int getRadius()
        {
            return Radius;
        }
    }
    class SquarePeg
    {
        public int Width { set; get; }
    }
    class SquarePegAdapter : RoundPeg
    {
        SquarePeg peg;
        public SquarePegAdapter(SquarePeg peg)
        {
            this.peg = peg;
        }
        public override int getRadius()
        {
            double halfWidth = peg.Width / 2;
            return (int)Math.Sqrt(Math.Pow(halfWidth, 2) * 2);
        }
    }
}