using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Organizer.Data temp;
            temp.eEvent = textBox1.Text;
            temp.Type = comboBox1.Text;
            DateTime t = dateTimePicker1.Value;
            DateTime d = monthCalendar1.SelectionStart.Date;
            temp.DateTime = (d.Date + t.TimeOfDay);
            if(temp.DateTime < DateTime.Now) { MessageBox.Show("Ввели прошедшую дату"); }
            else if(temp.eEvent == "") { MessageBox.Show("Нет события"); }
            else if(temp.Type == "") { MessageBox.Show("Не выбран тип события"); }
            else
            {
                Organizer f = (Organizer)this.Owner;
                f.dataList.Add(temp);
                Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Memo");
            comboBox1.Items.Add("Meeting");
            comboBox1.Items.Add("Task");
        }
    }
}
