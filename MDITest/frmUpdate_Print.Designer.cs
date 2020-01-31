namespace MDITest
{
    partial class frmUpdate_Print
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblDef = new System.Windows.Forms.Label();
            this.btn_OptUp = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.lbxLib = new System.Windows.Forms.ListBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCurr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(70, 161);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(231, 26);
            this.txtFile.TabIndex = 2;
            this.txtFile.Text = "type file here\r\n";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(70, 220);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(231, 29);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "U&pdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDef
            // 
            this.lblDef.AutoSize = true;
            this.lblDef.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDef.Location = new System.Drawing.Point(31, 46);
            this.lblDef.Name = "lblDef";
            this.lblDef.Size = new System.Drawing.Size(293, 26);
            this.lblDef.TabIndex = 5;
            this.lblDef.Text = "Default Update or Import?";
            // 
            // btn_OptUp
            // 
            this.btn_OptUp.Location = new System.Drawing.Point(37, 100);
            this.btn_OptUp.Name = "btn_OptUp";
            this.btn_OptUp.Size = new System.Drawing.Size(114, 29);
            this.btn_OptUp.TabIndex = 0;
            this.btn_OptUp.Text = "&Default";
            this.btn_OptUp.UseVisualStyleBackColor = true;
            this.btn_OptUp.Click += new System.EventHandler(this.btn_OptUp_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(226, 100);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(119, 29);
            this.btn_Import.TabIndex = 1;
            this.btn_Import.Text = "I&mport";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // lbxLib
            // 
            this.lbxLib.FormattingEnabled = true;
            this.lbxLib.ItemHeight = 20;
            this.lbxLib.Location = new System.Drawing.Point(210, 75);
            this.lbxLib.Name = "lbxLib";
            this.lbxLib.Size = new System.Drawing.Size(517, 304);
            this.lbxLib.TabIndex = 8;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(70, 269);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(231, 29);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(70, 349);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 29);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Au revoir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblCurr
            // 
            this.lblCurr.AutoSize = true;
            this.lblCurr.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurr.Location = new System.Drawing.Point(363, 46);
            this.lblCurr.Name = "lblCurr";
            this.lblCurr.Size = new System.Drawing.Size(207, 26);
            this.lblCurr.TabIndex = 11;
            this.lblCurr.Text = "Updated Database";
            // 
            // frmUpdate_Print
            // 
            this.AcceptButton = this.btn_OptUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(927, 444);
            this.Controls.Add(this.lblCurr);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lbxLib);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.btn_OptUp);
            this.Controls.Add(this.lblDef);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUpdate_Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Database";
            this.Load += new System.EventHandler(this.frmUpdate_Print_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblDef;
        private System.Windows.Forms.Button btn_OptUp;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.ListBox lbxLib;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblCurr;
    }
}