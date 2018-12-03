using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RaceLibrary
{
    public class SafetyCar : ILoader
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Bolide Bolide { get; set; }
        public int TrackWidth { get; set; }
        public int TrackHeight { get; set; }
        bool TrackChecked = false;

        public SafetyCar(string Name, Bolide Bolide)
        {
            this.Bolide = Bolide;
            this.Name = Name;
            Bolide.Crash += CheckTrack;
        }

        public void CheckTrack()
        {
            if (!TrackChecked)
            {
                int speed = RaceConfig.rnd.Next(5);
                X += speed;
                Thread.Sleep(5);
                if (Math.Abs(X - Bolide.X) < 50)
                {
                    int time = RaceConfig.rnd.Next(1000, 3000);
                    Thread.Sleep(time);
                    TrackChecked = true;
                    CheckTrack();
                }
                CheckTrack();
            }
            else if (TrackChecked && Y < TrackHeight)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y += speed;
                if (Math.Abs(Y - (TrackHeight + 200)) < 15)
                {
                    X = - 100;
                    Y = Bolide.Y;
                    TrackChecked = true;
                }
                Thread.Sleep(5);
                CheckTrack();
            }
        }

        public void SetPosition(int TrackWidth, int TrackHeight)
        {
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;

            Y = Bolide.Y;
            X = -100;
        }
    }
}
