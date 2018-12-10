using Kassa24.Model;
using Kassa24.Pages;
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

namespace Kassa24
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame mf { get; set; }
        public static Users user;
        public static Menu _mainMenu;

        public MainWindow()
        {
            InitializeComponent();
            
            mf = MainFrame;//set;
            _mainMenu = MainMenu;

            //1
            MainFrame.Source = 
                new Uri("Pages/LogOnPage.xaml", UriKind.RelativeOrAbsolute);

            //2
            //LogOnPage lp = new LogOnPage();
            //MainFrame.NavigationService.Navigate(lp);
        }
    }
}
