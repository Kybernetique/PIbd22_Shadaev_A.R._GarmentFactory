using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.ViewModels;

namespace GarmentFactoryView
{
    public partial class FormWarehouseTextile : Form
    {
        public int TextileId
        {
            get { return Convert.ToInt32(comboBoxTextile.SelectedValue); }
            set { comboBoxTextile.SelectedValue = value; }
        }

        public int WarehouseId
        {
            get { return Convert.ToInt32(comboBoxWarehouse.SelectedValue); }
            set { comboBoxTextile.SelectedValue = value; }
        }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set { comboBoxTextile.SelectedValue = value; }
        }

        IWarehouseLogic logicWarehouse;
        public FormWarehouseTextile(IWarehouseLogic logicWarehouse, ITextileLogic logicTextile)
        {
            InitializeComponent();
            List<TextileViewModel> listTextile = logicTextile.Read(null);
            if (listTextile != null)
            {
                comboBoxTextile.DisplayMember = "TextileName";
                comboBoxTextile.ValueMember = "Id";
                comboBoxTextile.DataSource = listTextile;
                comboBoxTextile.SelectedItem = null;
            }
            List<WarehouseViewModel> listWarehouse = logicWarehouse.Read(null);
            if (listWarehouse != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = listWarehouse;
                comboBoxWarehouse.SelectedItem = null;
            }
            this.logicWarehouse = logicWarehouse;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxTextile.SelectedValue == null)
            {
                MessageBox.Show("Выберите ткань", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            logicWarehouse.AddTextile(new WarehouseBindingModel { Id = WarehouseId }, TextileId, Count);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
