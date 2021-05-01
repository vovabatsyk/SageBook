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
    public partial class DeleteBookForm : Form
    {
        private List<Book> _books = new List<Book>();

        public DeleteBookForm()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var bookTitle = comboBox1.SelectedItem.ToString();
                var book = _books.FirstOrDefault(x => x.Title == bookTitle);
                if (book != null)
                {
                    var work = Form1.Work;
                    IGenericRepository<Book> repository = work.Repository<Book>();
                    IGenericRepository<SageBook> repositorySageBook = work.Repository<SageBook>();
                    var sageBook = repositorySageBook.GetAll().FirstOrDefault(x => x.IdBook == book.Id);
                    if (sageBook == null)
                    {
                        repository.Remove(book);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($@"Book '{book.Title}' have a sage and you can't delete it");
                    }
                }
                else
                {
                    MessageBox.Show("Oooops!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                button1.Enabled = true;
            }
        }

  

        private void LoadBooks()
        {
            try
            {
                var work = Form1.Work;
                var repository = work.Repository<Book>();
                var sages = repository.GetAll().ToList();

                foreach (var sage in sages)
                {
                    _books.Add(sage);
                    comboBox1.Items.Add(sage.Title);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
