using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace zd4_rogov
{
    public static class Calculator
    {
        public static double CalculateMonthPayment(double sumOfCredit, int monthsForPayment, int procentsRate)
        {
            //формула расчета: размер ежемес. платежа = сумма кредита * (мес. проц. ставка / ( 1 - (1 + мес.проц.ставка) ^ (-срок) ) )
            double monthProcentsRate = Convert.ToDouble(procentsRate) / (100 * 12); //месячная процентная ставка

            if (procentsRate == 0) return sumOfCredit / monthsForPayment; // в случае, если процентная ставка = 0

            double denominator = 1 - Math.Pow(1 + monthProcentsRate, -monthsForPayment); //знаменатель 

            double monthPayment = sumOfCredit * (monthProcentsRate / denominator);

            return Math.Round(monthPayment, 2);
        }

        //расчет общей суммы
        public static double CalcAllSumPayment(double sumOfCredit, int monthsForPayment, int procentsRate)
        {
            double monthPayment = CalculateMonthPayment(sumOfCredit, monthsForPayment, procentsRate);

            return Math.Round(monthPayment * monthsForPayment, 2);
        }

        //расчет переплаты
        public static double CalcOverPayment(double sumOfCredit, int monthsForPayment, int procentsRate)
        {
            double allSumPayment = CalcAllSumPayment(sumOfCredit, monthsForPayment, procentsRate);

            return Math.Round(allSumPayment - sumOfCredit, 2);
        }

        //проверка на правильную сумму кредита и срок месяцев
        public static string CheckValidSumAndMonths(double sumOfCredit, int monthsForPayment)
        {
            if (sumOfCredit < 1000 || sumOfCredit > 100000000)
            {
                return "Сумма кредита должна быть больше 5.000 и меньше 55.000.000";
            }
            if (monthsForPayment < 1 || monthsForPayment > 360)
            {
                return "Срок выплаты должен быть в диапазоне от 6 до 300 месяцев";
            }
            return "";
        }
    }
}