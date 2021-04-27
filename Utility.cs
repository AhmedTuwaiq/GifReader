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
        public static string getFilePath(TextBox filePathTxtInput)
        {
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
                    return dialog.FileName;
                }
            }
            else
            {
                if (!File.Exists(filePathTxtInput.Text))
                {
                    Log.printLine("Errro file doesn't exists");
                    return "";
                }

                return filePathTxtInput.Text;
            }

            return "";
        }
    }
}
