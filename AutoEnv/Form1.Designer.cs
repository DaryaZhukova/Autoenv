namespace AutoEnv
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Iisbutton = new System.Windows.Forms.Button();
            this.Iisvbutton = new System.Windows.Forms.Button();
            this.Outputbox = new System.Windows.Forms.RichTextBox();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 361);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Iisbutton);
            this.flowLayoutPanel1.Controls.Add(this.Iisvbutton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(478, 174);
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
            // Iisvbutton
            // 
            this.Iisvbutton.Location = new System.Drawing.Point(84, 3);
            this.Iisvbutton.Name = "Iisvbutton";
            this.Iisvbutton.Size = new System.Drawing.Size(75, 23);
            this.Iisvbutton.TabIndex = 1;
            this.Iisvbutton.Text = "IIS version";
            this.Iisvbutton.UseVisualStyleBackColor = true;
            this.Iisvbutton.Click += new System.EventHandler(this.Iisvbutton_Click);
            // 
            // Outputbox
            // 
            this.Outputbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Outputbox.Location = new System.Drawing.Point(3, 183);
            this.Outputbox.Name = "Outputbox";
            this.Outputbox.ReadOnly = true;
            this.Outputbox.Size = new System.Drawing.Size(478, 175);
            this.Outputbox.TabIndex = 1;
            this.Outputbox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "AutoEnv";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Iisbutton;
        private System.Windows.Forms.Button Iisvbutton;
        private System.Windows.Forms.RichTextBox Outputbox;
    }
}

