using System.Windows;
using System.Windows.Input;
using TestMader.ViewModels;
using TestMader.Views;

namespace TestMader
{
    public partial class MainWindow : Window
    {
        private AuthViewModel _authViewModel = new AuthViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_btn_Click(object sender, RoutedEventArgs e)
        {
            _authViewModel.SignInAction(Logintextbox.Text, Passwordtextbox.Password);
        }

        private void Exit_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйти?","Внимание",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch { return; }
        }

        private void SignUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddUserWindow _addUser = new AddUserWindow();
            _addUser.Show();
            this.Close();
        }
    }
}
