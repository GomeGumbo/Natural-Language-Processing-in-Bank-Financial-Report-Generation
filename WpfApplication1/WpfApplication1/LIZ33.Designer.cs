namespace WpfApplication1
{
    partial class LIZ33
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
            this.listView = new System.Windows.Forms.ListView();
            this.filtertxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Sltbtn = new System.Windows.Forms.Button();
            this.updbtn = new System.Windows.Forms.Button();
            this.delbtn = new System.Windows.Forms.Button();
            this.inbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.Location = new System.Drawing.Point(78, 80);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(491, 212);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // filtertxt
            // 
            this.filtertxt.Location = new System.Drawing.Point(190, 12);
            this.filtertxt.Multiline = true;
            this.filtertxt.Name = "filtertxt";
            this.filtertxt.Size = new System.Drawing.Size(271, 36);
            this.filtertxt.TabIndex = 3;
            this.filtertxt.TextChanged += new System.EventHandler(this.filtertxt_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(589, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Sltbtn
            // 
            this.Sltbtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Sltbtn.Location = new System.Drawing.Point(126, 54);
            this.Sltbtn.Name = "Sltbtn";
            this.Sltbtn.Size = new System.Drawing.Size(75, 23);
            this.Sltbtn.TabIndex = 5;
            this.Sltbtn.Text = "Select";
            this.Sltbtn.UseVisualStyleBackColor = false;
            // 
            // updbtn
            // 
            this.updbtn.BackColor = System.Drawing.Color.DimGray;
            this.updbtn.Location = new System.Drawing.Point(238, 54);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(75, 23);
            this.updbtn.TabIndex = 6;
            this.updbtn.Text = "Update";
            this.updbtn.UseVisualStyleBackColor = false;
            this.updbtn.Click += new System.EventHandler(this.updbtn_Click);
            // 
            // delbtn
            // 
            this.delbtn.BackColor = System.Drawing.Color.DarkRed;
            this.delbtn.Location = new System.Drawing.Point(449, 54);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(75, 23);
            this.delbtn.TabIndex = 7;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = false;
            // 
            // inbtn
            // 
            this.inbtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.inbtn.Location = new System.Drawing.Point(349, 54);
            this.inbtn.Name = "inbtn";
            this.inbtn.Size = new System.Drawing.Size(75, 23);
            this.inbtn.TabIndex = 8;
            this.inbtn.Text = "Insert";
            this.inbtn.UseVisualStyleBackColor = false;
            // 
            // LIZ33
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 329);
            this.Controls.Add(this.inbtn);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.updbtn);
            this.Controls.Add(this.Sltbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filtertxt);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LIZ33";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIZ33";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TextBox filtertxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Sltbtn;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button inbtn;
    }
}