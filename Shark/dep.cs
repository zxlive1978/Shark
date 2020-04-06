using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shark
{
    public class dep

    {
        //Dep-файл
        //Logsbuilder
        //52; 'Время сбора данных'
        //53; 'Глубина Забоя'
        //DTCIS
        //52; 'Время сбора данных'
        //53; 'Глубина Забоя'

        //public byte[] dep_file;
        //public byte[] dep_file_copy;
        public List<byte> dep_file = new List<byte>();
        //Lst-файл
        //public byte[] lst_file;
        public List<byte> lst_file = new List<byte>();
        //Cправочник
        public byte[] ref_;
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
        //Минимальное и максимальное значение У
        public double min_value_y;
        public double max_value_y;
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
        //Направление
        public bool forward_back = true;


        public byte[] dooble= new byte[4];
        public byte[] siingle = new byte[2];

        public DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public DateTime current;
        public DateTime current1;
        public char ruru = '\u02D0';
        public bool dep_ok = false;

        //Текст параметров из справочника
        public string[] str_;

        public dep()
        {
        }
        //Тип файла(временной, глубинный)
        public int type_file
        {
            get;
            set;
        }
        // Значение ключевого поля (глубина)
        public float key_value
        {
            get;
            set;
        }
        // Значение ключевого поля (время)
        public long key_time
        {
            get;
            set;
        }

        //Число битых записей
        public int petli
        {
            get;
            set;
        }
        //Текущее значение времени
        public string time_cur
        {
            get;
            set;
        }

        //Временной сдвиг в часах(секунды)

        public long timeshift
        {
            get;
            set;
        }
        //Сдвиг реального времени(часах)
        public long timeshift_hourse
        {
            get;
            set;
        }
        
        //Число записей
        public long n_max
        {
            get;
            set;
        }
        
        //Cреднее значение
        public double midle
        {
            get;
            set;
        }

        //Размер значения параметра из справочника par файла
        public int value_size
        {
            get;
            set;
        }

        //Тип параметра из справочника par файла
        //f-float
        //l-long
        //i-integer
        //d-unix time
        //c-string
        public char type_param
        {
            get;
            set;
        }

        //Значение параметра
        public float value
        {
            get;
            set;
        }
        //Максимальное значение параметра
        public double value_max
        {
            get;
            set;
        }
        //Минимальное значение параметра
        public double value_min
        {
            get;
            set;
        }


        //Значение ключевого параметра
        public float key_value_x
        {
            get;
            set;
        }

        //Проверка на null значений параметра
        public bool null_yes
        {
            get;
            set;
        }



        public void n_max_calc(){
            n_max = (lst_file.Count )/ 21;
        }
        // Чтение значений записи 21 байт
        public void read_lst_rec(int n)
        {
            if (type_file < 0)
            {
                byte[] flooat = new byte[4];
                for (int i = 0; i <= 3; i++)
                {
                    flooat[i] = lst_file[n * 21 + 4 + i];
                }
                key_value = BitConverter.ToSingle(flooat, 0);
            }
            else
            {
                byte[] loong = new byte[4];
                for (int i = 0; i <= 3; i++)
                {
                    loong[i] = lst_file[n * 21 + 8 + i];
                }


                current = origin.AddSeconds(BitConverter.ToInt32(loong, 0)+timeshift_hourse*3600);
                time_cur = current.ToString();
                key_time = BitConverter.ToInt32(loong, 0);

            }
        }

        //Часы, минуты, секунды
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string Seconds { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        //Перевод значения в дату
        public void value_to_date(double n) {
            current = origin.AddSeconds(n + timeshift_hourse * 3600);
            Hour = current.Hour.ToString();
            if (Hour.Length == 1) { Hour = "0" + Hour; }
            Minute = current.Minute.ToString();
            if (Minute.Length == 1) { Minute = "0" + Minute; }
            Seconds = current.Second.ToString();
            if (Seconds.Length == 1) { Seconds = "0" + Seconds; }

            Day = current.Day.ToString();
            if (Day.Length == 1) { Day= "0" + Day; }
            Month = current.Month.ToString();
            if (Month.Length == 1) {Month = "0" + Month; }
            Year = current.Year.ToString();
            if (Year.Length == 1) { Year = "0" + Year; }
        }

        // Запись dep и lst файла
        public void wr_dep(string n_file)
        {

            n_file = n_file.Remove(n_file.Length - 3, 3);
            n_file = n_file + "dep";
            System.IO.File.WriteAllBytes(n_file, dep_file.ToArray());
            dep_file.ToList();
            n_file = n_file.Remove(n_file.Length - 3, 3);
            n_file = n_file + "lst";
            System.IO.File.WriteAllBytes(n_file, lst_file.ToArray());
            lst_file.ToList();
        }

        // Тип файла
        public bool type_dep(string n_file) 
        {
            string test_text = n_file;
            string standard="TIME";
            test_text=test_text.ToUpper();

            if (test_text.StartsWith(standard))
            {
                return true;
            }
            else { return false; }
        }
        //Чтение значения параметра
        public void read_value(int number_param, int number_rec) {
            //Базовое смещение от начала файла
              for (int i = 0; i <= 3; i++)
                {
                    dooble[i] = lst_file[(21*number_rec) + i];
                }
            int adress = BitConverter.ToInt32(dooble,0);
            if ((adress >= 0) & (adress < dep_file.Count))
            {
                //Длинна записи в байтах (включая данный заголовок)
                for (int i = 0; i <= 1; i++)
                {
                    siingle[i] = dep_file[adress + 6 + i];
                }
                int lengh_rec_byte = BitConverter.ToUInt16(siingle, 0);
                //Номер параметра в справочнике
                byte number_param_in_real;
                for (int i = adress + 10; i < adress + lengh_rec_byte - 10; i++)
                {
                    number_param_in_real = dep_file[i + 1];
                    read_ref_size_value(number_param_in_real);
                    if (number_param_in_real == number_param)
                    {
                        //Размер 2 байта
                        if ((value_size == 2)&(type_param == 'i'))
                        {
                            for (int a = 0; a <= 1; a++)
                            {
                                siingle[a] = dep_file[i + 2  + a];
                            }
                            value = BitConverter.ToInt16(siingle, 0);
                            null_yes = false;
                        }
                        //Размер 4 байта
                        if ((value_size == 4) & (type_param == 'f'))
                        {
                            for (int a = 0; a <= 3; a++)
                            {
                                dooble[a] = dep_file[2 + i + a];
                            }
                            value = BitConverter.ToSingle(dooble, 0);
                            null_yes = false;
                        }
                        if ((value_size == 4) & (type_param == 'l'))
                        {
                            for (int a = 0; a <= 3; a++)
                            {
                                dooble[a] = dep_file[2 + i + a];
                            }
                            value = BitConverter.ToUInt32(dooble, 0);
                            null_yes = false;
                        }
                        if (value_size > 4)
                        {
                            //value = 999;
                            null_yes = true;
                        }
                        return;
                    }
                    else
                    {
                        //value = 999;
                        null_yes = true;
                        i = i + 1 + value_size;
                    }
                }
            }
        }

        //Пересчет из координат в значения
        //@@!!!Запись значения параметра
        public void write_value(int number_param, int number_rec, double write_value_xy)
        {
            
            //Базовое смещение от начала файла
            for (int i = 0; i <= 3; i++)
            {
                dooble[i] = lst_file[(21 * number_rec) + i];
            }
            int adress = BitConverter.ToInt32(dooble, 0);
            if ((adress >= 0) & (adress < dep_file.Count))
            {
                //Длинна записи в байтах (включая данный заголовок)
                for (int i = 0; i <= 1; i++)
                {
                    siingle[i] = dep_file[adress + 6 + i];
                }
                int lengh_rec_byte = BitConverter.ToUInt16(siingle, 0);
                //Номер параметра в справочнике
                byte number_param_in_real;
                for (int i = adress + 10; i < adress + lengh_rec_byte - 10; i++)
                {
                    number_param_in_real = dep_file[i + 1];
                    read_ref_size_value(number_param_in_real);
                    if (number_param_in_real == number_param)
                    {
                        //Размер 2 байта
                        if ((value_size == 2) & (type_param == 'i'))
                        {
                            siingle = BitConverter.GetBytes(write_value_xy);
                            for (int a = 0; a <= 1; a++)
                            {
                                dep_file[2 + i + a] = siingle[a];
                            }
                        }
                        //Размер 4 байта
                        if (value_size == 4 & type_param == 'f')
                        {
                            //dep_file[ 2 + i]=write_value_xy.
                            dooble = BitConverter.GetBytes(Convert.ToSingle(write_value_xy));
                            for (int a = 0; a <= 3; a++)
                            {
                                dep_file[2 + i + a] = dooble[a];
                            }
                        }

                        //Размер 4 байта
                        if (value_size == 4 & type_param == 'l')
                        {
                            //dep_file[ 2 + i]=write_value_xy.
                            dooble = BitConverter.GetBytes(Convert.ToUInt32(write_value_xy));
                            for (int a = 0; a <= 3; a++)
                            {
                                dep_file[2 + i + a] = dooble[a];
                            }
                        }
                        if (value_size > 4)
                        {
                            value = 999;
                        }
                        return;
                    }
                    else
                    {
                        i = i + 1 + value_size;
                    }
                }
            }
        }


        public void key_value_read(int nubmer_rec){

             //Чтение ключевого значения
              for (int i = 0; i <= 3; i++)
                {
                    dooble[i] = lst_file[(21 * nubmer_rec) + i + 4];
                }
            key_value_x= BitConverter.ToUInt32(dooble,0);
        }

        //public void key_value_write(int nubmer_rec)
        //{

        //    //Чтение ключевого значения
        //    for (int i = 0; i <= 3; i++)
        //    {
        //        dooble[i] = lst_file[(21 * nubmer_rec) + i + 4];
        //    }
        //    key_value_x = BitConverter.ToUInt32(dooble, 0);
        //}



        // Удаление последней нарисованной точки
        public void delete_last_new_point(){
        
            if (new_x_point.Count!=0){
                new_x_point.RemoveAt(new_x_point.Count - 1);
                new_y_point.RemoveAt(new_y_point.Count - 1);
            }
        }
        //Удаление всех нарисованных линий
        public void delete_all_new_point()
        {
            if (new_x_point.Count > 0)
            {
                new_x_point.Clear();
                new_y_point.Clear();
            }
        }

         // Чтение размера значения параметра из справочника par файла
        public void read_ref_size_value(int number_param) {
              for (int i = 0; i <= 1; i++)
                {
                    siingle[i] = ref_[number_param * 41 + 6+i];
                }
              value_size = BitConverter.ToUInt16(siingle, 0);
              type_param = (char)(ref_[number_param * 41 + 8]);
        }

        // Обработка точек нарисованнной кривой и загруженнной
        public void process() {
            double new_curr_point_x1;
            double new_curr_point_x2;
            double new_curr_point_y1;
            double new_curr_point_y2;
            double old_curr_point_x;

            if (new_x_point.Count > 1)
            {
                if (forward_back)
                {
                    for (int i = 0; i <= new_x_point.Count - 2; i += 1)
                    {
                        new_curr_point_x1 = new_x_point[i];
                        new_curr_point_y1 = new_y_point[i];
                        new_curr_point_x2 = new_x_point[i + 1];
                        new_curr_point_y2 = new_y_point[i + 1];

                        for (int j = 0; j <= x_coord.Count - 1; j++)
                        {
                            old_curr_point_x = x_coord[j];

                            if (new_curr_point_x1 <= old_curr_point_x & new_curr_point_x2 >= old_curr_point_x)
                            {
                                y_coord[j] = (new_curr_point_y2 - new_curr_point_y1) * ((old_curr_point_x - new_curr_point_x1) / (new_curr_point_x2 - new_curr_point_x1)) + new_y_point[i];
                            }
                        }
                    }
                }
                else {
                      for (int i = 0; i <= new_x_point.Count - 2; i += 1)
                    {
                        new_curr_point_x1 = new_x_point[i];
                        new_curr_point_y1 = new_y_point[i];
                        new_curr_point_x2 = new_x_point[i + 1];
                        new_curr_point_y2 = new_y_point[i + 1];

                        for (int j = 0; j <= x_coord.Count - 1; j++)
                        {
                            old_curr_point_x = x_coord[j];

                            if (new_curr_point_x1 >= old_curr_point_x & new_curr_point_x2 <= old_curr_point_x)
                            {
                                y_coord[j] = (new_curr_point_y2 - new_curr_point_y1) * ((old_curr_point_x - new_curr_point_x1) / (new_curr_point_x2 - new_curr_point_x1)) + new_y_point[i];

                            }
                        }
                    }
                }

                
            }
        }


        // Чтение справочника par,sup-файла
        public void read_ref() {
            ref_ = System.IO.File.ReadAllBytes(@"Referncs\Parsys01.sup");
            Encoding ascii = Encoding.GetEncoding(866);
            string path = System.IO.Directory.GetCurrentDirectory();
            str_ = System.IO.File.ReadAllLines(path + @"\Referncs\Referncs.par", ascii);
        }

        // Чтение dep,lst-файла
        public void read_dep(string n_file)
        {
            
            dep_file= System.IO.File.ReadAllBytes(n_file).ToList();
            
            
            
            n_file = n_file.Remove(n_file.Length - 3, 3);
            n_file = n_file + "LST";
            lst_file = System.IO.File.ReadAllBytes(n_file).ToList();
            lst_file.ToList();
           
            string ttext = "Time";
            type_file = n_file.ToUpper().IndexOf(ttext.ToUpper());



        }

        //Выбранная запись
        public int  selected_record;
        public byte[] buffer ;
        //Число записей
        public int count_records;
        //Шаг между записями
        public double step_count;
        //Длина записи lst
        public int lenght_lst = 21;
        //Длина записи dep
        public int lenght_dep;
        //Значение ключевого параметра для записи
        public double key_value_write;
        //Номер ключевого параметра
        public int numb_key;
        //Добавление новой записи
        public void add_record()
        {
           
            //DEP-файл
            //Базовое смещение от начала файла
            for (int a = 0; a <= 3; a++)
            {
                dooble[a] = lst_file[(lenght_lst * (selected_record)) + a];
            }
            int adresss = BitConverter.ToInt32(dooble, 0);

            //Длинна записи в байтах (включая данный заголовок)
            for (int b = 0; b <= 1; b++)
            {
                siingle[b] = dep_file[adresss + 6 + b];
            }
            lenght_dep = BitConverter.ToUInt16(siingle, 0);

           
           
            //Копия Вставка 1 dep записи
            Array.Resize(ref buffer, lenght_dep);
            Array.Copy(dep_file.ToArray(), (Int64)adresss, buffer, 0, (Int64)lenght_dep);
            dep_file.AddRange(buffer);
                
            //Копия Вставка l lst записи
            Array.Resize(ref buffer, lenght_lst);
            Array.Copy(lst_file.ToArray(), (Int64)lenght_lst * (selected_record), buffer, 0, (Int64)lenght_lst);
            lst_file.InsertRange(lenght_lst * (selected_record), buffer);
            
            //Изменение ключевого параметра
            if (type_file < 0)
            {
                dooble = BitConverter.GetBytes(Convert.ToSingle(key_value_write));
                for (int i = 0; i <= 3; i++)
                {
                    lst_file[(21 * selected_record) + i + 4] = dooble[i];
                }
            }
            else {
                dooble = BitConverter.GetBytes(Convert.ToUInt32(key_value_write));
                for (int i = 0; i <= 3; i++)
                {
                    lst_file[selected_record * 21 + 8 + i] = dooble[i];
                }
            }

            //Изменяем адрес смещение dep записи в следующих записях lst
            for (int a = 0; a <= 3; a++)
            {
                dooble[a] = lst_file[lenght_lst * (selected_record) + a];
            }
            adresss = BitConverter.ToInt32(dooble, 0);

            adresss = dep_file.Count - lenght_dep;
                    
            dooble = BitConverter.GetBytes(Convert.ToUInt32(adresss));
            for (int a = 0; a <= 3; a++)
            {
                lst_file[lenght_lst * (selected_record) + a] = dooble[a];
            }

            
        }

        //Удаление записи
        public void del_record()
        {
            //LST-файл
            lst_file.RemoveRange(selected_record * lenght_lst, lenght_lst);
        }


    }
}

//Формат LST (индексный файл)
//Размер, byte	Тип	Параметр
//21	4	DWORD	Базовое смещение от начала файла
//    4	FLOAT	Значение ключевого поля
//    4	LONG	Время (DOS формат)
//    4	LONG	Номер записи (истинный)
//    4	LONG	Номер записи (логический)
//    1	CHAR	Флаг состояния


//Формат DEP
//Структура записи
//заголовок	под¬за-го¬ло¬вок	значение	под¬за-го¬ло¬вок	значение	под¬за-го¬ло¬вок	значение	. . .

//Заголовок
//Размер, byte	Тип	Параметр
//10	4	LONG	Номер записи
//    2	SHORT	Уникальный номер скважины
//    2	SHORT	Длинна записи в байтах (включая данный заголовок)
//    1	CHAR	Номер параметра, который является ключевым
//    1	CHAR	Количество параметров в записи

//Под¬за¬го¬ло¬вок
//Размер, byte	Тип	Параметр
//2	1	CHAR	Номер справочника, или код единицы измерения
//    1	CHAR	Номер параметра в справочнике


//Формат справочника
//Размер, byte	Тип	Параметр
//41	4	FLOAT	Коэффициент пересчета в СИ (СИ=Value*K)
//    2	SHORT	Номер (код) параметра (0-255)
//    2	SHORT	Размер значения в байтах
//    1	CHAR	Тип представления параметра:
//  f	— float
//  l	— long
//  i	— integer
//  d	— windows datatime
//  c	— string
//    11	STRING	Название единицы измерения
//    21	STRING	Название параметра


//Формат файла списка справочников (list_sup.srv)
//Код справочника (единица измерения)	Имя файла данных по этой единице измерения	Количество параметров в справочнике
