using System;
using System.Collections.Generic;
using System.Windows;
using TestMader.Models;
using TestMader.Views;

namespace TestMader.ViewModels
{
    public class RunTestViewModel
    {
        private List<Question> _questions;
        private int _currentQuestionIndex = 1;
        private int _correctAnswers = 0;

        public RunTestViewModel(TestViewModel test)
        {
            _questions = test.Test_questions;
            DisplayCurrentQuestion();
        }

        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string ResultText { get; set; }
        public bool IsTestCompleted { get; set; }

        public Action NextButtonClickAction => Next;
        public Action ExitButtonClickAction => Exit;

        private void DisplayCurrentQuestion()
        {
            if (_currentQuestionIndex <= _questions.Count)
            {
                var question = _questions[_currentQuestionIndex - 1];
                QuestionText = question.Question_name;
                AnswerText = string.Empty;
                ResultText = string.Empty;
                IsTestCompleted = false;
            }
            else
            {
                ResultText = $"Вы завершили тест. \nПравильных ответов: {_correctAnswers} из {_questions.Count}";
                QuestionText = string.Empty;
                IsTestCompleted = true;
            }
        }

        private void Next()
        {
            if (!string.IsNullOrWhiteSpace(AnswerText))
            {
                var question = _questions[_currentQuestionIndex - 1];
                if (AnswerText.Trim().Equals(question.Question_answer, StringComparison.OrdinalIgnoreCase))
                {
                    _correctAnswers++;
                }
                _currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите ответ.");
            }
        }

        private void Exit()
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
            }
        }
    }
}
