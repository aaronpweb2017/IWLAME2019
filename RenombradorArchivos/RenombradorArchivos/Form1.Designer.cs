namespace RenombradorArchivos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRoute = new System.Windows.Forms.Label();
            this.txtBoxRoute = new System.Windows.Forms.TextBox();
            this.btnOpenFolderFiles = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtBoxFileName = new System.Windows.Forms.TextBox();
            this.lblFileNumber = new System.Windows.Forms.Label();
            this.txtBoxFileNumber = new System.Windows.Forms.TextBox();
            this.lblDirectoryFiles = new System.Windows.Forms.Label();
            this.lstBoxFolderFiles = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnInterChange = new System.Windows.Forms.Button();
            this.rdBtnModifiedName = new System.Windows.Forms.RadioButton();
            this.rdBtnOriginalName = new System.Windows.Forms.RadioButton();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnAleatorio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(18, 11);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(64, 24);
            this.lblRoute.TabIndex = 0;
            this.lblRoute.Text = "Ruta:";
            // 
            // txtBoxRoute
            // 
            this.txtBoxRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxRoute.Enabled = false;
            this.txtBoxRoute.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRoute.Location = new System.Drawing.Point(88, 11);
            this.txtBoxRoute.Name = "txtBoxRoute";
            this.txtBoxRoute.Size = new System.Drawing.Size(619, 26);
            this.txtBoxRoute.TabIndex = 1;
            // 
            // btnOpenFolderFiles
            // 
            this.btnOpenFolderFiles.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolderFiles.Location = new System.Drawing.Point(714, 12);
            this.btnOpenFolderFiles.Name = "btnOpenFolderFiles";
            this.btnOpenFolderFiles.Size = new System.Drawing.Size(133, 26);
            this.btnOpenFolderFiles.TabIndex = 2;
            this.btnOpenFolderFiles.Text = "Abrir Carpeta";
            this.btnOpenFolderFiles.UseVisualStyleBackColor = true;
            this.btnOpenFolderFiles.Click += new System.EventHandler(this.btnOpenFolderFiles_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(18, 439);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(199, 22);
            this.lblFileName.TabIndex = 5;
            this.lblFileName.Text = "Nombre del Archivo:";
            // 
            // txtBoxFileName
            // 
            this.txtBoxFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxFileName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFileName.Location = new System.Drawing.Point(215, 439);
            this.txtBoxFileName.Name = "txtBoxFileName";
            this.txtBoxFileName.Size = new System.Drawing.Size(452, 26);
            this.txtBoxFileName.TabIndex = 6;
            this.txtBoxFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxFileName_tb_KeyDown);
            // 
            // lblFileNumber
            // 
            this.lblFileNumber.AutoSize = true;
            this.lblFileNumber.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileNumber.Location = new System.Drawing.Point(681, 439);
            this.lblFileNumber.Name = "lblFileNumber";
            this.lblFileNumber.Size = new System.Drawing.Size(90, 22);
            this.lblFileNumber.TabIndex = 7;
            this.lblFileNumber.Text = "Número:";
            // 
            // txtBoxFileNumber
            // 
            this.txtBoxFileNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxFileNumber.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFileNumber.Location = new System.Drawing.Point(769, 439);
            this.txtBoxFileNumber.Name = "txtBoxFileNumber";
            this.txtBoxFileNumber.Size = new System.Drawing.Size(74, 26);
            this.txtBoxFileNumber.TabIndex = 8;
            this.txtBoxFileNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxFileNumber_tb_KeyDown);
            // 
            // lblDirectoryFiles
            // 
            this.lblDirectoryFiles.AutoSize = true;
            this.lblDirectoryFiles.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectoryFiles.Location = new System.Drawing.Point(18, 56);
            this.lblDirectoryFiles.Name = "lblDirectoryFiles";
            this.lblDirectoryFiles.Size = new System.Drawing.Size(213, 23);
            this.lblDirectoryFiles.TabIndex = 3;
            this.lblDirectoryFiles.Text = "Archivos de la Carpeta:";
            // 
            // lstBoxFolderFiles
            // 
            this.lstBoxFolderFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBoxFolderFiles.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxFolderFiles.FormattingEnabled = true;
            this.lstBoxFolderFiles.ItemHeight = 19;
            this.lstBoxFolderFiles.Location = new System.Drawing.Point(22, 82);
            this.lstBoxFolderFiles.Name = "lstBoxFolderFiles";
            this.lstBoxFolderFiles.Size = new System.Drawing.Size(823, 344);
            this.lstBoxFolderFiles.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(758, 522);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 40);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRename
            // 
            this.btnRename.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRename.Location = new System.Drawing.Point(22, 518);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(294, 38);
            this.btnRename.TabIndex = 11;
            this.btnRename.Text = "Renombrar Archivos";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnInterChange
            // 
            this.btnInterChange.Font = new System.Drawing.Font("Arial Narrow", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterChange.Location = new System.Drawing.Point(525, 518);
            this.btnInterChange.Name = "btnInterChange";
            this.btnInterChange.Size = new System.Drawing.Size(150, 38);
            this.btnInterChange.TabIndex = 13;
            this.btnInterChange.Text = "Intercambiar";
            this.btnInterChange.UseVisualStyleBackColor = true;
            this.btnInterChange.Click += new System.EventHandler(this.btnInterChange_Click_1);
            // 
            // rdBtnModifiedName
            // 
            this.rdBtnModifiedName.AutoSize = true;
            this.rdBtnModifiedName.Checked = true;
            this.rdBtnModifiedName.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnModifiedName.Location = new System.Drawing.Point(22, 471);
            this.rdBtnModifiedName.Name = "rdBtnModifiedName";
            this.rdBtnModifiedName.Size = new System.Drawing.Size(310, 32);
            this.rdBtnModifiedName.TabIndex = 9;
            this.rdBtnModifiedName.TabStop = true;
            this.rdBtnModifiedName.Text = "Modificar Nombre Original";
            this.rdBtnModifiedName.UseVisualStyleBackColor = true;
            this.rdBtnModifiedName.CheckedChanged += new System.EventHandler(this.rdBtnModifiedName_CheckedChanged);
            // 
            // rdBtnOriginalName
            // 
            this.rdBtnOriginalName.AutoSize = true;
            this.rdBtnOriginalName.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnOriginalName.Location = new System.Drawing.Point(459, 474);
            this.rdBtnOriginalName.Name = "rdBtnOriginalName";
            this.rdBtnOriginalName.Size = new System.Drawing.Size(312, 32);
            this.rdBtnOriginalName.TabIndex = 10;
            this.rdBtnOriginalName.Text = "Mantener Nombre Original";
            this.rdBtnOriginalName.UseVisualStyleBackColor = true;
            this.rdBtnOriginalName.CheckedChanged += new System.EventHandler(this.rdBtnOriginalName_CheckedChanged);
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Arial Narrow", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Location = new System.Drawing.Point(362, 518);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(98, 38);
            this.btnClean.TabIndex = 12;
            this.btnClean.Text = "limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnAleatorio
            // 
            this.btnAleatorio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAleatorio.Location = new System.Drawing.Point(758, 53);
            this.btnAleatorio.Name = "btnAleatorio";
            this.btnAleatorio.Size = new System.Drawing.Size(85, 26);
            this.btnAleatorio.TabIndex = 15;
            this.btnAleatorio.Text = "Aleatorio";
            this.btnAleatorio.UseVisualStyleBackColor = true;
            this.btnAleatorio.Click += new System.EventHandler(this.btnAleatorio_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 568);
            this.Controls.Add(this.btnAleatorio);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.rdBtnOriginalName);
            this.Controls.Add(this.rdBtnModifiedName);
            this.Controls.Add(this.btnInterChange);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.lblDirectoryFiles);
            this.Controls.Add(this.lstBoxFolderFiles);
            this.Controls.Add(this.txtBoxFileNumber);
            this.Controls.Add(this.lblFileNumber);
            this.Controls.Add(this.txtBoxFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnOpenFolderFiles);
            this.Controls.Add(this.txtBoxRoute);
            this.Controls.Add(this.lblRoute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Renombrador de Archivos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.TextBox txtBoxRoute;
        private System.Windows.Forms.Button btnOpenFolderFiles;
        private System.Windows.Forms.Label lblDirectoryFiles;
        private System.Windows.Forms.ListBox lstBoxFolderFiles;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtBoxFileName;
        private System.Windows.Forms.Label lblFileNumber;
        private System.Windows.Forms.TextBox txtBoxFileNumber;
        private System.Windows.Forms.RadioButton rdBtnModifiedName;
        private System.Windows.Forms.RadioButton rdBtnOriginalName;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnInterChange;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAleatorio;
    }
}

