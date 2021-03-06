using System;
using System.Linq;
using System.Windows.Forms;
using DALSageBookDB;
using Repository;

namespace SageBookWinForms
{
    public partial class AddUpdateDeleteSageBook : Form
    {
        private readonly string _flag;
        public AddUpdateDeleteSageBook(string flag)
        {
            _flag = flag;
            InitializeComponent();
            LoadData();
            ChangeState(_flag);
        }

        #region Events

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_flag)
            {
                case "Add":
                    AddSageBook();
                    break;
                case "Delete":
                    DeleteSageBook();
                    break;
                case "Update":
                    UpdateSageBook();
                    break;
            }
        }
        
        private void listBoxSageBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flag == "Update")
            {
                if (listBoxSageBook.SelectedIndex >= 0)
                {
                    listBoxBook.Enabled = true;
                    listBoxSage.Enabled = true;
                }
            }
        }

        #endregion

        #region Methods

        private void LoadData()
        {
            LoadBooks();
            LoadSages();
            LoadSageBooks();
        }

        private void LoadBooks()
        {
            try
            {
                var work = Form1.Work;
                IGenericRepository<Book> repository = work.Repository<Book>();
                var data = repository.GetAll().ToList();
                foreach (var book in data)
                {
                    listBoxBook.Items.Add(book);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadSages()
        {
            try
            {
                var work = Form1.Work;
                IGenericRepository<Sage> repository = work.Repository<Sage>();
                var data = repository.GetAll().ToList();
                foreach (var sage in data)
                {
                    listBoxSage.Items.Add(sage);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadSageBooks()
        {
            try
            {
                var work = Form1.Work;

                var repository = work.Repository<SageBook>();
                var repositoryBook = work.Repository<Book>();
                var repositorySage = work.Repository<Sage>();

                var sageBook = repository.GetAll().ToList();
                var data = sageBook.Select(x => new NewSageBook()
                {
                    Id = x.Id,
                    IdBook = x.IdBook,
                    IdSage = x.IdSage,
                    BookTitle = repositoryBook.FindById(x.IdBook).Title,
                    BookPages = repositoryBook.FindById(x.IdBook).Pages,
                    SageName = repositorySage.FindById(x.IdSage).Name,
                    SageAge = repositorySage.FindById(x.IdSage).Age
                }).ToList();

                foreach (var newSageBook in data)
                {
                    listBoxSageBook.Items.Add(newSageBook);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ChangeState(string flag)
        {
            switch (flag)
            {
                case "Add":
                    listBoxBook.Enabled = true;
                    listBoxSage.Enabled = true;
                    break;
                case "Delete":
                    listBoxSageBook.Enabled = true;
                    break;
                case "Update":
                    listBoxSageBook.Enabled = true;
                    break;
            }
        }

        private void AddSageBook()
        {
            var sage = listBoxSage.SelectedItem as Sage;
            var book = listBoxBook.SelectedItem as Book;
            var work = Form1.Work;
            IGenericRepository<SageBook> repository = work.Repository<SageBook>();
            if (sage != null)
            {
                if (book != null)
                {
                    var sageBook = new SageBook()
                    {
                        IdBook = book.Id,
                        IdSage = sage.Id
                    };

                    var isSageBook = repository.GetAll()
                        .FirstOrDefault(x => x.IdBook == book.Id && x.IdSage == sage.Id);
                    
                    if (isSageBook == null)
                        repository.Add(sageBook);
                    else
                        MessageBox.Show(@"SageBook already exists");

                }

                listBoxSageBook.Items.Clear();
                LoadSageBooks();
            }




        }


        private void DeleteSageBook()
        {
            try
            {
                var work = Form1.Work;
                var repository = work.Repository<SageBook>();
                if (listBoxSageBook.SelectedItem is NewSageBook item)
                {
                    var sageBook = repository.FindById(item.Id);
                    repository.Remove(sageBook);
                    listBoxSageBook.Items.Clear();
                    LoadSageBooks();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateSageBook()
        {
            try
            {
                var work = Form1.Work;
                var repository = work.Repository<SageBook>();

                var book = listBoxBook.SelectedItem as Book;
                var sage = listBoxSage.SelectedItem as Sage;
                if (listBoxSageBook.SelectedItem is NewSageBook item)
                {
                    var sageBook = repository.FindById(item.Id);
                    if (book != null) sageBook.IdBook = book.Id;
                    if (sage != null) sageBook.IdSage = sage.Id;
                    repository.Update(sageBook);
                    listBoxSageBook.Items.Clear();
                    listBoxSage.Enabled = false;
                    listBoxBook.Enabled = false;
                    LoadSageBooks();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

    }

    #region HelperClass

    public class NewSageBook
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public int IdSage { get; set; }
        public string BookTitle { get; set; }
        public int BookPages { get; set; }
        public string SageName { get; set; }
        public int SageAge { get; set; }
        public override string ToString() => $"Sage name: {SageName}, sage age: {SageAge}, book title: {BookTitle}, book pages: {BookPages}";
    }
    
    #endregion

}
