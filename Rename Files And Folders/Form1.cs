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
            try
            {
                FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
                if (directchoosedlg.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = directchoosedlg.SelectedPath;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Oh! Sometighns wrongs");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var dirAa = new DirectoryInfo(textBox1.Text);
                foreach (var dir in dirAa.GetDirectories())
                {
                    if (!dir.Name.Contains(textBox2.Text)) continue;
                    string name = dir.Name.Replace(textBox2.Text, textBox3.Text);
                    var newpath = dirAa.FullName + "\\" + name ;
                    Directory.Move(dir.FullName, newpath);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Oh! Sometighns wrongs");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var dirAa = new DirectoryInfo(textBox1.Text);
                foreach (var dir in dirAa.GetFiles())
                {
                    if (!Path.GetFileNameWithoutExtension(dir.Name).Contains(textBox2.Text)) continue;
                    var name = Path.GetFileNameWithoutExtension(dir.Name).Replace(textBox2.Text, textBox3.Text);
                    var newpath = dirAa.FullName + "\\" + name+ Path.GetExtension(dir.Name);
                    Directory.Move(dir.FullName, newpath);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Oh! Sometighns wrongs");
            }
        }
    }
}
