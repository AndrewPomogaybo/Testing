
using System.Collections.Generic;
using System.Windows.Documents;

namespace TestMader.Models
{
    public class Test
    {
        public int Test_id { get; set; }
        public string Test_name { get; set;}
        public int Test_user {  get; set;}
        public List<Question> Test_questions {  get; set; } = new List<Question>();
    }
}
