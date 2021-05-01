using System;
using System.Linq;
using System.Windows.Forms;
using DALSageBookDB;
using Repository;

namespace SageBookWinForms
{
    public partial class EditSageForm : Form
    {
        private Sage _sage;
        public EditSageForm()
        {
            InitializeComponent();
            ShowData();
        }

        private void ShowData()
        {
            try
            {
                var work = Form1.Work;
                IGenericRepository<Sage> repository = work.Repository<Sage>();
                var data = repository.GetAll().ToList();
                foreach (var sage in data)
                {
                    listBox1.Items.Add(sage);
                }
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                button1.Enabled = true;
                _sage = listBox1.SelectedItem as Sage;
                if (_sage != null)
                {
                    textBox1.Text = _sage.Name;
                    numericUpDown1.Value = _sage.Age;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (_sage != null)
            {
                try
                {
                    var work = Form1.Work;
                    var repository = work.Repository<Sage>();
                    _sage.Name = textBox1.Text;
                    _sage.Age = Convert.ToInt32(numericUpDown1.Value);
                    repository.Update(_sage);

                    listBox1.Items.Clear();
                    ShowData();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show(@"Oooops!!!", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
