using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace RaceLibrary
{
    public class Race
    {
        public List<Bolide> Bolides { get; private set; }
        public List<Mechanic> Mechanics { get; private set; }
        public List<ILoader> Loaders { get; private set; }
        public List<Thread> Threads { get; private set; }

        public int TrackWidth { get; set; }
        public int TrackHeight { get; set; }

        public bool RaceIsOn = false;

        public Race(int TrackWidth, int TrackHeight)
        {
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;
            Bolides = new List<Bolide>();
            Mechanics = new List<Mechanic>();
            Loaders = new List<ILoader>();
            Threads = new List<Thread>();
        }

        public void UpdateTrack(int TrackWidth, int TrackHeight)
        {
            this.TrackWidth = TrackWidth;
            this.TrackHeight = TrackHeight;
            SetStartGrid();
        }

        public void StartRace()
        {
            if (Bolides.Count == 0)
                throw new Exception("Вы не добавили ни одного участника!");
            if (RaceIsOn)
                throw new Exception("Гонка уже началась!");
            foreach (Bolide b in Bolides)
            {
                Thread thread = new Thread(() => b.Drive());
                thread.IsBackground = true;
                Threads.Add(thread);
            }
            foreach (Thread t in Threads)
            {
                t.Start();
            }
            RaceIsOn = true;
        }

        public void StopRace()
        {
            if (!RaceIsOn)
                throw new Exception("Гонка ещё не началась!");
            foreach (Thread t in Threads)
            {
                t.Abort();
            }
            Threads.Clear();
            SetStartGrid();
            RaceIsOn = false;
        }

        public void ClearParticipants()
        {
            if (!RaceIsOn)
            {
                Bolides.Clear();
                Loaders.Clear();
                Mechanics.Clear();
            }
            else throw new Exception("Гонка уже началась! Сначала остановите гонку");
        }

        public void CreateRace()
        {
            Test();
            SetStartGrid();
        }

        public void AddRacer(string Name)
        {
            if (!RaceIsOn)
            {
                Bolide newbolide = new Bolide(Name, TrackWidth, TrackHeight);
                Bolides.Add(newbolide);

                Mechanic newmechanic = new Mechanic(Name, newbolide);
                newmechanic.SetPosition(TrackWidth, TrackHeight);
                Mechanics.Add(newmechanic);
                

                ReparingLoader newloader = new ReparingLoader(Name, newbolide);
                newloader.SetPosition(TrackWidth, TrackHeight);
                Loaders.Add(newloader);

                SafetyCar safety = new SafetyCar(Name, newbolide);
                safety.SetPosition(TrackWidth, TrackHeight);
                Loaders.Add(safety);

                SetStartGrid();
            }
                else throw new Exception("Гонка уже началась! Сначала остановите гонку");
        }

        private void Test()
        {
            if (RaceIsOn) throw new Exception("Гонка уже началась! Сначала остановите гонку");

            Bolides.AddRange(new List<Bolide>()
            {
                new Bolide("Ferrari", TrackWidth, TrackHeight),
                new Bolide("RedBull", TrackWidth, TrackHeight),
                new Bolide("ForceIndia", TrackWidth, TrackHeight),
                new Bolide("Mercedes", TrackWidth, TrackHeight),
            });
            foreach (Bolide bolide in Bolides)
            {
                Mechanic mechanic = new Mechanic(bolide.Name, bolide);
                mechanic.SetPosition(TrackWidth, TrackHeight);
                Mechanics.Add(mechanic);

                ReparingLoader repaing = new ReparingLoader(bolide.Name, bolide);
                repaing.SetPosition(TrackWidth, TrackHeight);
                Loaders.Add(repaing);

                SafetyCar safety = new SafetyCar(bolide.Name, bolide);
                safety.SetPosition(TrackWidth, TrackHeight);
                Loaders.Add(safety);
            }
        }

        private void SetStartGrid()
        {
            if (Bolides.Count == 0) return;
            int startY = 100;
            int gap = (TrackHeight - startY) / Bolides.Count;
            for (int i = 0; i < Bolides.Count; i++)
            {
                Bolides[i].SetPosition(0, startY + gap * i, TrackWidth, TrackHeight);
            }
            foreach (ILoader loader in Loaders)
            {
                loader.SetPosition(TrackWidth, TrackHeight);
            }
        }
    }
}
