using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.ViewModels;


namespace GarmentFactoryView
{
    public partial class FormGarmentTextile : Form
    {
        public int Id
        {
            get { return Convert.ToInt32(comboBoxTextile.SelectedValue); }
            set { comboBoxTextile.SelectedValue = value; }
        }

        public string TextileName { get { return comboBoxTextile.Text; } }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormGarmentTextile(ITextileLogic logic)
        {
            InitializeComponent();

            List<TextileViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxTextile.DisplayMember = "TextileName";
                comboBoxTextile.ValueMember = "Id";
                comboBoxTextile.DataSource = list;
                comboBoxTextile.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxTextile.SelectedValue == null)
            {
                MessageBox.Show("Выберите ткань", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
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
