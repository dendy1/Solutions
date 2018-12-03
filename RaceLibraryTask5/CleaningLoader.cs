using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaceLibraryTask5
{
    public class CleaningLoader : ILoader
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int TrackWidth { get; set; }
        public int TrackHeight { get; set; }
        public bool Busy { get; set; }

        bool TrackChecked = false;

        public CleaningLoader(string Name)
        {
            this.Name = Name;
            X = -100;
        }

        public void CheckTrack(Bolide Bolide)
        {
            X = -100;
            Y = Bolide.Y;
            int speed = RaceConfig.rnd.Next(10);
            while (!TrackChecked)
            {
                X += speed;
                Thread.Sleep(5);
                if (Math.Abs(X - Bolide.X) < 105)
                {
                    int time = RaceConfig.rnd.Next(100, 300);
                    Thread.Sleep(time);
                    TrackChecked = true;
                }
            }
            while (Y < TrackHeight + 50)
            {
                Y += speed;
                Thread.Sleep(5);
            }
            X = -100;
            Y = -100;
            Busy = false;
            TrackChecked = false;
        }

        public void SetPosition(int TrackWidth, int TrackHeight)
        {
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;
        }

        public void InteractingWithBolide(Bolide bolide)
        {
            Task.Run(() => CheckTrack(bolide));
            Busy = false;
        }
    }
}
