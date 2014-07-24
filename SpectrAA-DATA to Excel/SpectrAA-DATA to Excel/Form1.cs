using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrAA_DATA_to_Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> output = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            progressBar1.Value = 0;
            //Load selected file locations
            if (fileRadioButton.Checked)
            {
                if (inputFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    files.AddRange(inputFileDialog.FileNames);
            }
            else
            {
                if (inputFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DirectorySearch(inputFolderDialog.SelectedPath);
                    files.AddRange(output);
                }

            }

            progressBar1.Maximum = files.Count;
            files.ForEach(item => Exporter.ExportToXls(item, textBox2.Text, progressBar1));

            output.Clear();
            files.Clear();
        }

        private void DirectorySearch(string path)
        {
            foreach(string d in Directory.GetDirectories(path))
            {
                foreach(string f in Directory.GetFiles(d).Where(item => item.Contains(".DATA")))
                {
                    output.Add(f);
                }
                DirectorySearch(d);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(outputFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = outputFolderDialog.SelectedPath;
            }
        }
    }
}
