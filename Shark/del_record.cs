using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class del_record
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

        //Шаг времени(Режим Добавить Записи)
        public double step_time = 10;
        //Шаг глубины(Режим Добавить Записи)
        public double step_deep = 0.5;

        //Первая запись в выделенном интервале (номер)
        public int first_record;
        //Последняя запись (номер)
        public int last_record;
        //Разница в интервале x1-x0
        public double in_interval;

        //Число записей для создания
        public int N_create;

        //Буфер
        public List<double>  buf = new List<double>();

        public del_record (){
        
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
    }
}
