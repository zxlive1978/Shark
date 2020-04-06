using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    //Шкала
    public class woodoo_y
    {
        public woodoo_y()
        {
            //init();
        
        }

       //СВОЙСТВА  Диапазон шкалы
       //Первое текущее значение параметра a1
        public double a1 { get; set; }
       //Первое новое значение a1new
        public double a1new { get; set; }
        //Последнее текущее значение a2
        public double a2 { get; set; }
        //Последнее новое значение a1new
        public double a2new { get; set; }

        //Значение параметра первой риски шкалы
        public double b0 { get; set; }
        //Значение параметра текущей риски шкалы
        public double bi { get; set; }
        //Массив значений рисок шкалы
        public double[] bi_mass;
        //Массив координат рисок шкалы
        public double[] bi_mass_coord;
        //Массив отрезков
        public float[] all_coord;


        //Число основных делений
        public uint N { get; set; }
        //Число дополнительных делений
        public uint n { get; set; }
        //a2-a1 Длина области
        public double megadelta { get; set; }
        //b2-b1 Длина между рисками
        public double delta { get; set; }


        //Название параметра(текст)
        public string text { get; set; }
        public char[] text_char;

        //Ось значений x
        public List<double> x_value = new List<double>();
        //public double[] x_value;
        public List<double> x_coord = new List<double>();
        //public double[] x_coord;
        //Ось значений y
        public List<double> y_value = new List<double>();
        //public double[] y_value;
        public List<double> y_coord = new List<double>();
        //public double[] y_coord;

        //Начало и конец значения
        public double begin_union;
        public double end_union;

        //Точность знаков
        public int precission;

        //Смещение относительно оси Y
        public double y_plus;


        
        //Массив отрезков(координат)
        public void all_calc_init()
        {
            //Основная линия
            all_coord[0] =(float)(x + dx);
            all_coord[1] = (float)(y + dy);
            all_coord[2] = (float)(x + dx);
            all_coord[3] = (float)(y + d2 - dy);
            //2 основная линия
            all_coord[4] = (float)(x + dx +dx/4);
            all_coord[5] = (float)(y + dy);
            all_coord[6] = (float)(x + dx +dx/4);
            all_coord[7] = (float)(y + d2 - dy);
            //Риски
            int j = 0;
            for (int i = 4+4; i < N*4+4+4; i=i+4) {
                all_coord[i] = (float)(x + dx );
                all_coord[i + 1] = (float)(dy + (bi_mass[j] - a1new) * ((d2-2*dy) / (a2new - a1new)));
                all_coord[i + 2] = (float)(x + dx + dx/2);
                all_coord[i + 3] = (float)(dy + (bi_mass[j] - a1new) * ((d2-2*dy) / (a2new - a1new)));

                j++;
            }

        }

        //Инициализация шкалы
        public void init(){
            a1 = a1new; a2 = a2new;
            bi_mass= new double[N];
            
            megadelta = a2 - a1;
            delta = megadelta / (N-1);
            for (int i = 0; i < N; i++) {
                bi_mass[i] = a1 + delta*(i);} 
            //Объявление размера массива отрезков
            all_coord = new float[N *4 + 4+4];
            //Перевод руского символа для печати
            uint ruso = 176;
            //text = text.ToUpper();
            text_char = text.ToCharArray();
            for (int i = 0; i < text_char.Length; i++) {
                if ((int)(text_char[i])>1000){
                text_char[i] = Convert.ToChar((uint)text_char[i]+ruso);}
                if ((int)(text_char[i]) == 1279) { text_char[i] = Convert.ToChar((uint)text_char[i] - 32); }
            }
        }

        //Пересчет шкалы (рабочая лошадка)
        public void calc() {
            //1) i----i----i----i--b0--i
            double testdelta = a2new - a1new / N;
            //if (a1 > a1new & a1 < a1new + testdelta)
            //{

            //    //a1 = a1new; a2 = a2new;

            //    megadelta = a2 - a1;
            //    delta = megadelta / (N - 1);
            //    //bi_mass[0] = bi_mass[0] - Math.Truncate((bi_mass[0] - a1new) / delta);
            //    bi_mass[0] = a1;
                
            //}
            if (a1 > a1new & a1 >= a1new +delta)
            {

                a1 = a1new; a2 = a2new;

                megadelta = a2 - a1;
                delta = megadelta / (N - 1);
                //bi_mass[0] = bi_mass[0] + Math.Truncate((bi_mass[0] - a1) / delta);
                bi_mass[0] = a1;
               
            }
            //2) b0  i----i----i----i----i
            //if (bi_mass[0] < a1new & bi_mass[0] > a1new - testdelta)
            //{
            //    //a1 = a1new; a2 = a2new;

            //    megadelta = a2 - a1;
            //    delta = megadelta / (N - 1);
            //    //bi_mass[0] = bi_mass[0] + Math.Truncate((a1new - bi_mass[0]) / delta);
            //    bi_mass[0] = a1;
            //}
            if (bi_mass[0] < a1new & bi_mass[0] <= a1new - delta)
            {
                a1 = a1new; a2 = a2new;

                megadelta = a2 - a1;
                delta = megadelta / (N - 1);
                //bi_mass[0] = bi_mass[0] - Math.Truncate((a1 - bi_mass[0]) / delta);
                bi_mass[0] = a1;

            }

       
  
            //Пересчет рисок
            for (int i = 0; i < N; i++)
            {
                bi_mass[i] = bi_mass[0] + delta * (i);
                //Проверка b[i] за границей шкалы i----i----i----i----i  b[n]
                //if (bi_mass[i] > a2) { bi_mass[i] = bi_mass[i - 1]; }
            }
        }

        //Начальная координата контейнера
        public double x { get; set; }//I----I
        public double y { get; set; }//xy---I

        //Ширина, Высота контейнера
        public double d1 { get; set; }//<---->
        public double d2 { get; set; }//I

        //Отступы сверху и снизу от контейнера до основной линии оси
        public double dy { get; set; }

        //Отступы слева от контейнера до основной линии оси
        public double dx { get; set; }

        //Ширина риски
        public double dr { get; set; }

        //Цвет
        public float[] color;
        
        //Отступ текста от риски
        public double dtxt { get; set; }
    
    }
}
