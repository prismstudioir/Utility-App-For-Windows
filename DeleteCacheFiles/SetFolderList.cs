using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeleteCacheFiles.Properties;

namespace DeleteCacheFiles
{
    public partial class SetFolderList : Form
    {
        public SetFolderList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.FolderList = textBox1.Text;
            Settings.Default.Save();
            Settings.Default.Upgrade();
            this.Close();
            //Application.Restart();
        }

        private void SetFolderList_Load(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            textBox1.Text = Settings.Default.FolderList;
        }
    }
}
