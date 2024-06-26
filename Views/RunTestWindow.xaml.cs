using System.Windows;
using TestMader.ViewModels;

namespace TestMader.Views
{
    public partial class RunTestWindow : Window
    {
        private RunTestViewModel _runViewModel;

        public RunTestWindow(TestViewModel test)
        {
            InitializeComponent();
            
            _runViewModel = new RunTestViewModel(test);
            DataContext = _runViewModel;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _runViewModel.NextButtonClickAction();
            UpdateBindings();
        }

        private void UpdateBindings()
        {
            QuestionTextBlock.Text = _runViewModel.QuestionText;
            AnswerTextBox.Text = _runViewModel.AnswerText;
            ResultTextBlock.Text = _runViewModel.ResultText;
            NextButton.IsEnabled = !_runViewModel.IsTestCompleted;
            AnswerTextBox.IsEnabled = !_runViewModel.IsTestCompleted;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            _runViewModel.ExitButtonClickAction();
            this.Close();
        }
    }
}
