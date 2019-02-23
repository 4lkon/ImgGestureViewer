using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//emgu
using Emgu.CV;
using Emgu.CV.Structure;

namespace ImgGestureViewer.SkinDetector
{
    public abstract class IColorSkinDetector
    {
        public abstract Image<Gray, Byte> DetectSkin(Image<Bgr, Byte> Img, IColor min, IColor max);
    }
}
