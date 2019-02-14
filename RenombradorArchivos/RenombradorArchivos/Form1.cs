using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RenombradorArchivos
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog FBD;
        string[] fileRoutes; String fileName; int fileNumber;
        public Form1()
        {
            InitializeComponent(); CenterToScreen();
            FBD = new FolderBrowserDialog();
        }

        private void btnOpenFolderFiles_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                lstBoxFolderFiles.Items.Clear(); FileInfo file;
                txtBoxRoute.Text = FBD.SelectedPath;
                fileRoutes = Directory.GetFiles(FBD.SelectedPath);
                foreach (string fileRoute in fileRoutes)
                {
                    file = new FileInfo(fileRoute);
                    lstBoxFolderFiles.Items.Add(file.Name + " | " + file.Length / 1024 + "KB");
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (txtBoxFileName.Text == "" || txtBoxFileNumber.Text == "" || fileRoutes == null)
            {
                MessageBox.Show("Faltan datos por ingresar."); return;
            }
            fileName = txtBoxFileName.Text; String modifiedFileName = "";
            fileNumber = Convert.ToUInt16(txtBoxFileNumber.Text); FileInfo file;
            int noFiles = fileRoutes.Length, maxNumber = (fileNumber + noFiles) - 1; int i = 0;
            int zeroCounter = Convert.ToString(maxNumber).Length - txtBoxFileNumber.Text.Length;
            lstBoxFolderFiles.Items.Clear(); fileRoutes = Directory.GetFiles(FBD.SelectedPath);
            foreach (string fileRoute in fileRoutes)
            {
                file = new FileInfo(fileRoute); i++;
                if (rdBtnOriginalName.Checked)
                    fileName = file.Name;
                for (int j = 10; j <= i; j *= 10)
                    if (j == i) zeroCounter = zeroCounter - 1;
                if (lblFileName.Location.X == 18 && lblFileNumber.Location.X == 681)
                    modifiedFileName = fileName + getNZeros(zeroCounter) + fileNumber + file.Extension;
                else if (lblFileNumber.Location.X == 18 && lblFileName.Location.X == 194)
                    modifiedFileName = getNZeros(zeroCounter) + fileNumber + ".- " + fileName;
                file.MoveTo(FBD.SelectedPath + "\\" + modifiedFileName); fileNumber++;
                lstBoxFolderFiles.Items.Add(modifiedFileName + " | " + file.Length / 1024 + "KB");
            }
        }

        public static string getNZeros(int n)
        {
            String zeros = "";
            for (int i = 0; i < n; i++)
                zeros += "0";
            return zeros;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInterChange_Click_1(object sender, EventArgs e)
        {
            if (lblFileName.Location.X == 18 && lblFileName.Location.Y == 439)
            {
                lblFileName.Location = new Point(194, 438);
                txtBoxFileName.Location = new Point(391, 438);
                lblFileNumber.Location = new Point(18, 439);
                txtBoxFileNumber.Location = new Point(104, 439);
            }
            else
            {
                lblFileName.Location = new Point(18, 439);
                txtBoxFileName.Location = new Point(215, 439);
                lblFileNumber.Location = new Point(681, 439);
                txtBoxFileNumber.Location = new Point(769, 439);
            }

        }

        private void rdBtnOriginalName_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxFileName.Enabled = false;
        }

        private void rdBtnModifiedName_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxFileName.Enabled = true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtBoxRoute.Text = "";
            lstBoxFolderFiles.Items.Clear();
            txtBoxFileName.Text = "";
            txtBoxFileNumber.Text = "";
            lblFileName.Location = new Point(18, 439);
            txtBoxFileName.Location = new Point(215, 439);
            lblFileNumber.Location = new Point(681, 439);
            txtBoxFileNumber.Location = new Point(769, 439);
            rdBtnModifiedName.Checked = true;
            btnRename.Enabled = false;
        }

        private void txtBoxFileName_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBoxFileName.Text.Length > 0)
                {
                    if (lblFileName.Location.X == 18)
                        txtBoxFileNumber.Focus();
                    else
                        btnRename.Focus();
                }
                else
                    MessageBox.Show("Ingrese un dato.");
            }
        }

        private void txtBoxFileNumber_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBoxFileNumber.Text.Length > 0)
                {
                    if (txtBoxFileNumber.Location.X == 104)
                        txtBoxFileName.Focus();
                    else
                        btnRename.Focus();
                }
                else
                    MessageBox.Show("Ingrese un dato.");
            }
        }
    }
}
