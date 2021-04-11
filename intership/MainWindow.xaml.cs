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
using intership.dict;

namespace intership
// связь логики поиска с элементами UI интерфейса
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dict dictSearch = new Dict("word.txt");
        public MainWindow()
        {
            InitializeComponent();
        }
        // проверка на добавление поиска по последовательным символам
        private void symbols(object sender, RoutedEventArgs e)
        {
           if (Check.IsChecked.Value)
            {
                dictSearch.temp = 1;
            }
            else
            {
                dictSearch.temp = 0;
            }
        }
        // реализация ввода слова и вывода результата 
        private void search(object sender, RoutedEventArgs e)
        {
            string text = In.Text;
            string[] ans = dictSearch.search(text);
            Out.Text = "";

            string Text = " ";
            
            for (int i = 0; i < ans.Length; i++)
            {
                if (i >= 5000)
                {
                    Text = "Показано " + i + " результатов из " + ans.Length + " :" + "\r\n" + "\r\n" + Text;
                    break;
                }
                Text += ans[i];
                Text += "\r\n";
            }
            if (Text[0] == 'П')
            {
                Out.Text += Text;
            }
            else
            {
                Text = "Показано " + ans.Length + " результатов из " + ans.Length + " :" + "\r\n" + "\r\n" + Text;
                Out.Text += Text;
            }
        }
    }
}
