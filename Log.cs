using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifReader
{
    public class Log
    {
        public static TextBox output;

        public static void print(string message)
        {
            clearLog();
            output.Text = message;
        }

        public static void printLine(string message)
        {
            clearLog();
            output.Text = message;
            output.AppendText(Environment.NewLine);
        }

        private static void clearLog()
        {
            output.Text = "";
        }

        public static void display(Gif gif)
        {
            clearLog();

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
    }
}
