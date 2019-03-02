namespace EliminadorDirectorio
{
    partial class Marco
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
            this.lstBoxDirectoryFiles = new System.Windows.Forms.ListBox();
            this.btnDetete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDirectoryFiles = new System.Windows.Forms.Label();
            this.btnOpenDirectoryFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(13, 13);
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
            this.txtBoxRoute.Location = new System.Drawing.Point(83, 14);
            this.txtBoxRoute.Name = "txtBoxRoute";
            this.txtBoxRoute.Size = new System.Drawing.Size(536, 26);
            this.txtBoxRoute.TabIndex = 1;
            // 
            // lstBoxDirectoryFiles
            // 
            this.lstBoxDirectoryFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoxDirectoryFiles.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxDirectoryFiles.FormattingEnabled = true;
            this.lstBoxDirectoryFiles.ItemHeight = 19;
            this.lstBoxDirectoryFiles.Location = new System.Drawing.Point(17, 80);
            this.lstBoxDirectoryFiles.Name = "lstBoxDirectoryFiles";
            this.lstBoxDirectoryFiles.Size = new System.Drawing.Size(773, 361);
            this.lstBoxDirectoryFiles.TabIndex = 2;
            // 
            // btnDetete
            // 
            this.btnDetete.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetete.Location = new System.Drawing.Point(17, 455);
            this.btnDetete.Name = "btnDetete";
            this.btnDetete.Size = new System.Drawing.Size(521, 46);
            this.btnDetete.TabIndex = 3;
            this.btnDetete.Text = "Eliminar archivos y carpetas del directorio";
            this.btnDetete.UseVisualStyleBackColor = true;
            this.btnDetete.Click += new System.EventHandler(this.btnDetete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(672, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 48);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblDirectoryFiles
            // 
            this.lblDirectoryFiles.AutoSize = true;
            this.lblDirectoryFiles.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectoryFiles.Location = new System.Drawing.Point(13, 58);
            this.lblDirectoryFiles.Name = "lblDirectoryFiles";
            this.lblDirectoryFiles.Size = new System.Drawing.Size(304, 23);
            this.lblDirectoryFiles.TabIndex = 5;
            this.lblDirectoryFiles.Text = "Archivos y carpetas del directorio:";
            // 
            // btnOpenDirectoryFiles
            // 
            this.btnOpenDirectoryFiles.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenDirectoryFiles.Location = new System.Drawing.Point(625, 14);
            this.btnOpenDirectoryFiles.Name = "btnOpenDirectoryFiles";
            this.btnOpenDirectoryFiles.Size = new System.Drawing.Size(165, 26);
            this.btnOpenDirectoryFiles.TabIndex = 6;
            this.btnOpenDirectoryFiles.Text = "Abrir Directorio";
            this.btnOpenDirectoryFiles.UseVisualStyleBackColor = true;
            this.btnOpenDirectoryFiles.Click += new System.EventHandler(this.btnOpenDirectoryFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 523);
            this.Controls.Add(this.btnOpenDirectoryFiles);
            this.Controls.Add(this.lblDirectoryFiles);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDetete);
            this.Controls.Add(this.lstBoxDirectoryFiles);
            this.Controls.Add(this.txtBoxRoute);
            this.Controls.Add(this.lblRoute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Depurar Archivos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.TextBox txtBoxRoute;
        private System.Windows.Forms.ListBox lstBoxDirectoryFiles;
        private System.Windows.Forms.Button btnDetete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDirectoryFiles;
        private System.Windows.Forms.Button btnOpenDirectoryFiles;
    }
}