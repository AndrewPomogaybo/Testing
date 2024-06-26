using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using TestMader.Models;

namespace TestMader.ViewModels
{
    public class TakeTestViewModel
    {
        public TakeTestViewModel(ListBox test) 
        {
            LoadTestsForCurrentUser(test);
        }

        private static void LoadTestsForCurrentUser(ListBox test)
        {
            string jsonFilePath = "tests.json";

            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                var tests = JsonSerializer.Deserialize<List<Test>>(jsonString);

                // Фильтрация тестов, исключая тесты текущего пользователя
                int currentUserId = UserSession.Instance._userId;
                var filteredTests = tests.Where(t => t.Test_user != currentUserId).ToList();

                var testViewModels = filteredTests.Select(t => new TestViewModel(t)).ToList();
                test.ItemsSource = testViewModels;
            }
            else
            {
                MessageBox.Show("Файл тестов не найден.");
            }
        }
    }
}
