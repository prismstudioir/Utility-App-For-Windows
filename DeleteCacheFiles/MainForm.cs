using System;
using System.IO;
using System.Windows.Forms;
using DeleteCacheFiles.Properties;

namespace DeleteCacheFiles
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var list = Settings.Default.FolderList;
                if (list != null)
                {
                    string[] lines = list.Replace("\r", "").Split('\n');
                    foreach (var sr in lines)
                    {
                        try
                        {
                            Directory.Delete(sr, true);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                MessageBox.Show(@"Done!");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetFolderList fol = new SetFolderList();
            fol.ShowDialog();
        }
    }
}
