using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceLibraryTask5;
using System.Drawing;
using System.Threading;

namespace DrawingLibraryTask5
{
    public class Drawing
    {
        public static void DrawRace(Bitmap bmp, Race race)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Bolide bolide in race.Bolides)
                {
                    Image temp = (Image)Resources.ResourceManager.GetObject(bolide.Name);
                    Image model = Utils.RotateModel(temp, DrawingConfig.size, RotateFlipType.Rotate270FlipNone);
                    temp.Dispose();
                    if (bolide.X > race.TrackWidth)
                    {
                        bolide.X = -model.Width;
                    }
                    else
                    {
                        if (bolide.Arguing)
                        {
                            g.DrawString("BROKEN!!!", new Font("Arial", 12), Brushes.Black, bolide.X, bolide.Y - 22);
                        }
                        g.DrawImage(model, bolide.X, bolide.Y);
                        g.DrawString(bolide.Name, new Font("Arial", 20), Brushes.LimeGreen, bolide.X, bolide.Y);
                    }
                        
                }

                foreach (Mechanic mechanic in race.Mechanics)
                {
                    Image temp = (Image)Resources.ResourceManager.GetObject(mechanic.Name + "Mechanic");
                    Image model = Utils.RotateModel(temp, DrawingConfig.size, RotateFlipType.RotateNoneFlipNone);
                    temp.Dispose();
                    g.DrawImage(model, mechanic.X, mechanic.Y);
                }

                foreach (ILoader loader in race.Loaders)
                {
                    Image temp = (Image)Resources.ResourceManager.GetObject(loader.Name);
                    Image model = temp;
                    if (loader is ReparingLoader)
                        model = Utils.RotateModel(temp, DrawingConfig.size, RotateFlipType.RotateNoneFlipNone);
                    else if (loader is CleaningLoader)
                        model = Utils.RotateModel(temp, DrawingConfig.size, RotateFlipType.Rotate90FlipNone);
                    temp.Dispose();
                    g.DrawImage(model, loader.X, loader.Y);
                }
                
            }
        }
    }
}
