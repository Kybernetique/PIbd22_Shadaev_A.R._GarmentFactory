using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.ViewModels;
using PagedList;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace GarmentFactoryView
{
    public partial class FormMessages : Form
    {
        private readonly IMessageInfoLogic logic;

        private bool hasNext = false;

        private readonly int mailsOnPage = 4;

        private int currentPage = 0;

        public FormMessages(IMessageInfoLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            if (mailsOnPage < 1)
            {
                mailsOnPage = 5;
            }
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData();
            labelPageNumber.Text = "1";
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                labelPageNumber.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                buttonNext.Text = "Next " + (currentPage + 2);
                if (currentPage == 0)
                {
                    buttonPrevious.Enabled = false;
                    buttonPrevious.Text = "Previous";
                }
                else
                {
                    buttonPrevious.Text = "Previous" + (currentPage);
                }
                LoadData();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                currentPage++;
                labelPageNumber.Text = (currentPage + 1).ToString();
                buttonPrevious.Enabled = true;
                buttonPrevious.Text = "Previous" + (currentPage);
                LoadData();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormMessage>();
            form.MessageId = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            form.ShowDialog();
            LoadData();
        }

        public void LoadData()
        {
            Program.ConfigGrid(logic.Read(new MessageInfoBindingModel
            {
                ToSkip = currentPage * mailsOnPage,
                ToTake = mailsOnPage + 1
            }), dataGridView);
            labelPageNumber.Text = currentPage.ToString();
            hasNext = !(dataGridView.Rows.Count <= mailsOnPage);
            if (hasNext)
            {
                buttonNext.Text = "Next " + (currentPage + 2);
                buttonNext.Enabled = true;
            }
            else
            {
                buttonNext.Text = "Next";
                buttonNext.Enabled = false;
            }
        }
    }
}
