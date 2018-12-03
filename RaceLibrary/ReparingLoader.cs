using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace RaceLibrary
{
    public class ReparingLoader : ILoader
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int TrackHeight { get; set; }
        public int TrackWidth { get; set; }
        public Bolide Bolide { get; set; }
        private bool OnWayToHome { get; set; } = false;

        public ReparingLoader(string Name, Bolide Bolide)
        {
            this.Name = Name;
            this.Bolide = Bolide;
            Bolide.Crash += FixBolide;
        }

        public void FixBolide()
        {
            X = Bolide.X;
            if (Y > Bolide.Y && Bolide.Crashed && !OnWayToHome)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y -= speed;
                Thread.Sleep(5);
                if (Math.Abs(Y - Bolide.Y) < 10)
                {
                    int time = RaceConfig.rnd.Next(1000, 8000);
                    Thread.Sleep(time);
                    Bolide.Crashed = false;
                    FixBolide();
                }
                FixBolide();
            }
            else if (Y < TrackHeight + 200 && !Bolide.Crashed)
            {
                OnWayToHome = true;
                int speed = RaceConfig.rnd.Next(5);
                Y += speed;
                if (Math.Abs(Y - (TrackHeight + 200)) < 15)
                {
                    Y = TrackHeight + 200;
                    OnWayToHome = false;
                }
                Thread.Sleep(5);
                FixBolide();
            }
        }

        public void SetPosition(int TrackWidth, int TrackHeight)
        {
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;

            Y = TrackHeight;
            X = 0;
        }
    }
}
