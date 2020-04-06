using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class summ_calc
    {

        //Границы кривая XY
        public List<double> new_x_point = new List<double>();
        public List<double> new_y_point = new List<double>();
        //Кординаты интервала и значения
        public List<double> new_x_point_coord = new List<double>();
        public List<double> new_y_point_coord = new List<double>();
        public List<double> new_x_point_value = new List<double>();
        public List<double> new_y_point_value = new List<double>();

        public List<string> modifer = new List<string>();
        public List<string> modifer_faq = new List<string>();
        public  summ_calc() {
            //modifer.Add("");
            //modifer_faq.Add("");
            modifer.Add(" +");
            modifer_faq.Add("x + y cложение");
            modifer.Add(" -");
            modifer_faq.Add("x - y вычитание");
            modifer.Add(" *");
            modifer_faq.Add("x * y умножение");
            modifer.Add(" /");
            modifer_faq.Add("x / y деление");
            modifer.Add(" //");
            modifer_faq.Add("x // y - получение целой части от деления");
            modifer.Add(" %");
            modifer_faq.Add("x % y - остаток от деления");
            modifer.Add(" abs(x)");
            modifer_faq.Add("abs(x) - модуль числа");
            modifer.Add(" **");
            modifer_faq.Add("x ** y - возведение в степень");
            modifer.Add(" math.ceil(X)");
            modifer_faq.Add(" math.ceil(X) – округление до ближайшего большего числа");
            modifer.Add(" math.factorial(X)");
            modifer_faq.Add("math.factorial(X) - факториал числа X");
            modifer.Add(" math.exp(X)");
            modifer_faq.Add("возвращает e в степени x, где e=2.71827... (основание натуральных логарифмов)(число Эйлера)");
            modifer.Add(" math.log(X, [base])");
            modifer_faq.Add("math.log(X, [base]) - логарифм X по основанию base. Если base не указан, вычисляется натуральный логарифм");
            modifer.Add(" math.log10(X)");
            modifer_faq.Add(" math.log10(X) - логарифм X по основанию 10");
            modifer.Add(" math.sqrt(X)");
            modifer_faq.Add("math.sqrt(X) - квадратный корень из X");
            modifer.Add(" math.acos(X)");
            modifer_faq.Add("math.acos(X) - арккосинус X. В радианах.");
            modifer.Add(" math.asin(X)");
            modifer_faq.Add("math.asin(X) - арксинус X. В радианах.");
            modifer.Add(" math.atan(X)");
            modifer_faq.Add("math.atan(X) - арктангенс X. В радианах.");
            modifer.Add(" math.cos(X)");
            modifer_faq.Add("math.cos(X) - косинус X (X указывается в радианах).");
            modifer.Add(" math.sin(X)");
            modifer_faq.Add("math.sin(X) - синус X (X указывается в радианах).");
            modifer.Add(" math.tan(X)");
            modifer_faq.Add("math.tan(X) - тангенс X (X указывается в радианах).");
            modifer.Add(" math.hypot(X, Y)");
            modifer_faq.Add("math.hypot(X, Y) - вычисляет гипотенузу треугольника с катетами X и Y (math.sqrt(x * x + y * y)).");
            modifer.Add(" math.degrees(X)");
            modifer_faq.Add("math.degrees(X) - конвертирует радианы в градусы.");
            modifer.Add(" math.radians(X)");
            modifer_faq.Add("math.radians(X) - конвертирует градусы в радианы.");
            modifer.Add(" math.cosh(X)");
            modifer_faq.Add("math.cosh(X) - вычисляет гиперболический косинус.");
            modifer.Add(" math.sinh(X)");
            modifer_faq.Add("math.sinh(X) - вычисляет гиперболический синус.");
            modifer.Add(" math.tanh(X)");
            modifer_faq.Add("math.tanh(X) - вычисляет гиперболический тангенс.");
            modifer.Add(" math.acosh(X)");
            modifer_faq.Add("math.acosh(X) - вычисляет обратный гиперболический косинус.");
            modifer.Add(" math.asinh(X)");
            modifer_faq.Add("math.asinh(X) - вычисляет обратный гиперболический синус.");
            modifer.Add(" math.atanh(X)");
            modifer_faq.Add("math.atanh(X) - вычисляет обратный гиперболический тангенс.");
            modifer.Add(" math.gamma(X)");
            modifer_faq.Add("math.gamma(X) - гамма-функция X.");
            modifer.Add(" math.pi");
            modifer_faq.Add("math.pi   pi = 3,1415926...");
            modifer.Add(" math.e");
            modifer_faq.Add("math.e    e = 2,718281... (число Эйлера)");
            
        }
        //Удаление линий границ
        public void delete_all_new_point()
        {
            if (new_x_point.Count > 0)
            {
                new_x_point.Clear();
                new_y_point.Clear();
            }
        }
        //Удаление буфера копирования
        public void delete_all_new_point_coord_value()
        {
            if (new_x_point_coord.Count > 0)
            {

                new_x_point_coord.Clear();
                new_x_point_value.Clear();
                new_y_point_coord.Clear();
                new_y_point_value.Clear();
            }
        }
    }
}
