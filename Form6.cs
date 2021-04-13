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
            get {
                
                return Convert.ToInt32(transportDataSet2.Route2[route2BindingSource1.Position].Route_ID); }
            set {}
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            // this.route1TableAdapter.Fill(this.transportDataSet2.Route1);
            //transportDataSet2.Route2.FindByRoute_ID();
            //comboBox1_SelectedIndexChanged(sender, e);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Type = comboBox1.Text;
            route2TableAdapter.Fill(transportDataSet2.Route2, Type);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            this.route1TableAdapter.Fill(this.transportDataSet2.Route1);
            comboBox1_SelectedIndexChanged(sender, e);
        }
    }
}
