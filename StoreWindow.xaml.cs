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
    /// Логика взаимодействия для StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        private List <Book> books;
        private List<Book> filteredBooks;
        public StoreWindow()
        {
            InitializeComponent();
            DataContext dbContext = new DataContext();

            books = dbContext.Books.Select(item => new Book
            {
                Title = item.Name,
                ImageURL = item.Image,
                Description = item.Description,
                Style = item.Style,
                NameAuthor = item.NameAuthor,
                SubnameAuthor = item.SubnameAuthor,
                Price = item.Price
            }).ToList();
            bookListView.ItemsSource = books;
        }

        private void bookListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bookListView.SelectedItem != null)
            {
                Book selectedBook = (Book)bookListView.SelectedItem;
                DescriptionWindow descriptionWindow = new DescriptionWindow(selectedBook);
                descriptionWindow.Show();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox SearchTextBox = (TextBox)sender;
            if (SearchTextBox.Text == SearchTextBox.Tag as string)
            {
                SearchTextBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox SearchTextBox = (TextBox)sender;
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                SearchTextBox.Text = SearchTextBox.Tag as string;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text ?? string.Empty;
            SearchByTitle(searchText);
        }
        private void SearchByTitle(string searchText)
        {
            if (books != null)
            {
                filteredBooks = books.Where(book => book.Title != null && book.Title.ToLower().Contains(searchText)).ToList();
                bookListView.ItemsSource = filteredBooks;
            }
        }
    }
}
