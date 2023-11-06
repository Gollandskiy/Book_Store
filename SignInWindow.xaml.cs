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
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        private DataContext dbContext;
        public SignInWindow()
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
        public UserClass FindUser(string username, string password)
        {
            using (DataContext context = new DataContext())
            {
                UserClass user = context.Users
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                return user;
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PassBox.Text;

            UserClass foundUser = FindUser(username, password);

            if (foundUser != null)
            {
                this.Hide();
                new StoreWindow().ShowDialog();
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
            }
        }
    }
}
