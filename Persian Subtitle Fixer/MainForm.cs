using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            string newpath = "";
            foreach (var subfile in data)
            {
                try
                {
                    newpath = Path.GetDirectoryName(subfile)+@"/Edited/";
                    if (newpath != null) Directory.CreateDirectory(newpath);
                }
                catch (Exception exception)
                {
                    // ignored
                }

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
                            newpath + Path.GetFileName(subfile), false,
                            Encoding.UTF8);
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
            this.Paint += new PaintEventHandler(Set_Background);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Set_Background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Rectangle gradientRectangle = new Rectangle(0, 0, Width, Height);

            Brush b = new LinearGradientBrush(gradientRectangle, Color.FromArgb(30, 214, 217), Color.FromArgb(15, 161, 163), 65f);

            graphics.FillRectangle(b, gradientRectangle);
        }
    }
}
