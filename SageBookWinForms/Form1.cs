using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using DALSageBookDB;
using Repository;

namespace SageBookWinForms
{
    public partial class Form1 : Form
    {
        public static GenericUnitOfWork Work;
        public Form1()
        {
            InitializeComponent();
            var conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            Work = new GenericUnitOfWork(new SageBookContext(conStr));
            dataGridViewShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ShowDataSageBook();
        }

        #region ShowData

        private void ShowDataSageBook()
        {
            try
            {
                var repository = Work.Repository<SageBook>();
                var repositoryBook = Work.Repository<Book>();
                var repositorySage = Work.Repository<Sage>();

                var sageBook = repository.GetAll().ToList();
                var data = sageBook.Select(x => new
                {
                    Book_Title = repositoryBook.FindById(x.IdBook).Title,
                    Book_Pages = repositoryBook.FindById(x.IdBook).Pages,
                    Sage_Name = repositorySage.FindById(x.IdSage).Name,
                    Sage_Age = repositorySage.FindById(x.IdSage).Age
                }).ToList();

                dataGridViewShow.DataSource = data;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowDataBook()
        {
            IGenericRepository<Book> repository = Work.Repository<Book>();
            try
            {
                var books = repository.GetAll();
                var data = books.Select(x => new
                {
                    Book_Title = x.Title,
                    Book_Pages = x.Pages
                }).ToList();

                dataGridViewShow.DataSource = data;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowDataSage()
        {
            try
            {
                IGenericRepository<Sage> repository = Work.Repository<Sage>();

                var sages = repository.GetAll();
                var data = sages.Select(x => new
                {
                    Sage_Name = x.Name,
                    Sage_Age = x.Age
                }).ToList();

                dataGridViewShow.DataSource = data;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region StripMenu

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDataSage();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ShowDataBook();
        }

        private void showToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowDataSageBook();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new AddUpdateDeleteForm("AddSage", "Sage");
            form.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var form = new AddUpdateDeleteForm("AddBook", "Book");
            form.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var form = new AddUpdateDeleteForm("DeleteSage", "Sage");
            form.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddUpdateDeleteForm("DeleteBook", "Book");
            form.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddUpdateDeleteForm("UpdateSage", "Sage");
            form.ShowDialog();
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new AddUpdateDeleteForm("UpdateBook", "Book");
            form.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sageBook = new AddUpdateDeleteSageBook("Add");
            sageBook.ShowDialog();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var sageBook = new AddUpdateDeleteSageBook("Delete");
            sageBook.ShowDialog();
        }

        private void updateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var sageBook = new AddUpdateDeleteSageBook("Update");
            sageBook.ShowDialog();
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/vovabatsyk/SageBook");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
