using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using TestMader.Models;

namespace TestMader.ViewModels
{
    public class UserViewModel
    {

        private  List<User> _users = new List<User>();

        private  List<User> LoadUsers()
        {
            if (!File.Exists("users.json"))
            {
                return new List<User>();
            }

            string json = File.ReadAllText("users.json");
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        private  void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("users.json", json);
        }

        private  int GenerateId(List<User> users)
        {
            if (users.Count == 0)
            {
                return 1;
            }
            return users.Max(u => u.User_id) + 1;
        }

        public void AddUser(string name, string surname, string login, string pwd)
        {
            var _user = LoadUsers();
            User _newUser = new User
            {
                User_id = GenerateId(_user),
                User_name = name,
                User_surname = surname,
                User_login = login,
                User_password = pwd
            };

            _user.Add(_newUser);
            SaveUsers(_user);
            MessageBox.Show("Вы успешно зарегистрированы");
        }
    }
}
