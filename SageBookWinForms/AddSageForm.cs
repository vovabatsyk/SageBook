using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALSageBookDB;
using Repository;

namespace SageBookWinForms
{
    public partial class AddSageForm : Form
    {
        public AddSageForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 form1 = new Form1();
                var work = form1.Work;
                var sageName = !string.IsNullOrWhiteSpace(textBox1.Text);
                MessageBox.Show(sageName.ToString());
                IGenericRepository<Sage> repository = work.Repository<Sage>();
                if (sageName)
                {
                    var sage = new Sage()
                    {
                        Name = textBox1.Text,
                        Age = Convert.ToInt32(numericUpDown1.Value)
                    };
                    repository.Add(sage);
                    Close();
                }
                else
                {
                    MessageBox.Show("Name is required", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}
