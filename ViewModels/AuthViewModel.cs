using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using TestMader.Models;
using TestMader.Views;

namespace TestMader.ViewModels
{
    public  class AuthViewModel
    {
        private  List<User> _users;
        private  int _userId;

        public Action<string, string> SignInAction => SignInHandler;

        public AuthViewModel() 
        { 
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                string _json = File.ReadAllText("users.json");
                _users = JsonSerializer.Deserialize<List<User>>(_json);
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignInHandler(string login, string pwd)
        {
            if (SignIn(login, pwd))
            {
                MenuWindow _menuWindow = new MenuWindow();
                _menuWindow.Show();
            }
            else
            {
                MessageBox.Show("неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private  bool SignIn(string login, string pwd)
        {
            User _user = _users.FirstOrDefault(u => u.User_login == login && u.User_password == pwd);

            if( _user != null)
            {
                _userId = _user.User_id;
                UserSession.Instance._userId = _userId;
                return true;
            }
                
            return false;
        }
    }
}
