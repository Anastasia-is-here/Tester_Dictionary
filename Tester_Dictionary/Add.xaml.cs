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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Add : Page
    {
        private dictionary _currentDict = new dictionary();
        MainWindow win = Application.Current.Windows[0] as MainWindow;
        public Add()
        {
            InitializeComponent();
            DataContext = _currentDict;
        }

        public void AddTerm()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(term.Text))
            {
                errors.AppendLine("Введите термин");
            }
            if (string.IsNullOrWhiteSpace(definition.Text))
            {
                errors.AppendLine("Введите определение для термина");
            }
            if (string.IsNullOrWhiteSpace(source.Text))
            {
                errors.AppendLine("Введите ссылку на источник");
            }
            if (errors.Length != 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            dictionary _newTerm = new dictionary();
            _newTerm.термин = term.Text;
            _newTerm.описание = definition.Text;
            _newTerm.источник = source.Text;

            if (_newTerm.id == 0)
            {
                DictionaryEntities.GetContext().dictionary.Add(_newTerm);
            }

            try
            {
                DictionaryEntities.GetContext().SaveChanges();
                MessageBox.Show("Новый термин успешно сохранён");
                term.Clear();
                definition.Clear();
                source.Clear();
                win.Main.Navigate(new View());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           AddTerm();
           
        }
    }
}
