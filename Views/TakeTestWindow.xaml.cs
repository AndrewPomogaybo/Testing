using System.Windows;
using System.Windows.Controls;
using TestMader.ViewModels;

namespace TestMader.Views
{
    public partial class TakeTestWindow : Window
    {
        public TakeTestWindow()
        {
            InitializeComponent();
            DataContext = new TakeTestViewModel(TestsListBox);
        }

        private void TestsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TestsListBox.SelectedItem is TestViewModel selectedTest)
            {
                RunTestWindow _runTest = new RunTestWindow(selectedTest);
                _runTest.Show();
                this.Close();
            }
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow _menu = new MenuWindow();
            _menu.Show();
            this.Close();
        }
    }
}

