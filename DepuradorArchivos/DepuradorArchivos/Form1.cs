using System;
using System.IO;
using System.Windows.Forms;

namespace DepuradorArchivos
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog FBD = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void btnOpenDirectoryFiles_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                lstBoxDirectoryFiles.Items.Clear();
                txtBoxRoute.Text = FBD.SelectedPath; FileInfo file;
                string [] filesRoutes = Directory.GetFiles(FBD.SelectedPath);
                foreach (string fileRoute in filesRoutes) {
                    file = new FileInfo(fileRoute);
                    lstBoxDirectoryFiles.Items.Add(fileRoute + " | " + file.Length / 1024 + "KB");
                }  
            }
        }

        private void btnDetete_Click(object sender, EventArgs e)
        {
            String route = FBD.SelectedPath; FileStream file;
            string [] filesRoutes = Directory.GetFiles(route);
            foreach (string fileRoute in filesRoutes)
            {
                file = File.Open(fileRoute, FileMode.Open);
                file.SetLength(0); file.Close();
            }
        }
    }
}