using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace RaceLibrary
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
            Bolide.Tires += FixBolide;
        }

        public void FixBolide()
        {
            X = Bolide.X;
            if (Y < Bolide.Y && Bolide.TiresWornOut)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y += speed;
                Thread.Sleep(5);
                if (Math.Abs(Y - Bolide.Y) < 10)
                {
                    int time = RaceConfig.rnd.Next(1000, 5000);
                    Thread.Sleep(time);
                    Bolide.TiresCondition = RaceConfig.DefaultTiresCondition;
                    Bolide.TiresWornOut = false;
                }
                FixBolide();
            }
            else if (Y > -110 && !Bolide.TiresWornOut)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y -= speed;
                Thread.Sleep(5);
                FixBolide();
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
