namespace Shark
{
    partial class helphelp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Интерфейс");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Навигация");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Рисовать");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Копирование интервалов");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Копирование из разных файлов(store time)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Копировать(пример)", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Шум параметра");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Рисование газа");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Точное рисование газа");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Шум/Смещение(пример)", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("ДМК (Мех.скорость)");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Сумма объемов емкостей");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Копирование всего интервала параметра в другой");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Вычислить(пример)", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Измерить");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Вставка записей");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Удалить записи");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Записи", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Удалить петли");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("*Cвернуть/развернуть видео двойной щелчок на экране", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode6,
            treeNode10,
            treeNode14,
            treeNode15,
            treeNode18,
            treeNode19});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helphelp));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axWindowsMediaPlayer1);
            this.splitContainer1.Size = new System.Drawing.Size(756, 330);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeView1.ImageIndex = 76;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "shark.ico";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "Интерфейс";
            treeNode2.ImageKey = "colors.ico";
            treeNode2.Name = "Узел2";
            treeNode2.Text = "Навигация";
            treeNode3.ImageKey = "pencil_4559.ico";
            treeNode3.Name = "Узел4";
            treeNode3.Text = "Рисовать";
            treeNode4.ImageKey = "copydoc_3544.ico";
            treeNode4.Name = "Узел100";
            treeNode4.Text = "Копирование интервалов";
            treeNode5.ImageKey = "copydoc_3544.ico";
            treeNode5.Name = "Узел200";
            treeNode5.Text = "Копирование из разных файлов(store time)";
            treeNode6.ImageKey = "copydoc_3544.ico";
            treeNode6.Name = "Узел7";
            treeNode6.Text = "Копировать(пример)";
            treeNode7.ImageKey = "wave_high_frequency_icon.jpg";
            treeNode7.Name = "Узел300";
            treeNode7.Text = "Шум параметра";
            treeNode8.ImageKey = "wave_high_frequency_icon.jpg";
            treeNode8.Name = "Узел400";
            treeNode8.Text = "Рисование газа";
            treeNode9.ImageKey = "wave_high_frequency_icon.jpg";
            treeNode9.Name = "Узел500";
            treeNode9.Text = "Точное рисование газа";
            treeNode10.ImageKey = "wave_high_frequency_icon.jpg";
            treeNode10.Name = "Узел9";
            treeNode10.Text = "Шум/Смещение(пример)";
            treeNode11.ImageKey = "sum.ico";
            treeNode11.Name = "Узел600";
            treeNode11.Text = "ДМК (Мех.скорость)";
            treeNode12.ImageKey = "sum.ico";
            treeNode12.Name = "Узел700";
            treeNode12.Text = "Сумма объемов емкостей";
            treeNode13.ImageKey = "sum.ico";
            treeNode13.Name = "Узел800";
            treeNode13.Text = "Копирование всего интервала параметра в другой";
            treeNode14.ImageKey = "sum.ico";
            treeNode14.Name = "Узел10";
            treeNode14.Text = "Вычислить(пример)";
            treeNode15.ImageKey = "designer.ico";
            treeNode15.Name = "Узел11";
            treeNode15.Text = "Измерить";
            treeNode16.ImageKey = "database_add.ico";
            treeNode16.Name = "Узел13";
            treeNode16.Text = "Вставка записей";
            treeNode17.ImageKey = "database_delete.ico";
            treeNode17.Name = "Узел14";
            treeNode17.Text = "Удалить записи";
            treeNode18.ImageKey = "database_edit.ico";
            treeNode18.Name = "Узел12";
            treeNode18.Text = "Записи";
            treeNode19.ImageKey = "bug_5726.ico";
            treeNode19.Name = "Узел15";
            treeNode19.Text = "Удалить петли";
            treeNode20.BackColor = System.Drawing.SystemColors.Control;
            treeNode20.ForeColor = System.Drawing.SystemColors.ControlText;
            treeNode20.ImageKey = "help_4856.ico";
            treeNode20.Name = "Узел0";
            treeNode20.Text = "*Cвернуть/развернуть видео двойной щелчок на экране";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20});
            this.treeView1.SelectedImageIndex = 76;
            this.treeView1.Size = new System.Drawing.Size(357, 330);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "59613.png");
            this.imageList1.Images.SetKeyName(1, "1416698146_apply.png");
            this.imageList1.Images.SetKeyName(2, "activity_monitor_add_7234.ico");
            this.imageList1.Images.SetKeyName(3, "activitymonitor_9056.ico");
            this.imageList1.Images.SetKeyName(4, "application-exit_1536.ico");
            this.imageList1.Images.SetKeyName(5, "application-exit_3069.ico");
            this.imageList1.Images.SetKeyName(6, "apply_9965.ico");
            this.imageList1.Images.SetKeyName(7, "Bruce1.JPG");
            this.imageList1.Images.SetKeyName(8, "Bruce.jpg");
            this.imageList1.Images.SetKeyName(9, "bug.ico");
            this.imageList1.Images.SetKeyName(10, "bug_5726.ico");
            this.imageList1.Images.SetKeyName(11, "calc (1).ico");
            this.imageList1.Images.SetKeyName(12, "calc.ico");
            this.imageList1.Images.SetKeyName(13, "calculator.ico");
            this.imageList1.Images.SetKeyName(14, "calculator_yellow.ico");
            this.imageList1.Images.SetKeyName(15, "chart_bar (1).ico");
            this.imageList1.Images.SetKeyName(16, "chart_bar.ico");
            this.imageList1.Images.SetKeyName(17, "chart_curve_3598.ico");
            this.imageList1.Images.SetKeyName(18, "chart_curve_add.ico");
            this.imageList1.Images.SetKeyName(19, "chart_curve_edit_8874.ico");
            this.imageList1.Images.SetKeyName(20, "chart_curve_go.ico");
            this.imageList1.Images.SetKeyName(21, "chart_line_8163.ico");
            this.imageList1.Images.SetKeyName(22, "chart_line_add_4725.ico");
            this.imageList1.Images.SetKeyName(23, "chart_line_delete_3196.ico");
            this.imageList1.Images.SetKeyName(24, "check (1).ico");
            this.imageList1.Images.SetKeyName(25, "clock_1897.ico");
            this.imageList1.Images.SetKeyName(26, "cog_8457.ico");
            this.imageList1.Images.SetKeyName(27, "color_palette.png");
            this.imageList1.Images.SetKeyName(28, "colors (1).ico");
            this.imageList1.Images.SetKeyName(29, "colors.ico");
            this.imageList1.Images.SetKeyName(30, "copy.ico");
            this.imageList1.Images.SetKeyName(31, "copydoc_3544.ico");
            this.imageList1.Images.SetKeyName(32, "database_add.ico");
            this.imageList1.Images.SetKeyName(33, "database_chart_3470.ico");
            this.imageList1.Images.SetKeyName(34, "database_delete.ico");
            this.imageList1.Images.SetKeyName(35, "database_edit.ico");
            this.imageList1.Images.SetKeyName(36, "database_error.ico");
            this.imageList1.Images.SetKeyName(37, "database_gear.ico");
            this.imageList1.Images.SetKeyName(38, "database_go.ico");
            this.imageList1.Images.SetKeyName(39, "database_lightning.ico");
            this.imageList1.Images.SetKeyName(40, "database_save.ico");
            this.imageList1.Images.SetKeyName(41, "database_save_2107.ico");
            this.imageList1.Images.SetKeyName(42, "designer.ico");
            this.imageList1.Images.SetKeyName(43, "designer.png");
            this.imageList1.Images.SetKeyName(44, "dialog-ok_7679.ico");
            this.imageList1.Images.SetKeyName(45, "dialog-ok_9935.ico");
            this.imageList1.Images.SetKeyName(46, "disk_7913.ico");
            this.imageList1.Images.SetKeyName(47, "document-open_2682.ico");
            this.imageList1.Images.SetKeyName(48, "document-open_4928.ico");
            this.imageList1.Images.SetKeyName(49, "document-save_7068.ico");
            this.imageList1.Images.SetKeyName(50, "document-save_7167.ico");
            this.imageList1.Images.SetKeyName(51, "door_out_7821.ico");
            this.imageList1.Images.SetKeyName(52, "edit-cut_7574.ico");
            this.imageList1.Images.SetKeyName(53, "edit-delete_2968.ico");
            this.imageList1.Images.SetKeyName(54, "edit-delete_5822.ico");
            this.imageList1.Images.SetKeyName(55, "edit-paste_9499.ico");
            this.imageList1.Images.SetKeyName(56, "fileopen_7651.ico");
            this.imageList1.Images.SetKeyName(57, "filesave_2895.ico");
            this.imageList1.Images.SetKeyName(58, "findingnemo5_4133.ico");
            this.imageList1.Images.SetKeyName(59, "findingnemo5_6853.ico");
            this.imageList1.Images.SetKeyName(60, "findingnemo5_6853.jpg");
            this.imageList1.Images.SetKeyName(61, "findingnemo5_7849.ico");
            this.imageList1.Images.SetKeyName(62, "folder-new_5323.ico");
            this.imageList1.Images.SetKeyName(63, "format-justify-fill_2339.ico");
            this.imageList1.Images.SetKeyName(64, "format-justify-left_9990.ico");
            this.imageList1.Images.SetKeyName(65, "format-justify-right_2984.ico");
            this.imageList1.Images.SetKeyName(66, "gnome_accessories_calculator (1).ico");
            this.imageList1.Images.SetKeyName(67, "gnome_accessories_calculator.ico");
            this.imageList1.Images.SetKeyName(68, "gnome_color_chooser.ico");
            this.imageList1.Images.SetKeyName(69, "gnome-monitor_7081.ico");
            this.imageList1.Images.SetKeyName(70, "gnome-monitor_7369.ico");
            this.imageList1.Images.SetKeyName(71, "gnome-run_7137.ico");
            this.imageList1.Images.SetKeyName(72, "gtk-cancel_4609.ico");
            this.imageList1.Images.SetKeyName(73, "gtk-media-forward-ltr_2345.ico");
            this.imageList1.Images.SetKeyName(74, "gtk-media-forward-rtl_6252.ico");
            this.imageList1.Images.SetKeyName(75, "hammer_7660.ico");
            this.imageList1.Images.SetKeyName(76, "help_4856.ico");
            this.imageList1.Images.SetKeyName(77, "help_7980.ico");
            this.imageList1.Images.SetKeyName(78, "import_8846.ico");
            this.imageList1.Images.SetKeyName(79, "kwikdisk.ico");
            this.imageList1.Images.SetKeyName(80, "lightbulb_9776.ico");
            this.imageList1.Images.SetKeyName(81, "minus.ico");
            this.imageList1.Images.SetKeyName(82, "page_add_9133.ico");
            this.imageList1.Images.SetKeyName(83, "page_blank_add_9726.ico");
            this.imageList1.Images.SetKeyName(84, "paste1.ico");
            this.imageList1.Images.SetKeyName(85, "paste1.PNG");
            this.imageList1.Images.SetKeyName(86, "paste1_1.bmp");
            this.imageList1.Images.SetKeyName(87, "paste1_1.ico");
            this.imageList1.Images.SetKeyName(88, "paste.ico");
            this.imageList1.Images.SetKeyName(89, "paste_m.bmp");
            this.imageList1.Images.SetKeyName(90, "paste_m.ico");
            this.imageList1.Images.SetKeyName(91, "pencil_4559.ico");
            this.imageList1.Images.SetKeyName(92, "pin_blue.ico");
            this.imageList1.Images.SetKeyName(93, "plus (1).ico");
            this.imageList1.Images.SetKeyName(94, "save_8855.ico");
            this.imageList1.Images.SetKeyName(95, "save_upload_8580.ico");
            this.imageList1.Images.SetKeyName(96, "shark (1).ico");
            this.imageList1.Images.SetKeyName(97, "shark (2).ico");
            this.imageList1.Images.SetKeyName(98, "shark (3).ico");
            this.imageList1.Images.SetKeyName(99, "shark (4).ico");
            this.imageList1.Images.SetKeyName(100, "shark.ico");
            this.imageList1.Images.SetKeyName(101, "shark.png");
            this.imageList1.Images.SetKeyName(102, "stock_save_3738.ico");
            this.imageList1.Images.SetKeyName(103, "sum.ico");
            this.imageList1.Images.SetKeyName(104, "tools-2_8658.ico");
            this.imageList1.Images.SetKeyName(105, "tools_1318.ico");
            this.imageList1.Images.SetKeyName(106, "wave11.ico");
            this.imageList1.Images.SetKeyName(107, "wave.ico");
            this.imageList1.Images.SetKeyName(108, "wave.png");
            this.imageList1.Images.SetKeyName(109, "wave_high_frequency_icon.jpg");
            this.imageList1.Images.SetKeyName(110, "window_app_list_chart_4625.ico");
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(395, 330);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // helphelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(766, 340);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "helphelp";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.helphelp_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;

    }
}