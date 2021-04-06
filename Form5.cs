using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Form5 : Form
    {
        bool _Rc;
        public bool Rc { get { return _Rc; } }
        public int StopNumber
        {
            get { return Convert.ToInt32(textBox1.Text); }
            set { textBox1.Text = Convert.ToString(value); }
        }
        public int Stop_ID
        {
            get { return Convert.ToInt32(comboBox1.SelectedValue); }
            set { comboBox1.SelectedValue = value; }
        }
        public Form5()
        {
            _Rc = false;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "transportDataSet.Stop". При необходимости она может быть перемещена или удалена.
            this.stopTableAdapter.Fill(this.transportDataSet.Stop);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Rc = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _Rc = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Frm = new Form3();
            Frm.ShowDialog();
            comboBox1.SelectedValue = Frm.SelectedValue;
        }
    }
}
