using System;
using System.Linq;
using System.Windows.Forms;
using DALSageBookDB;
using Repository;
using static System.Decimal;
using static System.String;

namespace SageBookWinForms
{
    public partial class AddUpdateDeleteForm : Form
    {
        private readonly string _flag;
        private readonly string _load;
     
        public AddUpdateDeleteForm(string flag, string load)
        {
            InitializeComponent();
            _flag = flag;
            _load = load;

            ControlsName(_flag);
            LoadData(_load);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
            {
                switch (_flag)
                {
                    case "UpdateSage":
                    {
                        textBox1.Enabled = true;
                        numericUpDown1.Enabled = true;
                        if (listBox.SelectedItem is Sage sage)
                        {
                            textBox1.Text = sage.Name;
                            numericUpDown1.Value = sage.Age;
                        }
                        button1.Enabled = true;
                        break;
                    }
                    case "DeleteSage":
                        button1.Enabled = true;
                        break;

                    case "UpdateBook":
                    {
                        textBox1.Enabled = true;
                        numericUpDown1.Enabled = true;
                        if (listBox.SelectedItem is Book book)
                        {
                            textBox1.Text = book.Title;
                            numericUpDown1.Value = book.Pages;
                        }
                        button1.Enabled = true;
                        break;
                    }
                    case "DeleteBook":
                        button1.Enabled = true;
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_flag)
            {
                case "AddSage":
                    AddSage();
                    break;
                case "DeleteSage":
                    DeleteSage();
                    break;
                case "UpdateSage":
                    UpdateSage();
                    break;
                case "AddBook":
                    AddBook();
                    break;
                case "DeleteBook":
                    DeleteBook();
                    break;
                case "UpdateBook":
                    UpdateBook();
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void ControlsName(string flag)
        {
            switch (flag)
            {
                case "AddSage":
                    groupBox1.Text = @"Add Sage";
                    button1.Text = @"Add";
                    textBox1.Enabled = true;
                    numericUpDown1.Enabled = true;
                    break;
                case "UpdateSage":
                    groupBox1.Text = @"Update Sage";
                    button1.Text = @"Save";
                    break;
                case "DeleteSage":
                    groupBox1.Text = @"Delete Sage";
                    button1.Text = @"Delete";
                    break;

                case "AddBook":
                    groupBox1.Text = @"Add Book";
                    button1.Text = @"Add";
                    textBox1.Enabled = true;
                    numericUpDown1.Enabled = true;
                    break;
                case "UpdateBook":
                    groupBox1.Text = @"Update Book";
                    button1.Text = @"Save";
                    break;
                case "DeleteBook":
                    groupBox1.Text = @"Delete Book";
                    button1.Text = @"Delete";
                    break;
            }
        }

        private void LoadData(string load)
        {
            if (load == "Sage")
            {
                label1.Text = @"Name";
                label2.Text = @"Age";
                numericUpDown1.Maximum = 110;
                try
                {
                    var work = Form1.Work;
                    IGenericRepository<Sage> repository = work.Repository<Sage>();
                    var data = repository.GetAll().ToList();
                    foreach (var sage in data)
                    {
                        listBox.Items.Add(sage);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (load == "Book")
            {
                label1.Text = @"Title";
                label2.Text = @"Pages";
                numericUpDown1.Maximum = 10000;
                try
                {
                    var work = Form1.Work;
                    IGenericRepository<Book> repository = work.Repository<Book>();
                    var data = repository.GetAll().ToList();
                    foreach (var book in data)
                    {
                        listBox.Items.Add(book);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        private void AddSage()
        {
            try
            {
                if (!IsNullOrWhiteSpace(textBox1.Text))
                {

                    var work = Form1.Work;
                    IGenericRepository<Sage> repository = work.Repository<Sage>();
                    var sage = new Sage()
                    {
                        Name = textBox1.Text,
                        Age = Convert.ToInt32(numericUpDown1.Value)
                    };
                    repository.Add(sage);
                    listBox.Items.Clear();
                    textBox1.Text = Empty;
                    numericUpDown1.Value = Zero;
                    button1.Enabled = false;
                    LoadData(_load);
                }
                else
                {
                    MessageBox.Show(@"All fields are required", Empty, MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddBook()
        {
            try
            {
                if (!IsNullOrWhiteSpace(textBox1.Text))
                {

                    var work = Form1.Work;
                    IGenericRepository<Book> repository = work.Repository<Book>();
                    var book = new Book()
                    {
                        Title = textBox1.Text,
                        Pages = Convert.ToInt32(numericUpDown1.Value)
                    };
                    repository.Add(book);
                    listBox.Items.Clear();
                    textBox1.Text = Empty;
                    numericUpDown1.Value = Zero;
                    button1.Enabled = false;
                    LoadData(_load);
                }
                else
                {
                    MessageBox.Show(@"All fields are required", Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DeleteSage()
        {
            try
            {
                if (listBox.SelectedIndex >=0)
                {

                    var work = Form1.Work;
                    IGenericRepository<Sage> repository = work.Repository<Sage>();
                    var sage = listBox.SelectedItem as  Sage;
                    repository.Remove(sage);
                    listBox.Items.Clear();
                    button1.Enabled = false;
                    LoadData(_load);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DeleteBook()
        {
            try
            {
                if (listBox.SelectedIndex >= 0)
                {

                    var work = Form1.Work;
                    IGenericRepository<Book> repository = work.Repository<Book>();
                    var book = listBox.SelectedItem as Book;
                    repository.Remove(book);
                    listBox.Items.Clear();
                    button1.Enabled = false;
                    LoadData(_load);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateSage()
        {
            try
            {
                if (listBox.SelectedIndex >= 0)
                {

                    var work = Form1.Work;
                    IGenericRepository<Sage> repository = work.Repository<Sage>();
                    if (listBox.SelectedItem is Sage sage)
                    {
                        sage.Name = textBox1.Text;
                        sage.Age = Convert.ToInt32(numericUpDown1.Value);
                        repository.Update(sage);
                    }

                    listBox.Items.Clear();
                    textBox1.Text = Empty;
                    numericUpDown1.Value = Zero;
                    button1.Enabled = false;
                    textBox1.Enabled = false;
                    numericUpDown1.Enabled = false;
                    LoadData(_load);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void UpdateBook()
        {
            try
            {
                if (listBox.SelectedIndex >= 0)
                {

                    var work = Form1.Work;
                    IGenericRepository<Book> repository = work.Repository<Book>();
                    var book = listBox.SelectedItem as Book;
                    if (book != null)
                    {
                        book.Title = textBox1.Text;
                        book.Pages = Convert.ToInt32(numericUpDown1.Value);
                        repository.Update(book);
                    }

                    listBox.Items.Clear();
                    textBox1.Text = Empty;
                    numericUpDown1.Value = Zero;
                    textBox1.Enabled = false;
                    numericUpDown1.Enabled = false;
                    button1.Enabled = false;
                    LoadData(_load);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

       
    }
}
