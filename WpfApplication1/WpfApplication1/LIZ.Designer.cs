﻿namespace WpfApplication1
{
    partial class LIZ
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
            this.filtertxt = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.inbtn = new System.Windows.Forms.Button();
            this.delbtn = new System.Windows.Forms.Button();
            this.updbtn = new System.Windows.Forms.Button();
            this.Sltbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filtertxt
            // 
            this.filtertxt.Location = new System.Drawing.Point(201, 36);
            this.filtertxt.Multiline = true;
            this.filtertxt.Name = "filtertxt";
            this.filtertxt.Size = new System.Drawing.Size(271, 36);
            this.filtertxt.TabIndex = 0;
            this.filtertxt.TextChanged += new System.EventHandler(this.filtertxt_TextChanged);
            // 
            // listView
            // 
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.Location = new System.Drawing.Point(88, 105);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(491, 212);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(605, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inbtn
            // 
            this.inbtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.inbtn.Location = new System.Drawing.Point(361, 78);
            this.inbtn.Name = "inbtn";
            this.inbtn.Size = new System.Drawing.Size(75, 23);
            this.inbtn.TabIndex = 12;
            this.inbtn.Text = "Insert";
            this.inbtn.UseVisualStyleBackColor = false;
            // 
            // delbtn
            // 
            this.delbtn.BackColor = System.Drawing.Color.DarkRed;
            this.delbtn.Location = new System.Drawing.Point(461, 78);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(75, 23);
            this.delbtn.TabIndex = 11;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = false;
            // 
            // updbtn
            // 
            this.updbtn.BackColor = System.Drawing.Color.DimGray;
            this.updbtn.Location = new System.Drawing.Point(250, 78);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(75, 23);
            this.updbtn.TabIndex = 10;
            this.updbtn.Text = "Update";
            this.updbtn.UseVisualStyleBackColor = false;
            // 
            // Sltbtn
            // 
            this.Sltbtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Sltbtn.Location = new System.Drawing.Point(138, 78);
            this.Sltbtn.Name = "Sltbtn";
            this.Sltbtn.Size = new System.Drawing.Size(75, 23);
            this.Sltbtn.TabIndex = 9;
            this.Sltbtn.Text = "Select";
            this.Sltbtn.UseVisualStyleBackColor = false;
            // 
            // LIZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 343);
            this.Controls.Add(this.inbtn);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.updbtn);
            this.Controls.Add(this.Sltbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.filtertxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LIZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIZ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filtertxt;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button inbtn;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Button Sltbtn;
    }
}