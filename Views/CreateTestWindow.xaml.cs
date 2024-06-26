using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TestMader.Models;
using TestMader.ViewModels;

namespace TestMader.Views
{

    public partial class CreateTestWindow : Window
    {
        public Test _currentTest;
        private List<Test> _tests;
        public CreateTestWindow()
        {
            InitializeComponent();
            _currentTest = new Test
            {
                Test_questions = new List<Question>() 
            };
        }

        private void Next_btn_Click(object sender, RoutedEventArgs e)
        {
            if (NametestTextbox.Text == "")
                Error_txtbox.Visibility = Visibility.Visible;
            else
            {
                _currentTest.Test_name = NametestTextbox.Text;
                _currentTest.Test_user = UserSession.Instance._userId;
                _currentTest.Test_id = TestViewModel.GenerateId(_tests,"Test_id");
                AddQuestionWindow _addQuestion = new AddQuestionWindow(_currentTest);
                _addQuestion.Show();
            }
        }

        private void Exit_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MenuWindow _menu = new MenuWindow();
                _menu.Show();
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
    }
}
