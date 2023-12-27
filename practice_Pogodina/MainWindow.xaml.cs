using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace practice_Pogodina
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CanvasContainer.MouseWheel += GraphCanvas_MouseWheel;
        }

        //Текущий масштаб
        private double currentScale = 1.0;

        private void GraphCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Увеличиваем или уменьшаем на 10%
            double scaleChange = (e.Delta > 0) ? 1.1 : 0.9;
            currentScale *= scaleChange;

            //Изменение масштаба при прокрутке
            CanvasContainer.LayoutTransform = new ScaleTransform(currentScale, currentScale);

            e.Handled = true;
        }

        //Объявление и инициализация линии графика
        Polyline polyline = new Polyline();

        //Событие кнопки "Построить график"
        private void BuildGraphik_Click(object sender, RoutedEventArgs e)
        {
            //Если роль пользователя admin
            if (UserClass.userRole == "admin")
            {
                //Проверка на отсутствие уже построенных графиков на поле
                if (CanvasContainer.Children.Count == 19)
                {
                    //Окно ввода коэффициентов k и b
                    ValuesWindow setValues = new ValuesWindow();
                    setValues.ShowDialog();

                    //Построение графика
                    Polyline graph = CalculateClass.CalculateFunction();

                    //Добавление графика на поле
                    CanvasContainer.Children.Add(graph);

                    //Отображение функции, по которой построен график
                    GraphInfo.Content += CheckingCoefficients.CheckCoefficients();
                }

                else
                {
                    //Вывод сообщения о непустом поле
                    MessageBox.Show("Сначала очистите поле!", "График уже построен!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            //Если роль пользователя - пользователь
            if (UserClass.userRole == "user")
            {
                if (CanvasContainer.Children.Count == 19)
                {
                    //Присвоение значений коэффициентам k и b 
                    CalculateClass.k = 1;
                    CalculateClass.b = 0;

                    Polyline graph = CalculateClass.CalculateFunction();

                    CanvasContainer.Children.Add(graph);

                    GraphInfo.Content += CheckingCoefficients.CheckCoefficients();

                }
                else
                {
                    MessageBox.Show("Сначала очистите поле!", "График уже построен!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
        //Очищение поля
        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            if (CanvasContainer.Children.Count == 19)
            {
                MessageBox.Show("Поле и так пустое!", "Нечего очищать!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                CanvasContainer.Children.Remove(CanvasContainer.Children[CanvasContainer.Children.Count - 1]);
                GraphInfo.Content = "График функции: ";
            }
        }

        //Событие загрузки окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Открытие окна авторизации
            AutorizationWindow autorization = new AutorizationWindow();
            autorization.ShowDialog();

            //Если вход неуспешный - закрытие окна
            if (!UserClass.sucsessEnter)
            {
                this.Close();
            }
        }

        //Событие кнопки сменить пользователя
        private void ChangeUserBtn_Click(object sender, RoutedEventArgs e)
        {
            //Обнуление роли и успешного входа пользователя
            UserClass.userRole = string.Empty;
            UserClass.sucsessEnter = false;

            GraphInfo.Content = string.Empty;
            CanvasContainer.Children.Remove(CanvasContainer.Children[CanvasContainer.Children.Count - 1]);

            AutorizationWindow autorization = new AutorizationWindow();
            autorization.ShowDialog();

            if (!UserClass.sucsessEnter)
            {
                this.Close();
            }
        }
    }
}