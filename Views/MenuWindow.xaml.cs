using System.Windows;
using System.Windows.Input;

namespace TestMader.Views
{

    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {
            CreateTestWindow _createTest = new CreateTestWindow();
            _createTest.Show();
            this.Close();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow _main = new MainWindow();
                _main.Show();
                this.Close();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch{}
        }

        private void RunTest_btn_Click(object sender, RoutedEventArgs e)
        {
            TakeTestWindow _takeTest = new TakeTestWindow();
            _takeTest.Show();
            this.Close();
        }

        private void WatchTests_Click(object sender, RoutedEventArgs e)
        {
            CreatedTestsWindow _createdTests = new CreatedTestsWindow();
            _createdTests.Show();
            this.Close();
        }
    }
}
