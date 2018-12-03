using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace RaceLibrary
{
    public class Bolide
    {
        public delegate void BolideStateHandler();
        public event BolideStateHandler Tires;
        public event BolideStateHandler Crash;

        public int X { get; set; }
        public int Y { get; set; }
        public int StartY { get; set; }
        public int TrackWidth { get; set; }
        public int TrackHeight { get; set; }

        private double CrashProbability { get; set; } = RaceConfig.DefaultCrashProbabiliy;
        public int TiresCondition { get; set; } = RaceConfig.DefaultTiresCondition;
        public string Name { get; set; }
        public bool Crashed { get; set; } = false;
        public bool Retire { get; set; } = false;
        public bool TiresWornOut { get; set; } = false;
        public bool PitStopRequested { get; set; } = false;
        public Bolide (string Name, int TrackWidth, int TrackHeight)
        {
            this.Name = Name;
        }

        public bool NeedBox
        {
            get { return TiresCondition < 30; }
        }

        public void Drive()
        {
            if (!Crashed && !TiresWornOut)
            {
                double crashProbability = RaceConfig.rnd.NextDouble();
                if (crashProbability > CrashProbability /*&& X > 0 && X < TrackWidth*/)
                {
                    crashProbability = RaceConfig.rnd.NextDouble();
                    if (crashProbability > CrashProbability)
                    {
                        Crashed = true;
                        Crash();
                    }
                }
                if (NeedBox)
                {
                    TiresWornOut = true;
                    DriveBox();
                }
                DriveForward();
            }
            Thread.Sleep(5);
            Drive();
        }

        private void DriveForward()
        {
            int speed = RaceConfig.rnd.Next(5);
            X += speed;
            TiresCondition -= speed;
        }

        public void DriveBox()
        {
            if (TiresWornOut && Y > 0)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y -= speed;
                X += speed;
                Thread.Sleep(5);
                DriveBox();
            }
            else if (Y <= 0 && !PitStopRequested)
            {
                PitStopRequested = true;
                Tires();
                DriveBox();
            }
            else if (!TiresWornOut && Math.Abs(StartY - Y) > 15)
            {
                PitStopRequested = false;
                int speed = RaceConfig.rnd.Next(5);
                Y += speed;
                X += speed;
                Thread.Sleep(5);
                DriveBox();
            }
            else if (Math.Abs(StartY - Y) < 15)
            {
                Y = StartY;
                PitStopRequested = false;
                Drive();
            }
        }

        public void SetPosition(int X, int Y, int TrackWidth, int TrackHeight)
        {
            this.X = X;
            this.Y = Y;
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;
            StartY = Y;
        }
    }
}
