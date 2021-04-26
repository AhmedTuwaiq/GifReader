using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifReader
{
    public class Gif
    {
        public static readonly byte[] Magic_Number = { 71, 73, 70 };
        public static readonly byte[] Version = { 56, 57, 97 };
        public int CanvasWidth;
        public int CanvasHieght;
        public int SizeOfGlobalColorTable;
        public int GlobalColorTableFlag;
        public int SortFlag;
        public int ColorResolution;
        public int BackgroundColorIndex;
        public int PixelAspectRatio;
    }
}
