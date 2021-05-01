using System.Linq;
using System.Windows.Forms;
using DALSageBookDB;
using Repository;

namespace SageBookWinForms
{
    public partial class ShowDataForm : Form
    {
        public ShowDataForm(IGenericRepository<Sage> repository)
        {
            InitializeComponent();
            var data = repository.GetAll().ToList();
            dataGridViewShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShow.DataSource = data;
        }

    }
}
