using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;

namespace RaceLibraryTask5
{
    public class ReparingLoader : ILoader
    {
        public string Name { get; set; }
        public bool Busy { get; set; } = false;
        public int X { get; set; }
        public int Y { get; set; }
        public int TrackHeight { get; set; }
        public int TrackWidth { get; set; }
        private bool OnWayToHome { get; set; } = false;
        
        public ReparingLoader(string Name)
        {
            this.Name = Name;
        }

        private void FixBolide(Bolide Bolide)
        {
            //Console.WriteLine(Name + ';' + Busy + ';' + Bolide.Name);

            if (!OnWayToHome)
                X = Bolide.X;

            while (Y > Bolide.Y && Bolide.Crashed && !OnWayToHome)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y -= speed;
                Thread.Sleep(5);
                if (Math.Abs(Y - Bolide.Y) < 40)
                {
                    int time = RaceConfig.rnd.Next(7000, 12000);
                    Bolide.WaitingTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    Thread.Sleep(time);
                    Bolide.Crashed = false;
                    Bolide.Arguing = false;                  
                }
            }
        
            while (Y < TrackHeight + 110)
            {
                int speed = 5;
                Y += speed;
                Thread.Sleep(5);
            }
            Y = TrackHeight + 110;
            Busy = false;
        }

        public void SetPosition(int TrackWidth, int TrackHeight)
        {
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;

            Y = TrackHeight;
            X = 0;
        }

        public void InteractingWithBolide(Bolide bolide)
        {
            Task.Run(() => FixBolide(bolide));
        }
    }
}
