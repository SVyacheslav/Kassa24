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
    /// Interaction logic for AddOperatorPage.xaml
    /// </summary>
    public partial class AddOperatorPage : Page
    {
        public AddOperatorPage(Table_Operator op = null)
        {
            InitializeComponent();
            if (op != null)
            {
                OperatorBind.DataContext = op;

                //изменили текст у кнопки
                btnAddNewOperator.Content = "Редактировать";

                //удадили старую ссылку на метод, который добавлял
                btnAddNewOperator.Click -= btnAddNewOperator_Click;

                //добавили новый метот, который будет сохранять изменения
                btnAddNewOperator.Click += BtnEditNewOperator_Click;
            }
            else
                OperatorBind.DataContext = new Table_Operator();
        }

        private void BtnEditNewOperator_Click(object sender, RoutedEventArgs e)
        {
            Table_Operator oper = 
                (Table_Operator)OperatorBind.DataContext;

            using (ModelEntity db = new ModelEntity())
            {
                //нашли оператора по ID
                Table_Operator fineOp = db.Table_Operator
                                        .Find(oper.OperatorId);

                //заменили  значения в найденном операторе, 
                //на то что ввел пользователь
                fineOp.Logo = oper.Logo;
                fineOp.Name = oper.Name;
                fineOp.Tax = oper.Tax;

                try
                {
                    //сохранили изменения
                    db.SaveChanges();

                    MessageBox.Show("Изменения прошли успешно!");

                    OperatorsPage op = new OperatorsPage();
                    MainWindow.mf.NavigationService.Navigate(op);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
        }

        private int perfCount = 1;
        private void addPrefix_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel wp =
                new WrapPanel() { Orientation = Orientation.Horizontal };
            Label lbl = new Label()
            {
                Content = "Префикс",
                Margin = new Thickness(10)
            };
            wp.Children.Add(lbl);

            TextBox tbx = new TextBox();
            tbx.Name = "Prefix" + perfCount++;
            tbx.Height = 25;
            tbx.FontSize = 14;
            tbx.Width = 150;
            tbx.Margin = new Thickness(10);
            wp.Children.Add(tbx);

            Button btn = new Button();
            btn.Click += addPrefix_Click;
            btn.Content = "Добавить префикс";
            btn.Margin = new Thickness(10);
            wp.Children.Add(btn);

            //Button btnDel = new Button();
            //btnDel.Click += BtnDel_Click;
            //btnDel.Content = "Удалить префикс";
            //btnDel.Margin = new Thickness(10);
            //wp.Children.Add(btnDel);

            stPrefixList.Children.Add(wp);
        }

        private void btnAddNewOperator_Click(object sender, RoutedEventArgs e)
        {
            List<int> prefixes = new List<int>();
            //1 получить префиксы
            foreach (WrapPanel wp in stPrefixList.Children)
            {
                TextBox tb = (TextBox)wp.Children[1];
                int prefix = 0;
                if (Int32.TryParse(tb.Text, out prefix))
                    prefixes.Add(prefix);
            }
            //2 получитьвсе остальные свойства
            Table_Operator oper = (Table_Operator)OperatorBind.DataContext;

            try
            {
                ModelEntity db = new ModelEntity();
                db.Table_Operator.Add(oper);
                db.SaveChanges();

                foreach (int item in prefixes)
                {
                    Table_Prefix pref = new Table_Prefix();
                    pref.OperatorId = oper.OperatorId;
                    pref.Prefix = item.ToString();

                    db.Table_Prefix.Add(pref);
                    db.SaveChanges();
                }

                OperatorBind.DataContext = new Table_Operator();

                MessageBox.Show("Оператор добавлен успешно!");

                OperatorsPage op = new OperatorsPage();
                MainWindow.mf.NavigationService.Navigate(op);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Оператор  не добавле: " + ex.Message);
            }
        }
    }
}
