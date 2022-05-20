using GarmentFactoryBusinessLogic.MailWorker;
using GarmentFactoryContracts.BindingModels;
using GarmentFactoryContracts.BusinessLogicsContracts;
using GarmentFactoryContracts.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GarmentFactoryView
{
    public partial class FormMessage : Form
    {
        public string MessageId
        {
            set { _messageId = value; }
        }

        private readonly IMessageInfoLogic _messageLogic;

        private readonly IClientLogic _clientLogic;

        private readonly AbstractMailWorker _mailWorker;

        private string _messageId;

        public FormMessage(IMessageInfoLogic messageLogic, IClientLogic clientLogic, AbstractMailWorker mailWorker)
        {
            InitializeComponent();
            _messageLogic = messageLogic;
            _clientLogic = clientLogic;
            _mailWorker = mailWorker;
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            if (_messageId != null)
            {
                try
                {
                    MessageInfoViewModel view = _messageLogic.Read(new MessageInfoBindingModel { MessageId = _messageId })?[0];
                    if (view != null)
                    {
                        if (view.Viewed.Equals(false))
                        {
                            _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                            {
                                ClientId = _clientLogic.Read(new ClientBindingModel { Email = view.SenderName })?[0].Id,
                                MessageId = _messageId,
                                FromMailAddress = view.SenderName,
                                Subject = view.Subject,
                                Body = view.Body,
                                DateDelivery = view.DateDelivery,
                                Viewed = true,
                                ReplyText = view.ReplyText
                            });
                        }
                        labelSender.Text = view.SenderName;
                        labelDateDelivery.Text = view.DateDelivery.ToString();
                        labelSubject.Text = view.Subject;
                        labelBody.Text = view.Body;
                        textBoxReply.Text = view.ReplyText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonReply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReply.Text))
            {
                MessageBox.Show("Enter text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _mailWorker.MailSendAsync(new MailSendInfoBindingModel
                {
                    MailAddress = labelSender.Text,
                    Subject = "Answer for: " + labelSubject.Text,
                    Text = textBoxReply.Text
                });

                _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                {
                    ClientId = _clientLogic.Read(new ClientBindingModel { Email = labelSender.Text })?[0].Id,
                    MessageId = _messageId,
                    FromMailAddress = labelSender.Text,
                    Subject = labelSubject.Text,
                    Body = labelBody.Text,
                    DateDelivery = DateTime.Parse(labelDateDelivery.Text),
                    Viewed = true,
                    ReplyText = textBoxReply.Text
                });

                MessageBox.Show("Answer sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
