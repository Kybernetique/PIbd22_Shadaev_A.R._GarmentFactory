using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.ViewModels;
using Unity;

namespace GarmentFactoryView
{
    public partial class FormGarment : Form
    {
        public int Id { set { id = value; } }

        private readonly IGarmentLogic _logic;

        private int? id;

        private Dictionary<int, (string, int)> garmentTextiles;

        public FormGarment(IGarmentLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormGarment_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    GarmentViewModel view = _logic.Read(new GarmentBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.GarmentName;
                        textBoxPrice.Text = view.Price.ToString();
                        garmentTextiles = view.GarmentTextiles;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                garmentTextiles = new Dictionary<int, (string, int)>();
            }

        }

        private void LoadData()
        {
            try
            {
                if (garmentTextiles != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var gt in garmentTextiles)
                    {
                        dataGridView.Rows.Add(new object[] { gt.Key, gt.Value.Item1,
                        gt.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormGarmentTextile>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (garmentTextiles.ContainsKey(form.Id))
                {
                    garmentTextiles[form.Id] = (form.TextileName, form.Count);
                }
                else
                {
                    garmentTextiles.Add(form.Id, (form.TextileName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormGarmentTextile>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = garmentTextiles[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    garmentTextiles[form.Id] = (form.TextileName, form.Count);
                    LoadData();
                }
            }

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        garmentTextiles.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,

                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (garmentTextiles == null || garmentTextiles.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new GarmentBindingModel
                {
                    Id = id,
                    GarmentName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    GarmentTextiles = garmentTextiles
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
