using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class noise
    {
        //Границы кривая XY
        public List<double> new_x_point = new List<double>();
        public List<double> new_y_point = new List<double>();
        //Кординаты интервала и значения
        public List<double> new_x_point_coord = new List<double>();
        public List<double> new_y_point_coord = new List<double>();
        public List<double> new_x_point_value = new List<double>();
        public List<double> new_y_point_value = new List<double>();

        //Амплитуда
        public double amplitude
        {
            get;
            set;
        }

        //Смещение
        public double disp
        {
            get;
            set;
        }

        //Шаг время
        public double step_time
        {
            get;
            set;
        }
        //Шаг глубина
        public double step_deep
        {
            get;
            set;
        }


        //Инициализация
        public noise()
        {
            amplitude = 0;
            disp = 0;
            step_time = 0;
            step_deep = 0;
        }
        //Обработка
        public void process()
        {
            if (new_x_point[0] > new_x_point[1])
            {


            }

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
