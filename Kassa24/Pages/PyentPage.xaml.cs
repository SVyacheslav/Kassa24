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
    /// Interaction logic for PyentPage.xaml
    /// </summary>
    public partial class PyentPage : Page
    {
        ModelEntity db = new ModelEntity();

        public PyentPage()
        {
            InitializeComponent();

            lbOperators.ItemsSource = db.Table_Operator.ToList();
        }

        private void lbOperators_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Table_Operator to = 
                (Table_Operator)((ListBox)sender).SelectedItem;

            cmPrefix.ItemsSource = db.Table_Prefix.Where(w => w.OperatorId == to.OperatorId).ToList();
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            Table_Payments payment = new Table_Payments();
            payment.Amount = Int32.Parse(tbxAmount.Text);
            payment.OperatorId = 
                ((Table_Operator)lbOperators.SelectedItem).OperatorId;
            payment.PrefixId = 
                ((Table_Prefix)cmPrefix.SelectedItem).PrefixId;
            payment.CreateDate = DateTime.Now;
            payment.CreateUser = MainWindow.user.UserId;
            payment.Table_Operator = db.Table_Operator.Find(payment.OperatorId);

            using (ModelEntity db = new ModelEntity())
            {
                try
                {
                    db.Table_Payments.Add(payment);
                    db.SaveChanges();

                    BillWindow billWindow = new BillWindow(payment);
                    billWindow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
           
        }
    }
}
