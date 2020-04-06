using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class rulery
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
        //Список текстовых меток
        public List<double> ruler_text = new List<double>();




        public rulery()
        {


        }
        public double high_rizka_2
        {
            get;
            set;
        }
        public double y_cur
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
        public double y
        {
            get;
            set;
        }
        public double l
        {
            get;
            set;
        }

        public double n_rizka
        {
            get;
            set;
        }
        public double high_rizka
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
        public bool type_r_bool
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

        public double size_text
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
        public double[] color = { 0.0f, 0.5f, 0.3f };

        public int number_char
        {
            get;
            set;
        }
        public double n_rizka_add
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

        }



    }
}
