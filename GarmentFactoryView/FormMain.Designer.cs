﻿
namespace GarmentFactoryView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тканиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.швейныеИзделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИзделийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тканиПоИзделиямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1143, 35);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тканиToolStripMenuItem,
            this.швейныеИзделияToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(139, 29);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // тканиToolStripMenuItem
            // 
            this.тканиToolStripMenuItem.Name = "тканиToolStripMenuItem";
            this.тканиToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.тканиToolStripMenuItem.Text = "Ткани";
            this.тканиToolStripMenuItem.Click += new System.EventHandler(this.тканиToolStripMenuItem_Click);
            // 
            // швейныеИзделияToolStripMenuItem
            // 
            this.швейныеИзделияToolStripMenuItem.Name = "швейныеИзделияToolStripMenuItem";
            this.швейныеИзделияToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.швейныеИзделияToolStripMenuItem.Text = "Швейные изделия";
            this.швейныеИзделияToolStripMenuItem.Click += new System.EventHandler(this.швейныеИзделияToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокИзделийToolStripMenuItem,
            this.тканиПоИзделиямToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокИзделийToolStripMenuItem
            // 
            this.списокИзделийToolStripMenuItem.Name = "списокИзделийToolStripMenuItem";
            this.списокИзделийToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.списокИзделийToolStripMenuItem.Text = "Список изделий";
            this.списокИзделийToolStripMenuItem.Click += new System.EventHandler(this.списокИзделийToolStripMenuItem_Click);
            // 
            // тканиПоИзделиямToolStripMenuItem
            // 
            this.тканиПоИзделиямToolStripMenuItem.Name = "тканиПоИзделиямToolStripMenuItem";
            this.тканиПоИзделиямToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.тканиПоИзделиямToolStripMenuItem.Text = "Ткани по изделиям";
            this.тканиПоИзделиямToolStripMenuItem.Click += new System.EventHandler(this.тканиПоИзделиямToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(17, 45);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(894, 685);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(920, 45);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(191, 38);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(920, 93);
            this.buttonTakeOrderInWork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(191, 63);
            this.buttonTakeOrderInWork.TabIndex = 3;
            this.buttonTakeOrderInWork.Text = "Отдать заказ на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(920, 167);
            this.buttonOrderReady.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(191, 38);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(920, 215);
            this.buttonIssuedOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(191, 38);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(920, 263);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(191, 38);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 750);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Швейная фабрика";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тканиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem швейныеИзделияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonIssuedOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИзделийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тканиПоИзделиямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    }
}