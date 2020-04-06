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
    public partial class helphelp : Form
    {
        public helphelp()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void helphelp_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name) {
                case "Узел0":
                    {
                        axWindowsMediaPlayer1.URL = @"help\введение11.wmv";
                        axWindowsMediaPlayer1.Visible = true;
                        break;
                    }
                case "Узел1":{
                    axWindowsMediaPlayer1.URL = @"help\введение.wmv";
                    axWindowsMediaPlayer1.Visible = true;
                break;
                }
                case "Узел2":
                    {
                        axWindowsMediaPlayer1.URL = @"help\навигация.wmv";
                        axWindowsMediaPlayer1.Visible=true;

                        break;
                    }
                case "Узел4":
                    {
                        axWindowsMediaPlayer1.URL = @"help\рисовать.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел100":
                    {
                        axWindowsMediaPlayer1.URL = @"help\копировать.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел200":
                    {
                        axWindowsMediaPlayer1.URL = @"help\копировать из файла в файл.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел300":
                    {
                        axWindowsMediaPlayer1.URL = @"help\шум.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел400":
                    {
                        axWindowsMediaPlayer1.URL = @"help\шум_газ1.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел500":
                    {
                        axWindowsMediaPlayer1.URL = @"help\шум_газ1_1.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел600":
                    {
                        axWindowsMediaPlayer1.URL = @"help\вычисление_дмк_мех_скорость.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел700":
                    {
                        axWindowsMediaPlayer1.URL = @"help\сумма_объем_емкостей.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел800":
                    {
                        axWindowsMediaPlayer1.URL = @"help\вычисление_копирование_всего_интервала_параметра_в_другой.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел11":
                    {
                        axWindowsMediaPlayer1.URL = @"help\измерить.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел13":
                    {
                        axWindowsMediaPlayer1.URL = @"help\добавить_записи.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел14":
                    {
                        axWindowsMediaPlayer1.URL = @"help\удалить_записи.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
                case "Узел15":
                    {
                        axWindowsMediaPlayer1.URL = @"help\удаление_петель.wmv";
                        axWindowsMediaPlayer1.Visible = true;

                        break;
                    }
            
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
