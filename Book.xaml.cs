using System;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Book_Store
{
    public partial class Book : UserControl
    {
        public Book()
        {
            InitializeComponent();
        }
        public string Style
        {
            get { return (string)GetValue(StyleProperty); }
            set { SetValue(StyleProperty, value); }
        }

        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.Register("Style", typeof(string), typeof(Book));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(Book));
        public string NameAuthor
        {
            get { return (string)GetValue(NameAuthorProperty); }
            set { SetValue(NameAuthorProperty, value); }
        }

        public static readonly DependencyProperty NameAuthorProperty =
            DependencyProperty.Register("NameAuthor", typeof(string), typeof(Book));

        public string SubnameAuthor
        {
            get { return (string)GetValue(SubnameAuthorProperty); }
            set { SetValue(SubnameAuthorProperty, value); }
        }

        public static readonly DependencyProperty SubnameAuthorProperty =
            DependencyProperty.Register("SubnameAuthor", typeof(string), typeof(Book));

        public float Price
        {
            get { return (float)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(float), typeof(Book));

        public string ImageURL
        {
            get { return (string)GetValue(ImageURLProperty); }
            set { SetValue(ImageURLProperty, value); }
        }

        public static readonly DependencyProperty ImageURLProperty =
            DependencyProperty.Register("ImageURL", typeof(string), typeof(Book), new PropertyMetadata(OnImageURLChanged));

        private static void OnImageURLChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Book book && e.NewValue is string imageURL)
            {
                book.LoadBook(imageURL);
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Book));

        private async void LoadBook(string imageURL)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(imageURL);
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new System.IO.MemoryStream(imageBytes);
                    bitmapImage.EndInit();
                    BookImage.Source = bitmapImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BookTitle.Text = Title;            
        }
    }
 }
