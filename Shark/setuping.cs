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
    public partial class setuping : Form
    {
        public setuping()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void setuping_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void setuping_Shown(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Узел1":
                    {
                        tabControl1.SelectedTab = tabPage1;
                        break;
                    }
                case "Узел3":
                    {
                        tabControl1.SelectedTab = tabPage2;
                        break;
                    }
                case "Узел6":
                    {
                        tabControl1.SelectedTab = tabPage3;
                        break;
                    }
            }
        }
    }
}
