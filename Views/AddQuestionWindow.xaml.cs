using System.Windows;
using TestMader.Models;
using TestMader.ViewModels;

namespace TestMader.Views
{
    public partial class AddQuestionWindow : Window
    {
        private Test _currentTest;

        public AddQuestionWindow(Test test)
        {
            InitializeComponent();
            _currentTest = test;
        }

        private void AddQuestion_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTestViewModel.AddQuestion(QuestionNameTextBox, QuestionAnswerTextBox, _currentTest);
        }

        private void SaveTest_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTestViewModel.SaveTest(_currentTest);
            MenuWindow _menu = new MenuWindow();
            _menu.Show();   
            this.Close();
        }
    }
}
