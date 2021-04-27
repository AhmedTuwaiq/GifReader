using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifReader
{
    public class GifFactory
    {
        private static readonly byte[] Magic_Number = { 71, 73, 70 };
        private static readonly byte[] Version = { 56, 57, 97 };
        private Gif gif;
        private List<byte> bytes;
        private string filePath;
        private BinaryReader reader;

        public GifFactory(string filePath)
        {
            gif = new Gif();
            bytes = new();
            this.filePath = filePath;
        }

        private bool validateFile(string filePath)
        {
            return File.Exists(filePath);
        }

        private bool validateMagicNumber()
        {
            reader = new BinaryReader(new StreamReader(filePath).BaseStream);

            for (int i = 0; i < 3; i++)
            {
                int by = reader.ReadByte();

                if (Gif.Magic_Number[i] != by)
                {
                    return false;
                }
            }

            return true;
        }

        private bool validateVersion()
        {
            for (int i = 0; i < 3; i++)
            {
                int by = reader.ReadByte();

                if (Gif.Version[i] != by)
                {
                    return false;
                }
            }

            return true;
        }

        private void readBytes()
        {
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                bytes.Add(reader.ReadByte());
            }
        }

        public Gif build()
        {
            if(!this.validateFile(this.filePath))
            {
                Log.printLine("Error file doesn't exists");
                this.abortBuild();
                return null;
            }
            else if(!this.validateMagicNumber() || !this.validateVersion())
            {
                Log.printLine("Error wrong file format");
                this.abortBuild();
                return null;
            }

            this.readBytes();
            this.gif.CanvasWidth = this.calculateByte(bytes[0], bytes[1]);
            this.gif.CanvasHieght = this.calculateByte(bytes[2], bytes[3]);
            this.unpack();
            gif.BackgroundColorIndex = bytes[5];
            gif.PixelAspectRatio = bytes[6];

            this.abortBuild();

            return this.gif;
        }

        private void unpack()
        {
            byte by = bytes[4];

            gif.SizeOfGlobalColorTable = by & 0b111;
            by >>= 3;
            gif.SortFlag = by & 0b1;
            by >>= 1;
            gif.ColorResolution = by & 0b111;
            by >>= 3;
            gif.BackgroundColorIndex = by;
        }

        private void abortBuild()
        {
            reader.Close();
            reader = null;
        }

        private int calculateByte(byte by1, byte by2)
        {
            return ((int)by1) + (((int)by2) * 256);
        }
    }
}
