using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;

namespace GarmentFactoryView
{
    public partial class FormReportTotalOrders : Form
    {
        private readonly ReportViewer reportViewer;
        private readonly IReportLogic _logic;

        public FormReportTotalOrders(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            reportViewer.LocalReport.LoadReportDefinition(new
           FileStream("C://Users//Tony//Desktop//ComplexLab4//PIbd22_Shadaev_A.R._GarmentFactory/GarmentFactoryView//ReportTotalOrders.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            panel.Dock = DockStyle.Top;
            Controls.Add(panel);
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = _logic.GetTotalOrders();
                var source = new ReportDataSource("TotalOrders", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToPDF_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveTotalOrdersToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                    });
                    MessageBox.Show("Выполнено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
