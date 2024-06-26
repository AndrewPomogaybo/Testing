using System.Windows;
using System.Windows.Input;
using TestMader.ViewModels;

namespace TestMader.Views
{
    public partial class AddUserWindow : Window
    {
        UserViewModel _userViewModel = new UserViewModel();
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow _main = new MainWindow();
            _main.Show();
            this.Close();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameTxtBox.Text == "" || SurnameTxtBox.Text == "" || LoginTxtBox.Text == "" || PwdTxtBox.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _userViewModel.AddUser(NameTxtBox.Text,SurnameTxtBox.Text,LoginTxtBox.Text, PwdTxtBox.Text);
            this.Close();
            MainWindow _main = new MainWindow();
            _main.Show();
        }
    }
}
