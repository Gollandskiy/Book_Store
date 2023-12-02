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
using System.Diagnostics;

namespace Book_Store
{
    /// <summary>
    /// Логика взаимодействия для DescriptionWindow.xaml
    /// </summary>
    public partial class DescriptionWindow : Window
    {
        public DescriptionWindow(Book book)
        {
            InitializeComponent();
            DataContext = book;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Open(@"D:\HTML и CSS и JS ШАГ\28.11.2023(Ekz)\GBooks.html");
        }
        private void Open(string site)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = site,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии браузера: {ex.Message}");
            }
        }


    }
}
