using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace RaceLibraryTask5
{
    public class Bolide
    {
        public delegate void BolideStateHandler(Bolide b);
        public event BolideStateHandler Tires;
        public event BolideStateHandler RequestRepairing;
        public event BolideStateHandler RequestCleaning;

        public int X { get; set; }
        public int Y { get; set; }
        public int StartY { get; set; }
        public int TrackWidth { get; set; }
        public int TrackHeight { get; set; }
        public Timer WaitingTimer { get; set; }
        public int StandingTime { get; set; } = 8000;
        private double CrashProbability { get; set; } = RaceConfig.DefaultCrashProbabiliy;
        public int TiresCondition { get; set; } = RaceConfig.DefaultTiresCondition;
        public string Name { get; set; }
        public bool Crashed { get; set; } = false;
        public bool TiresWornOut { get; set; } = false;
        public bool PitStopRequested { get; set; } = false;
        public bool Arguing { get; set; } = false;
        public bool Q { get; set; } = false;
        public Bolide (string Name)
        {
            this.Name = Name;
        }

        public bool NeedBox
        {
            get { return TiresCondition < 30; }
        }

        public void Drive()
        {
            while (true)
            {
                if (!Crashed && !TiresWornOut)
                {
                    Thread.Sleep(5);
                    double crashProbability = RaceConfig.rnd.NextDouble();
                    if (crashProbability > CrashProbability && X > 0 && X < TrackWidth)
                    {
                        crashProbability = RaceConfig.rnd.NextDouble();
                        if (crashProbability > CrashProbability && X > 0 && X < TrackWidth)
                        {
                            Crashed = true;
                            WaitingTimer = new Timer(new TimerCallback(StartAgruing), 0, StandingTime, Timeout.Infinite);
                            RequestRepairing(this);
                            RequestCleaning(this);
                        }
                    }
                    else if (NeedBox)
                    {
                        TiresWornOut = true;
                        DriveBox();
                    }
                    else if (Y != StartY)
                    {
                        DriveBox();
                    }
                    else
                        DriveForward();
                }
            }
        }
    

        private void DriveForward()
        {
            int speed = RaceConfig.rnd.Next(5);
            X += speed;
            TiresCondition -= speed;
        }

        public void DriveBox()
        {
            while (Y > 0 && TiresWornOut && !PitStopRequested)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y -= speed;
                X += speed;
                Thread.Sleep(5);
            }
            if (TiresWornOut && !PitStopRequested)
            {
                PitStopRequested = true;
                Tires(this);
            }
            if (!TiresWornOut && PitStopRequested)
            {
                PitStopRequested = false;
            }
            while (!PitStopRequested && !TiresWornOut && Math.Abs(StartY - Y) > 15)
            {
                int speed = RaceConfig.rnd.Next(5);
                Y += speed;
                X += speed;
                Thread.Sleep(5); 
            }
            if (!PitStopRequested && !TiresWornOut && Math.Abs(StartY - Y) < 20)
            {
                Y = StartY;
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

        public void StartAgruing(object obj)
        {
            Arguing = true;
        }
    }
}
