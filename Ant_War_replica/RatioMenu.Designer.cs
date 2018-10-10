using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Ant_War_replica
{
    partial class RatioMenu
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
            this.next_button = new System.Windows.Forms.Button();
            this.LocationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(167, 308);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(75, 23);
            this.next_button.TabIndex = 0;
            this.next_button.Text = "Next Turn";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // LocationButton
            // 
            this.LocationButton.Location = new System.Drawing.Point(442, 308);
            this.LocationButton.Name = "LocationButton";
            this.LocationButton.Size = new System.Drawing.Size(130, 23);
            this.LocationButton.TabIndex = 1;
            this.LocationButton.Text = "Change Location";
            this.LocationButton.UseVisualStyleBackColor = true;
            this.LocationButton.Click += new System.EventHandler(this.LocationButton_Click);
            // 
            // RatioMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LocationButton);
            this.Controls.Add(this.next_button);
            this.Name = "RatioMenu";
            this.Text = "Temp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button next_button;
        private Button LocationButton;
    }
}