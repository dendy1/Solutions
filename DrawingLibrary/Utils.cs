using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingLibrary
{
    public class Utils
    {
        public static Image RotateModel(Image image, Size size, RotateFlipType rotate)
        {
            Image temp = new Bitmap(image, size);
            temp.RotateFlip(rotate);
            return temp;
        }
    }
}
