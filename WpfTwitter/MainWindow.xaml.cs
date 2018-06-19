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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCustomMessageBox;
using WpfTwitter.Models;
using WpfTwitter.ViewModels;

namespace WpfTwitter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        List<TweetInfo> list;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.list = new List<TweetInfo>();
            TwitterViewModel viewmodel = new TwitterViewModel();
            list= viewmodel.Get(textbox.Text);
            List<KeyValuePair<string,string>> temp = new List<KeyValuePair<string, string>>();
            foreach(var item in list)
            {
                temp.Add(new KeyValuePair<string, string>(item.Username,item.Tweet));
            }
           
            listbox.ItemsSource = temp;

            }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
             var selected = (KeyValuePair<string,string>)listbox.SelectedItem;
            foreach(var item in list)
            {
                if (selected.Key == item.Username)
                {
                    string address = item.ProfilePic;
                    var image = new Image();                
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(address, UriKind.Absolute);
                    bitmap.EndInit();

                    image.Source = bitmap;
                    wrappanel1.Children.Add(image);
                   
                }
            } 
                
          
        }
    }
}
