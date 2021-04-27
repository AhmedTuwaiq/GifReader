using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Log.output = outputBox;
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            string filePath = Utility.getFilePath(filePathTxtInput);
            Gif gif = new GifFactory(filePath).build();

            if(gif != null)
            {
                Log.display(gif);
            }
        }
    }
}
