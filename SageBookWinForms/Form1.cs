﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //   Book book = new Book(){Title = "JS", Pages = 100};


            //   IGenericRepository<Book> rep = work.Repository<Book>(); 
            //  // rep.Add(new Book(){Title = "JS", Pages = 1000});

            //   var b = rep.FindAll(x => x.Id == 1).ToList()[0];

            //   IGenericRepository<Sage> s = work.Repository<Sage>();
            ////   s.Add(new Sage() { Age = 45, Name = "John" });

            //   var s1 = s.FindAll(x => x.Id == 1).ToList()[0];

            //   var sageID = s1.Id;
            //   var BookId = b.Id;


            //IGenericRepository<SageBook> repository = work.Repository<SageBook>();

            //var sb = new SageBook() { IdBook = BookId, IdSage = sageID };
            //repository.Add(sb);

        }


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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var addSageForm = new AddSageForm();
            addSageForm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var deleteSageForm = new DeleteSageForm();
            deleteSageForm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var deleteBookForm = new DeleteBookForm();
            deleteBookForm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editSageForm = new EditSageForm();
            editSageForm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/vovabatsyk/SageBook");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/vovabatsyk/SageBook");
        }
    }
}
