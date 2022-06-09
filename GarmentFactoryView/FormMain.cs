using System;
using System.Windows.Forms;
using GarmentFactoryBusinessLogic.BusinessLogics;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryFileImplement;
using GarmentFactoryFileImplement.Models;
using Unity;
using System.Reflection;

namespace GarmentFactoryView
{
    public partial class FormMain : Form
    {
        private readonly IOrderLogic _orderLogic;

        private readonly IReportLogic _reportLogic;

        private readonly IImplementerLogic _implementerLogic;

        private readonly IWorkProcess _workProcces;

        private readonly IBackUpLogic _backUpLogic;

        public FormMain(IOrderLogic orderLogic, IReportLogic reportLogic,
            IWorkProcess workProcess, IImplementerLogic implementerLogic,
            IBackUpLogic backUpLogic)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _implementerLogic = implementerLogic;
            _workProcces = workProcess;
            _backUpLogic = backUpLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(_orderLogic.Read(null), dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void тканиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormTextiles>();
            form.ShowDialog();
        }

        private void швейныеИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormGarments>();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouses>();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouseTextile>();
            form.ShowDialog();
        }

        private void buttonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.DeliveryOrder(new ChangeStatusBindingModel
                    {
                        OrderId = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void списокИзделийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MethodInfo method = _reportLogic.GetType().GetMethod("SaveGarmentsToWordFile");
                method.Invoke(_reportLogic, new object[] { new ReportBindingModel { FileName = dialog.FileName } });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void тканиПоИзделиямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportGarmentTextiles>();
            form.ShowDialog();
        }

        private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void информацияОЗаказахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportTotalOrders>();
            form.ShowDialog();
        }

        private void списокСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MethodInfo method = _reportLogic.GetType().GetMethod("SaveWarehousesToWordFile");
                    method.Invoke(_reportLogic, new object[] { new ReportBindingModel { FileName = dialog.FileName } });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        private void тканиПоСкладамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportWarehouseTextiles>();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouseTextile>();
            form.ShowDialog();
        }

        private void складыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouses>();
            form.ShowDialog();
        }

        private void списокИзделийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveGarmentsToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void тканиПоИзделиямToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportGarmentTextiles>();
            form.ShowDialog();
        }

        private void списокЗаказовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void информацияОЗаказахToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportTotalOrders>();
            form.ShowDialog();
        }

        private void списокСкладовToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _reportLogic.SaveWarehousesToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        private void тканиПоСкладамToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportWarehouseTextiles>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void тканиПоСкладамToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportWarehouseTextiles>();
            form.ShowDialog();
        }

        private void запуститьРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workModeling = Program.Container.Resolve<WorkModeling>();
            _workProcces.DoWork(_implementerLogic, _orderLogic);
            LoadData();
        }

        private void сообщенияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormMessages>();
            form.ShowDialog();
        }

        private void создатьБекапToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpLogic.CreateBackUp(new
                        BackUpSaveBinidngModel
                        { FolderName = fbd.SelectedPath });
                        MessageBox.Show("Бекап создан", "Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
