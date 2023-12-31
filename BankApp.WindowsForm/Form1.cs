using BankApp.Core.ServiceManager.Abstraction;

namespace BankApp.WindowsForm
{
    public partial class Form1 : Form
    {
        private IServiceManager _serviceManager;
        BindingSource _bindingTransactions;
        public Form1(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _bindingTransactions = new BindingSource();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text;
            string password = textBox3.Text;
            Label errorMessage = new Label();
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage.Text = "Fill the form";
                MessageBox.Show(errorMessage.Text);
                return;
            }
            Register.Enabled = false;
            var actualDetails = await _serviceManager.AuthenticationService.RegisterUser(email, password);
            if (!actualDetails.status)
            {
                errorMessage.Text = actualDetails.error;
                errorMessage.Visible = true;
            }
            else
            {
                MessageBox.Show("Success");

            }
            Register.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string email =textBox2.Text;
            string password = textBox3.Text;
            Label errorMessage = new Label();
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage.Text = "Enter the right details";
                return;
            }
            button2.Enabled = false;
            var value = await _serviceManager.AuthenticationService.Login(email, password);
            if (value.user == null)
            {
                errorMessage.Text = value.error;
                errorMessage.Visible = true;
            }
            else
            {
                MessageBox.Show("Login Successful");
                _bindingTransactions.DataSource = await _serviceManager.AccountService.GetAccountByUserIdAsync(value.user.Id);
               
            }
            button2.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}