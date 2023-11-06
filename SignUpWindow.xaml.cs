using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Book_Store
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private DataContext dbContext;
        public SignUpWindow()
        {
            InitializeComponent();
            dbContext = new DataContext();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == textBox.Tag as string)
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Tag as string;
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PassBox.Text;
            string email = EmailBox.Text;

            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Вы ввели неправильный адрес электронной почты. Пожалуйста, используйте адрес Gmail.");
                return;
            }
            if (password.Length < 8 || username.Length < 8)
            {
                MessageBox.Show("Ваш пароль или никнейм слишком короткий! Корректный пароль от 8 символов.");
                return;
            }
            else if (dbContext.Users.Any(user => user.Username == username))
            {
                MessageBox.Show("Пользователь с таким никнеймом уже существует!");
                return;
            }

            UserClass newUser = new UserClass
            {
                Username = username,
                Password = password,
                Email = email
            };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            UsernameBox.Clear();
            PassBox.Clear();
            EmailBox.Clear();
            MessageBox.Show("Вы успешно создали аккаунт!");
        }
    }
}
