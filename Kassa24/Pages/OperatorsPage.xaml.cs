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
    /// Interaction logic for OperatorsPage.xaml
    /// </summary>
    public partial class OperatorsPage : Page
    {
        ModelEntity db = new ModelEntity();
        public OperatorsPage()
        {
            InitializeComponent();
            lvOperators.ItemsSource = db.Table_Operator.ToList();
        }

        private void deleteOperatorMenu_Click(object sender, RoutedEventArgs e)
        {
            Table_Operator data =
               (Table_Operator)(((ListView)lvOperators).SelectedItem);

            using (ModelEntity db = new ModelEntity())
            {
                Table_Operator findOper = db.Table_Operator.Find(data.OperatorId);
                db.Table_Operator.Remove(findOper);

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Удаление прошло успшено!");

                    lvOperators.ItemsSource = db.Table_Operator.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editOperatorMenu_Click(object sender, RoutedEventArgs e)
        {
            Table_Operator data = 
                (Table_Operator)(((ListView)lvOperators).SelectedItem);
            AddOperatorPage op = new AddOperatorPage(data);
            MainWindow.mf.NavigationService.Navigate(op);
        }
    }
}
