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

namespace Tester_Dictionary
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Page
    {
        MainWindow win = Application.Current.Windows[0] as MainWindow;
        public View()
        {
            InitializeComponent();
            DG.ItemsSource =DictionaryEntities.GetContext().dictionary.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win.Main.Navigate(new Add());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var DelTerm = DG.SelectedItems.Cast<dictionary>().ToList();

            if (DelTerm.Count == 0)
            {
                MessageBox.Show("Вы не выбрали термины для удаления");
                return;
            }

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {DelTerm.Count()} элементов?", "!!!!!!!!!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DictionaryEntities.GetContext().dictionary.RemoveRange(DelTerm);
                    DictionaryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DG.ItemsSource = DictionaryEntities.GetContext().dictionary.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void ChangeProcessing(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DictionaryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DG.ItemsSource = DictionaryEntities.GetContext().dictionary.ToList();
            }
        }
    }
}
