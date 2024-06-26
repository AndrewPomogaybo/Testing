using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestMader.Models;

namespace TestMader.ViewModels
{
    public class AddTestViewModel
    {
        public static void AddQuestion(TextBox name, TextBox answer, Test _currentTest)
        {
            if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(answer.Text))
            {
                var NewQuestion = new Question
                {
                    Question_name = name.Text,
                    Question_answer = answer.Text
                };

                _currentTest.Test_questions.Add(NewQuestion);

                name.Clear();
                answer.Clear();
            }
            Console.WriteLine($"Вопрос добавлен в тест {_currentTest.Test_name}");
        }

        public static void SaveTest(Test _currentTest)
        {
            // Загрузить существующие тесты
            List<Test> tests;
            string jsonFilePath = "tests.json";

            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                if (!string.IsNullOrWhiteSpace(jsonString))
                    tests = System.Text.Json.JsonSerializer.Deserialize<List<Test>>(jsonString);
                else
                    tests = new List<Test>();
            }
            else
                tests = new List<Test>();

            tests.Add(_currentTest);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonStringNew = System.Text.Json.JsonSerializer.Serialize(tests, options);
            File.WriteAllText(jsonFilePath, jsonStringNew);

            MessageBox.Show("Тест сохранен");
        }
    }
}
