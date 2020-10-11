using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System;


namespace Laba3Inform
{
    public partial class Form1 : Form
    {
        Timer timer;
        public Form1()
        {
            InitializeComponent();
             timer = new Timer() { Interval = 1000 };
             timer.Tick += timer_Tick;
             timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString();
        }

        void AddDirectories(TreeNode node) 
        {
            string path = node.FullPath;

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo[] arrDirInfo;
            try
            {
                // Пытаемся получить список подкаталогов
                arrDirInfo = dirInfo.GetDirectories();
            }
            catch
            {
                // Подкаталогов нет, выходим из рекурсии
                return;
            }
            foreach (DirectoryInfo dir in arrDirInfo)
            {
                // Создаем новый узел с именем подкаталога
                TreeNode nodeDir = new TreeNode(dir.Name);
                // Добавляем его как дочерний к текущему узлу
                node.Nodes.Add(nodeDir);
                AddDirectories(nodeDir);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = treeView1.SelectedNode.FullPath;
            AddFiles(path);
        }
        void AddFiles(string path) 
        {
            listView1.Clear();
            string[] files = null;
            listView1.Columns.Add("Name", 200);
            listView1.Columns.Add("Size", 50);
            listView1.Columns.Add("Type", 50);
            try
            {
                files = Directory.GetFiles(path);
            }
            catch 
            {
                MessageBox.Show("Ошибка доступа");
            }
            int indexOfFile = 0;
            if (files != null) 
                foreach (string file in files)
                {
                    ListViewItem lvi = new ListViewItem();
                    // установка названия файла
                    lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                    lvi.Checked = true;
                    // добавляем элемент в ListView
                    listView1.Items.Add(lvi);

                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(lvi, "Size");
                    FileInfo fileInfo = new FileInfo(file);
                    long size = fileInfo.Length;
                    subItem.Text = System.Convert.ToString(size);
                    lvi.SubItems.Add(subItem);

                    ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(lvi, "Type");
                    string type = Path.GetExtension(file);
                    subItem1.Text = type;
                    lvi.SubItems.Add(subItem1);
                    if (type ==".png" || type == ".jpg" || type == ".bmp" || type == ".gif")
                        listView1.Items[indexOfFile].BackColor = System.Drawing.Color.LightGreen;
                    else if (type == ".docx" || type == ".xlsx" || type == ".pdf" || type == ".txt")
                        listView1.Items[indexOfFile].BackColor = System.Drawing.Color.LightBlue;
                    else if (type == ".zip" || type == ".rar" || type == ".7z")
                        listView1.Items[indexOfFile].BackColor = System.Drawing.Color.Purple;
                    else if (type == ".dll" || type == ".exe")
                        listView1.Items[indexOfFile].BackColor = System.Drawing.Color.PaleVioletRed;
                    indexOfFile++;
                }
            chartDraw();
        }

        void chartDraw() 
        {
            chart1.Series[0].Points.Clear();
            int cntLongNames = 0;
            int cntMediumNames = 0;
            int cntSmallNames = 0;
            int indexOfItem = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Checked) 
                    {
                        int nameLenght = listView1.Items[i].Text.LastIndexOf('.');

                        if (nameLenght <= 4)
                            cntSmallNames++;
                        else if (nameLenght > 4 && nameLenght <= 10)
                            cntMediumNames++;
                        else
                            cntLongNames++;
                    }
                }
            chart1.Series[0].Points.AddXY("Long Name", cntLongNames);
            chart1.Series[0].Points.AddXY("Medium Name", cntMediumNames);
            chart1.Series[0].Points.AddXY("Small Name", cntSmallNames);
        }

        private void settingToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
              
            }
            TreeNode rootDir = new TreeNode(FBD.SelectedPath);
            treeView1.Nodes.Add(rootDir);
            AddDirectories(rootDir);
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK) 
            {
                string filename = save.FileName;
                using (var sw = new StreamWriter(filename)) 
                {
                    for (int i =0; i < listView1.Items.Count; i++) 
                    {
                        sw.WriteLine(listView1.Items[i].Text);
                    }
                }
                MessageBox.Show("Файл сохранен");
            }
        }

        private void colorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ColorDialog colorChanger = new ColorDialog();
            if (colorChanger.ShowDialog() == DialogResult.OK)
                BackColor = colorChanger.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FontDialog fontChanger = new FontDialog();
            if (fontChanger.ShowDialog() == DialogResult.OK)
                listView1.Font = fontChanger.Font;
        }

        private void chart1_Click(object sender, System.EventArgs e)
        {
            chartDraw();
        }

        private void toolStripLabel1_Click(object sender, System.EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
