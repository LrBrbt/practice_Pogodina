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
using System.Windows.Threading;

namespace practice_Pogodina
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        int countAttempts = 0;
        private DispatcherTimer timer = new DispatcherTimer();
        int time = 10;

        public AutorizationWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;

            if (time <= 0)
            {
                // Если истекло 10 секунд, разблокируем кнопку и остановим таймер
                EnterBtn.IsEnabled = true;
                timer.Stop();
                countAttempts = 0;
                labelTimeTxt.Visibility = Visibility.Hidden;
            }

            // Обновляем отображение времени для пользователя 
            labelTimeTxt.Content = time.ToString();
        }


        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTxt.Text;
            login = login.ToLower();
            if ((login == "admin" || login == "админ") && PasswordTxt.Password == "admin123")
            {
                UserClass.userRole = "admin";
                UserClass.sucsessEnter = true;

                this.Close();
            }
            else if ((login == "user" || login == "пользователь") && PasswordTxt.Password == "1234567890")
            {
                UserClass.userRole = "user";
                UserClass.sucsessEnter = true;
                this.Close();
            }
            else
            {
                countAttempts += 1;
                MessageBox.Show("Неправильный логин и/или пароль!\nОсталось попыток: " + (3 - countAttempts).ToString(), "Вход не выполнен!", MessageBoxButton.OK, MessageBoxImage.Information);
                if (countAttempts == 3)
                {
                    labelTimeTxt.Visibility = Visibility.Visible;
                    EnterBtn.IsEnabled = false;
                    time = 10;
                    timer.Start();
                }
            }

        }

        private void LoginTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Contains("Логин"))
            {
                textBox.Text = string.Empty;
            }
            textBox.Foreground = Brushes.Black;
            textBox.FontStyle = FontStyles.Normal;
        }

        private void PasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox.Password.Contains("Пароль"))
            {
                passwordBox.Password = string.Empty;
            }
            passwordBox.Foreground = Brushes.Black;
            passwordBox.FontStyle = FontStyles.Normal;
        }
    }
}

