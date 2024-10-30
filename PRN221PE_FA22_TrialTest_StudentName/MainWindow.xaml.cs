using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using businessObject.Models;
using Services;

namespace PRN221PE_FA22_TrialTest_StudentName_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountServices iAccountService;
        public MainWindow()
        {
            InitializeComponent();
            iAccountService = new HRAccountServices();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iAccountService.GetHraccountByEmail(txtEmail.Text.Trim());
            if(hraccount != null && txtPass.Password.Equals(hraccount.Password) && hraccount.MemberRole==1)
            {
                this.Hide();
                Candidate jobForm = new Candidate(); 
                jobForm.Show();
            }
            else
            {
                {
                    MessageBox.Show("bye");
                }
            }
        }
    }
}