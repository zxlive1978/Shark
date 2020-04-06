using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Cameras;
using SharpGL.SceneGraph.Collections;
using SharpGL.SceneGraph.Lighting;
using SharpGL.SceneGraph.Primitives;
//ironpython
//using IronPython;
//using IronPython;
//using Microsoft;
//using Microsoft.Scripting.Hosting;
using System.Globalization;


namespace Shark
{
    public partial class SharpGLForm : Form
    {
        //Рулетка
        public ruler rul = new ruler();
        public rulerx rul1 = new rulerx();
        public rulery rul2 = new rulery();
        public dep data = new dep();
        //Откат значений
        public backupall backupall = new backupall();
       
        //Режим Копировать
        public copy_paste copy_paste = new copy_paste();
        //Режим Измерить
        public measure measure = new measure();
        //Режим Шум
        public noise noise = new noise();
        //Режим Добавить запись
        public add_record add_record = new add_record();
        //Режим Удалить запись
        public del_record del_record = new del_record();
        //Режим Удаление петель
        public loops loops = new loops();
        //Режим Перемещение точек
        public move_dots move_dots = new move_dots();


        //Опции
        setuping settings = new setuping();
        //Вычисление
        public summ_calc summ_calc = new summ_calc();
        //Поиск
        public find 
            find = new find();
        
        //Список новых шкал Y
        public List<woodoo_y> shkalas = new List<woodoo_y>();
        //Новая шкала X
        public woodoo_x shkalas_x = new woodoo_x();
        public int how_many_woodoo = 0;
        //Поворот камеры
        public bool rot = false;

        //Публичные переменные
        //Размер viewport в пикселях
        public double dots = 100;
        public double dots_bak_x1 = 100;
        public double dots_bak_y1 = 100;
        public double dotsx = 100;
        public double dotsy = 100;
        public double dotsx1 = 100;
        public double dotsy1 = 100;
        public double dotsx3 = 100;
        public double dotsy3 = 100;
        //public double aa;
        //public double bb;
        //public double ddotsx;
        //public double ddotsy;

        //Мышка левая кнопка нажата
        public bool hit_mouse_left = false;
        //Мышка левая кнопка нажата
        public bool hit_mouse_right = false;
        //Мышка колесик
        public bool hit_mouse_whell = false;
        //Мышка левая кнопка нажата
        public bool hit_mouse_left2 = false;
        //Мышка левая кнопка нажата
        public bool hit_mouse_right2 = false;
        //Мышка колесик
        public bool hit_mouse_whell2 = false;
        //Мышка левая кнопка нажата
        public bool hit_mouse_left3 = false;
        //Мышка левая кнопка нажата
        public bool hit_mouse_right3 = false;
        //Мышка колесик
        public bool hit_mouse_whell3 = false;
        //Клавиатура
        public bool hit_shift = false;
        public bool hit_alt = false;
        public bool hit_ctrl = false;



        //Координаты мыши
        public int y_hit_before = 0;
        public int y_hit_after = 0;
        public int x_hit_before = 0;
        public int x_hit_after = 0;
        public double test;
        //Коэффициент Зума
        public double scale_xy = 4;
        public double scale_xy_good = 0.05;
        //Номер выбранного параметра
        public int numb_param = 0;
        //Список номеров выбранных параметров
        public List<int> numbs_param = new List<int>();
        //Индекс в списке текущего графика;
        public int curr_graph = 0;

        //Cетка временная переменная 
        public double new_new;
        //Триггер операции масштаба
        public bool work_zoom = false;
        //Триггер операции перемещение
        public bool work_move = false;
        //Режим редактирования
        public int edit_mode = 7;

        //Информация о файле
        public string beg_end_txt;
        public string status_file;
        //Координаты курсора
        public string status_value = "999999";
        public int x_move;
        public int y_move;
        //Цвет
        public color_collection color_amm = new color_collection();
        //Границы отоборажения графиков(Номер записи)
        public int left_corner;
        public int right_corner;
        //Имя файла
        public string name_file_back="nop";
        //Лицензия
        public bool tri_al = true;
        //Толщина линии графика
        public float main_line_width =1.0f;
        //Толщина точки
        public float dots_width = 3.0f;
        //Вкл..выкл точки
        public bool dots_on_off=true;
        //Толщина линии сетки
        public float grid_line_width = 4f;
        //Качество отрисовки
        public bool quality = false;

        //Путь к файлу
        public string work_path="";

        //Настройки
        ini nastr = new ini();
        XmlWriterSettings settings_ini = new XmlWriterSettings();
        XmlTextReader rdr = new XmlTextReader("Settings.xml");


        //Шаблон закраски
        public byte[] halftone = { 
      //0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
      //0x03, 0x80, 0x01, 0xC0, 0x06, 0xC0, 0x03, 0x60, 
      //0x04, 0x60, 0x06, 0x20, 0x04, 0x30, 0x0C, 0x20, 
      //0x04, 0x18, 0x18, 0x20, 0x04, 0x0C, 0x30, 0x20, 
      //0x04, 0x06, 0x60, 0x20, 0x44, 0x03, 0xC0, 0x22, 
      //0x44, 0x01, 0x80, 0x22, 0x44, 0x01, 0x80, 0x22, 
      //0x44, 0x01, 0x80, 0x22, 0x44, 0x01, 0x80, 0x22, 
      //0x44, 0x01, 0x80, 0x22, 0x44, 0x01, 0x80, 0x22, 
      //0x66, 0x01, 0x80, 0x66, 0x33, 0x01, 0x80, 0xCC, 
      //0x19, 0x81, 0x81, 0x98, 0x0C, 0xC1, 0x83, 0x30, 
      //0x07, 0xe1, 0x87, 0xe0, 0x03, 0x3f, 0xfc, 0xc0, 
      //0x03, 0x31, 0x8c, 0xc0, 0x03, 0x33, 0xcc, 0xc0, 
      //0x06, 0x64, 0x26, 0x60, 0x0c, 0xcc, 0x33, 0x30, 
      //0x18, 0xcc, 0x33, 0x18, 0x10, 0xc4, 0x23, 0x08, 
      //0x10, 0x63, 0xC6, 0x08, 0x10, 0x30, 0x0c, 0x08, 
      //0x10, 0x18, 0x18, 0x08, 0x10, 0x00, 0x00, 0x08 

0x00,0x00,0x00,0x00
,0x00,0x00,0x00,0x00
,0x00,0x00,0x00,0x00
,0x00,0x00,0x00,0x00
,0x00,0x00,0x00,0x00
,0x00,0x38,0x00,0x00
,0x00,0x48,0x00,0x10
,0x00,0xc0,0x3c,0x68
,0x01,0x88,0x64,0x86
,0x07,0x09,0xcd,0x02
,0x05,0x8f,0x89,0x02
,0x08,0xca,0xc9,0x02
,0x10,0x7a,0x69,0x04
,0x2e,0x4b,0x3f,0x08
,0x22,0x49,0x39,0x08
,0x20,0x41,0x19,0x10
,0x22,0x41,0x19,0x10
,0x27,0x41,0x19,0x08
,0x12,0x49,0x39,0x08
,0x09,0xcb,0x29,0x08
,0x0f,0x1e,0x6b,0x08
,0x06,0x3f,0xcd,0x04
,0x03,0xe0,0xf8,0x84
,0x00,0x40,0x04,0x48
,0x00,0x40,0x0c,0x30
,0x00,0x60,0x18,0x00
,0x00,0x30,0xe0,0x00
,0x00,0x1f,0x00,0x00
,0x00,0x00,0x00,0x00
,0x00,0x00,0x00,0x00
,0x00,0x00,0x00,0x00
,0x00,0x00,0x00,0x00



      // 0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55, 
      //0xAA, 0xAA, 0xAA, 0xAA, 0x55, 0x55, 0x55, 0x55 
    }; 
        public void init_class()
        {
            //Число откатов
            backupall.kol_otkatov = 10;

            //Рулетка XY
            //диапозон значений
            rul.begin_union = 0;
            rul.end_union = 5000;
            //xy рулетки; l-длина
            rul.x = 5;
            rul.y = 5;
            rul.l = 1000;
            //шаг рулетки x,y
            rul1.x_cur = 10;
            rul1.y_cur = 10;
            //число рисок
            rul.n_rizka = 100;
            //высота рисок
            rul.high_rizka = 2;
            //верт/гор расположение рулетки
            rul.hv_rizka = true;
            //размер текста меток
            rul.size_text = 10;
            //отступ текста от оси 
            rul.v_text_disp = 1.4;
            //разрядность значений
            rul.number_char = 3;
            //название рулетки
            rul.type_r = "Время:";
            //цвет рулетки

            rul.color[0] = 0.0f;
            rul.color[1] = 0.0f;
            rul.color[2] = 0.0f;
            //пересчет рулетки
            rul.calc();

            //Рулетка X
            //диапозон значений
            rul1.begin_union = 0;
            rul1.end_union = 5000;
            //xy рулетки; l-длина
            rul1.x = 5;
            rul1.y = 90;
            rul1.l = 1000;
            //шаг рулетки x,y
            rul1.x_cur = 20;
            rul1.y_cur = 20;
            //число рисок
            rul1.n_rizka = 100;
            //число доп рисок
            rul1.n_rizka_add = 6;
            //высота рисок
            rul1.high_rizka = 20;
            //верт/гор расположение рулетки
            rul1.hv_rizka = true;
            //размер текста меток
            rul1.size_text = 10;
            //отступ текста Y
            rul1.v_text_disp = 21;
            //разрядность значений
            rul1.number_char = 3;
            //название рулетки
            rul1.type_r = "Время:";
            rul1.type_r_bool = false;
            //цвет рулетки
            rul1.color[0] = 0.0f;
            rul1.color[1] = 0.0f;
            rul1.color[2] = 0.0f;
            //масштаб x
            rul1.scalex = 1;
            //пересчет рулетки
            rul1.calc();
            rul1.new_pos_text = 0;
            rul1.old_pos_text = rul1.new_pos_text;

            //Рулетка Y
            //диапозон значений
            rul2.begin_union = 0;
            rul2.end_union = 400;
            //xy рулетки; l-длина
            rul2.x = 5;
            rul2.y = 90;
            rul2.l = 100;
            //шаг рулетки x,y
            rul2.x_cur = 20;
            rul2.y_cur = 20;
            //число рисок
            rul2.n_rizka = 10;
            //число доп рисок
            rul2.n_rizka_add = 6;
            //высота рисок
            rul2.high_rizka = 20;
            //верт/гор расположение рулетки
            rul2.hv_rizka = true;
            //размер текста меток
            rul2.size_text = 10;
            //отступ текста Y
            rul2.v_text_disp = 23;
            //разрядность значений
            rul2.number_char = 3;
            //название рулетки
            rul2.type_r = "Время:";
            //тип файла dep
            rul2.type_r_bool = false;
            //цвет рулетки
            rul2.color[0] = 0.0f;
            rul2.color[1] = 0.3f;
            rul2.color[2] = 0.0f;
            //масштаб x
            rul2.scalex = 2;
            //пересчет рулетки
            rul2.calc();



            //Часовой пояс
            data.timeshift_hourse =Convert.ToInt32(nastr.time_shift);
        }

        public SharpGLForm()
        {
            //Инициализация свойств классов
            init_class();
            //Инициализация Sharpgl
            InitializeComponent();
        }

        private void openGLControl_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl1.OpenGL;
            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //  Load the identity matrix.

            //gl.ShadeModel(OpenGL.GL_SMOOTH);
            //gl.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);
            //gl.Enable(OpenGL.GL_SMOOTH);
            
            //Качество отрисовки
            if (quality == true)
            {
                gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
                gl.Enable(OpenGL.GL_BLEND);
                // Сглаживание точек
                gl.Enable(OpenGL.GL_POINT_SMOOTH);
                gl.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
                // Сглаживание линий
                gl.Enable(OpenGL.GL_LINE_SMOOTH);
                gl.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);
                // Сглаживание полигонов    
                //gl.Enable(OpenGL.GL_POLYGON_SMOOTH);
                //gl.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_NICEST);
            }
            else {
                gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
                gl.Disable(OpenGL.GL_BLEND);
                // Сглаживание точек
                gl.Disable(OpenGL.GL_POINT_SMOOTH);
                gl.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_FASTEST);
                // Сглаживание линий
                gl.Disable(OpenGL.GL_LINE_SMOOTH);
                gl.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_FASTEST);
                // Сглаживание полигонов    
                gl.Disable(OpenGL.GL_POLYGON_SMOOTH);
                gl.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_FASTEST);
            }

            gl.LoadIdentity();
            //Перемещение камеры
            gl.Translate(0, 0, 1);

            
           
            //Поворот аппаратный
            if (rot) {
                gl.Rotate(0, 0, 45);
                //gl.Sphere()
                //rot = false;
            }

            if (data.dep_ok & how_many_woodoo > 0)
            {
                ////Толщина линий
                gl.LineWidth(1.0f);

                //Сетка
                gl.Enable(OpenGL.GL_LINE_STIPPLE);
                gl.LineStipple(1, 0x8888);
                gl.Begin(OpenGL.GL_LINES);
                for (int i = 0; i < shkalas[curr_graph].bi_mass.Length; i++)
                {
                    new_new = rul2.x + (shkalas[curr_graph].bi_mass[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                    gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                    gl.Vertex(a, new_new, 0.0f);
                    gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                    gl.Vertex(dotsx, new_new, 0.0f);
                }
                new_new = rul2.x + ((2 * shkalas[curr_graph].bi_mass[0] - shkalas[curr_graph].bi_mass[1]) - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(a, new_new, 0.0f);
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(dotsx, new_new, 0.0f);
                new_new = rul2.x + ((shkalas[curr_graph].bi_mass[shkalas[curr_graph].bi_mass.Length - 1] + (shkalas[curr_graph].bi_mass[1] - shkalas[curr_graph].bi_mass[0])) - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(a, new_new, 0.0f);
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(dotsx, new_new, 0.0f);
                gl.End();
                gl.Begin(OpenGL.GL_LINES);
                for (int i = 0; i < shkalas_x.bi_mass.Length; i++)
                {
                    new_new = rul.x + (shkalas_x.bi_mass[i] - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union));
                    gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                    gl.Vertex(new_new, b, 0.0f);
                    gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                    gl.Vertex(new_new, dotsy, 0.0f);
                }
                new_new = rul.x + ((2 * shkalas_x.bi_mass[0] - shkalas_x.bi_mass[1]) - shkalas_x.begin_union) * (rul.l / (shkalas_x.end_union - shkalas_x.begin_union));
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(new_new, b, 0.0f);
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(new_new, dotsy, 0.0f);
                new_new = rul.x + ((shkalas_x.bi_mass[shkalas_x.bi_mass.Length - 1] + shkalas_x.bi_mass[1] - shkalas_x.bi_mass[0]) - shkalas_x.begin_union) * (rul.l / (shkalas_x.end_union - shkalas_x.begin_union));
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(new_new, b, 0.0f);
                gl.Color(shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2]);
                gl.Vertex(new_new, dotsy, 0.0f);

                gl.End();
                gl.Disable(OpenGL.GL_LINE_STIPPLE);

                //Заливка по шаблону
                //gl.PolygonStipple(halftone);
                //gl.Enable(OpenGL.GL_POLYGON_STIPPLE);
                
                //a Viewport
                //gl.DrawText((int)0,
                //            (int)20,
                //                     shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                //                    (float)rul1.size_text, "REAL a="+coord3[0].ToString());
                //gl.DrawText((int)0,
                //           (int)30,
                //                    shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                //                   (float)rul1.size_text, "CALC a=" + a.ToString());
                
                ////b Viewport
                ////gl.DrawText((int)0,
                ////            (int)40,
                ////                     shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                ////                    (float)rul1.size_text, "REAL b=" + coord3[1].ToString());
                //gl.DrawText((int)0,
                //           (int)50,
                //                    shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                //                   (float)rul1.size_text, "CALC b=" + b.ToString());


                
                ////dotx Viewport
                ////gl.DrawText((int)0,
                ////            (int)60,
                ////                     shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                ////                    (float)rul1.size_text, "REAL dotsx=" + coord3[0].ToString());
                //gl.DrawText((int)0,
                //           (int)70,
                //                    shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                //                   (float)rul1.size_text, "CALC dotsx=" + dotsx.ToString());

                ////doty Viewport
                ////gl.DrawText((int)0,
                ////            (int)80,
                ////                     shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                ////                    (float)rul1.size_text, "REAL dotsy=" + coord3[1].ToString());
                //gl.DrawText((int)0,
                //           (int)90,
                //                    shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                //                   (float)rul1.size_text, "CALC dotsy=" + dotsy.ToString());

                //Толщина линий
                gl.LineWidth(main_line_width);

                //Новая линия(Режим Переместить точки)
                if (edit_mode == 7)
                {
                    if (move_dots.new_x_point.Count >= 1)
                    {
                        //gl.Begin(OpenGL.GL_LINE_STRIP);
                        //for (int i = 0; i < move_dots.new_x_point.Count; i++)
                        //{
                        //    gl.Color(1.0f, 0.0f, 0.0f);
                        //    gl.Vertex(move_dots.new_x_point[i], move_dots.new_y_point[i], 0f);
                        //}
                        //gl.LineWidth(dots_width);

                        //Линия курсора(интерактивная)
                        gl.Begin(OpenGL.GL_POINT);
                        gl.Color(1.0f, 0.0f, 0.0f);
                        gl.Vertex(move_dots.cur_coord_x, move_dots.cur_coord_y, 0f);
                        gl.End();
                        
                        //Горизонтальная доп линия
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(a, move_dots.cur_coord_y, 0f);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(dotsx, move_dots.cur_coord_y, 0f);
                        gl.End();

                        //Вертикальная доп линия
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(move_dots.cur_coord_x, b, 0f);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(move_dots.cur_coord_x, dotsy, 0f);
                        gl.End();
                        gl.LineWidth(main_line_width);

                        gl.PointSize(dots_width);
                        gl.Begin(OpenGL.GL_POINTS);
                        for (int i = 0; i < move_dots.new_x_point.Count; i++)
                        {
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(move_dots.new_x_point[i], move_dots.new_y_point[i], 0f);

                        }
                        gl.Color(1.0f, 0.0f, 0.0f);
                        gl.Vertex(move_dots.cur_coord_x, move_dots.cur_coord_y, 0f);
                        gl.End();

                        gl.Enable(OpenGL.GL_LINE_STIPPLE);
                        gl.LineStipple((int)dots_width, 0xCCCC);
                        
                        //Квадрат выбора области(интерактивный)
                        if (move_dots.new_x_point.Count == 1)
                        {
                            //Пунктир
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                            gl.Begin(OpenGL.GL_QUADS);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.cur_coord_x, move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.cur_coord_x, move_dots.cur_coord_y, 0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.cur_coord_y, 0f);
                            gl.End();
                            //Точки
                            gl.PointSize(dots_width*2);
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);
                            gl.Begin(OpenGL.GL_QUADS);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.cur_coord_x, move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.cur_coord_x, move_dots.cur_coord_y, 0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.cur_coord_y, 0f);
                            gl.End();
                            
                        }
                        if (move_dots.new_x_point.Count == 2)
                        {
                            //gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                            //gl.Begin(OpenGL.GL_QUADS);
                            //gl.Color(0f, 0.4f, 0f);
                            //gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[0], 0f);
                            //gl.Vertex(move_dots.new_x_point[1], move_dots.new_y_point[0], 0f);
                            //gl.Vertex(move_dots.new_x_point[1], move_dots.new_y_point[1], 0f);
                            //gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[1], 0f);
                            //gl.End();
                            //Пунктир
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                            gl.Begin(OpenGL.GL_QUADS);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.new_x_point[1], move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.new_x_point[1], move_dots.new_y_point[1], 0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[1], 0f);
                            gl.End();
                            //Точки
                            gl.PointSize(dots_width * 2);
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);
                            gl.Begin(OpenGL.GL_QUADS);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.new_x_point[1], move_dots.new_y_point[0], 0f);
                            gl.Vertex(move_dots.new_x_point[1], move_dots.new_y_point[1], 0f);
                            gl.Vertex(move_dots.new_x_point[0], move_dots.new_y_point[1], 0f);
                            gl.End();

                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                        }
                        gl.Disable(OpenGL.GL_LINE_STIPPLE);
                        gl.PointSize(dots_width);
                    }
                }


                //(Режим Удалить Записи)Новая  вертикальная линия
                if (edit_mode == 6)
                {
                    if (del_record.new_x_point.Count > 0)
                    {
                        if (del_record.new_x_point.Count == 2)
                        {
                            gl.Begin(OpenGL.GL_POLYGON);
                            gl.Color(0.0f, 0.0f, 0.5f);
                            gl.Vertex(del_record.new_x_point[0], b, 0f);
                            //gl.Color(0.5f, 1.0f, 0.5f);
                            gl.Vertex(del_record.new_x_point[0], dotsy, 0f);
                            gl.Vertex(del_record.new_x_point[1], dotsy, 0f);
                            gl.Vertex(del_record.new_x_point[1], b, 0f);
                            gl.End();
                        }
                        for (int i = 0; i < del_record.new_x_point.Count; i++)
                        {
                            gl.Begin(OpenGL.GL_LINE_LOOP);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(del_record.new_x_point[i], b, 0f);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(del_record.new_x_point[i], dotsy, 0f);
                            gl.End();
                        }
                    }
                }

                 //(Режим Добавить Записи)Новая  вертикальная линия
                if (edit_mode == 5)
                {
                    if (add_record.new_x_point.Count > 0)
                    {
                        if (add_record.new_x_point.Count == 2)
                        {
                            gl.Begin(OpenGL.GL_POLYGON);
                            gl.Color(0.0f, 0.0f, 0.5f);
                            gl.Vertex(add_record.new_x_point[0], b, 0f);
                            //gl.Color(0.5f, 1.0f, 0.5f);
                            gl.Vertex(add_record.new_x_point[0], dotsy, 0f);
                            gl.Vertex(add_record.new_x_point[1], dotsy, 0f);
                            gl.Vertex(add_record.new_x_point[1], b, 0f);
                            gl.End();
                        }
                        for (int i = 0; i < add_record.new_x_point.Count; i++)
                        {
                            gl.Begin(OpenGL.GL_LINE_LOOP);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(add_record.new_x_point[i], b, 0f);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(add_record.new_x_point[i], dotsy, 0f);
                            gl.End();
                        }
                    }
                }

                //(Режим Шум/Смещение)Новая  вертикальная линия
                if (edit_mode == 2)
                {
                    if (noise.new_x_point.Count > 0)
                    {
                        if (noise.new_x_point.Count == 2)
                        {
                            gl.Begin(OpenGL.GL_POLYGON);
                            gl.Color(0.0f, 0.0f, 0.5f);
                            gl.Vertex(noise.new_x_point[0], b, 0f);
                            //gl.Color(0.5f, 1.0f, 0.5f);
                            gl.Vertex(noise.new_x_point[0], dotsy, 0f);
                            gl.Vertex(noise.new_x_point[1], dotsy, 0f);
                            gl.Vertex(noise.new_x_point[1], b, 0f);
                            gl.End();
                        }
                        for (int i = 0; i < noise.new_x_point.Count; i++)
                        {
                            gl.Begin(OpenGL.GL_LINE_LOOP);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(noise.new_x_point[i], b, 0f);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(noise.new_x_point[i], dotsy, 0f);
                            gl.End();
                        }
                    }

                    //Шум/Смещение
                    if (noise.new_x_point_coord.Count > 1)
                    {
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        for (int i = 0; i < noise.new_x_point_coord.Count; i++)
                        {
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(noise.new_x_point_coord[i], noise.new_y_point_coord[i], 0f);
                        }
                        gl.End();
                    }
                }

                //(Режим Копировать)Новая  вертикальная линия
                if (edit_mode == 1)
                {
                    if (copy_paste.new_x_point.Count > 0)
                    {
                        if (copy_paste.new_x_point.Count == 2)
                        {
                            gl.Begin(OpenGL.GL_POLYGON);
                            gl.Color(0.0f, 0.0f, 0.5f);
                            gl.Vertex(copy_paste.new_x_point[0], b, 0f);
                            //gl.Color(0.5f, 1.0f, 0.5f);
                            gl.Vertex(copy_paste.new_x_point[0], dotsy, 0f);
                            gl.Vertex(copy_paste.new_x_point[1], dotsy, 0f);
                            gl.Vertex(copy_paste.new_x_point[1], b, 0f);
                            gl.End();
                        }
                        for (int i = 0; i < copy_paste.new_x_point.Count; i++)
                        {
                            gl.Begin(OpenGL.GL_LINE_LOOP);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(copy_paste.new_x_point[i], b, 0f);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(copy_paste.new_x_point[i], dotsy, 0f);
                            gl.End();
                        }
                       
                    }
                }

                //(Режим Вычислить)Новая  вертикальная линия
                if (edit_mode == 3)
                {
                    if (summ_calc.new_x_point.Count > 0)
                    {
                        if (summ_calc.new_x_point.Count == 2)
                        {
                            gl.Begin(OpenGL.GL_POLYGON);
                            gl.Color(0.0f, 0.0f, 0.5f);
                            gl.Vertex(summ_calc.new_x_point[0], b, 0f);
                            //gl.Color(0.5f, 1.0f, 0.5f);
                            gl.Vertex(summ_calc.new_x_point[0], dotsy, 0f);
                            gl.Vertex(summ_calc.new_x_point[1], dotsy, 0f);
                            gl.Vertex(summ_calc.new_x_point[1], b, 0f);
                            gl.End();
                        }
                        for (int i = 0; i < summ_calc.new_x_point.Count; i++)
                        {
                            gl.Begin(OpenGL.GL_LINE_LOOP);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(summ_calc.new_x_point[i], b, 0f);
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(summ_calc.new_x_point[i], dotsy, 0f);
                            gl.End();
                        }

                    }
                }


                


                //График
                left_corner = 0;
                right_corner = (shkalas[curr_graph].x_coord.Count)-1;
                for (int g = 0; g < shkalas[curr_graph].x_coord.Count; g++)
                {
                    if (shkalas[curr_graph].x_coord[g] < a)
                    {
                        left_corner = g;
                    }
                    if (shkalas[curr_graph].x_coord[g] > (Math.Abs(a) + Math.Abs(dotsx)))
                    {
                        right_corner = g;
                        break;
                    }
                }

                for (int g = 0; g < shkalas.Count; g++)
                {
                    gl.Begin(OpenGL.GL_LINE_STRIP);
                    for (int i = left_corner; i <= right_corner; i++)
                    {
                        
                        gl.Color(shkalas[g].color[0], shkalas[g].color[1], shkalas[g].color[2]);
                        gl.Vertex(shkalas[g].x_coord[i], shkalas[g].y_coord[i], 0.0f);
                        
                    }
                    gl.End();

                }


                //Вкл..выкл точки
                if (dots_on_off)
                {
                    //Точки на графике
                    gl.PointSize(dots_width);
                    gl.Begin(OpenGL.GL_POINTS);
                    for (int i = left_corner; i <= right_corner; i++)
                    {
                        //if (shkalas[curr_graph].x_coord[i] > dotsx + (dotsx - a) / 10) { break; }
                        //if (shkalas[curr_graph].x_coord[i] >= a - (dotsx - a) / 10)
                        //{
                        //Random r=new Random();
                        //double col = Convert.ToDouble(r.Next(100)) / 100;
                        gl.Color(shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2]);
                        gl.Vertex(shkalas[curr_graph].x_coord[i], shkalas[curr_graph].y_coord[i], 0.0f);

                        //}
                    }
                    gl.End();
                }
                

                

                //Новая линия(Режим Рисовать)
                if (edit_mode == 0)
                {
                    if (data.new_x_point.Count >= 1)
                    {
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        for (int i = 0; i < data.new_x_point.Count; i++)
                        {
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(data.new_x_point[i], data.new_y_point[i], 0f);
                        }
                        gl.LineWidth(dots_width);
                        //Линия курсора(интерактивная)
                        gl.Color(1.0f, 0.0f, 0.0f);
                        gl.Vertex(data.cur_coord_x, data.cur_coord_y, 0f);
                        gl.End();
                        //Горизонтальная доп линия
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(a, data.cur_coord_y, 0f);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(dotsx, data.cur_coord_y, 0f);
                        gl.End();

                        //Вертикальная доп линия
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(data.cur_coord_x, b, 0f);
                        gl.Color(0f, 0.4f, 0f);
                        gl.Vertex(data.cur_coord_x, dotsy, 0f);
                        gl.End();
                        gl.LineWidth(main_line_width);

                        gl.PointSize(dots_width);
                        gl.Begin(OpenGL.GL_POINTS);
                        for (int i = 0; i < data.new_x_point.Count; i++)
                        {
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(data.new_x_point[i], data.new_y_point[i], 0f);

                        }
                        gl.Color(1.0f, 0.0f, 0.0f);
                        gl.Vertex(data.cur_coord_x, data.cur_coord_y, 0f);
                        gl.End();
                    }
                }


                //Шум/Смещение Макет будующей кривой
                if (edit_mode == 2)
                {
                    if (noise.new_x_point_coord.Count > 1)
                    {
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        for (int i = 0; i < noise.new_x_point_coord.Count; i++)
                        {
                            gl.Color(1.0f, 0.0f, 0.0f);
                            gl.Vertex(noise.new_x_point_coord[i], noise.new_y_point_coord[i], 0f);
                        }
                        gl.End();
                    }
                }



                //Новая линия(Режим Измерить)
                if (edit_mode == 4)
                {
                    if (measure.new_y_point.Count >= 1)
                    {
                        gl.Enable(OpenGL.GL_LINE_STIPPLE);
                        gl.LineStipple(1, 0xFF0C);
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        for (int i = 0; i < measure.new_x_point.Count; i++)
                        {
                            gl.Color(0.5f, 1.0f, 0.5f);
                            gl.Vertex(measure.new_x_point[i], measure.new_y_point[i], 0f);
                        }
                        //Линия курсора(интерактивная)
                        gl.Color(0.5f, 1.0f, 0.5f);
                        gl.Vertex(data.cur_coord_x, data.cur_coord_y, 0f);
                        gl.End();
                        //Горизонтальная доп линия
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        gl.Color(0.5f, 1.0f, 0.5f);
                        gl.Vertex(a, data.cur_coord_y, 0f);
                        gl.Color(0.5f, 1.0f, 0.5f);
                        gl.Vertex(dotsx, data.cur_coord_y, 0f);
                        gl.End();

                        //Вертикальная доп линия
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        gl.Color(0.5f, 1.0f, 0.5f);
                        gl.Vertex(data.cur_coord_x, b, 0f);
                        gl.Color(0.5f, 1.0f, 0.5f);
                        gl.Vertex(data.cur_coord_x, dotsy, 0f);
                        gl.End();


                        gl.PointSize(3f);
                        gl.Begin(OpenGL.GL_POINTS);
                        for (int i = 0; i < measure.new_x_point.Count; i++)
                        {
                            gl.Color(0.5f, 1.0f, 0.5f);
                            gl.Vertex(measure.new_x_point[i], measure.new_y_point[i], 0f);
                           

                        }
                        gl.Color(0.5f, 1.0f, 0.5f);
                        gl.Vertex(data.cur_coord_x, data.cur_coord_y, 0f);
                        gl.End();
                        for (int i = 1; i < measure.new_x_point.Count; i++)
                        {
                            if (rul1.type_r_bool)
                            {
                                //Координаты курсора
                                //data.value_to_date(Math.Round(measure.new_x_point_disp[i], 0));
                                //measure.now_time = data.Hour + ":" +
                                //    data.Minute + ":" + data.Seconds;
                                
                                gl.DrawText((int)((measure.new_x_point[i] - a) * rul.aspect_x),
                                            (int)((((measure.new_y_point[i] - b) * rul.aspect_y))),
                                                  0.0f, 0.0f, 1.0f, "Tahoma",
                                                 (float)rul1.size_text,
                                 ("DX=" + (Math.Round(measure.new_x_point_disp[i], 0)).ToString() + "cek.   DY=" + (Math.Round((measure.new_y_point_disp[i]), 4)).ToString()));
                            }
                            else
                            {

                                gl.DrawText((int)((measure.new_x_point[i] - a) * rul.aspect_x),
                                            (int)((((measure.new_y_point[i] - b) * rul.aspect_y))),
                                                  0f, 0f, 1.0f, "Tahoma",
                                                 (float)rul1.size_text,
                                 ("DX=" + Math.Round((measure.new_x_point_disp[i]), 4).ToString() + "m.   DY=" + (Math.Round((measure.new_y_point_disp[i]), 4)).ToString()));
                            }

                        }
                        gl.Disable(OpenGL.GL_LINE_STIPPLE);
                        //Текст Названия параметра
                        //for (int i = 0; i < shkalas[g].text_char.Length; i++)
                        //    gl2.DrawText((int)((shkalas[g].x + shkalas[g].dx / 3.5) * rul2.aspect_x),
                        //                (int)(((shkalas[g].d2 - shkalas[g].dy - (float)rul1.size_text) - i * shkalas[g].dy / 2 - b2) * rul2.aspect_y),
                        //                 shkalas[g].color[0], shkalas[g].color[1], shkalas[g].color[2], "Tahoma",
                        //                (float)rul1.size_text, shkalas[g].text_char[i].ToString());
                        
                    }
                    //Application.DoEvents();
                }
                if (status_value != "999999")
                {
                    //Демонстрация
                    gl.DrawText(0, openGLControl1.Height - 10,
                         shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                          (float)rul1.size_text, status_value);
                }



            }
            else
            {
                //Заставка
                //gl.Begin(OpenGL.GL_LINE_STRIP);
                //gl.Color(0.5f, 1.0f, 0.5f);
                //gl.Vertex(0, 0, 0f);
                //gl.Color(0.5f, 1.0f, 0.5f);
                //gl.Vertex(dotsx, dotsx, 0f);
                //gl.End();

            }
        }



        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl1.OpenGL;
            //  Set the clear color.
            //113,111,100
            gl.ClearColor(0.0f, 0.0f, 0.0f, 0);
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl1.OpenGL;
            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity.
            gl.LoadIdentity();
            gl.Viewport(0, 0, openGLControl1.Width, openGLControl1.Height);
            //Пропорции экрана
            double aspect = openGLControl1.Width / openGLControl1.Height;
            double inv_aspect = openGLControl1.Height / openGLControl1.Width;

            if (openGLControl1.Width <= openGLControl1.Height)
            {
                gl.Ortho2D(a, dotsx, b, dotsy * inv_aspect);
            }
            else
            {
                gl.Ortho2D(a, dotsx, b, dotsy);
            }
            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            rul.aspect_x = openGLControl1.Width / dotsx;
            rul.aspect_y = openGLControl1.Height / dotsy;
        }

        //Ось х
        private void openGLControl3_OpenGLDraw(object sender, PaintEventArgs e)
        {


            //  Get the OpenGL object.
            OpenGL gl1 = openGLControl3.OpenGL;
            //  Clear the color and depth buffer.
            gl1.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //  Load the identity matrix.
            //Качество отрисовки
            //if (quality == true)
            //{
            //    gl1.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //    gl1.Enable(OpenGL.GL_BLEND);
            //    // Сглаживание точек
            //    gl1.Enable(OpenGL.GL_POINT_SMOOTH);
            //    gl1.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание линий
            //    gl1.Enable(OpenGL.GL_LINE_SMOOTH);
            //    gl1.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание полигонов    
            //    //gl.Enable(OpenGL.GL_POLYGON_SMOOTH);
            //    //gl.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_NICEST);
            //}
            //else
            //{
            //    gl1.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //    gl1.Disable(OpenGL.GL_BLEND);
            //    // Сглаживание точек
            //    gl1.Disable(OpenGL.GL_POINT_SMOOTH);
            //    gl1.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание линий
            //    gl1.Disable(OpenGL.GL_LINE_SMOOTH);
            //    gl1.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание полигонов    
            //    gl1.Disable(OpenGL.GL_POLYGON_SMOOTH);
            //    gl1.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_NICEST);
            //}
            //gl1.LineWidth(main_line_width);
            gl1.LoadIdentity();
            gl1.Translate(0, 0, -1);


            //Новая Рулетка


            if (data.dep_ok)
            {
                gl1.Begin(OpenGL.GL_LINES);
                for (int i = 0; i < shkalas_x.all_coord.Length; i += 2)
                {   //Проверка b[i] за границей шкалы b[n] ... i----i----i----i----i ... b[n]
                    if (shkalas_x.all_coord[i + 1] >= shkalas_x.dy & shkalas_x.all_coord[i + 1] <= (shkalas_x.d2 - shkalas_x.dy))
                    {

                        gl1.Color(shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2]);
                        gl1.Vertex(shkalas_x.all_coord[i + 1], shkalas_x.all_coord[i], 0f);
                    }
                }
                gl1.End();

                int j = 0;
                for (int i = 4 + 4; i < shkalas_x.all_coord.Length; i = 4 + i)
                {   //Проверка b[i] за границей шкалы b[n] ... i----i----i----i----i ... b[n]
                    //Текст Значений параметра
                    if (shkalas_x.all_coord[i + 1] >= shkalas_x.dy & shkalas_x.all_coord[i + 1] <= (shkalas_x.d2 - shkalas_x.dy))
                    {
                        if (rul1.type_r_bool)
                        {
                            data.value_to_date(shkalas_x.bi_mass[j]);
                            gl1.DrawText((int)((shkalas_x.all_coord[i + 1] - b2) * rul1.aspect_x - (float)rul1.size_text),
                                (int)((shkalas_x.all_coord[i] + +shkalas_x.dx * 1.1) * rul1.aspect_y),

                                shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                                (float)rul1.size_text, (data.Hour + ":" + data.Minute));
                        }
                        else
                        {
                            gl1.DrawText((int)((shkalas_x.all_coord[i + 1] - b2) * rul1.aspect_x - (float)rul1.size_text),
                               (int)((shkalas_x.all_coord[i] + +shkalas_x.dx * 1.1) * rul1.aspect_y),

                                shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                               (float)rul1.size_text, Math.Round(shkalas_x.bi_mass[j], shkalas_x.precission).ToString());

                        }

                    } j++;
                }
                //Текст Названия параметра
                //for (int i = 0; i < shkalas_x.text_char.Length; i++)
                gl1.DrawText((int)(((shkalas_x.y) + 50 - shkalas_x.text_char.Length / 4) * rul1.aspect_x),
                    (int)((shkalas_x.x + shkalas_x.dx / 4) * rul1.aspect_y),
                             shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                            (float)rul1.size_text, shkalas_x.text_print);
                //Описание файла
                gl1.DrawText((int)(((shkalas_x.y)) * rul1.aspect_x),
                            (int)((shkalas_x.y + 5) * rul1.aspect_y),
                                     shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                                    (float)rul1.size_text, (status_file));
                //Число и Месяц Год
                if (rul1.type_r_bool)
                {
                    data.value_to_date(shkalas_x.bi_mass[0]);
                    gl1.DrawText((int)(((shkalas_x.y) + 5) * rul1.aspect_x),
                        (int)((shkalas_x.x + shkalas_x.dx / 4) * rul1.aspect_y),
                                 shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2], "Tahoma",
                                (float)rul1.size_text, (data.Day + "." + data.Month + "." + data.Year));
                    //data.value_to_date(shkalas_x.bi_mass[shkalas_x.bi_mass.Length-1]);
                    //gl1.DrawText((int)((-5 + shkalas_x.d2) * rul1.aspect_x),
                    //    (int)((shkalas_x.x + shkalas_x.dx / 4) * rul1.aspect_y),
                    //             shkalas_x.color[0], shkalas_x.color[1], shkalas_x.color[2], "Tahoma",
                    //            (float)rul1.size_text, (data.Day + "." + data.Month));  

                }

            }

        }

        private void openGLControl3_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl1 = openGLControl3.OpenGL;
            //  Set the clear color.
            gl1.ClearColor(113 / 256, 111 / 256, 100 / 256, 0);
        }

        private void openGLControl3_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl1 = openGLControl3.OpenGL;
            //  Set the projection matrix.
            gl1.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity.
            gl1.LoadIdentity();
            gl1.Viewport(0, 0, openGLControl3.Width, openGLControl3.Height);
            //Пропорции экрана
            double aspect1 = openGLControl3.Width / openGLControl3.Height;
            double inv_aspect1 = openGLControl3.Height / openGLControl3.Width;
            gl1.Ortho2D(a1, dotsx1, b1, dotsy1);
            //  Set the modelview matrix.
            gl1.MatrixMode(OpenGL.GL_MODELVIEW);

            aspetxy();
            //if (data.dep_ok)
            //{

            //    {
            //        shkalas_x.N = (uint)(20*(openGLControl3.Width/shkalas_x.old_fact_height));
            //        shkalas_x.n = 10;
            //        shkalas_x.init();
            //        shkalas_x.all_calc_init();
            //    }
            //}

        }

        private void openGLControl2_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl2 = openGLControl2.OpenGL;
            //  Clear the color and depth buffer.
            gl2.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //  Load the identity matrix.
            //Качество отрисовки
            //if (quality == true)
            //{
            //    gl2.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //    gl2.Enable(OpenGL.GL_BLEND);
            //    // Сглаживание точек
            //    gl2.Enable(OpenGL.GL_POINT_SMOOTH);
            //    gl2.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание линий
            //    gl2.Enable(OpenGL.GL_LINE_SMOOTH);
            //    gl2.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание полигонов    
            //    //gl.Enable(OpenGL.GL_POLYGON_SMOOTH);
            //    //gl.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_NICEST);
            //}
            //else
            //{
            //    gl2.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            //    gl2.Disable(OpenGL.GL_BLEND);
            //    // Сглаживание точек
            //    gl2.Disable(OpenGL.GL_POINT_SMOOTH);
            //    gl2.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание линий
            //    gl2.Disable(OpenGL.GL_LINE_SMOOTH);
            //    gl2.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_NICEST);
            //    // Сглаживание полигонов    
            //    gl2.Disable(OpenGL.GL_POLYGON_SMOOTH);
            //    gl2.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_NICEST);
            //}
            //gl2.LineWidth(main_line_width);
            gl2.LoadIdentity();
            gl2.Translate(0, 0, -1);

            //Пример новой рулетки (отрисовка)
            if (data.dep_ok)
            {
                for (int g = 0; g < shkalas.Count; g++)
                {
                    //Выделенный график
                    gl2.Begin(OpenGL.GL_POLYGON);
                    gl2.Color(shkalas[curr_graph].color[0], shkalas[curr_graph].color[1], shkalas[curr_graph].color[2]);
                    gl2.Vertex(shkalas[curr_graph].all_coord[0], shkalas[curr_graph].all_coord[1], 0f);
                    gl2.Vertex((shkalas[curr_graph].all_coord[4] - shkalas[curr_graph].dx/8), (shkalas[curr_graph].all_coord[5]), 0f);
                    gl2.Vertex((shkalas[curr_graph].all_coord[6] - shkalas[curr_graph].dx/8), (shkalas[curr_graph].all_coord[7]), 0f);
                    gl2.Vertex(shkalas[curr_graph].all_coord[2], shkalas[curr_graph].all_coord[3], 0f);
                    
                    
                    
                    
                    
                    gl2.End();

                    gl2.Begin(OpenGL.GL_LINES);
                    for (int i = 0; i < shkalas[g].all_coord.Length; i += 2)
                    {   //Проверка b[i] за границей шкалы b[n] ... i----i----i----i----i ... b[n]
                        if (shkalas[g].all_coord[i + 1] >= shkalas[g].dy & shkalas[g].all_coord[i + 1] <= (shkalas[g].d2 - shkalas[g].dy))
                        {

                            gl2.Color(shkalas[g].color[0], shkalas[g].color[1], shkalas[g].color[2]);
                            gl2.Vertex(shkalas[g].all_coord[i], shkalas[g].all_coord[i + 1], 0f);
                        }
                    }
                    gl2.End();

                    int j = 0;
                    for (int i = 4 + 4; i < shkalas[g].all_coord.Length; i = 4 + i)
                    {   //Проверка b[i] за границей шкалы b[n] ... i----i----i----i----i ... b[n]
                        //Текст Значений параметра
                        if (shkalas[g].all_coord[i + 1] >= shkalas[g].dy & shkalas[g].all_coord[i + 1] <= (shkalas[g].d2 - shkalas[g].dy))
                        {

                            gl2.DrawText((int)((shkalas[g].all_coord[i] + shkalas[g].dx * 3 / 5) * rul2.aspect_x),
                                (int)((shkalas[g].all_coord[i + 1] - b2) * rul2.aspect_y),
                                 shkalas[g].color[0], shkalas[g].color[1], shkalas[g].color[2], "Tahoma",
                                (float)rul1.size_text, Math.Round(shkalas[g].bi_mass[j], shkalas[g].precission).ToString());

                        } j++;
                    }
                    //Текст Названия параметра
                    for (int i = 0; i < shkalas[g].text_char.Length; i++)
                        gl2.DrawText((int)((shkalas[g].x + shkalas[g].dx / 3.5) * rul2.aspect_x),
                                    (int)(((shkalas[g].d2 - shkalas[g].dy - (float)rul1.size_text) - i * shkalas[g].dy / 2 - b2) * rul2.aspect_y),
                                     shkalas[g].color[0], shkalas[g].color[1], shkalas[g].color[2], "Tahoma",
                                    (float)rul1.size_text, shkalas[g].text_char[i].ToString());
                }

            }



            //Старая Рулетка

            //rul2.high_rizka_2 = rul2.high_rizka / 2;
            //rul2.step_r = rul2.l / rul2.n_rizka;
            //rul2.step_txt = (rul2.end_union - rul2.begin_union) / rul2.n_rizka;

            //gl2.Begin(OpenGL.GL_LINES);
            //gl2.Color(0.0f, 0.4f, 0.0f);
            //gl2.Vertex(rul2.y,rul2.x, 0f);
            //gl2.Color(0.0f, 0.4f, 0.0f);
            //gl2.Vertex(rul2.y,rul2.x + rul2.l, 0f);
            //gl2.End();
            //int q = (int)((b2 - 10) / rul2.step_r);
            //if (q < 0) { q = 0; }

            //for (int i = q; i <= rul2.n_rizka; i++)
            //{
            //    rul2.x_cur = rul2.x + i * rul2.step_r;
            //    test = rul2.x_cur;
            //    if (test > b2 + (dotsy3 - b2))
            //    {
            //        break;
            //    }
            //    if (test >= b2 & test <= b2 + (dotsy3 - b2))
            //    {
            //       //Основная риска
            //        gl2.Begin(OpenGL.GL_LINES);
            //        gl2.Color(0.0f, 0.4f, 0.0f);
            //        gl2.Vertex(rul2.y - rul2.high_rizka_2,rul2.x_cur, 0f);
            //        gl2.Color(0.0f, 0.4f, 0.0f);
            //        gl2.Vertex(rul2.y + rul2.high_rizka_2,rul2.x_cur, 0f);
            //        gl2.End();
            //        //Дополнительная риска
            //        if (i <= rul2.n_rizka - 1 & i>0)
            //        {
            //            for (int j = 0; j < rul2.n_rizka_add; j++)
            //            {
            //                gl2.Begin(OpenGL.GL_LINES);
            //                gl2.Color(0.0f, 0.4f, 0.0f);
            //                gl2.Vertex(rul2.y - rul2.high_rizka_2 / 2, rul2.x_cur + j * rul2.step_r / rul2.n_rizka_add , 0f);
            //                gl2.Color(0.0f, 0.4f, 0.0f);
            //                gl2.Vertex(rul2.y + rul2.high_rizka_2 / 2, rul2.x_cur + j * rul2.step_r / rul2.n_rizka_add , 0f);
            //                gl2.End();

            //                gl2.Begin(OpenGL.GL_LINES);
            //                gl2.Color(0.0f, 0.4f, 0.0f);
            //                gl2.Vertex(rul2.y - rul2.high_rizka_2 / 2, rul2.x_cur - j * rul2.step_r / rul2.n_rizka_add , 0f);
            //                gl2.Color(0.0f, 0.4f, 0.0f);
            //                gl2.Vertex(rul2.y + rul2.high_rizka_2 / 2, rul2.x_cur - j * rul2.step_r / rul2.n_rizka_add, 0f);
            //                gl2.End();
            //            }
            //        }
            //            if (rul2.hv_rizka)
            //            {
            //                //Пересчет пропорций экрана
            //                //aspetxy();
            //                string text = Math.Round(rul2.begin_union + rul2.step_txt * i, rul2.number_char).ToString();
            //                //string text = (((rul2.x_cur - rul2.x) * (rul2.end_union - rul2.begin_union) / rul2.l) + rul2.begin_union).ToString;
            //                rul2.v_text_disp = 5 + 7 * text.Length;
            //                gl2.DrawText((int)((rul2.y - rul2.high_rizka_2 - rul2.v_text_disp) * rul2.aspect_x),
            //                    (int)((rul2.x_cur - b2) * rul2.aspect_y),
            //                    0.0f, 0.4f, 0.0f, "Tahoma", (float)rul2.size_text,
            //                    text);
            //            }
            //    }
            //}


        }

        private void openGLControl2_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl2 = openGLControl2.OpenGL;
            //  Set the clear color.
            gl2.ClearColor(113 / 256, 111 / 256, 100 / 256, 0);

        }

        private void openGLControl2_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl2 = openGLControl2.OpenGL;
            //  Set the projection matrix.
            gl2.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity.
            gl2.LoadIdentity();
            gl2.Viewport(0, 0, openGLControl2.Width, openGLControl2.Height);
            //Пропорции экрана
            double aspect1 = openGLControl2.Width / openGLControl2.Height;
            double inv_aspect1 = openGLControl2.Height / openGLControl2.Width;



            gl2.Ortho2D(a2, dotsx3, b2, dotsy3);
            //  Set the modelview matrix.
            gl2.MatrixMode(OpenGL.GL_MODELVIEW);
            aspetxy();
        }
        
        //Добавление масштаба в инструменты время
        public void zoom_add_time(){
            if (rul1.type_r_bool)
            {
                toolStripDropDownButton2.DropDownItems.Clear();
                toolStripDropDownButton2.DropDownItems.Add("5 мин");
                toolStripDropDownButton2.DropDownItems.Add("10 мин");
                toolStripDropDownButton2.DropDownItems.Add("30 мин");
                toolStripDropDownButton2.DropDownItems.Add("1 час");
                toolStripDropDownButton2.DropDownItems.Add("3 час");
                toolStripDropDownButton2.DropDownItems.Add("6 час");
                toolStripDropDownButton2.DropDownItems.Add("12 час");
                toolStripDropDownButton2.DropDownItems.Add("24 час");
                toolStripDropDownButton2.DropDownItems.Add("100 %");
            }
            else { }
        }

        //Добавление масштаба в инструменты глубина
        public void zoom_add_depth()
        {
            if (rul1.type_r_bool)
            { }
            else {
                toolStripDropDownButton2.DropDownItems.Clear();
                toolStripDropDownButton2.DropDownItems.Add("1 м");
                toolStripDropDownButton2.DropDownItems.Add("5 м");
                toolStripDropDownButton2.DropDownItems.Add("30 м");
                toolStripDropDownButton2.DropDownItems.Add("100 м");
                toolStripDropDownButton2.DropDownItems.Add("300 м");
                toolStripDropDownButton2.DropDownItems.Add("500 м");
                toolStripDropDownButton2.DropDownItems.Add("1000 м");
                toolStripDropDownButton2.DropDownItems.Add("100 %");
            }
        }
        
        //Загрузка файла
        public void load_files() {
            //очистка списка выделенных параметров   
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemChecked(index, false);
            }
            splitContainer3.Panel2Collapsed = true;
            splitContainer2.Panel1Collapsed = true;
            //

            data.dep_ok = false;


            //Очистка нарисованных линий
            data.delete_all_new_point();
            //Чтение dep и lst файла
            //Востановление прошлой директории и проверка на доступ к директории
            read_set();
            string file = openFileDialog1.FileName;
            if (nastr.work_path == "")
            {
                openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            }
            else
            {
                if (Directory.Exists(nastr.work_path))
                {
                    openFileDialog1.InitialDirectory = nastr.work_path;
                }
                else { 
                    openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory(); }
            }
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            Stream myStream = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nastr.work_path = Path.GetDirectoryName(openFileDialog1.FileName);
                this.Refresh();
                label3.Text = "Загрузка файла...";
                panel1.Visible = true;
                panel1.Refresh();
                //if ((openFileDialog1.FileName != "") & (name_file_back != openFileDialog1.FileName))
                //{
                dots = 100;
                dots_bak_x1 = 100;
                dots_bak_y1 = 100;
                dotsx = 100;


                dotsy = 100;
                dotsx1 = 100;
                dotsy1 = 100;
                dotsx3 = 100;
                dotsy3 = 100;
                     //Начало окна в локальных х и у главного окна
                    a = 0; a1 = 0; a2 = 0;
                    b = 0; b1 = 0; b2 = 0;
                    //,a2,b,b1,b2=0;
       
                    //Рулетка XY
                    //диапозон значений
                    rul.begin_union = 0;
                    rul.end_union = 5000;
                    //xy рулетки; l-длина
                    rul.x = 5;
                    rul.y = 5;
                    rul.l = 1000;
                    //шаг рулетки x,y
                    rul1.x_cur = 10;
                    rul1.y_cur = 10;
                    //число рисок
                    //Рулетка X
                    //диапозон значений
                    rul1.begin_union = 0;
                    rul1.end_union = 5000;
                    //xy рулетки; l-длина
                    rul1.x = 5;
                    rul1.y = 90;
                    rul1.l = 1000;
                    //шаг рулетки x,y
                    rul1.x_cur = 20;
                    rul1.y_cur = 20;

                    a = rul.x;
                //}
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            //Информационное окно


                            data.dep_ok = false;
                            //Читаем dep и lst
                            data.read_dep(openFileDialog1.FileName);
                            name_file_back = openFileDialog1.FileName;
                            //Тип файла(время или глубина)
                            rul1.type_r_bool = data.type_dep(openFileDialog1.SafeFileName);
                            //Подпись по оси Х параметра
                            if (rul1.type_r_bool)
                            {
                                rul1.type_r = "В  Р  Е  М  Я:";
                                //data.timeshift_hourse = -5;

                                //Число записей
                                data.n_max_calc();
                                
                                data.timeshift_hourse = Convert.ToInt32(settings.numericUpDown1.Value);
                    
                                //Читаем первую дату и последнюю запись с временем
                                data.read_lst_rec(0);
                                rul1.begin_union = data.key_time;
                                rul.begin_union = data.key_time;
                                data.read_lst_rec((int)data.n_max - 1);
                                rul1.end_union = data.key_time;
                                rul.end_union = data.key_time;
                                //Информация о файле
                                data.value_to_date(rul.begin_union);
                                beg_end_txt = data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                                    data.Minute + ":" + data.Seconds + "-";
                                data.value_to_date(rul.end_union);
                                beg_end_txt += data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                                    data.Minute + ":" + data.Seconds;

                                //Масштаб по оси Х в часах
                                //dotsx = dotsx * (8000f / (float)data.n_max);
                                //double dispo = rul.end_union - rul.begin_union;
                                //dotsx = 100;
                                ////dotsx = 1005;
                                dotsx = a + (1 *60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                                //Добавление масштаба в инструменты
                                zoom_add_time();
                            }
                            else
                            {

                                rul1.type_r = "Г  Л  У  Б  И  Н  А:";

                                //Часовой пояс
                                data.timeshift_hourse = 0;
                                //Число записей
                                data.n_max_calc();
                                //Читаем первую дату и последнюю запись с временем
                                data.read_lst_rec(0);
                                rul1.begin_union = data.key_value;
                                rul.begin_union = data.key_value;
                                data.read_lst_rec((int)data.n_max - 1);
                                rul1.end_union = data.key_value;
                                rul.end_union = data.key_value;
                                beg_end_txt = rul.begin_union + "-" + rul.end_union + "m";

                                //Добавление масштаба в инструменты
                                zoom_add_depth();
                            }

                            status_file = " " + openFileDialog1.SafeFileName +
                                " " + beg_end_txt;
                            //status_file = toolStripStatusLabel1.Text;
                            checkedListBox1.Enabled = true;


                            //Новая шкала X


                            //shkalas_x.x_value = new double[data.x_value.Length];
                            //shkalas[g].y_value = new double[data.y_value.Length];
                            //shkalas[g].x_coord = new double[data.x_coord.Length];
                            //shkalas[g].y_coord = new double[data.y_coord.Length];
                            //for (int s = 0; s < data.x_value.Length; s++)
                            //{
                            //    shkalas[g].x_value[s] = data.x_value[s];
                            //    shkalas[g].x_coord[s] = data.x_coord[s];
                            //}
                            //for (int s = 0; s < data.y_value.Length; s++)
                            //{
                            //    shkalas[g].y_coord[s] = data.y_coord[s];
                            //    shkalas[g].y_value[s] = data.y_value[s];
                            //}
                            shkalas_x.x = 20;
                            shkalas_x.y = 0;
                            shkalas_x.d1 = 100;
                            shkalas_x.d2 = 100;
                            shkalas_x.dy = 5;
                            shkalas_x.dx = 20;
                            shkalas_x.dr = 10;
                            shkalas_x.dtxt = 20;
                            shkalas_x.precission = 1;
                            //Значение мин и макс параметра
                            shkalas_x.end_union = rul1.end_union;
                            shkalas_x.begin_union = rul1.begin_union;
                            //Цвет параметра
                            shkalas_x.color = new float[] { 0, 0.5f, 0 };
                            //Название параметра
                            shkalas_x.text = rul1.type_r;
                            //5% отступ от Orto2d вычисление значения
                            shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                                (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                            shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                                (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;

                            //label4.Text = " " + shkalas[0].a1new;
                            //label5.Text = " " + shkalas[0].a2new;

                            shkalas_x.N = 15;
                            shkalas_x.n = 10;
                            shkalas_x.init();
                            shkalas_x.calc();
                            shkalas_x.all_calc_init();

                            splitContainer1.Panel1Collapsed = false;
                            //splitContainer1.Panel1Collapsed = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!!!" + ex.Message);
                }

            }
            save_set();

            panel1.Visible = false;
            splitContainer1.Panel1MinSize = 158;
            splitContainer1.SplitterDistance = 155;
        
        
        
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Откл. Откат
            toolStripButton21.Enabled = false;
            toolStripButton22.Enabled = false;
            backupall.remove_all_operation();

            load_files();
           
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
        }

        private void SharpGLForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //Чтение справочника
            data.read_ref();
            for (int i = 0; i < data.str_.Length; i++)
            {
                data.str_[i] = data.str_[i].Remove(0, 6);
                data.str_[i] = data.str_[i].Remove(data.str_[i].Length - 1, 1);
                checkedListBox1.Items.Add(data.str_[i], false);
            }
            //Панельки
            splitContainer1.Panel1Collapsed = true;
            splitContainer2.Panel1Collapsed = true;
            splitContainer3.Panel2Collapsed = true;

            shkalas_x.old_fact_height = openGLControl3.Width;

            //Чтение настроек
            read_set();
        }

        //Новая шкала Y
        public void new_shkala()
        {
            woodoo_y fa = new woodoo_y();
            shkalas.Add(fa);
            how_many_woodoo += 1;
        }
       

        public void load_curve(){


            Random rand = new Random();
            color_amm.colors_select.Clear();
            if (checkedListBox1.CheckedItems.Count > 0 )
            {
                splitContainer3.Panel2Collapsed = false;
                splitContainer2.Panel1Collapsed = true;
                splitContainer1.Panel1Collapsed = true;
                //button2.Text = "<<";
                //button1.Text = "<<";

                toolStripButton2.Enabled = false;


                // Информационое окно
                label3.Text = "Загрузка кривой...";
                panel1.Visible = true;
                panel1.Refresh();

                //Очистка нарисованных линий
                data.delete_all_new_point();
                //Очистка шкал
                data.dep_ok = false;
                how_many_woodoo = 0;
                shkalas.Clear();
                shkalas.Capacity = 0;
                numbs_param.Clear();
                numbs_param.Capacity = 0;
                numb_param = 0;
                data.x_coord.Clear();
                data.y_coord.Clear();
                data.x_value.Clear();
                data.y_value.Clear();

                //Выбранные параметры
                for (int g = 0; g < checkedListBox1.CheckedItems.Count; g++)
                {
                    //Номер параметра
                    numb_param = checkedListBox1.CheckedIndices[g];
                    numbs_param.Add(checkedListBox1.CheckedIndices[g]);
                    curr_graph = g;

                    //Значение параметра

                    for (int i = 0; i < data.n_max; i++)
                    {
                        data.read_value(numb_param, i);
                        //Массив значений (У)
                        data.y_value.Add( data.value);
                        Application.DoEvents();

                        data.read_lst_rec(i);
                        //Массив значений (Х)
                       
                            if (data.type_file < 0)
                            {
                                data.x_value.Add(data.key_value);
                            }
                            else
                            {
                                data.x_value.Add(data.key_time);
                            }

                        
                        //Cреднее значение (У)
                        data.midle += data.y_value[i];

                    }
                    data.value_min = data.y_value[0];
                    data.value_max = data.y_value[0];
                    for (int i = 0; i < data.n_max; i++)
                    {
                        Application.DoEvents();
                        if (data.value_min > data.y_value[i])
                        {
                            data.value_min = data.y_value[i];
                        }
                        if (data.value_max < data.y_value[i])
                        {
                            data.value_max = data.y_value[i];
                        }
                    }


                    data.midle /= data.n_max;
                    rul2.begin_union = data.value_min;
                    rul2.end_union = data.value_max;
                    if (rul2.begin_union == rul2.end_union)
                    {
                        rul2.begin_union -= 1;
                        rul2.end_union += 1;
                    }
                    //Координаты параметра
                    for (int i = 0; i < data.n_max; i++)
                    {
                        Application.DoEvents();
                        //WOODOoo привязка к оси х
                        
                            data.x_coord.Add(rul.x + (data.x_value[i] - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union)));
                            data.y_coord.Add(rul2.x + (data.y_value[i] - rul2.begin_union) * (rul2.l / (rul2.end_union - rul2.begin_union)));
                       

                    }

                    //Новая ось
                    //Настройка осей у
                    //!Тествое изменение размера области легенд

                    //Новая шкала

                    Random rand2 = new Random();


                    new_shkala();

                    for (int s = 0; s < data.x_value.Count; s++)
                    {
                       
                            shkalas[g].x_value.Add(data.x_value[s]);
                            shkalas[g].x_coord.Add(data.x_coord[s]);
                            shkalas[g].y_coord.Add(data.y_coord[s]);
                            shkalas[g].y_value.Add(data.y_value[s]);
                        
                    }
                    
                    //Расчет положения столбов 
                    shkalas[g].x = g * 100f / (float)checkedListBox1.CheckedItems.Count;
                    shkalas[g].y = 0f;
                    shkalas[g].d1 = 100f / (float)checkedListBox1.CheckedItems.Count;
                    shkalas[g].d2 = 100f;
                    shkalas[g].dy = 5f;
                    shkalas[g].dx = 20f / (float)checkedListBox1.CheckedItems.Count;
                    shkalas[g].dr = 10f / (float)checkedListBox1.CheckedItems.Count;
                    shkalas[g].dtxt = 20f / (float)checkedListBox1.CheckedItems.Count;
                    shkalas[g].end_union = rul2.end_union;
                    shkalas[g].begin_union = rul2.begin_union;

                    int colorN = 0;
                    if (color_amm.colors_collect.Count != 0)
                    {
                        colorN = rand.Next(0, color_amm.colors_collect.Count);
                    }
                    else
                    {
                        color_amm.color_copy();
                        colorN = rand.Next(0, color_amm.colors_collect.Count);
                    }
                    shkalas[g].color = new float[] { (float)color_amm.colors_collect[colorN][0], (float)color_amm.colors_collect[colorN][1], (float)color_amm.colors_collect[colorN][2] };
                    color_amm.colors_collect.RemoveAt(colorN);
                    //Проверка на zero значений параметра
                    if (data.value_max == 0.0f & data.value_min == 0.0f)
                    {
                        shkalas[g].text = "ZERO " + checkedListBox1.CheckedItems[g].ToString();
                    }
                    else
                    {
                        shkalas[g].text = checkedListBox1.CheckedItems[g].ToString();
                    }
                    //Проверка на null значений параметра
                    if (data.null_yes)
                    {
                        shkalas[g].text = "NULL " + checkedListBox1.CheckedItems[g].ToString();
                    }
                    else
                    {
                        shkalas[g].text = checkedListBox1.CheckedItems[g].ToString();
                    }
                    
                    //5% отступ от Orto2d вычисление значения
                    shkalas[g].a1new = ((b + shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                        (rul2.end_union - rul2.begin_union) / rul2.l) + rul2.begin_union;
                    shkalas[g].a2new = ((dotsy - shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                        (rul2.end_union - rul2.begin_union) / rul2.l) + rul2.begin_union;

                    shkalas[g].N = 20;
                    shkalas[g].n = 10;
                    shkalas[g].y_plus = 0;
                    shkalas[g].init();
                    shkalas[g].all_calc_init();

                    //Точность отображения в знаках
                    if (data.value_max > 0 & data.value_max < 1) { shkalas[g].precission = 4; }
                    else { shkalas[g].precission = 2; }
                    if (g < ((checkedListBox1.CheckedItems.Count)-1))
                    {
                    data.x_coord.Clear();
                    data.y_coord.Clear();
                    data.x_value.Clear();
                    data.y_value.Clear();}

                }
                data.color = shkalas[shkalas.Count - 1].color;
                splitContainer2.SplitterDistance = 66 * how_many_woodoo;
                panel1.Visible = false;
                
                dotsy = 105;
                toolStripButton2.Enabled = true;
                splitContainer2.Panel1Collapsed = false;
                //Зонтик смена цвета
                change_color_ambrela(data.color);
                //Обновление пропорций при изменении размера viewport
                refresh_opengl1();
                //Пересчет делений шкалы Х
                recalc_shakas_x_N();
                data.dep_ok = true;
            }
            recalc_shakas_x_N();
            mega_refresh();
        
        }

        //Загрузить кривую
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if ((66 * (checkedListBox1.CheckedItems.Count+3)) < (splitContainer1.Size.Width-125))
            {
                load_curve();
              
            }
            else { MessageBox.Show("Превышено число графиков, уменьшите количество, или увеличте разрещение экрана!"); }

        }

        //Пересчет делений шкалы Х
        public void recalc_shakas_x_N()
        {
            if (data.dep_ok)
            {
                data.dep_ok = false;
                {
                    shkalas_x.N = (uint)(24f * ((float)openGLControl3.Width / (float)shkalas_x.old_fact_height));
                    shkalas_x.n = 10;
                    shkalas_x.init();
                    shkalas_x.all_calc_init();
                }
                data.dep_ok = true;
            }
        }

        //Обновление пропорций при изменении размера viewport
        public void refresh_opengl1()
        {
            OpenGL gl = openGLControl1.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            dotsy -= dispy; b -= dispy; a += dispx; dotsx += dispx;

            gl.Ortho2D(a, dotsx, b, dotsy);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        //Зонтик смена цвета
        public void change_color_ambrela(float[] color)
        {
            int ca = 255, cr = Convert.ToInt32(color[0] * 255), cg = Convert.ToInt32(color[1] * 255), cb = Convert.ToInt32(color[2] * 255);
            toolStripButton9.BackColor = Color.FromArgb(ca, cr, cg, cb);
        }


        //Вычисление локальных координат на основе мировых 
        public double[] calc_xy(int x, int y)
        {
            double[] coords = openGLControl1.OpenGL.UnProject(x, y, 0.0);
            return coords;
        }

        double dispx = 0;
        double dispy = 0;
        Point oldPoint = Point.Empty;


        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            //Режим перемещение вершин
            if (edit_mode == 7 & data.dep_ok == true)
            {

                coord3 = calc_xy(e.X, openGLControl1.Height - e.Y - 2);
                //WoooDODOoo?????
                move_dots.cur_coord_x = coord3[0];
                move_dots.cur_coord_y = coord3[1];
                //data.cur_value_y = ((coord3[1] - rul2.x) * (rul2.end_union - rul2.begin_union) / rul2.l) + rul2.begin_union;
                move_dots.cur_value_x = ((coord3[0] - rul1.x) * (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                move_dots.cur_value_y = ((coord3[1] - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                
                
                //Проверка на вхождение в область
                openGLControl1.Cursor = Cursors.Cross;
                if (move_dots.check_field_in()) { 
                    openGLControl1.Cursor = Cursors.SizeAll;
                } else
                {
                    
                }
                //Проверка на вхождение в верхний угол
                if (move_dots.check_field_in_up_coner())
                {
                    openGLControl1.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    
                }
            
            
            }


            if (hit_mouse_right == false & data.dep_ok == true)
            {

                //Application.DoEvents();

                coord3 = calc_xy(e.X, openGLControl1.Height - e.Y - 2);
                //WoooDODOoo?????
                data.cur_coord_x = coord3[0];
                data.cur_coord_y = coord3[1];
                //data.cur_value_y = ((coord3[1] - rul2.x) * (rul2.end_union - rul2.begin_union) / rul2.l) + rul2.begin_union;
                data.cur_value_x = ((coord3[0] - rul1.x) * (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                data.cur_value_y = ((coord3[1] - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                //data.cur_value_x = ((coord3[0] - rul1.x) * (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                if (rul1.type_r_bool)
                {
                    //Координаты курсора
                    data.value_to_date(data.cur_value_x);
                    status_value = data.Day + ":" + data.Month + ":" + data.Year + " " + data.Hour + ":" +
                        data.Minute + ":" + data.Seconds + "  " + data.cur_value_y;
                }
                else
                {
                    status_value = "" + data.cur_value_x + "  " + data.cur_value_y;
                }
            }
            if (hit_mouse_right == true)
            {
                coord2 = calc_xy(e.X, openGLControl1.Height - e.Y);
                coord21 = calc_xy(e.X, e.Y);

                //if ((Math.Abs(coord1[0] - coord2[0]) > 0.000001) | (Math.Abs(coord1[1] - coord2[1]) > 0.000001))
                //{
                //сдвиг основной области 
                dispx = coord1[0] - coord2[0];
                dispy = coord2[1] - coord1[1];
                OpenGL gl = openGLControl1.OpenGL;
                gl.MatrixMode(OpenGL.GL_PROJECTION);
                gl.LoadIdentity();
                dotsy -= dispy; b -= dispy; a += dispx; dotsx += dispx;

                gl.Ortho2D(a, dotsx, b, dotsy);
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                ////label1.Text = "left:" + a.ToString() + " right:" + dotsx.ToString() +
                ////    " bottom:" + b.ToString() + " top:" + dotsy.ToString();
                //сдвиг оси х
                //a1 = a; b1 = 0; dotsx1 = dotsx; dotsy1 = dots;
                //OpenGL gl1 = openGLControl3.OpenGL;
                //gl1.MatrixMode(MatrixMode.Projection);
                //gl1.LoadIdentity();
                //gl1.Ortho2D(a1, dotsx1, b1, dotsy1);
                //gl1.MatrixMode(MatrixMode.Modelview);

                //Сдвиг Новая шкала Х новое значение

                shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
                shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;


                shkalas_x.calc();
                shkalas_x.all_calc_init();


                //сдвиг оси y

                //a2 = 0; b2 = b; dotsx3 = dots; dotsy3 = dotsy;
                //OpenGL gl2 = openGLControl2.OpenGL;
                //gl2.MatrixMode(MatrixMode.Projection);
                //gl2.LoadIdentity();
                //gl2.Ortho2D(a2, dotsx3, b2, dotsy3);
                //gl2.MatrixMode(MatrixMode.Modelview);

                //Сдвиг Новая шкала Y новое значение
                for (int g = 0; g < shkalas.Count; g++)
                {
                    shkalas[g].a1new = ((b + shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
               (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;
                    shkalas[g].a2new = ((dotsy - shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                        (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;

                    shkalas[g].calc();
                    shkalas[g].all_calc_init();
                }

                //}
            }
        }

        //пересчет пропорций
        public void aspetxy()
        {
            rul.aspect_x = openGLControl1.Width / (dotsx - a);
            rul.aspect_y = openGLControl1.Height / (dotsy - b);
            rul1.aspect_x = openGLControl3.Width / (dotsx1 - a1);
            rul1.aspect_y = openGLControl3.Height / (dotsy1 - b1);
            rul2.aspect_x = openGLControl2.Width / (dotsx3 - a2);
            rul2.aspect_y = openGLControl2.Height / (dotsy3 - b2);
        }

        //Начало окна в локальных х и у главного окна
        public double a = 0;
        public double a1 = 0;
        public double b = 0;
        public double b1 = 0;
        public double a2 = 0;
        public double b2 = 0;

        //Локальные координаты
        public double[] coord1;
        public double[] coord2;
        public double[] coord11;
        public double[] coord21;
        public double[] coord12;
        public double[] coord22;
        public double[] coord3;
        //Цвет пикселей 2x2 региона
        public byte[] pixelsData = new byte[16];
        //Цвет отсортированный
        public float[] pixel_color = new float[3];

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                //Режим Переместить вершины
                if (data.dep_ok & edit_mode == 7)
                {
                    hit_mouse_left = true;

                    //if (move_dots.new_x_point.Count > 1 & move_dots.forward_back == true)
                    //{
                    //    if (move_dots.new_x_point[move_dots.new_x_point.Count - 1] <= coord3[0])
                    //    {
                    //        move_dots.new_x_point.Add(coord3[0]);
                    //        move_dots.new_y_point.Add(coord3[1]);
                    //    }
                    //}
                    //if (move_dots.new_x_point.Count > 1 & move_dots.forward_back == false)
                    //{
                    //    if (move_dots.new_x_point[move_dots.new_x_point.Count - 1] >= coord3[0])
                    //    {
                    //        move_dots.new_x_point.Add(coord3[0]);
                    //        move_dots.new_y_point.Add(coord3[1]);
                    //    }
                    //}
                    //if (move_dots.new_x_point.Count == 2)
                    //{

                    //    move_dots.new_x_point.Clear();
                    //    move_dots.new_y_point.Clear();

                    //}

                    //if (move_dots.new_x_point.Count == 1)
                    //{
                    //    if (move_dots.new_x_point[0] > coord3[0])
                    //    {
                    //        move_dots.forward_back = false;
                    //    }
                    //    else
                    //    {
                    //        move_dots.forward_back = true;
                    //    }
                    //    move_dots.new_x_point.Add(coord3[0]);
                    //    move_dots.new_y_point.Add(coord3[1]);
                    //}

                    //if (move_dots.new_x_point.Count == 0)
                    //{
                    //    move_dots.new_x_point.Add(coord3[0]);
                    //    move_dots.new_y_point.Add(coord3[1]);
                    //}

                    switch (move_dots.new_x_point.Count)
                    {

                        case 0: {
                            move_dots.new_x_point.Add(coord3[0]);
                            move_dots.new_y_point.Add(coord3[1]);
                            break;
                        }
                        case 1:
                            {
                                if (move_dots.new_x_point[0] > coord3[0])
                                {
                                    move_dots.forward_back = false;
                                }
                                else
                                {
                                    move_dots.forward_back = true;
                                }
                                move_dots.new_x_point.Add(coord3[0]);
                                move_dots.new_y_point.Add(coord3[1]);
                                break;
                            }
                        case 2:
                            {
                                if (!move_dots.check_field_in())
                                {
                                    move_dots.new_x_point.Clear();
                                    move_dots.new_y_point.Clear();
                                }
                                break;
                            }                                        
                    }

                }



                //Режим Удалить записи
                if (data.dep_ok & edit_mode == 6)
                {
                    hit_mouse_left = true;
                    if (del_record.new_x_point.Count < 2)
                    {
                        del_record.new_x_point.Add(coord3[0]);
                        //copy_paste.new_y_point.Add(coord3[1]);
                    }
                    else
                    {
                        del_record.delete_all_new_point();
                        del_record.delete_all_new_point_coord_value();
                        //copy_paste.new_x_point.Clear();
                    }

                }

                //Режим Добавить записи
                if (data.dep_ok & edit_mode == 5)
                {
                    hit_mouse_left = true;
                    if (add_record.new_x_point.Count < 2)
                    {
                        add_record.new_x_point.Add(coord3[0]);
                        //copy_paste.new_y_point.Add(coord3[1]);
                    }
                    else
                    {
                        add_record.delete_all_new_point();
                        add_record.delete_all_new_point_coord_value();
                        //copy_paste.new_x_point.Clear();
                    }

                }

                //Режим Сумма(Вычислить)
                if (data.dep_ok & edit_mode == 3)
                {
                    hit_mouse_left = true;
                    if (summ_calc.new_x_point.Count < 2)
                    {
                        summ_calc.new_x_point.Add(coord3[0]);
                        //copy_paste.new_y_point.Add(coord3[1]);
                    }
                    else
                    {
                        summ_calc.delete_all_new_point();
                        summ_calc.delete_all_new_point_coord_value();
                        //copy_paste.new_x_point.Clear();
                    }

                }

                //Режим Шум/Смещение
                if (data.dep_ok & edit_mode == 2)
                {
                    hit_mouse_left = true;
                    if (noise.new_x_point.Count < 2)
                    {
                        noise.new_x_point.Add(coord3[0]);
                        //copy_paste.new_y_point.Add(coord3[1]);
                    }
                    else
                    {
                        noise.delete_all_new_point();
                        noise.delete_all_new_point_coord_value();
                        //copy_paste.new_x_point.Clear();
                    }

                }

                //Режим Копировать
                if (data.dep_ok & edit_mode == 1)
                {
                    hit_mouse_left = true;
                    if (copy_paste.new_x_point.Count < 2)
                    {
                        copy_paste.new_x_point.Add(coord3[0]);
                        //copy_paste.new_y_point.Add(coord3[1]);
                    }
                    else
                    {
                        copy_paste.new_x_point.Clear();
                        //copy_paste.new_x_point.Clear();
                    }

                }

                //Режим Рисовать
                if (data.dep_ok & edit_mode == 0)
                {
                    hit_mouse_left = true;

                    if (data.new_x_point.Count > 1 & data.forward_back == true)
                    {
                        if (data.new_x_point[data.new_x_point.Count - 1] <= coord3[0])
                        {
                            data.new_x_point.Add(coord3[0]);
                            data.new_y_point.Add(coord3[1]);
                        }
                    }
                    if (data.new_x_point.Count > 1 & data.forward_back == false)
                    {
                        if (data.new_x_point[data.new_x_point.Count - 1] >= coord3[0])
                        {
                            data.new_x_point.Add(coord3[0]);
                            data.new_y_point.Add(coord3[1]);
                        }
                    }
                    if (data.new_x_point.Count == 1)
                    {
                        if (data.new_x_point[0] > coord3[0])
                        {
                            data.forward_back = false;
                        }
                        else
                        {
                            data.forward_back = true;
                        }
                        data.new_x_point.Add(coord3[0]);
                        data.new_y_point.Add(coord3[1]);
                    }

                    if (data.new_x_point.Count == 0)
                    {
                        data.new_x_point.Add(coord3[0]);
                        data.new_y_point.Add(coord3[1]);
                    }

                }

                //Режим Измерить
                if (data.dep_ok & edit_mode == 4)
                {
                    hit_mouse_left = true;


                    measure.new_x_point.Add(coord3[0]);
                    measure.new_y_point.Add(coord3[1]);
                    measure.new_x_point_value.Add(data.cur_value_x);
                    measure.new_y_point_value.Add(data.cur_value_y);
                    if (measure.new_x_point.Count == 1)
                    {
                        measure.new_x_point_disp.Add(measure.new_x_point_value[0]);
                        measure.new_y_point_disp.Add(measure.new_y_point_value[0]);
                    }
                    else {
                        measure.new_x_point_disp.Add(Math.Abs((measure.new_x_point_value[measure.new_x_point_value.Count - 1]) - (measure.new_x_point_value[measure.new_x_point_value.Count - 2])));
                        measure.new_y_point_disp.Add(Math.Abs((measure.new_y_point_value[measure.new_y_point_value.Count - 1]) - (measure.new_y_point_value[measure.new_y_point_value.Count - 2])));
                        //if (rul1.type_r_bool)
                        //{
                        //    //Координаты курсора
                        //    data.value_to_date(data.cur_value_x);
                        //    status_value = data.Day + ":" + data.Month + ":" + data.Year + " " + data.Hour + ":" +
                        //        data.Minute + ":" + data.Seconds + "  " + data.cur_value_y;
                        //}
                        
                        
                    
                    }
                    //data.value_to_date(data.cur_value_x);
                    //measure.text_x_point.Add(status_value);
                    //measure.text_y_point.Add((data.cur_value_y).ToString());
                    

                }

                //Читаем цвет точки
                //gl.ReadPixels(x_hit - 1, y_hit - 1, 2, 2,
                //   OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, pixelsData);
                ////var depth = System.BitConverter.ToSingle(pixelsData, 0);
                //label1.Text = "X:" + (int)(coord1[0]) + "Y:" + (int)(dotsx - coord1[1]);
                //for (int j = 0; j <= 2; j++)
                //    for (int i = 0; i < 16; i = i + 4)
                //    {
                //        if (pixelsData[i] < 255 | pixelsData[i + 1] < 255 | pixelsData[i + 2] < 255)
                //        { label1.BackColor = Color.FromArgb(pixelsData[i], pixelsData[i + 1], pixelsData[i + 2]); }
                //        if (pixelsData[i] == 0 & pixelsData[i + 1] == 0 & pixelsData[i + 2] == 0)
                //        {
                //        }
                //    }
            }
            if ((e.Button == MouseButtons.Right)& data.dep_ok)
            {

                hit_mouse_right = true;
                coord1 = calc_xy(e.X, openGLControl1.Height - e.Y);
                coord11 = calc_xy(e.X, openGLControl1.Height - e.Y);

            }



        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {

            if (hit_mouse_right)
            {

                hit_mouse_right = false;
            }
        }
        //Тестовый зум

        public void zoomout() {
            OpenGL gl = openGLControl1.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //gl.PushMatrix();
            //gl.LoadIdentity();



            gl.Translate((dotsx + a) / 2, (dotsy + b) / 2, 0f);
            gl.Scale(1+scale_xy_good, 1+scale_xy_good, 1);
            gl.Translate(-(dotsx+a) / 2, -(dotsy+b) / 2, 0f);
            //coord3 = calc_xy(0, 0);
            //a = coord3[0];
            //b = coord3[0];
            //coord3 = calc_xy(openGLControl1.Height, openGLControl1.Width);
            //dotsx = coord3[0] - a;
            //dotsy = coord3[1] - b;
            ////gl.Translate(a, b , 0f);
            //gl.PopMatrix();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            aspetxy();

        
        }

        public void zoomin()
        {
            OpenGL gl = openGLControl1.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //gl.PushMatrix();
            //gl.LoadIdentity();
            //Перенос в центр экрана локальных  координат
            gl.Translate((dotsx + a) / 2, (dotsy + b) / 2, 0f);
            //Масштаб
            gl.Scale(1-scale_xy_good, 1-scale_xy_good, 1);
            //Перенос в центр экрана локальных  координат
            gl.Translate(-(dotsx + a) / 2, -(dotsy + b) / 2, 0f);
            //coord3 = calc_xy(0, 0);
            //a = coord3[0];
            //b = coord3[0];
            //coord3 = calc_xy(openGLControl1.Height, openGLControl1.Width);
            //dotsx = coord3[0] - a;
            //dotsy = coord3[1] - b;
            //gl.Rotate(0, 0, -2);
            //gl.PopMatrix();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            aspetxy();

        }

        private void openGLControl1_MouseWhell(object sender, MouseEventArgs e)
        {
            if (data.dep_ok)
            {

                if (hit_mouse_right == false)
                {
                    if (e.Delta > 0) { zoomout(); }
                    if (e.Delta < 0) { zoomin(); }

                    //if (e.Delta > 0) { xy_scale_max(); }
                    //if (e.Delta < 0) { xy_scale_min(); }
                }
                else
                {

                }

                //Пересчет значений координат a,b,dotsx,dotsy
                coord3 = calc_xy(0, 0);
                a = coord3[0];
                b = coord3[1];
                coord3 = calc_xy(openGLControl1.Width, openGLControl1.Height);
                dotsx = coord3[0];
                dotsy = coord3[1];
                aspetxy();

                //Масштаб Новая шкала X новое значение
                shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                   (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
                shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;

                //shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                //    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
                //shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                //    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;

                shkalas_x.calc();
                shkalas_x.all_calc_init();
                recalc_shakas_x_N();


                //Масштаб Новая шкала Y новое значение
                for (int g = 0; g < shkalas.Count; g++)
                {
                    shkalas[g].a1new = ((b + shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                        (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;
                    shkalas[g].a2new = ((dotsy - shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                        (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;

                    shkalas[g].init();
                    shkalas[g].calc();
                    shkalas[g].all_calc_init();
                }
            }
        }

        private void openGLControl3_MouseWhell(object sender, MouseEventArgs e)
        {
            openGLControl3.Cursor = Cursors.NoMoveHoriz;
            //if (hit_mouse_right == false)
            //{
                if (e.Delta > 0) { xy_scale_max(); 
                
                
                }
                if (e.Delta < 0) { xy_scale_min(); }
            //}
            //else
            //{

            //}
            //Масштаб Новая шкала X новое значение


            shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
            shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;

            shkalas_x.calc();
            shkalas_x.all_calc_init();


            //Масштаб Новая шкала Y новое значение
            for (int g = 0; g < shkalas.Count; g++)
            {
                shkalas[g].a1new = ((b + shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                    (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;
                shkalas[g].a2new = ((dotsy - shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                    (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;

                shkalas[g].init();
                shkalas[g].calc();
                shkalas[g].all_calc_init();
            }
            recalc_shakas_x_N();
            timer1.Enabled = true;
        }

        //Маштабирование оси х в %
        private void scale_main_xy(double scale)
        {

            if (hit_ctrl)
            {

                //Основная область
                rul.scalex = scale * Math.Abs(dotsx - a) / 100;
                OpenGL gl = openGLControl1.OpenGL;
                gl.MatrixMode(OpenGL.GL_PROJECTION);
                gl.LoadIdentity();
                gl.Ortho2D(a -= rul.scalex, dotsx += rul.scalex, b, dotsy);
                gl.MatrixMode(OpenGL.GL_MODELVIEW);


                //Ось х
                //rul1.scalex = scale * Math.Abs(dotsx1 - a1) / 100;
                //OpenGL gl1 = openGLControl3.OpenGL;
                //gl1.MatrixMode(MatrixMode.Projection);
                //gl1.LoadIdentity();
                //gl1.Ortho2D(a1 -= rul.scalex, dotsx1 += rul.scalex, b1, dotsy1);
                //gl1.MatrixMode(MatrixMode.Modelview);


            }
            else
            {
                rul.scalex = scale * Math.Abs(dotsx - a) / 100;
                if (a < dotsx & (b - rul.scalex) < dotsy + rul.scalex)
                {
                    //Основная область

                    OpenGL gl = openGLControl1.OpenGL;
                    gl.MatrixMode(OpenGL.GL_PROJECTION);
                    gl.LoadIdentity();
                    gl.Ortho2D(a -= rul.scalex, dotsx += rul.scalex, b -= rul.scalex, dotsy += rul.scalex);
                    gl.MatrixMode(OpenGL.GL_MODELVIEW);
                    //label2.Text = "a:" + a.ToString() + " dotsx:" + dotsx.ToString() + "b:" + b.ToString() + "dotsy:" + dotsy.ToString();

                    //Ось х
                    //rul1.scalex = scale * Math.Abs(dotsx1 - a1) / 100;
                    //OpenGL gl1 = openGLControl3.OpenGL;
                    //gl1.MatrixMode(MatrixMode.Projection);
                    //gl1.LoadIdentity();
                    //gl1.Ortho2D(a1 -= rul.scalex, dotsx1 += rul.scalex, b1, dotsy1);
                    //gl1.MatrixMode(MatrixMode.Modelview);

                    //Ось у
                    //rul2.scalex = scale * Math.Abs(dotsy3 - b2) / 100;
                    //OpenGL gl2 = openGLControl2.OpenGL;
                    //gl2.MatrixMode(MatrixMode.Projection);
                    //gl2.LoadIdentity();
                    //gl2.Ortho2D(a2, dotsx3, b2 -= rul.scalex, dotsy3 += rul.scalex);
                    //gl2.MatrixMode(MatrixMode.Modelview);
                }

            }


            aspetxy();

        }







        public void xy_scale_min()
        {

            //масштаб оси х в %
            scale_main_xy(scale_xy);
            //if ((dotsx1 - a1) >= dots_bak_x1 * 2)
            //{
            //    rul1.n_rizka = rul1.n_rizka / 2;
            //    dots_bak_x1 = (dotsx1 - a1);
            //}
            ////FFF!!!!!

            //if ((dotsy3 - b2) >= dots_bak_y1 * 1.5)
            //{
            //    rul2.n_rizka = rul2.n_rizka / 1.5;
            //    dots_bak_y1 = (dotsy3 - b2);
            //}

        }

        public void xy_scale_max()
        {

            //масштаб оси х в %
            scale_main_xy(-scale_xy);
            //Разряживание
            //if ((dotsx1 - a1) <= dots_bak_x1 / 2)
            //{
            //    rul1.n_rizka = rul1.n_rizka * 2;
            //    dots_bak_x1 = (dotsx1 - a1);
            //}
            ////FFF!!!!!

            //if ((dotsy3 - b2) <= dots_bak_y1 / 1.5)
            //{
            //    rul2.n_rizka = rul2.n_rizka * 1.5;
            //    dots_bak_y1 = (dotsy3 - b2);
            //}

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Удаление последней нарисованной точки
            data.delete_last_new_point();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Режим Шум/Смещение
            if (edit_mode == 2)
            {
                if (data.dep_ok & noise.new_x_point.Count == 2 & noise.new_x_point_coord.Count > 0)
                {

                   
                    //Прогресс

                    Random rand = new Random();
                    //Обработка Шума/Смещение
                    int j = 0;
                    for (int i = 0; i < shkalas[curr_graph].x_coord.Count; i++)
                    {
                        if ((shkalas[curr_graph].x_coord[i]) >= (noise.new_x_point[0])
                            & (shkalas[curr_graph].x_coord[i]) <= (noise.new_x_point[1]))
                        {
                            if (backupall.new_otkat)
                            {
                                 //Новый откат
                                backupall.add_operation();
                                backupall.new_otkat=false;
                            }

                            shkalas[curr_graph].y_value[i] = noise.new_y_point_value[j];
                            //Данные для отката изменений старое
                            backupall.list_backups[(backupall.curr_numb_otkat) - 1].add(curr_graph, i, data.y_value[i]);

                            data.y_value[i] = shkalas[curr_graph].y_value[i];
                            //Данные для отката изменений новое
                            backupall.list_backups[(backupall.curr_numb_otkat) - 1].y_value_new.Add(data.y_value[i]);

                            shkalas[curr_graph].y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                            data.y_coord[i] = shkalas[curr_graph].y_coord[i];
                            data.write_value(numb_param, i, data.y_value[i]);
                            j++;
                            if (j == noise.new_y_point_coord.Count) { break; }

                        }
                    }
                    noise.delete_all_new_point();
                    noise.delete_all_new_point_coord_value();
                }
                panel1.Visible = false;
                //Вкл. кнопку отката
                toolStripButton21.Enabled = true;
                toolStripButton22.Enabled = false;
                backupall.new_otkat = true;
            }

            //Режим Копирование
            if (edit_mode == 1)
            {
            }

            //Режим Рисование
            if ((edit_mode == 0) & data.dep_ok)
            {
                //Прогресс
                label3.Text = "Вычисление....";
                panel1.Visible = true;
                panel1.Refresh();
                //Новый откат
                //backupall.add_operation();
                // Обработка точек нарисованнной кривой и загруженнной
                //data.process();
                double new_curr_point_x1;
                double new_curr_point_x2;
                double new_curr_point_y1;
                double new_curr_point_y2;
                double old_curr_point_x;

                if (data.new_x_point.Count > 1)
                {
                    if (data.forward_back)
                    {
                        for (int i = 0; i <= data.new_x_point.Count - 2; i += 1)
                        {
                            new_curr_point_x1 = data.new_x_point[i];
                            new_curr_point_y1 = data.new_y_point[i];
                            new_curr_point_x2 = data.new_x_point[i + 1];
                            new_curr_point_y2 = data.new_y_point[i + 1];

                            for (int j = 0; j <= data.x_coord.Count - 1; j++)
                            {
                                old_curr_point_x = data.x_coord[j];

                                if (new_curr_point_x1 <= old_curr_point_x & new_curr_point_x2 >= old_curr_point_x)
                                {
                                    if (backupall.new_otkat)
                                    {
                                        //Новый откат
                                        backupall.add_operation();
                                        backupall.new_otkat = false;
                                    }
                                    //Данные для отката изменений старое
                                    backupall.list_backups[(backupall.curr_numb_otkat) - 1].add(curr_graph, j, data.y_value[j]);
                                    //list_backups[how_many_woodoo2].add(curr_graph, j, data.y_value[j]);
                                    //Новая кордината
                                    data.y_coord[j] = (new_curr_point_y2 - new_curr_point_y1) * ((old_curr_point_x - new_curr_point_x1) / (new_curr_point_x2 - new_curr_point_x1)) + data.new_y_point[i];
                                    //Данные для отката изменений новое
                                    backupall.list_backups[(backupall.curr_numb_otkat) - 1].y_value_new.Add( ((data.y_coord[j] - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= data.new_x_point.Count - 2; i += 1)
                        {
                            new_curr_point_x1 = data.new_x_point[i];
                            new_curr_point_y1 = data.new_y_point[i];
                            new_curr_point_x2 = data.new_x_point[i + 1];
                            new_curr_point_y2 = data.new_y_point[i + 1];

                            for (int j = 0; j <= data.x_coord.Count - 1; j++)
                            {
                                old_curr_point_x = data.x_coord[j];

                                if (new_curr_point_x1 >= old_curr_point_x & new_curr_point_x2 <= old_curr_point_x)
                                {
                                    if (backupall.new_otkat)
                                    {
                                        //Новый откат
                                        backupall.add_operation();
                                        backupall.new_otkat = false;
                                    }
                                    //Данные для отката изменений
                                    backupall.list_backups[(backupall.curr_numb_otkat) - 1].add(curr_graph, j, data.y_value[j]);
                                    //list_backups[how_many_woodoo2].add(curr_graph, j, data.y_value[j]);
                                    //Новая координата
                                    data.y_coord[j] = (new_curr_point_y2 - new_curr_point_y1) * ((old_curr_point_x - new_curr_point_x1) / (new_curr_point_x2 - new_curr_point_x1)) + data.new_y_point[i];
                                    //Данные для отката изменений новое
                                    backupall.list_backups[(backupall.curr_numb_otkat) - 1].y_value_new.Add(data.y_value[j]);
                                }
                            }
                        }
                    }
                   

                }
                data.delete_all_new_point();


                for (int i = 0; i < data.y_value.Count; i++)
                {
                    //Application.DoEvents();
                    //Пересчет из координат y в значения
                    data.y_value[i] = ((data.y_coord[i] - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                    //Запись значения в массив
                    data.write_value(numb_param, i, data.y_value[i]);
                    shkalas[curr_graph].x_coord[i] = data.x_coord[i];
                    shkalas[curr_graph].y_coord[i] = data.y_coord[i];
                    shkalas[curr_graph].x_value[i] = data.x_value[i];
                    shkalas[curr_graph].y_value[i] = data.y_value[i];
                }

                ////Перенос вычисленных координат и значений в текущий график 
                //for (int i = 0; i < data.x_coord.Length; i++)
                //{
                //    shkalas[curr_graph].x_coord[i] = data.x_coord[i];
                //    shkalas[curr_graph].y_coord[i] = data.y_coord[i];
                //    shkalas[curr_graph].x_value[i] = data.x_value[i];
                //    shkalas[curr_graph].y_value[i] = data.y_value[i];
                //}
                //Очистка всех нарисованных точек
                data.delete_all_new_point();
                panel1.Visible = false;
                //Вкл. кнопку отката
                toolStripButton21.Enabled = true ;
                toolStripButton22.Enabled = false;
                backupall.new_otkat = true;
            }
        }



        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            // shift
            if (e.KeyValue == 16)
            {
                //hit_shift = true;
            }
            // ctrl  раздвижение сужение области
            if (e.KeyValue == 17)
            {
                //hit_ctrl = true;
            }
            //alt
            if (e.KeyValue == 18)
            {
                //hit_alt = true;
            }
            //backspace delete
            if ((e.KeyValue == 8) | (e.KeyValue == 46))
            {
                data.delete_last_new_point();
                measure.delete_last_new_point();
            }
            //insert
            if (e.KeyValue == 45)
            {
                toolStripButton6_Click(null, null);
            }
            //space
            if (e.KeyValue == 13)
            {
                toolStripButton4_Click(null, null);
               
            }
            
        }

        private void openGLControl1_KeyUp(object sender, KeyEventArgs e)
        {
            //hit_alt = false;
            //hit_shift = false;
            hit_ctrl = false;
        }
        public void save_files() {
            if (data.dep_ok == true)
            {
                //Очистка нарисованных линий
                data.delete_all_new_point();
                // Информационое окно
                label3.Text = "Сохранение файла...";
                panel1.Visible = true;
                panel1.Refresh();
                //Пересчет из координат y в значения
                for (int i = 0; i < data.y_value.Count; i++)
                {
                    Application.DoEvents();
                    data.write_value(numb_param, i, data.y_value[i]);
                }
                data.wr_dep(openFileDialog1.FileName);
                panel1.Visible = false;

                //Запись значения в массив
                //!!!!!!!!!!!!data.write_value(0, 0);
            }
        
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            save_files();
        }

        //Настройки
        public void options() {
            //Настройки
            read_set();
            settings.numericUpDown1.Value = Convert.ToInt32(nastr.time_shift);
            settings.treeView1.ExpandAll();
            
            
            settings.ShowDialog(this);

            if (settings.DialogResult == DialogResult.OK)
            {
                if (rul1.type_r_bool)
                {
                    data.timeshift_hourse = Convert.ToInt32(settings.numericUpDown1.Value);
                    nastr.time_shift = settings.numericUpDown1.Value.ToString();
                }
                else { data.timeshift_hourse = 0; }
                //Информация о файле
                if (rul1.type_r_bool)
                {
                    data.value_to_date(rul.begin_union);
                    beg_end_txt = data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                        data.Minute + ":" + data.Seconds + "-";
                    data.value_to_date(rul.end_union);
                    beg_end_txt += data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                        data.Minute + ":" + data.Seconds;
                }
                else
                {
                    beg_end_txt = rul.begin_union + "-" + rul.end_union + "м";
                }
                status_file = " " + openFileDialog1.SafeFileName +
                               " " + beg_end_txt;
                checkedListBox1.Enabled = true;

                //Качество отрисовки
                if (settings.comboBox1.SelectedIndex == 0)
                { quality = true;
                }
                else { quality = false; }
               
                main_line_width = (float) Convert.ToDouble(settings.comboBox2.GetItemText(settings.comboBox2.SelectedItem));
                
                //Вкл..выкл точки
                if (settings.comboBox3.SelectedIndex == 0)
                {
                    dots_on_off = true;
                }
                else { dots_on_off = false; }
                dots_width = (float)Convert.ToDouble(settings.comboBox4.GetItemText(settings.comboBox4.SelectedItem));
                
                //Сохранение настроек
                save_set();
            
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //read_set();
            options();
        
        }




        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //Добавление точки с указаением точных координат(Глубина)
            if (data.dep_ok == true & data.type_file < 0)
            {
                Add_point_deep add_point_deep = new Add_point_deep();
                double x;
                double y;
                double new_x;
                double new_y;

                //Заполнение формы(начало или последнее значение)
                if (data.new_x_point.Count > 0)
                {
                    x = data.new_x_point[data.new_x_point.Count - 1];
                    //Координату в значение
                    x = ((x - rul1.x) * (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                    add_point_deep.maskedTextBox1.Text = x.ToString();

                    y = data.new_y_point[data.new_y_point.Count - 1];
                    y = ((y - rul2.x) * (rul2.end_union - rul2.begin_union) / rul2.l) + rul2.begin_union;
                    add_point_deep.maskedTextBox2.Text = y.ToString();

                }
                else
                {

                    x = data.x_coord[0];
                    x = ((x - rul1.x) * (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                    add_point_deep.maskedTextBox1.Text = x.ToString();

                    y = data.y_coord[0];
                    y = ((y - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                    add_point_deep.maskedTextBox2.Text = y.ToString();
                }
                add_point_deep.ShowDialog(this);


                if (add_point_deep.DialogResult == DialogResult.OK)
                {
                    //ОК - добавление новой точки
                    new_x = Convert.ToDouble(add_point_deep.maskedTextBox1.Text);
                    new_y = Convert.ToDouble(add_point_deep.maskedTextBox2.Text);
                    //Если новая точка по Х больше или равна предидущей, то Гуд!
                    if ((new_x >= x & data.forward_back) | (new_x <= x & !data.forward_back))
                    {
                        //Значение в координату
                        new_x = rul.x + (new_x - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union));
                        new_y = rul2.x + (new_y - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                        data.new_x_point.Add(new_x);
                        data.new_y_point.Add(new_y);
                    }
                }
            }

            //!!
            //Добавление точки с указаением точных координат(Время)
            if (data.dep_ok == true & data.type_file > 0)
            {
                Add_point_time add_point_time = new Add_point_time();
                double x;
                double y;
                double new_x;
                double new_y;

                //Заполнение формы(начало или последнее значение)
                if (data.new_x_point.Count > 0)
                {
                    x = data.new_x_point[data.new_x_point.Count - 1];
                    //Координату в значение
                    x = ((x - rul1.x) * (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                    data.cur_value_x = x;
                    data.value_to_date(data.cur_value_x);
                    add_point_time.maskedTextBox1.Text = data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                        data.Minute + ":" + data.Seconds;

                    y = data.new_y_point[data.new_y_point.Count - 1];
                    y = ((y - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                    add_point_time.maskedTextBox2.Text = y.ToString();

                }
                else
                {

                    x = data.x_coord[0];
                    x = ((x - rul1.x) * (rul1.end_union - rul1.begin_union) / rul1.l) + rul1.begin_union;
                    data.cur_value_x = x;
                    data.value_to_date(data.cur_value_x);
                    add_point_time.maskedTextBox1.Text = data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                        data.Minute + ":" + data.Seconds;

                    y = data.y_coord[0];
                    y = ((y - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                    add_point_time.maskedTextBox2.Text = y.ToString();
                }
                add_point_time.ShowDialog(this);


                if (add_point_time.DialogResult == DialogResult.OK)
                {
                    //ОК - добавление новой точки
                    //Преобразование sting в datetime и в doouble UTC
                    try
                    {
                        DateTime new_time = DateTime.Parse(add_point_time.maskedTextBox1.Text);
                        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        TimeSpan new_times = new_time.ToUniversalTime() - origin.ToUniversalTime();
                        new_x = new_times.TotalSeconds - 3600 * data.timeshift_hourse;

                        new_y = Convert.ToDouble(add_point_time.maskedTextBox2.Text);
                        //Если новая точка по Х больше предидущей, то Гуд!

                        if (new_x >= Math.Floor(x))
                        {
                            new_x = rul.x + (new_x - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union));
                            new_y = rul2.x + (new_y - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                            data.new_x_point.Add(new_x);
                            data.new_y_point.Add(new_y);
                        }
                    }
                    catch { }
                }
            }




        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Выход
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
                //button1.Text = "<<";
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                //button1.Text = ">>";
            }
            //Пересчет делений шкалы Х
            recalc_shakas_x_N();

        }

        private void splitContainer2_SizeChanged(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 66 * how_many_woodoo;
        }
        private void openGLControl2_MouseWhell(object sender, MouseEventArgs e)
        {

            int selected_graph = search_graph(e.X, e.Y);
            //label6.Text = selected_graph.ToString();
            //Смена текущего(редактируемого) графика
            if (selected_graph < 256) { change_dest_graph(selected_graph); }

            openGLControl2.Cursor = Cursors.NoMoveVert;

            if (e.Delta > 12 & work_zoom == false)
            {
                work_zoom = true;
                //Масштаб текущего графика
                //+5%
                shkalas[curr_graph].begin_union = shkalas[curr_graph].begin_union - (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) * 5 / 100;
                shkalas[curr_graph].end_union = shkalas[curr_graph].end_union + (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) * 5 / 100;


                for (int i = 0; i < data.n_max; i++)
                {
                    //Application.DoEvents();
                    shkalas[curr_graph].y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                    data.y_coord[i] = shkalas[curr_graph].y_coord[i];

                }

                shkalas[curr_graph].a1new = ((b + shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
                   (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                shkalas[curr_graph].a2new = ((dotsy - shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
                    (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;

                shkalas[curr_graph].calc();
                shkalas[curr_graph].all_calc_init();
                work_zoom = false;
            }
            if (e.Delta < 12 & work_zoom == false)
            {
                work_zoom = true;
                //Масштаб текущего графика
                //-5%
                shkalas[curr_graph].begin_union = shkalas[curr_graph].begin_union + (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) * 5 / 100;
                shkalas[curr_graph].end_union = shkalas[curr_graph].end_union - (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) * 5 / 100;


                for (int i = 0; i < data.n_max; i++)
                {
                    //Application.DoEvents();
                    shkalas[curr_graph].y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                    data.y_coord[i] = shkalas[curr_graph].y_coord[i];

                }

                shkalas[curr_graph].a1new = ((b + shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
                   (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                shkalas[curr_graph].a2new = ((dotsy - shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
                    (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;

                shkalas[curr_graph].calc();
                shkalas[curr_graph].all_calc_init();
                work_zoom = false;
            }
            timer1.Enabled = true;

        }

        //Поиск графика по клику
        public int search_graph(int x_world, int y_world)
        {
            double[] mas = openGLControl2.OpenGL.UnProject(x_world, openGLControl2.Height - y_world, 0.0);
            float x_loc = (float)mas[0];
            float y_loc = (float)mas[1];
            for (int i = 0; i < shkalas.Count; i++)
            {
                if ((x_loc >= shkalas[i].x) & (x_loc < (shkalas[i].x + shkalas[i].d1)))
                {
                    return i;
                }
            }
            return 256;
        }

        //Смена текущего(редактируемого) графика
        public void change_dest_graph(int graph)
        {
            data.delete_all_new_point();
            curr_graph = graph;
            for (int i = 0; i < shkalas[graph].x_coord.Count; i++)
            {
                data.x_coord[i] = shkalas[graph].x_coord[i];
                data.y_coord[i] = shkalas[graph].y_coord[i];
                data.x_value[i] = shkalas[graph].x_value[i];
                data.y_value[i] = shkalas[graph].y_value[i];
            }
            //Цвет
            data.color = shkalas[graph].color;
            numb_param = numbs_param[graph];
            //Зонтик смена цвета
            change_color_ambrela(data.color);

        }

        //Смещение редактируемого графика
        public void graph_plus()
        {


        }


        private void openGLControl2_MouseDown(object sender, MouseEventArgs e)
        {
            //openGLControl1.Cursor = Cursors.SizeAll;
            //hit_mouse_right2 = true;
            if (e.Button == MouseButtons.Left)
            {
                openGLControl2.Cursor = Cursors.Cross;
                if (data.dep_ok)
                {
                    hit_mouse_left2 = true;
                    //Поиск графика по клику
                    int selected_graph = search_graph(e.X, e.Y);
                    //label6.Text = selected_graph.ToString();
                    //Смена текущего(редактируемого) графика
                    if (selected_graph < 256) { change_dest_graph(selected_graph); }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                openGLControl2.Cursor = Cursors.SizeNS;
                if (data.dep_ok)
                {
                    //Поиск графика по клику
                    int selected_graph = search_graph(e.X, e.Y);
                    //label6.Text = selected_graph.ToString();
                    //Смена текущего(редактируемого) графика
                    if (selected_graph < 256) { change_dest_graph(selected_graph); }
                    hit_mouse_right2 = true;
                    x_hit_before = e.X;
                    y_hit_before = e.Y;
                }
            }
        }

        private void openGLControl2_MouseUp(object sender, MouseEventArgs e)
        {
            openGLControl2.Cursor = Cursors.Cross;
            if (hit_mouse_right2)
            {


                //Cдвиг текущего графика
                //graph_plus();
                openGLControl2.Cursor = Cursors.Cross;
                hit_mouse_right2 = false;

            }
        }

        private void openGLControl2_MouseMove(object sender, MouseEventArgs e)
        {
            if (hit_mouse_right2 & work_move == false)
            {
                work_move = true;

                x_hit_after = e.X;
                y_hit_after = e.Y;
                //Cдвиг текущего графика
                double[] coord_plus_before = openGLControl1.OpenGL.UnProject(x_hit_before, openGLControl1.Height - y_hit_before, 0.0);
                double[] coord_plus_after = openGLControl1.OpenGL.UnProject(x_hit_after, openGLControl1.Height - y_hit_after, 0.0);

                if (Math.Abs(coord_plus_after[1] - coord_plus_before[1]) > 1)
                {

                    coord_plus_before[1] = ((coord_plus_before[1] - rul.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul.l) + shkalas[curr_graph].begin_union;
                    coord_plus_after[1] = ((coord_plus_after[1] - rul.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul.l) + shkalas[curr_graph].begin_union;

                    shkalas[curr_graph].begin_union = shkalas[curr_graph].begin_union + (coord_plus_before[1] - coord_plus_after[1]) / 7;
                    shkalas[curr_graph].end_union = shkalas[curr_graph].end_union + (coord_plus_before[1] - coord_plus_after[1]) / 7;


                    for (int i = 0; i < data.n_max; i++)
                    {
                        //Application.DoEvents();
                        shkalas[curr_graph].y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                        data.y_coord[i] = shkalas[curr_graph].y_coord[i];

                    }

                    shkalas[curr_graph].a1new = ((b + shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
                       (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                    shkalas[curr_graph].a2new = ((dotsy - shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
                        (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;

                    shkalas[curr_graph].calc();
                    shkalas[curr_graph].all_calc_init();

                }
                work_move = false;
            }
        }

        private void openGLControl1_MouseEnter(object sender, EventArgs e)
        {

            openGLControl1.Focus();
            openGLControl1.Cursor = Cursors.Cross;
        }

        private void openGLControl2_MouseEnter(object sender, EventArgs e)
        {
            openGLControl2.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            openGLControl2.Cursor = Cursors.Cross;
            openGLControl3.Cursor = Cursors.Cross;
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (splitContainer2.Panel1Collapsed == true)
            {

                splitContainer2.Panel1Collapsed = false;
                //button1.Text = "<<";
                //button2.Text = "<<";
                if (splitContainer1.Panel1Collapsed == true) { button1.Text = ">>"; }
            }
            else
            {

                splitContainer2.Panel1Collapsed = true;
                //button1.Text = "<<";
                //button2.Text = ">>";
            }
            //Пересчет делений шкалы Х
            recalc_shakas_x_N();

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
            //Кнопка копировать нажата
            if (data.dep_ok & copy_paste.new_x_point.Count == 2)
            {
                copy_paste.delete_all_new_point_coord_value();



                //copy_paste.process();
                //Обработка
                // Смена между первым и последним
                double change_0_end;
                if (copy_paste.new_x_point[0] > copy_paste.new_x_point[1])
                {
                    change_0_end = copy_paste.new_x_point[0];
                    copy_paste.new_x_point[0] = copy_paste.new_x_point[1];
                    copy_paste.new_x_point[1] = change_0_end;

                }

                if (copy_paste.new_x_point[0] < copy_paste.new_x_point[1])
                {
                    for (int i = 0; i < shkalas[curr_graph].x_coord.Count; i++)
                    {
                        if ((shkalas[curr_graph].x_coord[i]) >= (copy_paste.new_x_point[0])
                            & (shkalas[curr_graph].x_coord[i]) <= (copy_paste.new_x_point[1]))
                        {
                            copy_paste.new_x_point_coord.Add(shkalas[curr_graph].x_coord[i]);
                            copy_paste.new_y_point_coord.Add(shkalas[curr_graph].y_coord[i]);

                            copy_paste.new_x_point_value.Add(shkalas[curr_graph].x_value[i]);
                            copy_paste.new_y_point_value.Add(shkalas[curr_graph].y_value[i]);
                        }
                    }

                }

                copy_paste.delete_all_new_point();
            }
        }




        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }



        private void toolStripButton9_Click(object sender, EventArgs e)
        {

            if ((colorDialog1.ShowDialog() == DialogResult.OK) & (data.dep_ok))
            {
                toolStripButton9.BackColor = colorDialog1.Color;
                shkalas[curr_graph].color[0] = (Convert.ToSingle(colorDialog1.Color.R)) / 255;
                shkalas[curr_graph].color[1] = (Convert.ToSingle(colorDialog1.Color.G)) / 255;
                shkalas[curr_graph].color[2] = (Convert.ToSingle(colorDialog1.Color.B)) / 255;
                Application.DoEvents();
                change_dest_graph(curr_graph);
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        //Режим Копировать
        public void copy_copy() {
            toolStripDropDownButton1.Image = toolStripMenuItem4.Image;
            edit_mode = 1;
            hide_all_tool();
            toolStripButton8.Visible = true;
            toolStripButton10.Visible = true;
            toolStripButton15.Visible = true;
            //toolStripButton20.Visible = true;
            //toolStripButton20.Visible = true;
            //Удаление точек режима Рисование
            data.delete_all_new_point();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            copy_copy();
        }

        //Режим Шум
        public void wave() {
            toolStripDropDownButton1.Image = toolStripMenuItem5.Image;
            edit_mode = 2;
            hide_all_tool();
            toolStripButton11.Visible = true;
            toolStripButton12.Visible = true;
            toolStripButton4.Visible = true;
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            wave();
        }

        //Режим Сумма
        public void add_calc() {
            toolStripDropDownButton1.Image = суммаToolStripMenuItem.Image;
            edit_mode = 3;
            hide_all_tool();
            toolStripButton13.Visible = true;
        }
        private void суммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_calc();
        }
        public void hide_all_tool()
        {
            toolStripButton3.Visible = false;
            toolStripButton4.Visible = false;
            toolStripButton6.Visible = false;
            toolStripButton8.Visible = false;
            toolStripButton10.Visible = false;
            toolStripButton11.Visible = false;
            toolStripButton12.Visible = false;
            toolStripButton13.Visible = false;
            toolStripButton14.Visible = false;
            toolStripButton15.Visible = false;
            toolStripButton17.Visible = false;
            toolStripButton18.Visible = false;
            toolStripButton19.Visible = false;
            toolStripButton20.Visible = false;


        }
        //Режим Рисование 
        public void paint() {
            toolStripDropDownButton1.Image = toolStripMenuItem2.Image;
            edit_mode = 0;
            hide_all_tool();
            toolStripButton6.Visible = true;
            toolStripButton3.Visible = true;
            toolStripButton4.Visible = true;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            paint();
        }

        //Режим Переместить
        public void change()
        {
            toolStripDropDownButton1.Image = переместитьToolStripMenuItem.Image;
            edit_mode = 7;
            hide_all_tool();
            //toolStripButton6.Visible = true;
            //toolStripButton3.Visible = true;
            //toolStripButton4.Visible = true;
        }

        private void переместитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {

        }


        //Режим Измерить
        public void measure_all() {
            toolStripDropDownButton1.Image = измеритьToolStripMenuItem.Image;
            edit_mode = 4;
            hide_all_tool();
            toolStripButton14.Visible = true;
            measure.delete_all_new_point();
        }
        private void измеритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            measure_all();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            label3.Text = "Загрузка файла...";
            panel1.Visible = true;
            panel1.Refresh();
        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            if (tri_al)
            {
                //Кнопка Вставить нажата
                if (data.dep_ok & copy_paste.new_x_point.Count == 2 & copy_paste.new_x_point_coord.Count > 0)
                {
                    label3.Text = "Вычисление...";
                    panel1.Visible = true;
                    panel1.Refresh();
                    //Новый откат
                    //backupall.add_operation();
                    //Лево-право селект

                    //copy_paste.process();
                    //Обработка
                    //if (copy_paste.new_x_point[0] < copy_paste.new_x_point[1])
                    //{

                    //double change_0_end;
                    //if (copy_paste.new_x_point[0] > copy_paste.new_x_point[1])
                    //{
                    //    change_0_end = copy_paste.new_x_point[0];
                    //    copy_paste.new_x_point[0] = copy_paste.new_x_point[1];
                    //    copy_paste.new_x_point[1] = change_0_end;
                    //    //change_0_end = copy_paste.new_y_point[0];
                    //    //copy_paste.new_y_point[0] = copy_paste.new_y_point[1];
                    //    //copy_paste.new_y_point[1] = change_0_end;
                    //}

                    if (copy_paste.new_x_point[0] > copy_paste.new_x_point[1])
                    {
                        int j = copy_paste.new_y_point_coord.Count - 1;
                        for (int i = shkalas[curr_graph].x_coord.Count - 1; i >= 0; i--)
                        {

                            if ((shkalas[curr_graph].x_coord[i]) <= (copy_paste.new_x_point[0])
                                & (shkalas[curr_graph].x_coord[i]) >= (copy_paste.new_x_point[1]))
                            {
                                if (backupall.new_otkat)
                                {
                                    //Новый откат
                                    backupall.add_operation();
                                    backupall.new_otkat = false;
                                }
                                shkalas[curr_graph].y_value[i] = copy_paste.new_y_point_value[j];
                                //Данные для отката изменений старое
                                backupall.list_backups[(backupall.curr_numb_otkat) - 1].add(curr_graph, i, data.y_value[i]);

                                data.y_value[i] = copy_paste.new_y_point_value[j];
                                //Данные для отката изменений новое
                                backupall.list_backups[(backupall.curr_numb_otkat) - 1].y_value_new.Add(data.y_value[i]);
                                

                                shkalas[curr_graph].y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                                //shkalas[curr_graph].y_coord[i] = copy_paste.new_y_point_coord[j];
                                data.y_coord[i] = shkalas[curr_graph].y_coord[i];
                                //shkalas[curr_graph].x_value[i] = copy_paste.new_x_point_value[j];
                                //Запись значения в массив
                                data.write_value(numb_param, i, data.y_value[i]);
                                j--;
                                if (j == 0) { break; }

                            }
                        }
                    }

                    if (copy_paste.new_x_point[0] < copy_paste.new_x_point[1])
                    {
                        int j = 0;

                        for (int i = 0; i < shkalas[curr_graph].x_coord.Count; i++)
                        {

                            if ((shkalas[curr_graph].x_coord[i]) >= (copy_paste.new_x_point[0])
                                & (shkalas[curr_graph].x_coord[i]) <= (copy_paste.new_x_point[1]))
                            {
                                if (backupall.new_otkat)
                                {
                                    //Новый откат
                                    backupall.add_operation();
                                    backupall.new_otkat = false;
                                }
                                shkalas[curr_graph].y_value[i] = copy_paste.new_y_point_value[j];
                                 //Данные для отката изменений старое
                                backupall.list_backups[(backupall.curr_numb_otkat) - 1].add(curr_graph, i, data.y_value[i]);

                                data.y_value[i] = copy_paste.new_y_point_value[j];
                                //Данные для отката изменений новое
                                backupall.list_backups[(backupall.curr_numb_otkat) - 1].y_value_new.Add(data.y_value[i]);

                                shkalas[curr_graph].y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                                //shkalas[curr_graph].y_coord[i] = copy_paste.new_y_point_coord[j];
                                data.y_coord[i] = shkalas[curr_graph].y_coord[i];
                                //shkalas[curr_graph].x_value[i] = copy_paste.new_x_point_value[j];
                                //Запись значения в массив
                                data.write_value(numb_param, i, data.y_value[i]);
                                j++;
                                if (j == copy_paste.new_y_point_coord.Count) { break; }

                            }
                        }
                    }


                    //Вкл. кнопку отката
                    toolStripButton21.Enabled = true;
                    toolStripButton22.Enabled = false;
                    copy_paste.delete_all_new_point();
                    backupall.new_otkat = true;
                    panel1.Visible = false;
                }
            }
            else
            {
                trial trial = new trial();
                trial.ShowDialog(this);
            
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            //Настройка Шум/Смещение
            //(Глубина)
            if (data.dep_ok == true & data.type_file < 0)
            {
                noise_deep noise_deep = new noise_deep();
                noise_deep.maskedTextBox1.Text = noise.amplitude.ToString();
                noise_deep.maskedTextBox2.Text = noise.disp.ToString();
                noise_deep.maskedTextBox3.Text = noise.step_deep.ToString();
                noise_deep.ShowDialog(this);

                if (noise_deep.DialogResult == DialogResult.OK)
                {
                    noise.amplitude = Convert.ToDouble(noise_deep.maskedTextBox1.Text);
                    noise.disp = Convert.ToDouble(noise_deep.maskedTextBox2.Text);
                    noise.step_deep = Convert.ToDouble(noise_deep.maskedTextBox3.Text);
                }
            }

            //Добавление точки с указаением точных координат(Время)
            if (data.dep_ok == true & data.type_file > 0)
            {
                noise_time noise_time = new noise_time();
                noise_time.maskedTextBox1.Text = noise.amplitude.ToString();
                noise_time.maskedTextBox2.Text = noise.disp.ToString();
                noise_time.maskedTextBox3.Text = noise.step_time.ToString();
                noise_time.ShowDialog(this);

                if (noise_time.DialogResult == DialogResult.OK)
                {
                    noise.amplitude = Convert.ToDouble(noise_time.maskedTextBox1.Text);
                    noise.disp = Convert.ToDouble(noise_time.maskedTextBox2.Text);
                    noise.step_time = Convert.ToDouble(noise_time.maskedTextBox3.Text);
                }
            }

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (tri_al)
            {
                //Кнопка Шум/Смещение нажата
                if (data.dep_ok & noise.new_x_point.Count == 2)
                {
                    noise.delete_all_new_point_coord_value();

                    // Смена между первым и последним
                    double change_0_end;
                    if (noise.new_x_point[0] > noise.new_x_point[1])
                    {
                        change_0_end = noise.new_x_point[0];
                        noise.new_x_point[0] = noise.new_x_point[1];
                        noise.new_x_point[1] = change_0_end;

                    }

                    if (noise.new_x_point[0] < noise.new_x_point[1])
                    {
                        for (int i = 0; i < shkalas[curr_graph].x_coord.Count; i++)
                        {
                            if ((shkalas[curr_graph].x_coord[i]) >= (noise.new_x_point[0])
                                & (shkalas[curr_graph].x_coord[i]) <= (noise.new_x_point[1]))
                            {
                                noise.new_x_point_coord.Add(shkalas[curr_graph].x_coord[i]);
                                noise.new_y_point_coord.Add(shkalas[curr_graph].y_coord[i]);

                                noise.new_x_point_value.Add(shkalas[curr_graph].x_value[i]);
                                noise.new_y_point_value.Add(shkalas[curr_graph].y_value[i]);
                            }
                        }

                    }
                    if (data.dep_ok & noise.new_x_point.Count == 2 & noise.new_x_point_coord.Count > 0)
                    {

                        //Обработка Шума/Смещение
                        Random rand = new Random();
                        //Текущее значение шага по Х
                        double step_cur = noise.new_x_point_value[0];
                        double amplitude_cur = noise.amplitude * rand.NextDouble();
                        for (int i = 0; i < noise.new_x_point_coord.Count; i++)
                        {
                            if (data.type_file < 0)
                            {
                                if (((step_cur + noise.step_deep) <= (noise.new_x_point_value[i]))
                                    | (noise.step_deep == 0))
                                {

                                    step_cur = noise.new_x_point_value[i];
                                    amplitude_cur = noise.amplitude * rand.NextDouble();
                                    noise.new_y_point_value[i] += noise.disp + amplitude_cur - noise.amplitude / 2;

                                }
                                else
                                {
                                    if (i > 0) { noise.new_y_point_value[i] = noise.new_y_point_value[i - 1]; }
                                    else
                                    {
                                        noise.new_y_point_value[i] += noise.disp + amplitude_cur - noise.amplitude / 2;
                                    }
                                }


                            }
                            else
                            {
                                if (((step_cur + noise.step_time) <= (noise.new_x_point_value[i]))
                                | (noise.step_time == 0))
                                {
                                    step_cur = noise.new_x_point_value[i];
                                    amplitude_cur = noise.amplitude * rand.NextDouble();
                                    noise.new_y_point_value[i] += noise.disp + amplitude_cur - noise.amplitude / 2;
                                }
                                else
                                {
                                    if (i > 0) { noise.new_y_point_value[i] = noise.new_y_point_value[i - 1]; }
                                    else
                                    {
                                        noise.new_y_point_value[i] += noise.disp + amplitude_cur - noise.amplitude / 2;
                                    }
                                }
                            }

                            //noise.new_y_point_value[i] += noise.disp + amplitude_cur - noise.amplitude / 2;

                            noise.new_y_point_coord[i] = rul2.x + (noise.new_y_point_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));

                        }
                        //noise.delete_all_new_point();
                    }
                }
            }
            else
            {
                trial trial = new trial();
                trial.ShowDialog(this);

            }
        }

        
        //Замена одной строки на другую
        private static string ReplaceEx(string original,
                    string pattern, string replacement)
        {
            int count, position0, position1;
            count = position0 = position1 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) *
                      (replacement.Length - pattern.Length);
            char[] chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern,
                                              position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                    chars[count++] = original[i];
                for (int i = 0; i < replacement.Length; ++i)
                    chars[count++] = replacement[i];
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0) return original;
            for (int i = position0; i < original.Length; ++i)
                chars[count++] = original[i];
            return new string(chars, 0, count);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            //Кнопка Сумма нажата
            //Кнопка Шум/Смещение нажата
                //if (data.dep_ok & summ_calc.new_x_point.Count == 2)
                //{
                    if (data.dep_ok)
                {
                    //summ_calc.delete_all_new_point_coord_value();

                    //// Смена между первым и последним
                    //double change_0_end;
                    //if (summ_calc.new_x_point[0] > summ_calc.new_x_point[1])
                    //{
                    //    change_0_end = summ_calc.new_x_point[0];
                    //    summ_calc.new_x_point[0] = summ_calc.new_x_point[1];
                    //    summ_calc.new_x_point[1] = change_0_end;

                    //}
                    //if (summ_calc.new_x_point[0] < summ_calc.new_x_point[1])
                    //{
                    //    for (int i = 0; i < shkalas[curr_graph].x_coord.Count; i++)
                    //    {
                    //        if ((shkalas[curr_graph].x_coord[i]) >= (summ_calc.new_x_point[0])
                    //            & (shkalas[curr_graph].x_coord[i]) <= (summ_calc.new_x_point[1]))
                    //        {
                    //            summ_calc.new_x_point_coord.Add(shkalas[curr_graph].x_coord[i]);
                    //            summ_calc.new_y_point_coord.Add(shkalas[curr_graph].y_coord[i]);

                    //            summ_calc.new_x_point_value.Add(shkalas[curr_graph].x_value[i]);
                    //            summ_calc.new_y_point_value.Add(shkalas[curr_graph].y_value[i]);
                    //        }
                    //    }

                    //}
            
            
                summ summ = new summ();
                

                summ.comboBox1.Visible = true;
                summ.textBox1.ReadOnly = true;
                summ.label3.Visible = true;

                summ.label1.Visible = false;
                summ.label2.Visible = false;
                summ.comboBox2.Visible = false;
                summ.comboBox3.Visible = false;
                summ.button2.Visible = false;
                summ.button3.Visible = false;

                summ.textBox1.Text = shkalas[curr_graph].text + " = ";
                summ.result = shkalas[curr_graph].text;
                if (shkalas.Count == 1) {
                    summ.textBox1.Text += " 0"; }
                for (int i = 0; i < shkalas.Count; i++)
                {
                    if (i != curr_graph)
                    {
                        summ.textBox1.Text += shkalas[i].text + " + ";
                        summ.param.Add(shkalas[i].text);
                    }

                }
                string txt_edit = summ.textBox1.Text;
                txt_edit = txt_edit.Remove(summ.textBox1.Text.Length - 3);
                summ.textBox1.Text = txt_edit;
                summ.comboBox1.Items.Add("A = B +...+n");
                summ.comboBox1.Items.Add("A = A - (B +...+n)");
                summ.comboBox1.Items.Add("A = A + (B +...+n)");
                summ.comboBox1.Items.Add("A = 1/(B +...+n)");
                summ.comboBox1.Items.Add("Конструктор формул");
                summ.comboBox1.SelectedItem = summ.comboBox1.Items[0];
                
                //Параметры
                for(int i=0;i<shkalas.Count;i++){
                    summ.comboBox2.Items.Add(shkalas[i].text);
                }
                summ.comboBox2.SelectedItem = summ.comboBox2.Items[0];
                
                //Операции
                for (int i = 0; i < summ_calc.modifer.Count; i++)
                {
                    summ.comboBox3.Items.Add(summ_calc.modifer[i]);
                    
                }
                summ.comboBox3.SelectedItem = summ.comboBox3.Items[0];

                summ.ShowDialog(this);

                if (summ.DialogResult == DialogResult.OK)
                {
                    //data.dep_ok = false;
                    //Новый откат
                    //backupall.add_operation();

                    label3.Text = "Вычисление...";
                    panel1.Visible = true;
                    panel1.Refresh();
                    //panel1.Focus();

                    switch (summ.comboBox1.SelectedIndex) {
                        case 0: {
                            //Прочистка
                            for (int j = 0; j < shkalas[curr_graph].y_value.Count; j++)
                            {
                                shkalas[curr_graph].y_value[j] = 0;
                            }
                            //Суммирование
                            for (int i = 0; i < shkalas.Count; i++)
                            {
                                if (i != curr_graph)
                                {
                                    for (int j = 0; j < shkalas[curr_graph].y_value.Count; j++)
                                    {
                                        shkalas[curr_graph].y_value[j] += shkalas[i].y_value[j];
                                    }
                                }
                            }

                            break;
                        }
                        case 1: {
                            //Вычитание
                            for (int i = 0; i < shkalas.Count; i++)
                            {
                                if (i != curr_graph)
                                {
                                    for (int j = 0; j < shkalas[curr_graph].y_value.Count; j++)
                                    {
                                        shkalas[curr_graph].y_value[j] -= shkalas[i].y_value[j];
                                    }
                                }
                            }

                            break;
                        }
                        case 2:
                            {
                                //Вычитание
                                for (int i = 0; i < shkalas.Count; i++)
                                {
                                    if (i != curr_graph)
                                    {
                                        for (int j = 0; j < shkalas[curr_graph].y_value.Count; j++)
                                        {
                                            shkalas[curr_graph].y_value[j] -= shkalas[i].y_value[j];
                                        }
                                    }
                                }


                                break;
                            }

                        case 3:
                            {
                                //Деление 1/X
                                for (int i = 0; i < shkalas.Count; i++)
                                {
                                    if (i != curr_graph)
                                    {
                                        for (int j = 0; j < shkalas[curr_graph].y_value.Count; j++)
                                        {
                                            shkalas[curr_graph].y_value[j] = 1/shkalas[i].y_value[j];
                                        }
                                    }
                                }


                                break;
                            }
                        /* case 4:
                            {
                                

                                Microsoft.Scripting.Hosting.ScriptEngine py = Python.CreateEngine(); // allow us to run ironpython programs
                                Microsoft.Scripting.Hosting.ScriptScope s = py.CreateScope(); // you need this to get the variables
                                //py.Execute("x = " + a + "+" + b, s); // this is your python program
                                //Console.WriteLine(s.GetVariable("x")); // get the variable from the python program
                                //Console.ReadLine(); // wait for the user to press a button



                                //Конструктор формул
                                //var engine = Python.CreateEngine();
                                
                                string cur;
                                
                                string result_txt;
                                for (int j = 0; j < shkalas[curr_graph].y_value.Count; j++)
                                {
                                    
                                    cur = summ.textBox1.Text;
                                    //Замена названия параметра на значение
                                    //cur = ReplaceEx(cur, shkalas[curr_graph].text, "x");
                                    for (int i = 0; i < shkalas.Count; i++)
                                    {
                                        
                                        cur = ReplaceEx(cur, shkalas[i].text, shkalas[i].y_value[j].ToString());
                                    }


                                    cur = ReplaceEx(cur,",", ".");
                                    cur = "import math \n" + "x = "  + cur;
                                    
                                    //var script = cur;
                                    try
                                    {
                                       var ok= py.Execute(cur, s); // this is your python program
                                       if (ok == null)
                                       {//var result = engine.Execute(script);
                                           result_txt = Convert.ToString(s.GetVariable("x"));
                                           }  
                                       else { MessageBox.Show("Ошибка вычисления"); break; }}

                                    catch {

                                               result_txt = shkalas[curr_graph].y_value[j].ToString();
                                               MessageBox.Show("Ошибка вычисления");
                                               break;


                                           }


                                           shkalas[curr_graph].y_value[j] = double.Parse(ReplaceEx(result_txt, ",", "."), CultureInfo.InvariantCulture);
                                           Application.DoEvents();
                                           
                                      
                                }
                                break;
                            
                            } */
                            data.dep_ok = true;
                            //aspetxy();
                    }
                    

                    //Прописать
                    //Максимум минимум параметра
                    //data.value_min = shkalas[curr_graph].y_value[0];
                    //data.value_max = shkalas[curr_graph].y_value[0];
                    //for (int i = 0; i < data.n_max; i++)
                    //{
                    //    //Application.DoEvents();
                    //    if (data.value_min > shkalas[curr_graph].y_value[i])
                    //    {
                    //        data.value_min = shkalas[curr_graph].y_value[i];
                    //    }
                    //    if (data.value_max < shkalas[curr_graph].y_value[i])
                    //    {
                    //        data.value_max = shkalas[curr_graph].y_value[i];
                    //    }
                    //}
                    //shkalas[curr_graph].begin_union = data.value_min;
                    //shkalas[curr_graph].end_union = data.value_max;
                    //if (shkalas[curr_graph].begin_union == shkalas[curr_graph].end_union)
                    //{
                    //    shkalas[curr_graph].begin_union -= 1;
                    //    shkalas[curr_graph].end_union += 1;
                    //}

                    //Пересчет координат
                    for (int i = 0; i < shkalas[curr_graph].y_value.Count; i++)
                    {
                        if (backupall.new_otkat)
                        {
                            //Новый откат
                            backupall.add_operation();
                            backupall.new_otkat = false;
                        }
                        //Данные для отката изменений старое
                        backupall.list_backups[(backupall.curr_numb_otkat) - 1].add(curr_graph, i, data.y_value[i]);

                        data.y_value[i] = shkalas[curr_graph].y_value[i];
                        //Данные для отката изменений новое
                        backupall.list_backups[(backupall.curr_numb_otkat) - 1].y_value_new.Add(data.y_value[i]);

                        
                        shkalas[curr_graph].y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                        data.y_coord[i] = shkalas[curr_graph].y_coord[i];
                        data.write_value(numb_param, i, data.y_value[i]);
                    }


                    //Обновление границ шкалы
                    shkalas[curr_graph].a1new = ((b + shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
               (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                    shkalas[curr_graph].a2new = ((dotsy - shkalas[curr_graph].dy * (dotsy - b) / 100 - rul2.x) *
                        (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;

                    shkalas[curr_graph].init();
                    shkalas[curr_graph].calc();
                    shkalas[curr_graph].all_calc_init();

                    //Обновление границ всех шкал
                    mega_refresh();

                    


                    panel1.Visible = false;
                    //Вкл. кнопку отката
                    toolStripButton21.Enabled = true;
                    toolStripButton22.Enabled = false;
                    backupall.new_otkat = true;

                }
            }


        }

        //Обновление границ всех шкал
        public void mega_refresh() {
            
            recalc_shakas_x_N();
            aspetxy();

            //Масштаб Новая шкала Y новое значение
            for (int g = 0; g < shkalas.Count; g++)
            {
                shkalas[g].a1new = ((b + shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                    (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;
                shkalas[g].a2new = ((dotsy - shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                    (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;

                shkalas[g].init();
                shkalas[g].calc();
                shkalas[g].all_calc_init();
            }

            shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
            shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;

            shkalas_x.init();
            shkalas_x.calc();
            shkalas_x.all_calc_init();

            //shkalas_x.calc();
            //shkalas_x.all_calc_init();
            refresh_opengl1();
        
        }

        private void загрузитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_files();
        }

        private void splitContainer3_Resize(object sender, EventArgs e)
        {
            //Обновление пропорций при изменении размера viewport
            refresh_opengl1();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            //Кнопка Измерить нажата
            if (data.dep_ok)
            {
                measure.delete_last_new_point();
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (tri_al)
            {
                //Кнопка Вставить нажата
                if (data.dep_ok & copy_paste.new_x_point.Count == 2 & copy_paste.new_x_point_coord.Count > 0)
                {
                    //Новый откат
                    //backupall.add_operation();
                    //Прогресс
                    label3.Text = "Вычисление....";
                    panel1.Visible = true;
                    
                    this.Refresh();
                    //Application.DoEvents();

                    //Лево-право селект
                    double change_0_end;
                    if (copy_paste.new_x_point[0] > copy_paste.new_x_point[1])
                    {
                        change_0_end = copy_paste.new_x_point[0];
                        copy_paste.new_x_point[0] = copy_paste.new_x_point[1];
                        copy_paste.new_x_point[1] = change_0_end;
                    }

                    //Перенос в масштабе
                    copy_paste.k_scale =
                    ((copy_paste.new_x_point_coord[copy_paste.new_x_point_coord.Count - 1])
                    - (copy_paste.new_x_point_coord[0])) / ((copy_paste.new_x_point[1]) - (copy_paste.new_x_point[0]));//new_x_point_coord.Count;

                    if (copy_paste.new_x_point.Count > 1)
                    {
                        double disp = (copy_paste.new_x_point[0] - copy_paste.new_x_point_coord[0]);
                        for (int i = 0; i < copy_paste.new_x_point_coord.Count; i++)
                        {
                            copy_paste.new_x_point_coord[i] = copy_paste.new_x_point_coord[i] + disp;

                        }
                        for (int i = 0; i < copy_paste.new_x_point_coord.Count; i++)
                        {
                            copy_paste.new_x_point_coord[i] = copy_paste.new_x_point_coord[i] / copy_paste.k_scale;

                        }
                        disp = (copy_paste.new_x_point[0] - copy_paste.new_x_point_coord[0]);
                        for (int i = 0; i < copy_paste.new_x_point_coord.Count; i++)
                        {
                            copy_paste.new_x_point_coord[i] = copy_paste.new_x_point_coord[i] + disp;

                        }
                    }


                    //Пересчет для каждой записи
                    double new_curr_point_x1;
                    double new_curr_point_x2;
                    double new_curr_point_y1;
                    double new_curr_point_y2;
                    double old_curr_point_x;

                    for (int i = 0; i <= copy_paste.new_x_point_coord.Count - 2; i += 1)
                    {
                        new_curr_point_x1 = copy_paste.new_x_point_coord[i];
                        new_curr_point_y1 = copy_paste.new_y_point_value[i];
                        new_curr_point_x2 = copy_paste.new_x_point_coord[i + 1];
                        new_curr_point_y2 = copy_paste.new_y_point_value[i + 1];

                        for (int j = 0; j <= data.x_coord.Count - 1; j++)
                        {
                            old_curr_point_x = data.x_coord[j];

                            if (new_curr_point_x1 <= old_curr_point_x & new_curr_point_x2 >= old_curr_point_x)
                            {
                                if (backupall.new_otkat)
                                {
                                    //Новый откат
                                    backupall.add_operation();
                                    backupall.new_otkat = false;
                                }
                                //Данные для отката изменений старое
                                backupall.list_backups[(backupall.curr_numb_otkat) - 1].add(curr_graph, j, data.y_value[j]);

                                data.y_value[j] = (new_curr_point_y2 - new_curr_point_y1) * ((old_curr_point_x - new_curr_point_x1) / (new_curr_point_x2 - new_curr_point_x1)) + copy_paste.new_y_point_value[i];
                                //Данные для отката изменений новое
                                backupall.list_backups[(backupall.curr_numb_otkat) - 1].y_value_new.Add(data.y_value[j]);
                                //data.y_coord[j] = (new_curr_point_y2 - new_curr_point_y1) * ((old_curr_point_x - new_curr_point_x1) / (new_curr_point_x2 - new_curr_point_x1)) + copy_paste.new_y_point_coord[i];
                                
                            }
                        }
                    }


                    //Перенос вычисленных координат и значений в текущий график 
                    for (int i = 0; i < data.y_value.Count; i++)
                    {

                        //Пересчет из координат y в значения
                        data.y_coord[i] = rul2.x + (data.y_value[i] - shkalas[curr_graph].begin_union) * (rul2.l / (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union));
                        //data.y_value[i] = ((data.y_coord[i] - rul2.x) * (shkalas[curr_graph].end_union - shkalas[curr_graph].begin_union) / rul2.l) + shkalas[curr_graph].begin_union;
                        //Запись значения в массив
                        data.write_value(numb_param, i, data.y_value[i]);
                        shkalas[curr_graph].x_coord[i] = data.x_coord[i];
                        shkalas[curr_graph].y_coord[i] = data.y_coord[i];
                        shkalas[curr_graph].x_value[i] = data.x_value[i];
                        shkalas[curr_graph].y_value[i] = data.y_value[i];
                    }



                    copy_paste.delete_all_new_point();
                    panel1.Visible = false;
                    //Вкл. кнопку отката
                    toolStripButton21.Enabled = true;
                    toolStripButton22.Enabled = false;
                    backupall.new_otkat = true;


                }
            }
            else
            {
                trial trial = new trial();
                trial.ShowDialog(this);

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.ShowDialog(this);
        }

        private void инструкцияToolStripMenuItem_Click(object sender, EventArgs e)
        {//
            //// Create a VideoDrawing.
            ////      
            //MediaPlayer player = new MediaPlayer();

            //player.Open(new Uri(@"sampleMedia\xbox.wmv", UriKind.Relative));

            //VideoDrawing aVideoDrawing = new VideoDrawing();

            //aVideoDrawing.Rect = new Rect(0, 0, 100, 100);

            //aVideoDrawing.Player = player;

            //// Play the video once.
            //player.Play(); 
           
            helphelp helphelp = new helphelp();
            helphelp.treeView1.ExpandAll();
           
          
            helphelp.ShowDialog(this);

            if (helphelp.DialogResult == DialogResult.OK)
            {

                //noise.amplitude = Convert.ToDouble(noise_deep.maskedTextBox1.Text);
                //noise.disp = Convert.ToDouble(noise_deep.maskedTextBox2.Text);
                //noise.step_deep = Convert.ToDouble(noise_deep.maskedTextBox3.Text);
            }
        }

        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_files();
        }

        private void загрузитьКривуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paint();
        }

        private void добавитьТочкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copy_copy();
        }

        private void удалитьТочкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wave();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_calc();
        }

        private void измеритьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            measure_all();
        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options();
        }

        private void openGLControl3_MouseEnter(object sender, EventArgs e)
        {
            hit_ctrl = true;
            openGLControl3.Focus();
            openGLControl3.Cursor = Cursors.Cross;
        }

        private void openGLControl3_MouseLeave(object sender, EventArgs e)
        {
            hit_ctrl = false;
            openGLControl3.Cursor = Cursors.Cross;
        }





        private void добавлениеЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Прогресс
            label3.Text = "Вычисление....";
            panel1.Visible = true;
            this.Refresh();
            data.selected_record = 1;

            //Добавление записи
            data.add_record();

            //Запись на диск
            //data.wr_dep(openFileDialog1.FileName);
            
            //Загрузка файла
            //load_files_after_add();
            //load_curve();
            panel1.Visible = false;
        }

        //Удаление петель
        public void del_loops() {
            if ((data.dep_ok) & (shkalas[curr_graph].x_value.Count>2))
            {
                label3.Text = "Поиск петель....";
                panel1.Visible = true;
                panel1.Refresh();

                //Прочистка номеров записей петлевых
                loops.numb_record_loop.Clear();
                loops.current_value = shkalas[curr_graph].x_value[0];
                //Поиск петель и занесение в список номеров записей
                for (int i = 1; i < shkalas[curr_graph].x_value.Count; i++) {

                    if (shkalas[curr_graph].x_value[i] <= loops.current_value)
                    {
                        loops.numb_record_loop.Add(i);
                    }
                    else {
                        loops.current_value = shkalas[curr_graph].x_value[i];
                    }
                
                }

                panel1.Visible = false;
                loops_clear_deep loops_clear_deep = new loops_clear_deep();
                loops_clear_deep.textBox1.Text="";
                loops_clear_deep.maskedTextBox1.Text = loops.numb_record_loop.Count.ToString();
                for (int i = 0; i < loops.numb_record_loop.Count; i++) {
                    loops_clear_deep.textBox1.Text += ((loops.numb_record_loop[i])+1).ToString()+"; ";
                
                }
                    loops_clear_deep.ShowDialog(this);

                //Удаление петель
                if (loops_clear_deep.DialogResult == DialogResult.OK)
                {
                    
                    //Удаление петель
                    if (loops.numb_record_loop.Count > 0)
                    {
                        data.dep_ok = false;

                        for (int i = loops.numb_record_loop.Count-1; i >= 0 ; i--)
                        {
                            data.x_coord.RemoveAt(loops.numb_record_loop[i]);
                            data.y_coord.RemoveAt(loops.numb_record_loop[i]);
                            data.x_value.RemoveAt(loops.numb_record_loop[i]);
                            data.y_value.RemoveAt(loops.numb_record_loop[i]);
                            for (int a = 0; a < shkalas.Count; a++) {
                                shkalas[a].x_coord.RemoveAt(loops.numb_record_loop[i]);
                                shkalas[a].y_coord.RemoveAt(loops.numb_record_loop[i]);
                                shkalas[a].x_value.RemoveAt(loops.numb_record_loop[i]);
                                shkalas[a].y_value.RemoveAt(loops.numb_record_loop[i]);
                            }
                            data.selected_record = loops.numb_record_loop[i];
                            data.del_record();
                        
                        }


                        data.n_max_calc();
                        data.dep_ok = true;
                    }
                }
            }
        }

        //Удаление петель
        private void петлиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tri_al)
            {
                if (data.dep_ok)
                {
                    del_loops();
                }
            }
            else
            {
                trial trial = new trial();
                trial.ShowDialog(this);

            }
        
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void утилитыToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
           
        }

        //Режим Добавление Записи
        public void add_records() {
            toolStripDropDownButton1.Image = добавитьЗаписьToolStripMenuItem.Image;
            edit_mode = 5;
            hide_all_tool();
            toolStripButton17.Visible = true;
            toolStripButton18.Visible = true;
        }

        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_records();
        
        }

        //Режим Удаление Записи
        public void del_records()
        {
            toolStripDropDownButton1.Image = удалитьЗаписьToolStripMenuItem.Image;
            edit_mode = 6;
            hide_all_tool();
            toolStripButton19.Visible = true;
        }
        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            del_records();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            if (data.dep_ok & edit_mode == 5) {
                if (data.type_file < 0)
                {
                    add_record_options_deep add_record_options_deep = new add_record_options_deep();
                    add_record_options_deep.maskedTextBox3.Text = add_record.step_deep.ToString();
                    add_record_options_deep.label2.Text = "Шаг(м):";
                    add_record_options_deep.ShowDialog(this);

                    if (add_record_options_deep.DialogResult == DialogResult.OK)
                    {
                        add_record.step_deep = Convert.ToDouble(add_record_options_deep.maskedTextBox3.Text);
                       
                    }
                }
                else {
                    add_record_options_deep add_record_options_deep = new add_record_options_deep();
                    add_record_options_deep.maskedTextBox3.Text = add_record.step_time.ToString();
                    add_record_options_deep.label2.Text = "Шаг(с):";

                    add_record_options_deep.ShowDialog(this);

                    if (add_record_options_deep.DialogResult == DialogResult.OK)
                    {
                        add_record.step_time = Convert.ToDouble(add_record_options_deep.maskedTextBox3.Text);

                    }
                
                }
            
            }
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            //Кнопка Добавить записи
            if (data.dep_ok & add_record.new_x_point.Count == 2)
            {
                label3.Text = "Вычисление...";
                panel1.Visible = true;
                panel1.Refresh();
                

                add_record.delete_all_new_point_coord_value();

                // Смена между первым и последним
                double change_0_end;
                if (add_record.new_x_point[0] > add_record.new_x_point[1])
                {
                    change_0_end = add_record.new_x_point[0];
                    add_record.new_x_point[0] = add_record.new_x_point[1];
                    add_record.new_x_point[1] = change_0_end;

                }
                //Перевод координаты в значение
                add_record.new_x_value.Add(((add_record.new_x_point[0] - rul.x) * (shkalas_x.end_union - shkalas_x.begin_union) / rul.l) + shkalas_x.begin_union);
                add_record.new_x_value.Add(((add_record.new_x_point[1] - rul.x) * (shkalas_x.end_union - shkalas_x.begin_union) / rul.l) + shkalas_x.begin_union);

                //Поиск первой и последней точки
                add_record.in_interval = 0;
                add_record.first_record = 0;
                add_record.last_record = 0;

                //Глубина
                if (data.type_file < 0)
                {
                    data.dep_ok = false;
                    ///!   !..!...Добавляем в начало новую запись
                    if (add_record.new_x_value[0]<shkalas[curr_graph].x_value[0]){
                        for (int a = 0; a < shkalas.Count; a++)
                        {
                            //Вставка записи
                            shkalas[a].x_value.Insert(0,
                                (((add_record.new_x_value[0])+add_record.step_deep)));
                            shkalas[a].y_value.Insert(0,
                                (shkalas[a].y_value[0]));
                            //Пересчет из значения в координаты
                            shkalas[a].x_coord.Insert(0,
                                (rul.x + (((shkalas[a].x_value[0])) - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union))));
                            shkalas[a].y_coord.Insert(0, shkalas[a].y_coord[0]);
                        }

                        data.x_value.Insert(0,
                            shkalas[curr_graph].x_value[0]);
                        data.y_value.Insert(0,
                            shkalas[curr_graph].y_value[0]);
                        //Пересчет из значения в координаты
                        data.x_coord.Insert(0,
                           shkalas[curr_graph].x_coord[0]);
                        data.y_coord.Insert(0, shkalas[curr_graph].y_coord[0]);

                        //Добавление записи в lst и dep
                        data.selected_record = 0;
                        data.key_value_write = shkalas[curr_graph].x_value[0];
                        data.add_record();
                        data.write_value(53, (0), shkalas[curr_graph].x_value[0]);
                    
                    }

                    ///////!..!...    !  Добавляем в конец новую запись
                    ////if (add_record.new_x_value[1] > shkalas[curr_graph].x_value[shkalas[curr_graph].x_value.Count-1])
                    ////{
                    ////    for (int a = 0; a < shkalas.Count; a++)
                    ////    {
                    ////        //Вставка записи
                    ////        shkalas[a].x_value.Add(
                    ////            (((add_record.new_x_value[1]) - 2*add_record.step_deep)));
                    ////        shkalas[a].y_value.Add(
                    ////            (shkalas[a].y_value[shkalas[curr_graph].y_value.Count - 1]));
                    ////        //Пересчет из значения в координаты
                    ////        shkalas[a].x_coord.Add(
                    ////            (rul.x + (((shkalas[a].x_value[shkalas[curr_graph].x_coord.Count - 1])) - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union))));
                    ////        shkalas[a].y_coord.Insert(shkalas[curr_graph].y_coord.Count - 1, shkalas[a].y_coord[shkalas[curr_graph].y_coord.Count - 1]);
                    ////    }

                    ////    data.x_value.Add(
                    ////        shkalas[curr_graph].x_value[shkalas[curr_graph].x_value.Count - 1]);
                    ////    data.y_value.Add(
                    ////        shkalas[curr_graph].y_value[shkalas[curr_graph].y_value.Count - 1]);
                    ////    //Пересчет из значения в координаты
                    ////    data.x_coord.Add(
                    ////       shkalas[curr_graph].x_coord[shkalas[curr_graph].x_coord.Count - 1]);
                    ////    data.y_coord.Add(shkalas[curr_graph].y_coord[shkalas[curr_graph].y_coord.Count - 1]);

                    ////    //Добавление записи в lst и dep
                    ////    data.selected_record = shkalas[curr_graph].x_value.Count - 2;
                    ////    data.key_value_write = shkalas[curr_graph].x_value[shkalas[curr_graph].x_value.Count - 2];
                    ////    data.add_record();
                    ////    data.write_value(53, (shkalas[curr_graph].x_value.Count - 1), shkalas[curr_graph].x_value[shkalas[curr_graph].x_value.Count - 1]);

                    ////}


                    //.....!..   ..!.....
                    if (add_record.new_x_value[1] - add_record.new_x_value[0] > add_record.step_deep)
                    {
                        for (int i = 0; i < shkalas[curr_graph].x_value.Count-1; i++)
                        {
                            //Разница между x1 и x0
                            add_record.in_interval = (shkalas[curr_graph].x_value[i + 1]) - (shkalas[curr_graph].x_value[i]);

                            if ((shkalas[curr_graph].x_value[i]) >= (add_record.new_x_value[0])
                                & (shkalas[curr_graph].x_value[i]) <= (add_record.new_x_value[1]) & (add_record.in_interval>1.9*add_record.step_deep))
                            {
                                add_record.first_record = i;
                                add_record.last_record = i+1;
                                break;
                            }
                            
                        }
                        //Считаем число Новых Записей
                        if (add_record.first_record != add_record.last_record)
                        {
                            add_record.N_create = (int)((shkalas[curr_graph].x_value[add_record.last_record]
                                - shkalas[curr_graph].x_value[add_record.first_record]) / add_record.step_deep);
                            
                            //Добавляем новые записи
                            data.dep_ok = false;
                            for (int i = add_record.first_record; i < add_record.first_record + add_record.N_create-1; i++)
                            {
                                for (int a = 0; a < shkalas.Count; a++)
                                {
                                    //Вставка записи
                                    shkalas[a].x_value.Insert(i+1,
                                        ((shkalas[a].x_value[i]) + add_record.step_deep));
                                    shkalas[a].y_value.Insert(i+1,
                                        (shkalas[a].y_value[i]));
                                    //Пересчет из значения в координаты
                                    shkalas[a].x_coord.Insert(i+1,
                                        (rul.x + (((shkalas[a].x_value[i+1])) - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union))));
                                    shkalas[a].y_coord.Insert(i+1, shkalas[a].y_coord[i]);
                                }

                                data.x_value.Insert(i+1,
                                    shkalas[curr_graph].x_value[i+1]);
                                data.y_value.Insert(i+1,
                                    shkalas[curr_graph].y_value[i+1]);
                                //Пересчет из значения в координаты
                                data.x_coord.Insert(i+1,
                                   shkalas[curr_graph].x_coord[i + 1]);
                                data.y_coord.Insert(i+1, shkalas[curr_graph].y_coord[i + 1]);

                                //Добавление записи в lst и dep
                                data.selected_record = i+1;
                                data.key_value_write = shkalas[curr_graph].x_value[i+1];
                                data.add_record();
                                data.write_value(53, (i + 1), shkalas[curr_graph].x_value[i + 1]);
                               

                            }
                        
                        }

                    }


                }

                ///////////////
                ///Время
                if (data.type_file >0 )
                {
                    data.dep_ok = false;
                    ///!   !..!...Добавляем в начало новую запись
                    if (add_record.new_x_value[0] < shkalas[curr_graph].x_value[0])
                    {
                        for (int a = 0; a < shkalas.Count; a++)
                        {
                            //Вставка записи
                            shkalas[a].x_value.Insert(0,
                                (((add_record.new_x_value[0]) + add_record.step_time)));
                            shkalas[a].y_value.Insert(0,
                                (shkalas[a].y_value[0]));
                            //Пересчет из значения в координаты
                            shkalas[a].x_coord.Insert(0,
                                (rul.x + (((shkalas[a].x_value[0])) - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union))));
                            shkalas[a].y_coord.Insert(0, shkalas[a].y_coord[0]);
                        }

                        data.x_value.Insert(0,
                            shkalas[curr_graph].x_value[0]);
                        data.y_value.Insert(0,
                            shkalas[curr_graph].y_value[0]);
                        //Пересчет из значения в координаты
                        data.x_coord.Insert(0,
                           shkalas[curr_graph].x_coord[0]);
                        data.y_coord.Insert(0, shkalas[curr_graph].y_coord[0]);

                        //Добавление записи в lst и dep
                        data.selected_record = 0;
                        data.key_value_write = shkalas[curr_graph].x_value[0];
                        data.add_record();
                        data.write_value(52, (0), shkalas[curr_graph].x_value[0]);

                    }

                    //.....!..   ..!.....
                    if (add_record.new_x_value[1] - add_record.new_x_value[0] > add_record.step_time)
                    {
                        for (int i = 0; i < shkalas[curr_graph].x_value.Count - 1; i++)
                        {
                            //Разница между x1 и x0
                            add_record.in_interval = (shkalas[curr_graph].x_value[i + 1]) - (shkalas[curr_graph].x_value[i]);

                            if ((shkalas[curr_graph].x_value[i]) >= (add_record.new_x_value[0])
                                & (shkalas[curr_graph].x_value[i]) <= (add_record.new_x_value[1]) & (add_record.in_interval > 1.9 * add_record.step_time))
                            {
                                add_record.first_record = i;
                                add_record.last_record = i + 1;
                                break;
                            }

                        }
                        //Считаем число Новых Записей
                        if (add_record.first_record != add_record.last_record)
                        {
                            add_record.N_create = (int)((shkalas[curr_graph].x_value[add_record.last_record]
                                - shkalas[curr_graph].x_value[add_record.first_record]) / add_record.step_time);

                            //Добавляем новые записи
                            data.dep_ok = false;
                            for (int i = add_record.first_record; i < add_record.first_record + add_record.N_create - 1; i++)
                            {
                                for (int a = 0; a < shkalas.Count; a++)
                                {
                                    //Вставка записи
                                    shkalas[a].x_value.Insert(i + 1,
                                        ((shkalas[a].x_value[i]) + add_record.step_time));
                                    shkalas[a].y_value.Insert(i + 1,
                                        (shkalas[a].y_value[i]));
                                    //Пересчет из значения в координаты
                                    shkalas[a].x_coord.Insert(i + 1,
                                        (rul.x + (((shkalas[a].x_value[i + 1])) - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union))));
                                    shkalas[a].y_coord.Insert(i + 1, shkalas[a].y_coord[i]);
                                }

                                data.x_value.Insert(i + 1,
                                    shkalas[curr_graph].x_value[i + 1]);
                                data.y_value.Insert(i + 1,
                                    shkalas[curr_graph].y_value[i + 1]);
                                //Пересчет из значения в координаты
                                data.x_coord.Insert(i + 1,
                                   shkalas[curr_graph].x_coord[i + 1]);
                                data.y_coord.Insert(i + 1, shkalas[curr_graph].y_coord[i + 1]);

                                //Добавление записи в lst и dep
                                data.selected_record = i + 1;
                                data.key_value_write = shkalas[curr_graph].x_value[i + 1];
                                data.add_record();
                                data.write_value(52, (i + 1), (shkalas[curr_graph].x_value[i + 1]));

                                //data.read_ref_size_value(52);
                            }

                        }

                    }


                }
                data.n_max_calc();
                //Прочистка номеров записей петлевых
                loops.numb_record_loop.Clear();
                loops.current_value = shkalas[curr_graph].x_value[0];
                //Поиск петель и занесение в список номеров записей
                for (int i = 1; i < shkalas[curr_graph].x_value.Count; i++)
                {

                    if (shkalas[curr_graph].x_value[i] <= loops.current_value)
                    {
                        loops.numb_record_loop.Add(i);
                    }
                    else
                    {
                        loops.current_value = shkalas[curr_graph].x_value[i];
                    }

                }
                 //Удаление петель
                if (loops.numb_record_loop.Count > 0)
                {
                    data.dep_ok = false;

                    for (int i = loops.numb_record_loop.Count - 1; i >= 0; i--)
                    {
                        data.x_coord.RemoveAt(loops.numb_record_loop[i]);
                        data.y_coord.RemoveAt(loops.numb_record_loop[i]);
                        data.x_value.RemoveAt(loops.numb_record_loop[i]);
                        data.y_value.RemoveAt(loops.numb_record_loop[i]);
                        for (int a = 0; a < shkalas.Count; a++)
                        {
                            shkalas[a].x_coord.RemoveAt(loops.numb_record_loop[i]);
                            shkalas[a].y_coord.RemoveAt(loops.numb_record_loop[i]);
                            shkalas[a].x_value.RemoveAt(loops.numb_record_loop[i]);
                            shkalas[a].y_value.RemoveAt(loops.numb_record_loop[i]);
                        }
                        data.selected_record = loops.numb_record_loop[i];
                        data.del_record();

                    }
                }

                data.n_max_calc();
                add_record.delete_all_new_point();
                panel1.Visible = false;
                data.dep_ok = true;

               

            }
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            //Кнопка Удалить записи
            if (data.dep_ok & del_record.new_x_point.Count == 2)
            {
                label3.Text = "Вычисление...";
                panel1.Visible = true;
                panel1.Refresh();


                del_record.delete_all_new_point_coord_value();

                // Смена между первым и последним
                double change_0_end;
                if (del_record.new_x_point[0] > del_record.new_x_point[1])
                {
                    change_0_end = del_record.new_x_point[0];
                    del_record.new_x_point[0] = del_record.new_x_point[1];
                    del_record.new_x_point[1] = change_0_end;
                }
                //    //Перевод координаты в значение
                //del_record.new_x_value.Add(((del_record.new_x_point[0] - rul.x) * (shkalas_x.end_union - shkalas_x.begin_union) / rul.l) + shkalas_x.begin_union);
                //del_record.new_x_value.Add(((del_record.new_x_point[1] - rul.x) * (shkalas_x.end_union - shkalas_x.begin_union) / rul.l) + shkalas_x.begin_union);

                //Поиск первой и последней точки
                del_record.in_interval = 0;
                del_record.first_record = 0;
                del_record.last_record = 0;

              
                //.....!..   ..!.....
                data.dep_ok = false;
                    
                    for (int i = shkalas[curr_graph].x_coord.Count - 1; i >=0 ; i--)
                    {
                        //Разница между x1 и x0

                        if ((shkalas[curr_graph].x_coord[i]) >= (del_record.new_x_point[0])
                            & (shkalas[curr_graph].x_coord[i]) <= (del_record.new_x_point[1]))
                        {
                                
                            for (int a = 0; a < shkalas.Count; a++)
                            {
                                //Удаление записи
                                shkalas[a].x_value.RemoveAt(i);
                                shkalas[a].y_value.RemoveAt(i);
                                //Пересчет из значения в координаты
                                shkalas[a].x_coord.RemoveAt(i);
                                shkalas[a].y_coord.RemoveAt(i);
                            }

                            data.x_value.RemoveAt(i);
                            data.y_value.RemoveAt(i);
                            //Пересчет из значения в координаты
                            data.x_coord.RemoveAt(i);
                            data.y_coord.RemoveAt(i);

                            //Удаление записи в lst
                            data.selected_record = i;
                            data.del_record();
                                
                        }

                    }
                
            }
            data.n_max_calc();
            del_record.delete_all_new_point();
            panel1.Visible = false;
            data.dep_ok = true;
           

        }

        private void добавитьЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_records();
        }

        private void удалитьЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            del_records();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            rot = true;
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton20_Click_1(object sender, EventArgs e)
        {
            if (tri_al)
            {
                //Кнопка Вставить нажата
                if (data.dep_ok & copy_paste.new_x_point.Count == 2 & copy_paste.new_x_point_coord.Count > 0)
                {
                    label3.Text = "Вычисление...";
                    panel1.Visible = true;
                    panel1.Refresh();
                    if (data.type_file<0) { }
                }

                panel1.Visible = false;
            }

            else
            {
                trial trial = new trial();
                trial.ShowDialog(this);

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                toolStripButton1_Click(null, null);
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                toolStripButton5_Click(null, null);
            }
            if (keyData == (Keys.Control | Keys.Z))
            {
                toolStripButton21_Click(null, null);
            }

            if (keyData == (Keys.Control | Keys.Y))
            {
                toolStripButton22_Click(null, null);
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                toolStripButton23_Click(null, null);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            if (backupall.curr_numb_otkat < (backupall.list_backups.Count))
            {
                if (backupall.curr_numb_otkat == backupall.list_backups.Count -1)
                {
                    toolStripButton22.Enabled = false;
                }
                else
                {
                    toolStripButton22.Enabled = true;

                }

                backupall.curr_numb_otkat += 1;
                for (int i = 0; i < backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param.Count; i++)
                {

                    //Восстановление последней операции
                    //shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].y_coord[list_backups[(list_backups.Count) - 1].numb_rec[i]] = rul2.x + (list_backups[(list_backups.Count) - 1].y_value[i] - shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].begin_union) * (rul2.l / (shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].end_union - shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].begin_union));
                    //data.y_coord[list_backups[(list_backups.Count) - 1].numb_rec[i]] = shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].y_coord[list_backups[(list_backups.Count) - 1].numb_rec[i]];
                    shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].y_coord[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] =
                    rul2.x + (backupall.list_backups[backupall.curr_numb_otkat - 1].y_value_new[i] - shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].begin_union) *
                    (rul2.l / (shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].end_union - shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].begin_union));
                    data.y_coord[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] = shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].y_coord[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]];

                    //shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].y_value[list_backups[(list_backups.Count) - 1].numb_rec[i]] = list_backups[(list_backups.Count) - 1].y_value[i];
                    //data.y_value[list_backups[(list_backups.Count) - 1].numb_rec[i]] = list_backups[(list_backups.Count) - 1].y_value[i];
                    //data.write_value(list_backups[(list_backups.Count) - 1].numb_param[i], list_backups[(list_backups.Count) - 1].numb_rec[i], list_backups[(list_backups.Count) - 1].y_value[i]);
                    shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].y_value[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] = backupall.list_backups[backupall.curr_numb_otkat - 1].y_value_new[i];
                    data.y_value[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] = backupall.list_backups[backupall.curr_numb_otkat - 1].y_value_new[i];
                    data.write_value(backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i], backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i], backupall.list_backups[backupall.curr_numb_otkat - 1].y_value_new[i]);
                }
                //Перемещение указателя последней выполенной операции восстановления


                //backupall.remove_operation();
                if (backupall.curr_numb_otkat > 0) {
                    toolStripButton21.Enabled = true;
                }
                else {  }

            }
            else {
                //Откл. кнопка откат
                //toolStripButton22.Enabled = false;
            }
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            if (backupall.curr_numb_otkat > 0)
            {
                //Вкл. кнопку отката
                if (backupall.curr_numb_otkat == backupall.list_backups.Count+1)
                {
                    toolStripButton22.Enabled = false;
                }
                else {
                    toolStripButton22.Enabled = true;
                
                }
                for (int i = 0; i < backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param.Count; i++)
                {

                    //Восстановление последней операции
                    //shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].y_coord[list_backups[(list_backups.Count) - 1].numb_rec[i]] = rul2.x + (list_backups[(list_backups.Count) - 1].y_value[i] - shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].begin_union) * (rul2.l / (shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].end_union - shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].begin_union));
                    //data.y_coord[list_backups[(list_backups.Count) - 1].numb_rec[i]] = shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].y_coord[list_backups[(list_backups.Count) - 1].numb_rec[i]];
                    shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].y_coord[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] =
                    rul2.x + (backupall.list_backups[backupall.curr_numb_otkat - 1].y_value[i] - shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].begin_union) *
                    (rul2.l / (shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].end_union - shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].begin_union));
                    data.y_coord[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] = shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].y_coord[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]];

                    //shkalas[list_backups[(list_backups.Count) - 1].numb_param[i]].y_value[list_backups[(list_backups.Count) - 1].numb_rec[i]] = list_backups[(list_backups.Count) - 1].y_value[i];
                    //data.y_value[list_backups[(list_backups.Count) - 1].numb_rec[i]] = list_backups[(list_backups.Count) - 1].y_value[i];
                    //data.write_value(list_backups[(list_backups.Count) - 1].numb_param[i], list_backups[(list_backups.Count) - 1].numb_rec[i], list_backups[(list_backups.Count) - 1].y_value[i]);
                    shkalas[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i]].y_value[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] = backupall.list_backups[backupall.curr_numb_otkat - 1].y_value[i];
                    data.y_value[backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i]] = backupall.list_backups[backupall.curr_numb_otkat - 1].y_value[i];
                    data.write_value(backupall.list_backups[backupall.curr_numb_otkat - 1].numb_param[i], backupall.list_backups[backupall.curr_numb_otkat - 1].numb_rec[i], backupall.list_backups[backupall.curr_numb_otkat - 1].y_value[i]);
                }
                //Перемещение указателя последней выполенной операции восстановления

                backupall.curr_numb_otkat -= 1;
                //backupall.remove_operation();
                //Откл. кнопку отката
                if (backupall.curr_numb_otkat > 0) { }
                else { toolStripButton21.Enabled = false; }

            }
            else
            {
                
                
            }

            
        }

        //Поиск места по х
        public void finder() { 
             //Кнопка поиск
            if (data.dep_ok)
            {
                find.type_r_bool = rul1.type_r_bool;
                find.timeshift_hourse = data.timeshift_hourse;
                //settings.numericUpDown1.Value = data.timeshift_hourse;
                //Информация о файле
                if (rul1.type_r_bool)
                {
                    data.value_to_date(rul.begin_union);
                    find.label1.Text = data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                        data.Minute + ":" + data.Seconds;
                    data.value_to_date(rul.end_union);
                    find.label2.Text = data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" +
                        data.Minute + ":" + data.Seconds;
                    find.hScrollBar1.Minimum = (int)rul.begin_union;
                    find.hScrollBar1.Maximum = (int)rul.end_union;

                    int value = (int)(((a - rul.x) * (shkalas_x.end_union - shkalas_x.begin_union) / rul.l) + shkalas_x.begin_union);
                    if (value < find.hScrollBar1.Minimum)
                    {
                        find.hScrollBar1.Value = find.hScrollBar1.Minimum;
                    }
                    else
                    {
                        find.hScrollBar1.Value = value;
                    }
                    find.couter();

                    //Масштаб время
                    //find.comboBox1.Items.Clear();
                    //find.comboBox1.Items.Add("текущий");
                    //find.comboBox1.Items.Add("5 мин.");
                    //find.comboBox1.Items.Add("10 мин.");
                    //find.comboBox1.Items.Add("30 мин.");
                    //find.comboBox1.Items.Add("1 ч.");
                    //find.comboBox1.Items.Add("3 ч.");
                    //find.comboBox1.Items.Add("6 ч.");
                    //find.comboBox1.Items.Add("12 ч.");
                    //find.comboBox1.Items.Add("24 ч.");
                    //find.comboBox1.Items.Add("всё");
                    //find.comboBox1.SelectedIndex = 0;
                    //find.label3.Text=
                    //find.label3.Text = (((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    //    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union).ToString();
                    //find.cur = (((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    //    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union);
                }
                else
                {
                    //beg_end_txt = rul.begin_union + "-" + rul.end_union + "м";
                    find.label1.Text = "" + Math.Round(rul.begin_union, 2);
                    find.label2.Text = "" + Math.Round(rul.end_union, 2);
                    find.hScrollBar1.Minimum = (int)rul.begin_union;
                    find.hScrollBar1.Maximum = (int)rul.end_union;

                    int value = (int)(((a - rul.x) * (shkalas_x.end_union - shkalas_x.begin_union) / rul.l) + shkalas_x.begin_union);
                    if (value < find.hScrollBar1.Minimum)
                    {
                        find.hScrollBar1.Value = find.hScrollBar1.Minimum;
                    }
                    else
                    {
                        find.hScrollBar1.Value = value;

                    }

                    find.label3.Text = "" + find.hScrollBar1.Value;
                }



                find.ShowDialog(this);

                if (find.DialogResult == DialogResult.OK)
                {
                    double sss = dotsx - a;
                    //data.timeshift_hourse = Convert.ToInt32(settings.numericUpDown1.Value);
                    a = rul.x + ((double)find.hScrollBar1.Value - rul.begin_union) * (rul.l / (rul.end_union - rul.begin_union));
                    dotsx = a + sss;


                    ////Масштаб (Ширина окна)
                    //switch (find.comboBox1.SelectedIndex)
                    //{
                    //    case 0:
                    //        {

                    //            break;
                    //        }
                    //    case 1:
                    //        {
                    //            dotsx = a + (5 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 2:
                    //        {
                    //            dotsx = a + (10 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 3:
                    //        {
                    //            dotsx = a + (30 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 4:
                    //        {
                    //            dotsx = a + (1 * 60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 5:
                    //        {
                    //            dotsx = a + (3 * 60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 6:
                    //        {
                    //            dotsx = a + (6 * 60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 7:
                    //        {
                    //            dotsx = a + (12 * 60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 8:
                    //        {
                    //            dotsx = a + (24 * 60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                    //            break;
                    //        }
                    //    case 9:
                    //        {
                    //            b = 0;
                    //            dotsy = 105;
                    //            a = 5;
                    //            dotsx = rul.l;
                    //            break;
                    //        }

                    //}

                    //shkalas_x.begin_union = sss;
                    OpenGL gl = openGLControl1.OpenGL;
                    gl.MatrixMode(OpenGL.GL_PROJECTION);
                    gl.LoadIdentity();


                    gl.Ortho2D(a, dotsx, b, dotsy);
                    gl.MatrixMode(OpenGL.GL_MODELVIEW);
                    //Сдвиг Новая шкала Х новое значение







                }

                //Сдвиг Новая шкала Х новое значение

                shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
                shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;

                shkalas_x.init();
                shkalas_x.calc();
                shkalas_x.all_calc_init();


                //сдвиг оси y

                //a2 = 0; b2 = b; dotsx3 = dots; dotsy3 = dotsy;
                //OpenGL gl2 = openGLControl2.OpenGL;
                //gl2.MatrixMode(MatrixMode.Projection);
                //gl2.LoadIdentity();
                //gl2.Ortho2D(a2, dotsx3, b2, dotsy3);
                //gl2.MatrixMode(MatrixMode.Modelview);

                //Сдвиг Новая шкала Y новое значение
                for (int g = 0; g < shkalas.Count; g++)
                {
                    shkalas[g].a1new = ((b + shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
               (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;
                    shkalas[g].a2new = ((dotsy - shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                        (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;
                    shkalas[g].init();
                    shkalas[g].calc();
                    shkalas[g].all_calc_init();
                }
                //mega_refresh();
                //recalc_shakas_x_N();
            }
        } 

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            finder();
        }

        private void openGLControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            toolStripButton4_Click(null, null);
        }

        //private void SharpGLForm_KeyDown(object sender, Keys KeyData)
        //{
        //    //
        //    if (KeyData == (Keys.Control & Keys.O))
        //    {
        //        toolStripButton1_Click(null, null);
        //    }

        //}
        //Cохранение настроек
        public void save_set()
        {

            //nastr.source_path = textBox1.Text;
            //nastr.destination_path = textBox2.Text;
            //nastr.current_time_name = comboBox1.Text;
            //nastr.wr_time = checkBox2.Checked.ToString();
            //nastr.loading_store = checkBox1.Checked.ToString();
            //nastr.wr_store = checkBox3.Checked.ToString();
            //nastr.pause_sec = (Math.Ceiling((double)numericUpDown1.Value)).ToString();
            //nastr.buffer_zap = (Math.Ceiling((double)numericUpDown2.Value)).ToString();
            nastr.time_shift = settings.numericUpDown1.Value.ToString();
            nastr.main_line_width = settings.comboBox2.Text;
            nastr.quality = settings.comboBox1.SelectedIndex.ToString();
            nastr.dots_on = settings.comboBox3.SelectedIndex.ToString();
            nastr.dots_width = settings.comboBox4.SelectedIndex.ToString();
            if (Path.GetDirectoryName(openFileDialog1.FileName)!=""){
            nastr.work_path =Path.GetDirectoryName(openFileDialog1.FileName);}

            try {
            settings_ini.Indent = true;
            settings_ini.IndentChars = ("    ");
            XmlWriter writer = XmlWriter.Create("Settings.xml", settings_ini);
            
                // Write XML time.
                writer.WriteStartElement(nastr.Sect);
                writer.WriteComment("Часовой сдвиг");
                writer.WriteElementString("timeshift_hourse", nastr.time_shift);
                writer.WriteComment("Рабочая директория");
                writer.WriteElementString("work_path", nastr.work_path);
                writer.WriteComment("Графика");
                writer.WriteComment("Толщина линий");
                writer.WriteElementString("main_line_width", nastr.main_line_width);
                writer.WriteComment("Качество отрисовки");
                writer.WriteElementString("quality", nastr.quality);
                writer.WriteComment("Вкл..выкл точки");
                writer.WriteElementString("dots_on", nastr.dots_on);
                writer.WriteComment("Вкл..выкл точки");
                writer.WriteElementString("dots_width", nastr.dots_width);
                //writer.WriteElementString("source_path", nastr.source_path);
                //writer.WriteElementString("destination_path", nastr.destination_path);
                //writer.WriteElementString("current_time_name", nastr.current_time_name);
                //writer.WriteElementString("wr_time", nastr.wr_time);
                //writer.WriteElementString("loading_store", nastr.loading_store);
                //writer.WriteElementString("wr_store", nastr.wr_store);
                //writer.WriteElementString("pause_sec", nastr.pause_sec);
                //writer.WriteElementString("buffer_zap", nastr.buffer_zap);
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }catch{}
        }

        //Чтение настроек
        public void read_set()
        {

            ////ini файл
            try
            {
                while (rdr.Read())
                {
                    if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "timeshift_hourse")
                    {
                        rdr.Read();
                        if (rul1.type_r_bool)
                        {
                            data.timeshift_hourse = Convert.ToInt32(rdr.Value);
                            nastr.time_shift = rdr.Value;
                            settings.numericUpDown1.Value = Convert.ToInt32(rdr.Value);
                        }
                        else { data.timeshift_hourse = 0; }

                        nastr.time_shift = rdr.Value;
                        settings.numericUpDown1.Value = Convert.ToInt32(rdr.Value);
                    }

                    if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "main_line_width")
                    {
                        rdr.Read();
                        settings.comboBox2.Text = rdr.Value.ToString();

                    }

                    if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "quality")
                    {
                        rdr.Read();
                        settings.comboBox1.SelectedIndex = Convert.ToInt16(rdr.Value);

                    }

                    if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "dots_on")
                    {
                        rdr.Read();
                        settings.comboBox3.SelectedIndex = Convert.ToInt16(rdr.Value);

                    }

                    if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "dots_width")
                    {
                        rdr.Read();
                        settings.comboBox4.SelectedIndex = Convert.ToInt16(rdr.Value);

                    }

                    if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "work_path")
                    {
                        rdr.Read();
                        nastr.work_path = rdr.Value;
                        //work_path = rdr.Value;
                        //openFileDialog1.InitialDirectory = work_path;

                    }

                    //Качество отрисовки
                    if (settings.comboBox1.SelectedIndex == 0)
                    {
                        quality = true;
                    }
                    else { quality = false; }

                    main_line_width = (float)Convert.ToDouble(settings.comboBox2.GetItemText(settings.comboBox2.SelectedItem));

                    //Вкл..выкл точки
                    if (settings.comboBox3.SelectedIndex == 0)
                    {
                        dots_on_off = true;
                    }
                    else { dots_on_off = false; }
                    dots_width = (float)Convert.ToDouble(settings.comboBox4.GetItemText(settings.comboBox4.SelectedItem));


                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "source_path")
                    //{
                    //    rdr.Read();
                    //    textBox1.Text = rdr.Value.ToString();

                    //}
                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "destination_path")
                    //{
                    //    rdr.Read();
                    //    textBox2.Text = rdr.Value.ToString();

                    //}
                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "current_time_name")
                    //{
                    //    rdr.Read();
                    //    comboBox1.Text = rdr.Value.ToString();
                    //    //comboBox1.SelectedItem = comboBox1.Text;
                    //}


                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "wr_time")
                    //{
                    //    rdr.Read();
                    //    checkBox2.Checked = Convert.ToBoolean(rdr.Value);

                    //}
                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "loading_store")
                    //{
                    //    rdr.Read();
                    //    checkBox1.Checked = Convert.ToBoolean(rdr.Value);

                    //}
                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "wr_store")
                    //{
                    //    rdr.Read();
                    //    checkBox3.Checked = Convert.ToBoolean(rdr.Value);

                    //}
                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "pause_sec")
                    //{
                    //    rdr.Read();
                    //    numericUpDown1.Value = Convert.ToInt16(rdr.Value);

                    //}

                    //if (rdr.NodeType == XmlNodeType.Element && rdr.Name == "buffer_zap")
                    //{
                    //    rdr.Read();
                    //    numericUpDown2.Value = Convert.ToInt16(rdr.Value);

                    //}

                }
                rdr.Close();
            }
            catch { }
        }

        //Сохранение настроек перед выходом
        private void SharpGLForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            save_set();
        }

        private void openGLControl3_MouseUp(object sender, MouseEventArgs e)
        {
            openGLControl3.Cursor = Cursors.Cross;
            if (hit_mouse_right3)
            {


                //Cдвиг текущего графика
                //graph_plus();
                openGLControl3.Cursor = Cursors.Cross;
                hit_mouse_right3 = false;

            }
        }

        private void openGLControl3_MouseMove(object sender, MouseEventArgs e)
        {
            if (hit_mouse_right3 & work_move == false)
            {
                work_move = true;

                coord2 = calc_xy(e.X, openGLControl1.Height - e.Y);
                coord21 = calc_xy(e.X, e.Y);

                //if ((Math.Abs(coord1[0] - coord2[0]) > 0.000001) | (Math.Abs(coord1[1] - coord2[1]) > 0.000001))
                //{
                //сдвиг основной области 
                dispx = coord1[0] - coord2[0];
                dispy = coord2[1] - coord1[1];
                OpenGL gl = openGLControl1.OpenGL;
                gl.MatrixMode(OpenGL.GL_PROJECTION);
                gl.LoadIdentity();
                dotsy -= 0; b -= 0; a += dispx; dotsx += dispx;

                gl.Ortho2D(a, dotsx, b, dotsy);
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                ////label1.Text = "left:" + a.ToString() + " right:" + dotsx.ToString() +
                ////    " bottom:" + b.ToString() + " top:" + dotsy.ToString();
                //сдвиг оси х
                //a1 = a; b1 = 0; dotsx1 = dotsx; dotsy1 = dots;
                //OpenGL gl1 = openGLControl3.OpenGL;
                //gl1.MatrixMode(MatrixMode.Projection);
                //gl1.LoadIdentity();
                //gl1.Ortho2D(a1, dotsx1, b1, dotsy1);
                //gl1.MatrixMode(MatrixMode.Modelview);

                //Сдвиг Новая шкала Х новое значение

                shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
                shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;


                shkalas_x.calc();
                shkalas_x.all_calc_init();

                }
                work_move = false;
            
        }

        private void openGLControl3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                openGLControl3.Cursor = Cursors.SizeWE;
                if (data.dep_ok)
                {
                    ////Поиск графика по клику
                    //int selected_graph = search_graph(e.X, e.Y);
                    ////label6.Text = selected_graph.ToString();
                    ////Смена текущего(редактируемого) графика
                    //if (selected_graph < 256) { change_dest_graph(selected_graph); }
                    hit_mouse_right3 = true;
                    //x_hit_before = e.X;
                    //y_hit_before = e.Y;
                    coord1 = calc_xy(e.X, openGLControl1.Height - e.Y);
                    coord11 = calc_xy(e.X, openGLControl1.Height - e.Y);
                }
            }
        }

        //Интерактивная смена Масштаба
        private void toolStripDropDownButton2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            
            if (data.dep_ok) {
                string st = e.ClickedItem.Text;

                switch (st) { 
                    case "5 мин": {
                        dotsx = a + (5 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                       
                    break;
                    }
                    case "10 мин":
                        {
                            dotsx = a + (10 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                            
                            break;
                        }
                    case "30 мин":
                        {
                            dotsx = a + (30 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                            
                            break;
                        }
                    case "1 час":
                        {
                            dotsx = a + (60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                            
                            break;
                        }
                    case "3 час":
                        {
                            dotsx = a + (3*60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                            
                            break;
                        }
                    case "6 час":
                        {
                            dotsx = a + (6*60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                            
                            break;
                        }
                    
                    case "12 час":
                        {
                            dotsx = a + (12*60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                            
                            break;
                        }
                    case "24 час":
                        {
                            dotsx = a + (24*60 * 60) * (rul.l / (rul.end_union - rul.begin_union));
                            
                            break;
                        }
                    case "100 %":
                        {
                            b = 0;
                            dotsy = 105;
                            a = 5;
                            dotsx = rul.l;
                            break;
                        }
                    case "1 м":
                        {
                            dotsx = a + (1) * (rul.l / (rul.end_union - rul.begin_union));

                            break;
                        }
                    case "5 м":
                        {
                            dotsx = a + (5) * (rul.l / (rul.end_union - rul.begin_union));

                            break;
                        }
                    case "30 м":
                        {
                            dotsx = a + (30) * (rul.l / (rul.end_union - rul.begin_union));

                            break;
                        }
                    case "100 м":
                        {
                            dotsx = a + (100) * (rul.l / (rul.end_union - rul.begin_union));

                            break;
                        }
                    case "300 м":
                        {
                            dotsx = a + (300) * (rul.l / (rul.end_union - rul.begin_union));

                            break;
                        }
                    case "500 м":
                        {
                            dotsx = a + (500) * (rul.l / (rul.end_union - rul.begin_union));

                            break;
                        }
                    case "1000 м":
                        {
                            dotsx = a + (1000) * (rul.l / (rul.end_union - rul.begin_union));

                            break;
                        }
                }


                //сдвиг основной области 
                dispx = 0;
                dispy = 0;
                OpenGL gl = openGLControl1.OpenGL;
                gl.MatrixMode(OpenGL.GL_PROJECTION);
                gl.LoadIdentity();
                dotsy -= dispy; b -= dispy; a += dispx; dotsx += dispx;

                gl.Ortho2D(a, dotsx, b, dotsy);
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                ////label1.Text = "left:" + a.ToString() + " right:" + dotsx.ToString() +
                ////    " bottom:" + b.ToString() + " top:" + dotsy.ToString();
                //сдвиг оси х
                //a1 = a; b1 = 0; dotsx1 = dotsx; dotsy1 = dots;
                //OpenGL gl1 = openGLControl3.OpenGL;
                //gl1.MatrixMode(MatrixMode.Projection);
                //gl1.LoadIdentity();
                //gl1.Ortho2D(a1, dotsx1, b1, dotsy1);
                //gl1.MatrixMode(MatrixMode.Modelview);

                //Сдвиг Новая шкала Х новое значение
                //shkalas_x.N = 10;
                shkalas_x.a1new = ((a + shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;
                shkalas_x.a2new = ((dotsx - shkalas_x.dy * (dotsx - a) / 100 - rul1.x) *
                    (shkalas_x.end_union - shkalas_x.begin_union) / rul1.l) + shkalas_x.begin_union;

                shkalas_x.init();
                shkalas_x.calc();
                shkalas_x.all_calc_init();


                //сдвиг оси y

                //a2 = 0; b2 = b; dotsx3 = dots; dotsy3 = dotsy;
                //OpenGL gl2 = openGLControl2.OpenGL;
                //gl2.MatrixMode(MatrixMode.Projection);
                //gl2.LoadIdentity();
                //gl2.Ortho2D(a2, dotsx3, b2, dotsy3);
                //gl2.MatrixMode(MatrixMode.Modelview);

                //Сдвиг Новая шкала Y новое значение
                for (int g = 0; g < shkalas.Count; g++)
                {
                    shkalas[g].a1new = ((b + shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
               (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;
                    shkalas[g].a2new = ((dotsy - shkalas[g].dy * (dotsy - b) / 100 - rul2.x) *
                        (shkalas[g].end_union - shkalas[g].begin_union) / rul2.l) + shkalas[g].begin_union;

                    shkalas[g].init();
                    shkalas[g].calc();
                    shkalas[g].all_calc_init();
                }
            }

        }

        



    }
}
