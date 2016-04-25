using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InputValidating
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            string msg = "";
            if (!Regex.IsMatch(txtName.Text, @"^([A-Za-z]*\s*)*$"))
                msg += "Name is invalid (only alphabetical characters allowed)\n";
            if (!Regex.IsMatch(txtPhone.Text, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$"))
                msg += "Phone number is not a valid US phone number!\n";
            if (!Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-” [email protected]\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                msg += "E-mail address is invalid!\n";
            if (msg.Length > 0)
                MessageBox.Show(msg, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
