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

namespace practice14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {
            private double firstNumber = 0;
            private string operation = "";
            private bool isNewInput = true;

            public MainWindow()
            {
                InitializeComponent();
            }

        //обработчик для кнопок с цифрами
        private void NumberButton_Click(object sender, RoutedEventArgs e)//sender возвращает свойства и состояния, а е возвращает события
        {
                Button button = (Button)sender;//дословно уверена что это будет в этом случае кнопка
            string number = button.Content.ToString();//получаем то что написано в кнопке

            if (isNewInput)
                {
                    SentenceTb.Text = number;
                    isNewInput = false;
                }
                else
                {
                    SentenceTb.Text += number;
                }
            }
        //обработчик для кнопок операций
        private void OperationButton_Click(object sender, RoutedEventArgs e)//обработчик нажатия на кнопку с точкой
        {
                Button button = (Button)sender;//наша кнопка на которую мы нажали
            string newOperation = button.Content.ToString();
            //если уже запомненная операция и не новый ввод, вычисляем промежуточный результат
            if (!string.IsNullOrEmpty(operation) && !isNewInput)
                {
                    double currentNumber;//хранит 2-е число, которое мы введем
                if (double.TryParse(SentenceTb.Text, out currentNumber))
                    {
                        switch (operation)
                        {
                            case "+":
                                firstNumber += currentNumber;
                                break;

                            case "-":
                                firstNumber -= currentNumber;
                                break;

                            case "*":
                                firstNumber *= currentNumber;
                                break;

                            case "/":
                                if (currentNumber != 0)
                                    firstNumber /= currentNumber;
                                else
                                    SentenceTb.Text = "Ошибка";
                                break;
                        }
                    }
                }
                else
                {
                //если это 1-я операция, просто запоминаем текущее число
                double.TryParse(SentenceTb.Text, out firstNumber);
                }

                operation = newOperation;
                isNewInput = true;
            }

            // =
            private void EqualsButton_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrEmpty(operation))
                    return;

                if (!double.TryParse(SentenceTb.Text, out double secondNumber))//проверяем, что мы не можем добавить число 
            {
                    SentenceTb.Text = "ОШИБКА";
                    return;
                }

                double result = 0;
                bool hasError = false;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;// firstNumber хранит результат, но не выводит его, а result выводит сохраненный результат в texBox 120
                    break;

                    case "-":
                        result = firstNumber - secondNumber;
                        break;

                    case "*":
                        result = firstNumber * secondNumber;
                        break;

                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        else
                        {
                            SentenceTb.Text = "Ошибка";
                            hasError = true;
                        }
                        break;
                }

                if (!hasError)
                {
                    SentenceTb.Text = result.ToString();
                    SentenceTbl.Text = result.ToString();
                }

                operation = "";
                isNewInput = true;
            }
            private void ClearButton_Click(object sender, RoutedEventArgs e)
            {
                SentenceTb.Text = "";
                SentenceTbl.Text = "Результат";

                firstNumber = 0;
                operation = "";
                isNewInput = true;
            }
        }
    }

