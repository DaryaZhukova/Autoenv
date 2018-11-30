namespace AutoEnv
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public Installfeatures fich = new Installfeatures();


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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Iisbutton = new System.Windows.Forms.Button();
            this.IISconf = new System.Windows.Forms.Button();
            this.advbtn = new System.Windows.Forms.Button();
            this.advinstbtn = new System.Windows.Forms.Button();
            this.Iisvbutton = new System.Windows.Forms.Button();
            this.iisfichtree = new System.Windows.Forms.TreeView();
            this.Outputbox = new System.Windows.Forms.RichTextBox();
            this.regbtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Outputbox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.04065F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.95935F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Iisbutton);
            this.flowLayoutPanel1.Controls.Add(this.IISconf);
            this.flowLayoutPanel1.Controls.Add(this.regbtn);
            this.flowLayoutPanel1.Controls.Add(this.advbtn);
            this.flowLayoutPanel1.Controls.Add(this.advinstbtn);
            this.flowLayoutPanel1.Controls.Add(this.Iisvbutton);
            this.flowLayoutPanel1.Controls.Add(this.iisfichtree);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(849, 313);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Iisbutton
            // 
            this.Iisbutton.Location = new System.Drawing.Point(3, 3);
            this.Iisbutton.Name = "Iisbutton";
            this.Iisbutton.Size = new System.Drawing.Size(75, 23);
            this.Iisbutton.TabIndex = 0;
            this.Iisbutton.Text = "IIS install";
            this.Iisbutton.UseVisualStyleBackColor = true;
            this.Iisbutton.Click += new System.EventHandler(this.Iisbutton_Click);
            // 
            // IISconf
            // 
            this.IISconf.Location = new System.Drawing.Point(84, 3);
            this.IISconf.Name = "IISconf";
            this.IISconf.Size = new System.Drawing.Size(75, 23);
            this.IISconf.TabIndex = 2;
            this.IISconf.Text = "IIS configure";
            this.IISconf.UseVisualStyleBackColor = true;
            this.IISconf.Click += new System.EventHandler(this.IISconf_Click);
            // 
            // advbtn
            // 
            this.advbtn.AutoSize = true;
            this.advbtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.advbtn.Location = new System.Drawing.Point(246, 3);
            this.advbtn.Name = "advbtn";
            this.advbtn.Size = new System.Drawing.Size(66, 23);
            this.advbtn.TabIndex = 4;
            this.advbtn.Text = "Advanced";
            this.advbtn.UseVisualStyleBackColor = true;
            this.advbtn.Click += new System.EventHandler(this.advbtn_Click);
            // 
            // advinstbtn
            // 
            this.advinstbtn.Location = new System.Drawing.Point(318, 3);
            this.advinstbtn.Name = "advinstbtn";
            this.advinstbtn.Size = new System.Drawing.Size(75, 23);
            this.advinstbtn.TabIndex = 5;
            this.advinstbtn.Text = "Install";
            this.advinstbtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.advinstbtn.UseVisualStyleBackColor = true;
            this.advinstbtn.Click += new System.EventHandler(this.advinstbtn_Click);
            // 
            // Iisvbutton
            // 
            this.Iisvbutton.Location = new System.Drawing.Point(399, 3);
            this.Iisvbutton.Name = "Iisvbutton";
            this.Iisvbutton.Size = new System.Drawing.Size(75, 23);
            this.Iisvbutton.TabIndex = 1;
            this.Iisvbutton.Text = "Test";
            this.Iisvbutton.UseVisualStyleBackColor = true;
            this.Iisvbutton.Click += new System.EventHandler(this.Iisvbutton_Click);
            // 
            // iisfichtree
            // 
            this.iisfichtree.CheckBoxes = true;
            this.iisfichtree.Location = new System.Drawing.Point(480, 3);
            this.iisfichtree.Name = "iisfichtree";
            this.iisfichtree.Size = new System.Drawing.Size(286, 310);
            this.iisfichtree.TabIndex = 3;
            this.iisfichtree.Visible = false;
            this.iisfichtree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.iisfichtree_AfterCheck);
            this.iisfichtree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.iisfichtree_AfterSelect);
            // 
            // Outputbox
            // 
            this.Outputbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Outputbox.Location = new System.Drawing.Point(3, 322);
            this.Outputbox.Name = "Outputbox";
            this.Outputbox.ReadOnly = true;
            this.Outputbox.Size = new System.Drawing.Size(849, 167);
            this.Outputbox.TabIndex = 1;
            this.Outputbox.Text = "";
            // 
            // regbtn
            // 
            this.regbtn.Location = new System.Drawing.Point(165, 3);
            this.regbtn.Name = "regbtn";
            this.regbtn.Size = new System.Drawing.Size(75, 23);
            this.regbtn.TabIndex = 6;
            this.regbtn.Text = "Register .NET";
            this.regbtn.UseVisualStyleBackColor = true;
            this.regbtn.Click += new System.EventHandler(this.regbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 492);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "AutoEnv";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Iisbutton;
        private System.Windows.Forms.Button Iisvbutton;
        private System.Windows.Forms.RichTextBox Outputbox;
        private System.Windows.Forms.Button IISconf;
        private System.Windows.Forms.TreeView iisfichtree;
        private System.Windows.Forms.Button advbtn;
        private System.Windows.Forms.Button advinstbtn;
        private System.Windows.Forms.Button regbtn;
    }
}

