using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifReader
{
    public class Utility
    {
        private static List<byte> data = new();

        public static void start(TextBox filePathTxtInput, TextBox output)
        {
            output.Text = "";

            if (filePathTxtInput.Text.Length == 0)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = "c:\\";
                dialog.Filter = "gif files (*.gif)|*.gif";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePathTxtInput.Text = dialog.FileName;

                    try
                    {
                        using (BinaryReader reader = new BinaryReader(new StreamReader(dialog.FileName).BaseStream))
                        {
                            process(reader, output);
                        }
                    }
                    catch (SecurityException ex)
                    {
                        
                    }
                }
            }
            else
            {
                if (!File.Exists(filePathTxtInput.Text))
                {
                    output.Text += "Errro file doesn't exists";
                    output.AppendText(Environment.NewLine);
                    return;
                }

                using (BinaryReader reader = new BinaryReader(new StreamReader(filePathTxtInput.Text).BaseStream))
                {
                    process(reader, output);
                }
            }
        }

        private static void process(BinaryReader reader, TextBox output)
        {
            // check header
            checkMagicNumber(reader);
            
            // read data
            while(reader.BaseStream.Position != reader.BaseStream.Length)
            {
                data.Add(reader.ReadByte());
            }

            reader.Close();

            // create Gif Object
            Gif gif = new Gif();

            gif.CanvasWidth = calculateByte(data[0], data[1]);
            gif.CanvasHieght = calculateByte(data[2], data[3]);
            unpack(data[4], gif);
            gif.BackgroundColorIndex = data[5];
            gif.PixelAspectRatio = data[6];

            display(gif, output);
        }

        private static void display(Gif gif, TextBox output)
        {
            output.Text += "Canvas Width: " + gif.CanvasWidth;
            output.AppendText(Environment.NewLine);

            output.Text += "Canvas Hieght: " + gif.CanvasHieght;
            output.AppendText(Environment.NewLine);

            output.Text += "SizeOfGlobalColorTable: " + gif.SizeOfGlobalColorTable;
            output.AppendText(Environment.NewLine);

            output.Text += "GlobalColorTableFlag: " + gif.GlobalColorTableFlag;
            output.AppendText(Environment.NewLine);

            output.Text += "SortFlag: " + gif.SortFlag;
            output.AppendText(Environment.NewLine);

            output.Text += "ColorResolution: " + gif.ColorResolution;
            output.AppendText(Environment.NewLine);

            output.Text += "BackgroundColorIndex: " + gif.BackgroundColorIndex;
            output.AppendText(Environment.NewLine);

            output.Text += "PixelAspectRatio: " + gif.PixelAspectRatio;
        }

        private static void unpack(byte by, Gif gif)
        {
            gif.SizeOfGlobalColorTable = by & 0b111;
            by >>= 3;
            gif.SortFlag = by & 0b1;
            by >>= 1;
            gif.ColorResolution = by & 0b111;
            by >>= 3;
            gif.BackgroundColorIndex = by;
        }

        private static void checkMagicNumber(BinaryReader reader)
        {
            for (int i = 0; i < 3; i++)
            {
                int by = reader.ReadByte();

                if (Gif.Magic_Number[i] != by)
                {
                    throw new Exception("Error wrong file format");
                }
            }

            checkVersion(reader);
        }

        private static void checkVersion(BinaryReader reader)
        {
            for (int i = 0; i < 3; i++)
            {
                int by = reader.ReadByte();

                if (Gif.Version[i] != by)
                {
                    throw new Exception("Error wrong file format");
                }
            }
        }

        private static int calculateByte(byte by1, byte by2)
        {
            return ((int)by1) + (((int)by2) * 256);
        }
    }
}
