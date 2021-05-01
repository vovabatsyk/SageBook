using System;
using System.Linq;
using System.Windows.Forms;
using DALSageBookDB;

namespace SageBookWinForms
{
    public partial class DeleteSageForm : Form
    {
        private Sage _sage;
        public DeleteSageForm()
        {
            InitializeComponent();
            LoadSages();
        }

        private void LoadSages()
        {
            try
            {
                var work = Form1.Work;
                var repository = work.Repository<Sage>();
                var sages = repository.GetAll().ToList();

                foreach (var sage in sages) comboBoxSages.Items.Add(sage);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _sage = comboBoxSages.SelectedItem as Sage;
                if (_sage != null)
                {
                    var work = Form1.Work;
                    var repository = work.Repository<Sage>();
                    var repositorySageBook = work.Repository<SageBook>();
                    var sageBook = repositorySageBook.GetAll().FirstOrDefault(x => x.IdSage == _sage.Id);
                    if (sageBook == null)
                    {
                        repository.Remove(_sage);
                        Close();
                    }
                    else
                        MessageBox.Show($@"Sage {_sage?.Name} have a book and you can't delete it");
                }
                else
                {
                    MessageBox.Show(@"Oooops!!!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void comboBoxSages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSages.SelectedIndex >= 0) button1.Enabled = true;
        }
    }

}
