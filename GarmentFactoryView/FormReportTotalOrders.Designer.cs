﻿namespace GarmentFactoryView
{
    partial class FormReportTotalOrders
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
            this.panel = new System.Windows.Forms.Panel();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPDF = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonToPDF);
            this.panel.Controls.Add(this.buttonMake);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(776, 36);
            this.panel.TabIndex = 0;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(3, 3);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(109, 30);
            this.buttonMake.TabIndex = 0;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // buttonToPDF
            // 
            this.buttonToPDF.Location = new System.Drawing.Point(118, 3);
            this.buttonToPDF.Name = "buttonToPDF";
            this.buttonToPDF.Size = new System.Drawing.Size(109, 30);
            this.buttonToPDF.TabIndex = 1;
            this.buttonToPDF.Text = "В Pdf";
            this.buttonToPDF.UseVisualStyleBackColor = true;
            this.buttonToPDF.Click += new System.EventHandler(this.buttonToPDF_Click);
            // 
            // FormReportTotalOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Name = "FormReportTotalOrders";
            this.Text = "Заказы по датам";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonToPDF;
        private System.Windows.Forms.Button buttonMake;
    }
}