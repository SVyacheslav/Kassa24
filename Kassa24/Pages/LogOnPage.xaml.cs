using Kassa24.Model;
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

namespace Kassa24.Pages
{
    /// <summary>
    /// Interaction logic for LogOnPage.xaml
    /// </summary>
    public partial class LogOnPage : Page
    {
        public LogOnPage()
        {
            InitializeComponent();
        }

        private void btnLogOn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxLogOn.Text))
            {
                lblLogin.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (string.IsNullOrWhiteSpace(tbxPassword.Password))
            {
                lblPass.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ModelEntity db = new ModelEntity();
                Users user = db.Users
                             .Where(w =>
                                w.Login == tbxLogOn.Text
                                &&
                                w.Password == tbxPassword.Password)
                             .FirstOrDefault();

                if (user != null)
                {

                    lblLogin.Foreground = new SolidColorBrush(Colors.Black);
                    lblPass.Foreground = new SolidColorBrush(Colors.Black);

                    MainWindow.user = user;

                    //admin
                    if (user.RoleId == 1)
                    {
                        MainWindow.mf.Source =
                        new Uri("Pages/AdminMainPage.xaml",      
                                UriKind.RelativeOrAbsolute);



                        MenuItem miOperator = new MenuItem();
                        miOperator.Header = "Операторы";

                        MenuItem OperatorList = new MenuItem();
                        OperatorList.Header = "Список операторов";
                        OperatorList.Click += OperatorList_Click; ;

                        MenuItem addOperator = new MenuItem();
                        addOperator.Header = "Добавить";
                        addOperator.Click += AddOperator_Click;

                        miOperator.Items.Add(addOperator);
                        miOperator.Items.Add(OperatorList);

                        Separator sep = new Separator();
                        miOperator.Items.Add(sep);

                        MainWindow._mainMenu.Items.Add(miOperator);


                    }
                    //cust
                    else if (user.RoleId == 2)
                    {
                        MainWindow.mf.Source =
                       new Uri("Pages/CustomerMainPage.xaml",
                               UriKind.RelativeOrAbsolute);

                        MenuItem addPayment = new MenuItem();
                        addPayment.Header = "Оплатить";
                        addPayment.Click += AddPayment_Click;

                        MainWindow._mainMenu.Items.Add(addPayment);
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль неверны");
                }

            }
        }

        private void OperatorList_Click(object sender, RoutedEventArgs e)
        {
            OperatorsPage op = new OperatorsPage();
            MainWindow.mf.NavigationService.Navigate(op);
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            PyentPage pp = new PyentPage();
            MainWindow.mf.NavigationService.Navigate(pp);
        }

        private void AddOperator_Click(object sender, RoutedEventArgs e)
        {
            AddOperatorPage lp = new AddOperatorPage();
            MainWindow.mf.NavigationService.Navigate(lp);
        }
    }
}
