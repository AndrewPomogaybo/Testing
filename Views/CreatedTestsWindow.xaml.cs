using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using TestMader.Models;
using TestMader.ViewModels;

namespace TestMader.Views
{
    public partial class CreatedTestsWindow : Window
    {
        public CreatedTestsWindow()
        {
            InitializeComponent();
            LoadTestsForCurrentUser();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow _menuWindow = new MenuWindow();
            _menuWindow.Show();
            this.Close();
        }

        private void LoadTestsForCurrentUser()
        {
            string jsonFilePath = "tests.json";

            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                var tests = JsonSerializer.Deserialize<List<Test>>(jsonString);

                // Фильтрация тестов по ID пользователя
                int currentUserId = UserSession.Instance._userId;
                var filteredTests = tests.Where(t => t.Test_user == currentUserId).ToList();

                var testViewModels = filteredTests.Select(t => new TestViewModel(t)).ToList();
                TestsListBox.ItemsSource = testViewModels;
            }
            else
            {
                MessageBox.Show("Файл тестов не найден.");
            }
        }

        private void TestsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TestsListBox.SelectedItem is TestViewModel selectedTest)
            {
                RunTestWindow _runTestWindow = new RunTestWindow(selectedTest);
                _runTestWindow.Show();
                this.Close();
            }
        }
    }
}
