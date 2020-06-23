using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS_ContextMenuStrip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            MessageBox.Show(menu.Text);
        }
        private ToolStripMenuItem GetMenuItem(string txt, Image img=null)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = txt;
            menuItem.Image = img;
            return menuItem;
        }
        private void BindMenu()
        {
            ToolStripMenuItem menu0 = GetMenuItem("一級1");
            ToolStripMenuItem menu01 = GetMenuItem("二級11");
            ToolStripMenuItem menu02 = GetMenuItem("二級12");
            menu01.Click += new EventHandler(toolStripMenuItem_Click);//新增事件
            menu0.DropDownItems.Add(menu01);
            menu0.DropDownItems.Add(menu02);
            contextMenuStrip1.Items.Add(menu0);
            ToolStripMenuItem menu1 = GetMenuItem("一級2");
            ToolStripMenuItem menu11 = GetMenuItem("二級21");
            ToolStripMenuItem menu12 = GetMenuItem("二級22");
            menu1.DropDownItems.Add(menu11);
            menu1.DropDownItems.Add(menu12);
            contextMenuStrip1.Items.Add(menu1);
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                Point p = MousePosition;//取得滑鼠位置
                contextMenuStrip1.Close();
                contextMenuStrip1.Show(p);//顯示右鍵選單
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindMenu();
        }
    }
}
