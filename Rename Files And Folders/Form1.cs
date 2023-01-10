using System;
using System.IO;
using System.Windows.Forms;

namespace Rename_Files_And_Folders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (directchoosedlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = directchoosedlg.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dirAa = new DirectoryInfo(textBox1.Text);

            foreach (var dir in dirAa.GetDirectories())
            {
                if (!dir.Name.Contains(textBox2.Text)) continue;
                string name = dir.Name.Replace(textBox2.Text, textBox3.Text);
                var newpath = dirAa.FullName + "\\" + name;
                Directory.Move(dir.FullName, newpath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dirAa = new DirectoryInfo(textBox1.Text);
            foreach (var dir in dirAa.GetFiles())
            {
                if (!dir.Name.Contains(textBox2.Text)) continue;
                var name = dir.Name.Replace(textBox2.Text, textBox3.Text);
                var newpath = dirAa.FullName + "\\" + name;
                Directory.Move(dir.FullName, newpath);
            }
        }
    }
}
