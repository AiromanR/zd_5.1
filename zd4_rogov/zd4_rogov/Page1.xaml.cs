using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_rogov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        //метод, считывающий значение слайдера
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ProcentsRate.Text = $"{e.NewValue:F0}%";//обновление Label с изображением процентов

            CalcAllData(sender, e);
        }
        //отчистка ежемесячного платежа если выбирается дифференцированный
        private void TypeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcAllData(sender, e);
            if (TypeOfPayment.SelectedIndex == 1)
            {
                MonthPayment.Text = "";
            }
        }
        //расчет нужных данных
        private void CalcAllData(object sender, EventArgs e)
        {
            try
            {
                if (TypeOfPayment.SelectedIndex == 0)//проверка на выбранный вид платежа
                {
                    double sumOfCredit = double.Parse(SumOfCredit.Text);
                    int monthForPayment = int.Parse(DateMonth.Text);
                    int procents = (int)ProcentsSlider.Value;

                    string checkValid = Calculator.CheckValidSumAndMonths(sumOfCredit, monthForPayment);

                    if (checkValid != "")//проверка на правильно введенные данные
                    {
                        DisplayAlert("Ошибка!", checkValid, "Ок");
                    }
                    else
                    {
                        double monthPayment = Calculator.CalculateMonthPayment(sumOfCredit, monthForPayment, procents);
                        double allSum = Calculator.CalcAllSumPayment(sumOfCredit, monthForPayment, procents);
                        double overPayment = Calculator.CalcOverPayment(sumOfCredit, monthForPayment, procents);

                        //вывод вычисленных данных на Label
                        MonthPayment.Text = $"Ежемесячный платеж: {Math.Round(monthPayment, 2)}р.";
                        AllSum.Text = $"Общая сумма: {Math.Round(allSum, 2)}p.";
                        OverPayment.Text = $"Переплата: {Math.Round(overPayment, 2)}p.";
                    }
                }
                else if (TypeOfPayment.SelectedIndex == 1)
                {
                    double sumOfCredit = double.Parse(SumOfCredit.Text);
                    int monthForPayment = int.Parse(DateMonth.Text);
                    int procents = (int)ProcentsSlider.Value;

                    string checkValid = Calculator.CheckValidSumAndMonths(sumOfCredit, monthForPayment);

                    if (checkValid != "")//проверка на правильно введенные данные
                    {
                        DisplayAlert("Ошибка!", checkValid, "Ок");
                    }
                    else
                    {
                        double allSum = Calculator.CalcAllSumPayment(sumOfCredit, monthForPayment, procents);
                        double overPayment = Calculator.CalcOverPayment(sumOfCredit, monthForPayment, procents);

                        //вывод вычисленных данных на Label
                        MonthPayment.Text = $"Ежемесячный платеж:";
                        AllSum.Text = $"Общая сумма: {Math.Round(allSum, 2)}p.";
                        OverPayment.Text = $"Переплата: {Math.Round(overPayment, 2)}p.";
                    }
                    if (TypeOfPayment.SelectedIndex == 1)
                    {
                        MonthPayment.Text = "";
                    }
                }
            }
            catch
            {
                DisplayAlert("Ошибка!", "Введите верные данные!", "Ок");
            }
        }
    }
}