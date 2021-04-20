using System.Windows.Forms;

namespace Turbo.plugins.patrick.forms.definitions
{
    using System;

    public partial class AddMasterProfile : Form
    {

        private string name;
        
        private AddMasterProfile()
        {
            InitializeComponent();
        }

        public static string GetNewMasterProfileName()
        {
            var form = new AddMasterProfile();
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

        private void AddMasterProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                b_Save.PerformClick();
            
            if (e.KeyData == Keys.Escape)
                b_Cancel.PerformClick();
        }
    }
}