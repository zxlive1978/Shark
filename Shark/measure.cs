using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class measure
    {
        public List<double> x_coord = new List<double>();
        public List<double> y_coord = new List<double>();
        public List<double> x_value = new List<double>();
        public List<double> y_value = new List<double>();

        //Значение под курсором ХУ
        public double cur_value_y;
        public double cur_value_x;
        //Значение под курсором ХУ
        public double cur_coord_y;
        public double cur_coord_x;
        //Цвет
        public float[] color;
        //Новая кривая XY
        public List<double> new_x_point = new List<double>();
        public List<double> new_y_point = new List<double>();
        public List<double> new_x_point_value = new List<double>();
        public List<double> new_y_point_value = new List<double>();
        public List<string> text_x_point = new List<string>();
        public List<string> text_y_point = new List<string>();
        public List<double> new_x_point_disp = new List<double>();
        public List<double> new_y_point_disp = new List<double>();

        //Тестовое значение времени
        public string now_time;

        public measure(){}
        // Удаление последней нарисованной точки
        public void delete_last_new_point()
        {

            if (new_x_point.Count != 0)
            {
                new_x_point.RemoveAt(new_x_point.Count - 1);
                new_y_point.RemoveAt(new_y_point.Count - 1);
                if (new_x_point_value.Count != 0)
                {
                    new_x_point_value.RemoveAt(new_y_point_value.Count - 1);
                    new_y_point_value.RemoveAt(new_y_point_value.Count - 1);
                }
                if (new_x_point_disp.Count != 0)
                {
                    new_x_point_disp.RemoveAt(new_y_point_disp.Count - 1);
                    new_y_point_disp.RemoveAt(new_y_point_disp.Count - 1);
                }

            }
        }
        //Удаление всех нарисованных линий
        public void delete_all_new_point()
        {
            if (new_x_point.Count > 0)
            {
                new_x_point.Clear();
                new_y_point.Clear();
                new_x_point_value.Clear();
                new_x_point_disp.Clear();
                new_y_point_value.Clear();
                new_y_point_disp.Clear();
            }
        }


    }
}
