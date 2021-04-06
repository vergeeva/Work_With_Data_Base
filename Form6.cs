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
    public partial class Form6 : Form
    {
        bool _Rc;
        public bool Rc { get { return _Rc; } }
        public int StopNumber
        {
            get { return Convert.ToInt32(textBox1.Text); }
            set { textBox1.Text = Convert.ToString(value); }
        }
        public int Route_ID
        {
            get { return Convert.ToInt32(comboBox1.SelectedValue); }
            set { comboBox1.SelectedValue = value; }
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            route2TableAdapter.Fill(this.transportDataSet2.Route2, "Автобус");
            // TODO: данная строка кода позволяет загрузить данные в таблицу "transportDataSet4.Route1". При необходимости она может быть перемещена или удалена.
            this.route1TableAdapter.Fill(this.transportDataSet2.Route1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "transportDataSet1.Route". При необходимости она может быть перемещена или удалена.
            this.routeTableAdapter.Fill(this.transportDataSet1.Route);
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
            Form1 Frm = new Form1();
            Frm.ShowDialog();
            comboBox1.SelectedValue = Frm.SelectedValue;
        }

        //private void fillByToolStripButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.routeTableAdapter.FillBy(this.transportDataSet.Route);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }

        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Определим текущую запись
            // Определим значение поля Route_ID текущей записи
            String Type = comboBox1.Text;

            route2TableAdapter.Fill(transportDataSet2.Route2, Type);
        }


    }
}
