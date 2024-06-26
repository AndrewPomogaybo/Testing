using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestMader.Models;

namespace TestMader.ViewModels
{
    public class TestViewModel
    {
        public int Test_id { get; set; }
        public string Test_name { get; set; }
        public int Test_user { get; set; }
        public List<Question> Test_questions { get; set; }
        public int QuestionCount => Test_questions?.Count ?? 0;

        public TestViewModel(Test test)
        {
            Test_id = test.Test_id;
            Test_name = test.Test_name;
            Test_user = test.Test_user;
            Test_questions = test.Test_questions;
        }

        public static int GenerateId<T>(List<T> model, string id)
        {
            if (model == null || model.Count == 0)
                return 1;

            PropertyInfo _idProperty = typeof(T).GetProperties()
                                               .FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) || p.Name.Equals(id, StringComparison.OrdinalIgnoreCase));

            return model.Max(item => (int)_idProperty.GetValue(item)) + 1;
        }
    }
}
