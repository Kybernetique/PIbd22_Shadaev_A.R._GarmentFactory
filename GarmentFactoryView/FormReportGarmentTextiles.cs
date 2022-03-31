﻿using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.BindingModels;
using System;
using System.Windows.Forms;

namespace GarmentFactoryView
{
    public partial class FormReportGarmentTextiles : Form
    {
        private readonly IReportLogic _logic;

        public FormReportGarmentTextiles(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormReportGarmentTextiles_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetGarmentTextile();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.TextileName, "", ""
                        });
                        foreach (var listElem in elem.Garments)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1,
                            listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount
                            });
                        dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveGarmentTextileToExcelFile(new
                    ReportBindingModel
                    {
                        FileName = dialog.FileName
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
