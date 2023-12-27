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
using System.Windows.Shapes;

namespace practice_Pogodina
{
    /// <summary>
    /// Логика взаимодействия для ValuesWindow.xaml
    /// </summary>
    public partial class ValuesWindow : Window
    {
        public ValuesWindow()
        {
            InitializeComponent();
        }

        private void AcceptValue_Click(object sender, RoutedEventArgs e)
        {
            bool kConversion = double.TryParse(ValueKTxt.Text, out double k);
            bool bConversion = double.TryParse(ValueBTxt.Text, out double b);

            if (kConversion && bConversion)
            {
                if (k != 0)
                {
                    CalculateClass.k = k;
                    CalculateClass.b = b;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Коэффициент k не может быть равен 0!", "Неверно введены данные!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Неверно введены данные!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox.Text.Contains("Введите"))
            {
                textBox.Text = string.Empty;
            }
            textBox.Foreground = Brushes.Black;
            textBox.FontStyle = FontStyles.Normal;
        }
    }
}
