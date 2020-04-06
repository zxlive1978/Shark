using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class backupall:backup_items
    {
        //Список значений
        public List<backup_items> list_backups = new List<backup_items>();
        //Число откатов
        public int kol_otkatov;
        //Текущий номер отката
        public int curr_numb_otkat=0;
        //Новый откат(триггер)
        public bool new_otkat = true;

        public backupall() { 
        
        }
        //Добавление одной операции
        public void add_operation(){
            backup_items new_operation = new backup_items();
            list_backups.Add(new_operation);
             if (((list_backups.Count)-1) >= curr_numb_otkat) 
            {
                list_backups.RemoveRange(curr_numb_otkat, ((list_backups.Count) - 1-curr_numb_otkat));
            }
             if (kol_otkatov == list_backups.Count)
             {
                 list_backups.RemoveAt(0);

             }
             else
             {
                 curr_numb_otkat += 1;

             }
        }
        //Удаление одной операции
        public void remove_operation()
        {
            list_backups.RemoveAt((list_backups.Count)-1);
        }
        //Удаление всех операции
        public void remove_all_operation()
        {
            list_backups.Clear();
            curr_numb_otkat = 0;
        }

        //

    }

    public class backup_items
    {
        //Список значений
        //Номер параметра
        public List<int> numb_param = new List<int>();
        //public List<double> x_coord = new List<double>();

        //Номер записи
        public List<int> numb_rec = new List<int>();

        //Значение y старое
        public List<double> y_value = new List<double>();
        //Значение y новое
        public List<double> y_value_new = new List<double>();

        //Текущий график
        //public List<int> curr_graph = new List<int>();

       
        //Инициализация
        public backup_items()
        {
            
        }
        //Добаление значения
        public void add(int numb_p, int numb_r,double y_val) {
            numb_param.Add(numb_p);
            numb_rec.Add(numb_r);
            y_value.Add(y_val);
            //curr_graph.Add(curr_g);
        }
        //Очистка
        public void clear()
        { 
            numb_param.Clear();
            numb_rec.Clear();
            y_value.Clear();
            //curr_graph.Clear();
        
        }
    }


}
