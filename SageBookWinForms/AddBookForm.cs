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
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var work = Form1.Work;
                var bookName = !string.IsNullOrWhiteSpace(textBox1.Text);
                var repository = work.Repository<Book>();
                if (bookName)
                {
                    var book = new Book()
                    {
                        Title = textBox1.Text,
                        Pages = Convert.ToInt32(numericUpDown1.Value)
                    };
                    repository.Add(book);
                    Close();
                }
                else
                {
                    MessageBox.Show("Title is required", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {

        }
    }
}
