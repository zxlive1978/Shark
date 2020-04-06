using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class move_dots
    {
        //Границы кривая XY
        public List<double> new_x_point = new List<double>();
        public List<double> new_y_point = new List<double>();
        public List<double> new_x_value = new List<double>();
        public List<double> new_y_value = new List<double>();
        //Кординаты интервала и значения
        public List<double> new_x_point_coord = new List<double>();
        public List<double> new_y_point_coord = new List<double>();
        public List<double> new_x_point_value = new List<double>();
        public List<double> new_y_point_value = new List<double>();
        //Вставка выполнена
        public bool paste_scale_x = false;
        //Коэффициент масштаба
        public double k_scale;
        //Направление
        public bool forward_back = true;
        //Значение под курсором ХУ
        public double cur_value_y;
        public double cur_value_x;
        //Значение под курсором ХУ
        public double cur_coord_y;
        public double cur_coord_x;
        //Цвет
        public float[] color;

        //Инициализация
        public move_dots()
        {
        }

        //Проверка на вхождение в область
        public bool check_field_in() {

            if (new_x_point.Count() > 1)
            {
                if (cur_coord_x > new_x_point[0]
                    & cur_coord_x < new_x_point[1]
                    & cur_coord_y > new_y_point[1]
                    & cur_coord_y < new_y_point[0])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Проверка на вхождение в верхний угол
        public bool check_field_in_up_coner()
        {

            if (new_x_point.Count() > 1)
            {
                if (cur_coord_x == new_x_point[0]
                    & cur_coord_x < new_x_point[1]
                    & cur_coord_y > new_y_point[1]
                    & cur_coord_y == new_y_point[0])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Удаление линий границ
        public void delete_all_new_point()
        {
            if (new_x_point.Count > 0)
            {
                new_x_point.Clear();
                new_y_point.Clear();
                new_x_value.Clear();
                new_y_value.Clear();
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

        // Обработка точек нарисованнной кривой и загруженнной
        public void process()
        {

            k_scale =
                ((new_x_point_coord[new_x_point_coord.Count - 1]) - (new_x_point_coord[0])) / ((new_x_point[1]) - (new_x_point[0]));//new_x_point_coord.Count;

            if (new_x_point.Count > 1)
            {
                double disp = (new_x_point[0] - new_x_point_coord[0]);
                for (int i = 0; i < new_x_point_coord.Count; i++)
                {
                    new_x_point_coord[i] = new_x_point_coord[i] + disp;
                }
                for (int i = 0; i < new_x_point_coord.Count; i++)
                {
                    new_x_point_coord[i] = new_x_point_coord[i] / k_scale;
                }
                disp = (new_x_point[0] - new_x_point_coord[0]);
                for (int i = 0; i < new_x_point_coord.Count; i++)
                {
                    new_x_point_coord[i] = new_x_point_coord[i] + disp;
                }
                if (true)
                {

                }
                else
                {
                    //for (int i = 0; i <= new_x_point.Count - 2; i += 1)
                    //{
                    //    new_curr_point_x1 = new_x_point[i];
                    //    new_curr_point_y1 = new_y_point[i];
                    //    new_curr_point_x2 = new_x_point[i + 1];
                    //    new_curr_point_y2 = new_y_point[i + 1];

                    //    for (int j = 0; j <= x_coord.Length - 1; j++)
                    //    {
                    //        old_curr_point_x = x_coord[j];

                    //        if (new_curr_point_x1 >= old_curr_point_x & new_curr_point_x2 <= old_curr_point_x)
                    //        {
                    //            y_coord[j] = (new_curr_point_y2 - new_curr_point_y1) * ((old_curr_point_x - new_curr_point_x1) / (new_curr_point_x2 - new_curr_point_x1)) + new_y_point[i];

                    //        }
                    //    }
                    //}
                }


            }
        }
    }
}
