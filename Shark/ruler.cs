using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class ruler
    {
        /// <summary>
        /// Рулетка
        /// </summary>
        /// <param name="x">хпоз</param>
        /// <param name="y">yпоз</param>
        /// <param name="l">длина</param>
        /// <param name="n_rizka">число рисок</param>
        /// <param name="high_rizka">высота рисок</param>
        /// <param name="hv_rizka">направление рулетки</param>
        /// <param name="type_r">время, глубина</param>



        //Список координат
        public List<double> ruler_m = new List<double>();
        //Список текстовых меток
        public List<string> ruler_text = new List<string>();

        //переменные
       //float step_r;
        //double step_txt;
        //float x_cur, y_cur = 10;
        //float high_rizka_2;



        public ruler()
        {
       

        }
        public float high_rizka_2
        {
            get;
            set;
        }
        public float y_cur
        {
            get;
            set;
        }
        public double x_cur 
        {
            get;
            set;
        }

        public double step_txt
        {
            get;
            set;
        }
        public double step_r
        {
            get;
            set;
        }

        public double x
        {
            get;
            set;
        }
        public float y
        {
            get;
            set;
        }
        public float l
        {
            get;
            set;
        }

        public double n_rizka
        {
            get;
            set;
        }
        public float high_rizka
        {
            get;
            set;
        }
        public bool hv_rizka
        {
            get;
            set;
        }
        public string type_r
        {
            get;
            set;
        }

        public int beg_paint
        {
            get;
            set;
        }

        public int end_paint
        {
            get;
            set;
        }

        public double aspect_x
        {
            get;
            set;
        }
        public double aspect_y
        {
            get;
            set;
        }

        public float size_text
        {
            get;
            set;
        }
        public double begin_union
        {
            get;
            set;
        }
        public double end_union
        {
            get;
            set;
        }
        public float[] color = { 0.0f, 0.5f, 0.3f };

        public int number_char
        {
            get;
            set;
        }

        public double v_text_disp
        {
            get;
            set;
        }
        public double scalex
        {
            get;
            set;
        }

        //Настройка рулетки
        public void calc()
        {
            ruler_m.Clear();
            ruler_text.Clear();

            if (hv_rizka)
            {
                high_rizka_2 = high_rizka / 2;
                step_r = l / n_rizka;
                step_txt = (end_union - begin_union) / n_rizka;
                for (int i = 0; i <= n_rizka; i++)
                {
                    //ось
                    ruler_m.Add(x);
                    ruler_m.Capacity += 1;
                    ruler_m.Add(y);
                    ruler_m.Capacity += 1;
                    ruler_m.Add(x + l);
                    ruler_m.Capacity += 1;
                    ruler_m.Add(y);
                    ruler_m.Capacity += 1;
                    
                    //риски
                    x_cur = x + i * step_r;
                    ruler_m.Add(x_cur);
                    ruler_m.Capacity += 1;
                    ruler_m.Add(y - high_rizka_2);
                    ruler_m.Capacity += 1;
                    ruler_m.Add(x_cur);
                    ruler_m.Capacity += 1;
                    ruler_m.Add(y + high_rizka_2);
                    ruler_m.Capacity += 1;

                    //подпись под рисками
                    ruler_text.Add(x_cur.ToString());
                    ruler_text.Capacity += 1;
                    ruler_text.Add((y - high_rizka_2 - v_text_disp).ToString());
                    ruler_text.Capacity += 1;
                    ruler_text.Add((Math.Round(begin_union + step_txt * i, number_char)).ToString());
                    ruler_text.Capacity += 1;
                }
            }
        }

        //Сдвиг текста по оси Х
        public void text_calc(double step_x_oZ)
        {
            for (int i = 0; i < ruler_text.Count; i += 3)
            {
                double action = x + step_r * i / 3 - step_x_oZ;
                ruler_text[i] = action.ToString();
             }
         }

        // Пересчет разряжевания цифр
        public void scalex_text() {
            
            if ( n_rizka/l > 1.4)
            {
                scalex =  n_rizka/l*5;
            }
            else { scalex = 7; }
            if (n_rizka / l < 1) {
                scalex = 3;
            }
            if (n_rizka / l < 0.5)
            {
                scalex = 1;
            }

        }


    }
}
