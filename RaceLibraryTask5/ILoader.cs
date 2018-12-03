using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RaceLibraryTask5
{
    public interface ILoader
    {
        string Name { get; set; }
        int X { get; set; }
        int Y { get; set; }
        bool Busy { get; set; }
        void SetPosition(int TrackWidth, int TrackHeight);
        void InteractingWithBolide(Bolide b);
    }
}
