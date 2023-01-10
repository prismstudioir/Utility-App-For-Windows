using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Persian_Subtitle_Fixer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var subfile in data)
            {
                string filetype = Path.GetExtension(subfile);
                if (filetype == ".srt" || filetype == ".ass")
                {
                    try
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        StreamReader streamReader = new StreamReader(subfile, Encoding.GetEncoding("Windows-1256"));
                        string end = streamReader.ReadToEnd();
                        streamReader.Close();
                        StreamWriter streamWriter = new StreamWriter(
                            subfile.Substring(0, subfile.Length - 4) + ".edited" + filetype, false, Encoding.UTF8);
                        streamWriter.Write(end);
                        streamWriter.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                else
                {
                    MessageBox.Show(@"Unknown file type!");
                }
            }
            

        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, false))
                return;
            e.Effect = DragDropEffects.All;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
        }
    }
}
