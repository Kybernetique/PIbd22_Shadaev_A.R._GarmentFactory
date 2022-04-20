namespace GarmentFactoryView
{
    partial class FormImplementer
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
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelWorkingTime = new System.Windows.Forms.Label();
            this.labelRestTime = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxRestTime = new System.Windows.Forms.TextBox();
            this.textBoxWorkingTime = new System.Windows.Forms.TextBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(14, 12);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(45, 20);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО:";
            // 
            // labelWorkingTime
            // 
            this.labelWorkingTime.AutoSize = true;
            this.labelWorkingTime.Location = new System.Drawing.Point(14, 48);
            this.labelWorkingTime.Name = "labelWorkingTime";
            this.labelWorkingTime.Size = new System.Drawing.Size(113, 20);
            this.labelWorkingTime.TabIndex = 1;
            this.labelWorkingTime.Text = "Время работы:";
            // 
            // labelRestTime
            // 
            this.labelRestTime.AutoSize = true;
            this.labelRestTime.Location = new System.Drawing.Point(14, 81);
            this.labelRestTime.Name = "labelRestTime";
            this.labelRestTime.Size = new System.Drawing.Size(110, 20);
            this.labelRestTime.TabIndex = 2;
            this.labelRestTime.Text = "Время отдыха:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(303, 116);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 31);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(130, 116);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 31);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxRestTime
            // 
            this.textBoxRestTime.Location = new System.Drawing.Point(130, 81);
            this.textBoxRestTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRestTime.Name = "textBoxRestTime";
            this.textBoxRestTime.Size = new System.Drawing.Size(270, 27);
            this.textBoxRestTime.TabIndex = 5;
            // 
            // textBoxWorkingTime
            // 
            this.textBoxWorkingTime.Location = new System.Drawing.Point(130, 45);
            this.textBoxWorkingTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxWorkingTime.Name = "textBoxWorkingTime";
            this.textBoxWorkingTime.Size = new System.Drawing.Size(270, 27);
            this.textBoxWorkingTime.TabIndex = 6;
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(130, 5);
            this.textBoxFIO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(270, 27);
            this.textBoxFIO.TabIndex = 7;
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 156);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.textBoxWorkingTime);
            this.Controls.Add(this.textBoxRestTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelRestTime);
            this.Controls.Add(this.labelWorkingTime);
            this.Controls.Add(this.labelFIO);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelWorkingTime;
        private System.Windows.Forms.Label labelRestTime;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxRestTime;
        private System.Windows.Forms.TextBox textBoxWorkingTime;
        private System.Windows.Forms.TextBox textBoxFIO;
    }
}