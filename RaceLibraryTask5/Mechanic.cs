using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace RaceLibraryTask5
{
    public class Mechanic
    {
        Bolide Bolide { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int TrackHeight { get; set; }
        public int TrackWidth { get; set; }

        public Mechanic(string Name, Bolide Bolide)
        {
            this.Name = Name;
            this.Bolide = Bolide;
            Bolide.Tires += Fix;
        }

        private void Fix(Bolide b)
        {
            Task.Run(() => FixBolide(b));
        }

        public void FixBolide(Bolide Bolide)
        {
            
            X = Bolide.X;
            while (Y < Bolide.Y && Bolide.TiresWornOut)
            {
                int speed = 5;
                Y += speed;
                Thread.Sleep(5);
                if (Math.Abs(Y - Bolide.Y) < 10)
                {
                    int time = RaceConfig.rnd.Next(1000, 5000);
                    Thread.Sleep(time);
                    Bolide.TiresCondition = RaceConfig.DefaultTiresCondition;
                    Bolide.TiresWornOut = false;
                }
            }
            while (Y > -110)
            {
                int speed = 5;
                Y -= speed;
                Thread.Sleep(5);
            }
        }

        public void SetPosition(int TrackWidth, int TrackHeight)
        {
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;

            Y = -100;
            X = 0;
        }
    }
}
