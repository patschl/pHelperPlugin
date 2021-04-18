using System.Windows.Forms;

namespace Turbo.plugins.patrick.forms.definitions
{
    using System;

    public partial class AddConfigProfile : Form
    {

        private string name;
        
        public AddConfigProfile()
        {
            InitializeComponent();
        }

        public static string GetNewConfigProfileName()
        {
            var form = new AddConfigProfile();
            form.ShowDialog();

            return form.name;
        }

        private void b_Save_Click(object sender, EventArgs e)
        {
            name = tb_ConfigProfileName.Text;
            Close();
        }

        private void b_Cancel_Click(object sender, EventArgs e)
        {
            name = null;
            Close();
        }
    }
}