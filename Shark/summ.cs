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
    public partial class summ : Form
    {
        public summ_calc summ_calc = new summ_calc();
        public List<string> param= new List<string>();
        public string result;
        public summ()
        {
            InitializeComponent();
        }

        private void summ_Load(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) {
                case 0:{
                    textBox1.Text = result + " = ";
                    if (param.Count == 0) { 
                        textBox1.Text += " 0"; }
                     if (param.Count >= 1){
                    textBox1.Text +=param[0];
                    for (int i = 1; i < param.Count; i++)
                    { textBox1.Text += " + " + param[i]; }
                   }
                     break;
                }
                case 1:
                    {
                    textBox1.Text = result + " = " + result;
                    if (param.Count >= 1)
                    {
                        textBox1.Text += " - ( ";
                        textBox1.Text += param[0];
                        for (int i = 1; i <  param.Count; i++)
                        { textBox1.Text += " + " + param[i]; }
                        textBox1.Text += " ) ";
                    }
                        break;
                    }
                case 2:
                    {
                        textBox1.Text = result + " = " + result;
                        if (param.Count >= 1)
                        {
                            textBox1.Text += " + ( ";
                            textBox1.Text += param[0];
                            for (int i = 1; i < param.Count; i++)
                            { textBox1.Text += " + " + param[i]; }
                            textBox1.Text += " ) ";
                        }

                        break;
                    }

                case 3:
                    {
                        textBox1.Text = result + " = 1/";
                        if (param.Count >= 1)
                        {
                            textBox1.Text += " ( ";
                            textBox1.Text += param[0];
                            for (int i = 1; i < param.Count; i++)
                            { textBox1.Text += " + " + param[i]; }
                            textBox1.Text += " ) ";
                        }

                        break;
                    }
                case 4:
                    {
                        textBox1.Text =  " ";
                        comboBox1.Visible = false;
                        textBox1.ReadOnly = false;
                        label3.Visible = false;
                        textBox1.Height = 166;

                        label1.Visible = true;
                        label2.Visible = true;
                        comboBox2.Visible = true;
                        comboBox3.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        textBox2.Visible = true;
                        break;
                    }
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText += " "+comboBox2.SelectedItem.ToString()+" ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText += " " + comboBox3.SelectedItem.ToString()+" ";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = summ_calc.modifer_faq[comboBox3.SelectedIndex];
        }
    }
}
