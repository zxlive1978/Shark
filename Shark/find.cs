using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shark
{
    public partial class find : Form
    {
        public double min;
        public double max;
        public double cur;
        public bool type_r_bool;
        public find()
        {
            InitializeComponent();
        }

        //Пересчет нового значения
        public void couter(){
        if (type_r_bool) {
               value_to_date(hScrollBar1.Value);
                label3.Text= Day + "." + Month + "." + Year + " " + Hour + ":" +
                    Minute + ":" + Seconds;
            
            } else {
                label3.Text = hScrollBar1.Value.ToString();
            
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            couter(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //Часы, минуты, секунды
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string Seconds { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public DateTime current;
        //Сдвиг реального времени(часах)
        public long timeshift_hourse;
        //Перевод значения в дату
        public void value_to_date(double n)
        {
            current = origin.AddSeconds(n + timeshift_hourse * 3600);
            Hour = current.Hour.ToString();
            if (Hour.Length == 1) { Hour = "0" + Hour; }
            Minute = current.Minute.ToString();
            if (Minute.Length == 1) { Minute = "0" + Minute; }
            Seconds = current.Second.ToString();
            if (Seconds.Length == 1) { Seconds = "0" + Seconds; }

            Day = current.Day.ToString();
            if (Day.Length == 1) { Day = "0" + Day; }
            Month = current.Month.ToString();
            if (Month.Length == 1) { Month = "0" + Month; }
            Year = current.Year.ToString();
            if (Year.Length == 1) { Year = "0" + Year; }
        }
    }
}
