namespace GarmentFactoryView
{
    partial class FormMessage
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
            this.labelSender = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelReply = new System.Windows.Forms.Label();
            this.textBoxReply = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonReply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSender
            // 
            this.labelSender.AutoSize = true;
            this.labelSender.Location = new System.Drawing.Point(18, 29);
            this.labelSender.Name = "labelSender";
            this.labelSender.Size = new System.Drawing.Size(121, 25);
            this.labelSender.TabIndex = 0;
            this.labelSender.Text = "Отправитель:";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(18, 72);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(53, 25);
            this.labelDateDelivery.TabIndex = 1;
            this.labelDateDelivery.Text = "Дата:";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(18, 117);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(56, 25);
            this.labelSubject.TabIndex = 2;
            this.labelSubject.Text = "Тема:";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(18, 164);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(58, 25);
            this.labelBody.TabIndex = 3;
            this.labelBody.Text = "Текст:";
            // 
            // labelReply
            // 
            this.labelReply.AutoSize = true;
            this.labelReply.Location = new System.Drawing.Point(18, 227);
            this.labelReply.Name = "labelReply";
            this.labelReply.Size = new System.Drawing.Size(63, 25);
            this.labelReply.TabIndex = 4;
            this.labelReply.Text = "Ответ:";
            // 
            // textBoxReply
            // 
            this.textBoxReply.Location = new System.Drawing.Point(87, 227);
            this.textBoxReply.Name = "textBoxReply";
            this.textBoxReply.Size = new System.Drawing.Size(354, 31);
            this.textBoxReply.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(87, 285);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 34);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonReply
            // 
            this.buttonReply.Location = new System.Drawing.Point(270, 285);
            this.buttonReply.Name = "buttonReply";
            this.buttonReply.Size = new System.Drawing.Size(171, 34);
            this.buttonReply.TabIndex = 7;
            this.buttonReply.Text = "Ответить";
            this.buttonReply.UseVisualStyleBackColor = true;
            this.buttonReply.Click += new System.EventHandler(this.buttonReply_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 399);
            this.Controls.Add(this.buttonReply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxReply);
            this.Controls.Add(this.labelReply);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelSender);
            this.Name = "FormMessage";
            this.Text = "Сообщение";
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSender;
        private System.Windows.Forms.Label labelDateDelivery;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelReply;
        private System.Windows.Forms.TextBox textBoxReply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReply;
    }
}