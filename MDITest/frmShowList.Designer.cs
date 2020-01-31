namespace MDITest
{
    partial class frmShowList
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
            this.lbxDat = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefreshed = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbLove = new System.Windows.Forms.RadioButton();
            this.rbHate = new System.Windows.Forms.RadioButton();
            this.grpBxAd = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBxAd.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxDat
            // 
            this.lbxDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxDat.FormattingEnabled = true;
            this.lbxDat.ItemHeight = 20;
            this.lbxDat.Location = new System.Drawing.Point(22, 29);
            this.lbxDat.Name = "lbxDat";
            this.lbxDat.Size = new System.Drawing.Size(750, 344);
            this.lbxDat.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(326, 399);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 39);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRefreshed
            // 
            this.btnRefreshed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshed.Location = new System.Drawing.Point(326, 397);
            this.btnRefreshed.Name = "btnRefreshed";
            this.btnRefreshed.Size = new System.Drawing.Size(114, 52);
            this.btnRefreshed.TabIndex = 1;
            this.btnRefreshed.Text = "Refreshed";
            this.btnRefreshed.UseVisualStyleBackColor = true;
            this.btnRefreshed.Click += new System.EventHandler(this.btnRefreshed_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MDITest.Properties.Resources.coke4;
            this.pictureBox4.Location = new System.Drawing.Point(32, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(719, 361);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MDITest.Properties.Resources.coke3;
            this.pictureBox3.Location = new System.Drawing.Point(45, 45);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(727, 344);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MDITest.Properties.Resources.coke2;
            this.pictureBox2.Location = new System.Drawing.Point(50, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(691, 344);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MDITest.Properties.Resources.coke1;
            this.pictureBox1.Location = new System.Drawing.Point(22, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(719, 344);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rbLove
            // 
            this.rbLove.AutoSize = true;
            this.rbLove.Location = new System.Drawing.Point(23, 33);
            this.rbLove.Name = "rbLove";
            this.rbLove.Size = new System.Drawing.Size(76, 22);
            this.rbLove.TabIndex = 7;
            this.rbLove.TabStop = true;
            this.rbLove.Text = "Love It";
            this.rbLove.UseVisualStyleBackColor = true;
            // 
            // rbHate
            // 
            this.rbHate.AutoSize = true;
            this.rbHate.Location = new System.Drawing.Point(23, 72);
            this.rbHate.Name = "rbHate";
            this.rbHate.Size = new System.Drawing.Size(121, 22);
            this.rbHate.TabIndex = 8;
            this.rbHate.TabStop = true;
            this.rbHate.Text = "Don\'t Love it";
            this.rbHate.UseVisualStyleBackColor = true;
            // 
            // grpBxAd
            // 
            this.grpBxAd.Controls.Add(this.rbLove);
            this.grpBxAd.Controls.Add(this.rbHate);
            this.grpBxAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBxAd.Location = new System.Drawing.Point(12, 325);
            this.grpBxAd.Name = "grpBxAd";
            this.grpBxAd.Size = new System.Drawing.Size(230, 100);
            this.grpBxAd.TabIndex = 9;
            this.grpBxAd.TabStop = false;
            this.grpBxAd.Text = "Do you love this product?";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(667, 395);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 52);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Au&f Wiedersehen";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmShowList
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpBxAd);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnRefreshed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbxDat);
            this.Name = "frmShowList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Database";
            this.Load += new System.EventHandler(this.frmShowList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBxAd.ResumeLayout(false);
            this.grpBxAd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxDat;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRefreshed;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.RadioButton rbLove;
        private System.Windows.Forms.RadioButton rbHate;
        private System.Windows.Forms.GroupBox grpBxAd;
        private System.Windows.Forms.Button btnExit;
    }
}